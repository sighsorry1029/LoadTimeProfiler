using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HarmonyLib;

namespace Jotunn.Managers;

/// <summary>
///     Manager for handling undo and redo actions in mods. Can handle multiple undo queues.<br />
///     Mods can make their own UndoActions using the provided <see cref="T:Jotunn.Managers.UndoManager.IUndoAction">interface</see>
///     or use the default ones Jötunn provides in <see cref="T:Jotunn.Utils.UndoActions" />.<br />
///     Undo queues get automatically reset on every login and logout.
/// </summary>
public class UndoManager : IManager
{
	/// <summary>
	///     Interface for actions which can be added to the undo queue.
	/// </summary>
	public interface IUndoAction
	{
		/// <summary>
		///     Description of this action to show on the queue's history.
		/// </summary>
		string Description();

		/// <summary>
		///     Code to revert whatever was executed.
		/// </summary>
		void Undo();

		/// <summary>
		///     Code to replay whatever was executed.
		/// </summary>
		void Redo();

		/// <summary>
		///     Message being displayed after a successful undo.
		/// </summary>
		string UndoMessage();

		/// <summary>
		///     Message being displayed after a successful redo.
		/// </summary>
		string RedoMessage();
	}

	private static class Patches
	{
		[HarmonyPatch(typeof(ZNetScene), "Awake")]
		[HarmonyPrefix]
		[HarmonyPriority(800)]
		private static void ClearUndoQueuesBefore(ZNetScene __instance)
		{
			foreach (UndoQueue value in Instance.Queues.Values)
			{
				value.Reset();
			}
		}

		[HarmonyPatch(typeof(ZNetScene), "Shutdown")]
		[HarmonyPostfix]
		[HarmonyPriority(0)]
		private static void ClearUndoQueuesAfter(ZNetScene __instance)
		{
			foreach (UndoQueue value in Instance.Queues.Values)
			{
				value.Reset();
			}
		}
	}

	/// <summary>
	///     Undo queue implementation.
	/// </summary>
	public class UndoQueue
	{
		private readonly string Name;

		private readonly int MaxSteps;

		private List<IUndoAction> History = new List<IUndoAction>();

		private int Index = -1;

		private bool Executing;

		internal UndoQueue(string name)
		{
			Name = name;
			MaxSteps = 50;
		}

		internal UndoQueue(string name, int maxSteps)
		{
			if (maxSteps <= 0 || maxSteps >= 100)
			{
				throw new ArgumentOutOfRangeException("maxSteps");
			}
			Name = name;
			MaxSteps = maxSteps;
		}

		/// <summary>
		///     Add a new action to this queue.
		/// </summary>
		/// <param name="action">Mod provided action which can undo and redo whatever was executed</param>
		public void Add(IUndoAction action)
		{
			if (!Executing)
			{
				if (History.Count > MaxSteps - 1)
				{
					History = History.Skip(History.Count - MaxSteps + 1).ToList();
				}
				if (Index < History.Count - 1)
				{
					History = History.Take(Index + 1).ToList();
				}
				History.Add(action);
				Index = History.Count - 1;
			}
		}

		/// <summary>
		///     Execute the undo action of the item at the queue's current position and decrease the position pointer.
		/// </summary>
		/// <returns>true if an action was undone, false if no actions exist or the action failed</returns>
		public bool Undo()
		{
			if (Index < 0)
			{
				AddMessage("Nothing to undo.");
				return false;
			}
			bool result = true;
			Executing = true;
			try
			{
				History[Index].Undo();
				AddMessage(History[Index].UndoMessage());
			}
			catch (Exception arg)
			{
				Logger.LogWarning($"Exception thrown at index {Index} in queue {Name}:\n{arg}");
				result = false;
			}
			Index--;
			Executing = false;
			return result;
		}

		/// <summary>
		///     Execute the redo action of the item after the queue's current position and increase the position pointer.
		/// </summary>
		/// <returns>true if an action was redone, false if no actions exist or the action failed</returns>
		public bool Redo()
		{
			if (Index < History.Count - 1)
			{
				bool result = true;
				Executing = true;
				Index++;
				try
				{
					History[Index].Redo();
					AddMessage(History[Index].RedoMessage());
				}
				catch (Exception arg)
				{
					Logger.LogWarning($"Exception thrown at index {Index} in queue {Name}:\n{arg}");
					result = false;
				}
				Executing = false;
				return result;
			}
			AddMessage("Nothing to redo.");
			return false;
		}

		/// <summary>
		///     Reset the queue's history and position pointer to its initial state.
		/// </summary>
		public void Reset()
		{
			History.Clear();
			Index = -1;
			Executing = false;
		}

		/// <summary>
		///     Get this queue's current position index, -1 when empty.
		/// </summary>
		public int GetIndex()
		{
			return Index;
		}

		/// <summary>
		///     Get a string array of this queue's current history.
		/// </summary>
		public string[] GetHistory()
		{
			return History.Select((IUndoAction x) => x.Description()).ToArray();
		}

		/// <inheritdoc />
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("Queue \"" + Name + "\"");
			if (Index < 0)
			{
				stringBuilder.AppendLine("Empty!");
			}
			else
			{
				int num = 0;
				foreach (IUndoAction item in History)
				{
					stringBuilder.AppendLine(string.Format("[{0:00}{1}] {2}", num, (Index == num) ? "*" : " ", item.Description()));
					num++;
				}
			}
			return stringBuilder.ToString();
		}
	}

	private static UndoManager _instance;

	/// <summary>
	///     Container to hold all Queues.
	/// </summary>
	private readonly Dictionary<string, UndoQueue> Queues = new Dictionary<string, UndoQueue>();

	/// <summary>
	///     The singleton instance of this manager.
	/// </summary>
	public static UndoManager Instance => _instance ?? (_instance = new UndoManager());

	/// <summary>
	///     Hide .ctor
	/// </summary>
	private UndoManager()
	{
	}

	static UndoManager()
	{
		((IManager)Instance).Init();
	}

	/// <summary>
	///     Registers all hooks.
	/// </summary>
	void IManager.Init()
	{
		Main.LogInit("UndoManager");
		Main.Harmony.PatchAll(typeof(Patches));
	}

	/// <summary>
	///     Add a message to the console or in the player HUD
	/// </summary>
	/// <param name="message"></param>
	/// <param name="priority"></param>
	private static void AddMessage(string message, bool priority = true)
	{
		if (Console.IsVisible())
		{
			Console.instance.AddString(message);
		}
		MessageHud instance = MessageHud.instance;
		Player localPlayer = Player.m_localPlayer;
		if (!localPlayer && !instance)
		{
			return;
		}
		if (priority)
		{
			MessageHud.MsgData[] array = instance.m_msgQeue.ToArray();
			instance.m_msgQeue.Clear();
			localPlayer.Message(MessageHud.MessageType.TopLeft, message);
			MessageHud.MsgData[] array2 = array;
			foreach (MessageHud.MsgData item in array2)
			{
				instance.m_msgQeue.Enqueue(item);
			}
			instance.m_msgQueueTimer = 10f;
		}
		else
		{
			localPlayer.Message(MessageHud.MessageType.TopLeft, message);
		}
	}

	/// <summary>
	///     Manually create a new queue by name and return it. If the queue already exists
	///     no new queue is created but the existing is returned.
	/// </summary>
	/// <param name="queueName">Global name of the queue</param>
	/// <param name="maxSteps">Optionally define the max history capacity of a newly generated queue</param>
	/// <returns>The <see cref="T:Jotunn.Managers.UndoManager.UndoQueue" /> with the given name</returns>
	public UndoQueue CreateQueue(string queueName, int maxSteps = 50)
	{
		if (!Queues.TryGetValue(queueName, out var value))
		{
			value = new UndoQueue(queueName, maxSteps);
			Queues.Add(queueName, value);
		}
		return value;
	}

	/// <summary>
	///     Get a list of all current undo queues.
	/// </summary>
	/// <returns>List of all registered queue names</returns>
	public List<string> GetQueueNames()
	{
		return Queues.Keys.OrderBy((string x) => x).ToList();
	}

	/// <summary>
	///     Get a queue by name. Creates a new queue if it does not exist.
	/// </summary>
	/// <param name="queueName">Global name of the queue</param>
	/// <returns>The <see cref="T:Jotunn.Managers.UndoManager.UndoQueue" /> with the given name</returns>
	public UndoQueue GetQueue(string queueName)
	{
		if (!Queues.TryGetValue(queueName, out var value))
		{
			value = new UndoQueue(queueName);
			Queues.Add(queueName, value);
		}
		return value;
	}

	/// <summary>
	///     Add a new action to a queue.<br />
	///     If a queue with the provided name does not exist it is automatically created.
	/// </summary>
	/// <param name="queueName">Global name of the queue</param>
	/// <param name="action">Mod provided action which can undo and redo whatever was executed</param>
	public void Add(string queueName, IUndoAction action)
	{
		GetQueue(queueName).Add(action);
	}

	/// <summary>
	///     Execute the undo action of the item at the queue's current position and decrease the position pointer.<br />
	///     If a queue with the provided name does not exist it is automatically created.
	/// </summary>
	/// <param name="queueName">Global name of the queue</param>
	/// <returns>true if an action was undone, false if no actions exist or the action failed</returns>
	public bool Undo(string queueName)
	{
		return GetQueue(queueName).Undo();
	}

	/// <summary>
	///     Execute the redo action of the item after the queue's current position and increase the position pointer.<br />
	///     If a queue with the provided name does not exist it is automatically created.
	/// </summary>
	/// <param name="queueName">Global name of the queue</param>
	/// <returns>true if an action was redone, false if no actions exist or the action failed</returns>
	public bool Redo(string queueName)
	{
		return GetQueue(queueName).Redo();
	}
}
