using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using BepInEx;
using Jotunn.Managers;
using UnityEngine;

namespace Jotunn.Entities;

/// <summary>
///     Wrapper for Valheim's RPC calls implementing convenience delegate methods for client and server processing of packages.<br />
///     Automatically compresses and slices big packages to fit into the Steam package limit.<br />
///     All sending and processing of received packages is executed in Coroutines to ensure the game loop's execution.
/// </summary>
public class CustomRPC : CustomEntity
{
	private const byte JOTUNN_PACKAGE = 1;

	private const byte FRAGMENTED_PACKAGE = 2;

	private const byte COMPRESSED_PACKAGE = 4;

	private static int CompressMinSize = 10000;

	private static int PackageSliceSize = 250000;

	private static int MaximumSendQueueSize = 20000;

	private static float Timeout = 30f;

	/// <summary>
	///     Delegate called when a package is received on the server
	/// </summary>
	internal NetworkManager.CoroutineHandler OnServerReceive;

	/// <summary>
	///     Delegate called when a package is received on the client
	/// </summary>
	internal NetworkManager.CoroutineHandler OnClientReceive;

	private short SendCount;

	private short ProcessingCount;

	private long PackageCount;

	private readonly Dictionary<string, SortedDictionary<int, byte[]>> PackageCache = new Dictionary<string, SortedDictionary<int, byte[]>>();

	private readonly List<KeyValuePair<long, string>> CacheExpirations = new List<KeyValuePair<long, string>>();

	/// <summary>
	///     Name of the custom RPC as defined at instantiation
	/// </summary>
	public string Name { get; }

	/// <summary>
	///     True, if this RPC is currently sending data
	/// </summary>
	public bool IsSending => SendCount > 0;

	/// <summary>
	///     True, if this RPC is currently receiving data
	/// </summary>
	public bool IsReceiving => PackageCache.Count > 0;

	/// <summary>
	///     True, if this RPC is currently processing received data.
	///     This is always true while executing the registered delegates.
	/// </summary>
	public bool IsProcessing => ProcessingCount > 0;

	/// <summary>
	///     True, if this RPC is processing received data outside the current delegate call.
	///     This should only be used in the registered delegate methods to determine
	///     if this RPC is already processing another package.
	/// </summary>
	public bool IsProcessingOther => ProcessingCount - 1 > 0;

	/// <summary>
	///     Unique ID of this RPC to prevent name clashes between mods
	/// </summary>
	internal string ID => base.SourceMod.GUID + "!" + Name;

	/// <summary>
	///     Internal constructor only, CustomRPCs are instantiated via <see cref="T:Jotunn.Managers.NetworkManager" />
	/// </summary>
	/// <param name="sourceMod">Reference to the <see cref="T:BepInEx.BepInPlugin" /> which created this RPC.</param>
	/// <param name="name"></param>
	/// <param name="serverReceive"></param>
	/// <param name="clientReceive"></param>
	internal CustomRPC(BepInPlugin sourceMod, string name, NetworkManager.CoroutineHandler serverReceive, NetworkManager.CoroutineHandler clientReceive)
		: base(sourceMod)
	{
		Name = name;
		OnServerReceive = serverReceive;
		OnClientReceive = clientReceive;
	}

	/// <summary>
	///     Initiates an RPC exchange with the server by sending an empty package.
	/// </summary>
	public void Initiate()
	{
		ZNet.instance?.StartCoroutine(SendPackageRoutine(ZRoutedRpc.instance.GetServerPeerID(), new ZPackage(new byte[1] { 1 })));
	}

	/// <summary>
	///     Send a package to a single target. Compresses and fragments the package if necessary.
	/// </summary>
	/// <param name="target"></param>
	/// <param name="package"></param>
	public void SendPackage(long target, ZPackage package)
	{
		ZNet.instance?.StartCoroutine(SendPackageRoutine(target, package));
	}

	/// <summary>
	///     Send a package to a list of peers. Compresses and fragments the package if necessary.
	/// </summary>
	/// <param name="peers"></param>
	/// <param name="package"></param>
	public void SendPackage(List<ZNetPeer> peers, ZPackage package)
	{
		ZNet.instance?.StartCoroutine(SendPackageRoutine(peers, package));
	}

	/// <summary>
	///     Coroutine to send a package to a single target. Compresses and fragments the package if necessary.
	/// </summary>
	/// <param name="target"></param>
	/// <param name="package"></param>
	/// <returns></returns>
	public IEnumerator SendPackageRoutine(long target, ZPackage package)
	{
		if (!ZNet.instance)
		{
			yield break;
		}
		if (target == ZRoutedRpc.instance.m_id)
		{
			byte[] array = package.GetArray();
			ZPackage zPackage = new ZPackage();
			zPackage.Write(array);
			zPackage.SetPos(0);
			ZNet.instance.StartCoroutine(HandlePackageRoutine(ZRoutedRpc.instance.m_id, zPackage, 1));
			yield break;
		}
		List<ZNetPeer> list = ZRoutedRpc.instance.m_peers;
		if (target != ZRoutedRpc.Everybody)
		{
			list = list.Where((ZNetPeer p) => p.m_uid == target).ToList();
		}
		yield return SendPackageRoutine(list, package);
	}

	/// <summary>
	///     Coroutine to send a package to a list of peers. Compresses and fragments the package if necessary.
	/// </summary>
	/// <param name="peers"></param>
	/// <param name="package"></param>
	/// <returns></returns>
	public IEnumerator SendPackageRoutine(List<ZNetPeer> peers, ZPackage package)
	{
		if (!ZNet.instance || peers.Count == 0)
		{
			yield break;
		}
		try
		{
			SendCount++;
			byte[] array = package.GetArray();
			ZPackage zPackage = new ZPackage();
			zPackage.Write((byte)1);
			zPackage.Write(array);
			zPackage.SetPos(0);
			package = zPackage;
			if (package.Size() > CompressMinSize)
			{
				package = CompressPackage(package);
			}
			List<IEnumerator<bool>> writers = (from p in peers
				where p.IsReady()
				select SendToPeer(p, package)).ToList();
			writers.RemoveAll((IEnumerator<bool> writer) => !writer.MoveNext());
			while (writers.Count > 0)
			{
				yield return null;
				writers.RemoveAll((IEnumerator<bool> writer) => !writer.MoveNext());
			}
		}
		finally
		{
			SendCount--;
		}
	}

	private ZPackage CompressPackage(ZPackage package)
	{
		byte[] array = package.GetArray();
		Logger.LogDebug($"[{ID}] Compressing package with length {array.Length}");
		ZPackage zPackage = new ZPackage();
		zPackage.Write((byte)4);
		MemoryStream memoryStream = new MemoryStream();
		using (DeflateStream deflateStream = new DeflateStream(memoryStream, System.IO.Compression.CompressionLevel.Optimal))
		{
			deflateStream.Write(array, 0, array.Length);
		}
		zPackage.Write(memoryStream.ToArray());
		return zPackage;
	}

	/// <summary>
	///     Coroutine to send a package to an actual peer.
	/// </summary>
	/// <param name="peer"></param>
	/// <param name="package"></param>
	/// <returns></returns>
	private IEnumerator<bool> SendToPeer(ZNetPeer peer, ZPackage package)
	{
		ZRoutedRpc rpc = ZRoutedRpc.instance;
		if (rpc == null)
		{
			yield break;
		}
		if (package.Size() > PackageSliceSize)
		{
			byte[] data = package.GetArray();
			int fragments = (int)(1 + (data.LongLength - 1) / PackageSliceSize);
			long packageIdentifier = ++PackageCount;
			for (int fragment = 0; fragment < fragments; fragment++)
			{
				foreach (bool item in WaitForQueue())
				{
					yield return item;
				}
				if (peer.m_socket.IsConnected())
				{
					ZPackage zPackage = new ZPackage();
					zPackage.Write((byte)2);
					zPackage.Write(packageIdentifier);
					zPackage.Write(fragment);
					zPackage.Write(fragments);
					zPackage.Write(data.Skip(PackageSliceSize * fragment).Take(PackageSliceSize).ToArray());
					Logger.LogDebug($"[{ID}] Sending fragmented package {packageIdentifier}:{fragment}");
					Send(zPackage);
					if (fragment != fragments - 1)
					{
						yield return true;
					}
					continue;
				}
				break;
			}
			yield break;
		}
		foreach (bool item2 in WaitForQueue())
		{
			yield return item2;
		}
		Logger.LogDebug("[" + ID + "] Sending package");
		Send(package);
		void Send(ZPackage pkg)
		{
			rpc.InvokeRoutedRPC(peer.m_uid, ID, pkg);
		}
		IEnumerable<bool> WaitForQueue()
		{
			float timeout = Time.time + Timeout;
			while (peer.m_socket.GetSendQueueSize() > MaximumSendQueueSize)
			{
				if (Time.time > timeout)
				{
					Logger.LogInfo($"Disconnecting {peer.m_uid} after {Timeout} seconds sending timeout");
					peer.m_rpc.Invoke("Error", ZNet.ConnectionStatus.ErrorConnectFailed);
					ZNet.instance.Disconnect(peer);
					break;
				}
				yield return false;
			}
		}
	}

	/// <summary>
	///     Receive and handle an incoming package
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="package"></param>
	internal void ReceivePackage(long sender, ZPackage package)
	{
		if (package == null || package.Size() <= 0)
		{
			return;
		}
		Logger.LogDebug("[" + ID + "] Received package");
		try
		{
			CacheExpirations.RemoveAll(delegate(KeyValuePair<long, string> kv)
			{
				if (kv.Key < DateTimeOffset.Now.Ticks)
				{
					PackageCache.Remove(kv.Value);
					return true;
				}
				return false;
			});
			byte b = package.ReadByte();
			if ((b & 2) != 0)
			{
				long num = package.ReadLong();
				string text = sender.ToString() + num;
				int key = package.ReadInt();
				int num2 = package.ReadInt();
				if (!PackageCache.TryGetValue(text, out var value))
				{
					value = new SortedDictionary<int, byte[]>();
					PackageCache[text] = value;
					CacheExpirations.Add(new KeyValuePair<long, string>(DateTimeOffset.Now.AddSeconds(60.0).Ticks, text));
				}
				value.Add(key, package.ReadByteArray());
				if (value.Count < num2)
				{
					return;
				}
				PackageCache.Remove(text);
				package = new ZPackage(value.Values.SelectMany((byte[] a) => a).ToArray());
				b = package.ReadByte();
			}
			ZNet.instance.StartCoroutine(HandlePackageRoutine(sender, package, b));
		}
		catch (Exception arg)
		{
			Logger.LogWarning($"[{ID}] Error caught while applying package: {arg}");
		}
	}

	private IEnumerator HandlePackageRoutine(long sender, ZPackage package, byte packageFlags)
	{
		Logger.LogDebug("[" + ID + "] Processing package");
		try
		{
			ProcessingCount++;
			if ((packageFlags & 4) != 0)
			{
				byte[] buffer = package.ReadByteArray();
				MemoryStream stream = new MemoryStream(buffer);
				MemoryStream memoryStream = new MemoryStream();
				using (DeflateStream deflateStream = new DeflateStream(stream, CompressionMode.Decompress))
				{
					deflateStream.CopyTo(memoryStream);
				}
				package = new ZPackage(memoryStream.ToArray());
				packageFlags = package.ReadByte();
				Logger.LogDebug($"[{ID}] Decompressed package to length {memoryStream.Length}");
			}
			if ((packageFlags & 1) != 1)
			{
				Logger.LogWarning($"[{ID}] Package flag does not equal {(byte)1} ({packageFlags:X4})");
				yield break;
			}
			byte[] data = package.ReadByteArray();
			ZPackage zPackage = new ZPackage(data);
			package = zPackage;
			if (!ZNet.instance.IsServer())
			{
				yield return OnClientReceive(sender, package);
			}
			else
			{
				yield return OnServerReceive(sender, package);
			}
		}
		finally
		{
			ProcessingCount--;
		}
	}

	/// <inheritdoc />
	public override string ToString()
	{
		return ID;
	}
}
