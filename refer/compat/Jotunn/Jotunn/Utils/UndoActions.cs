using System;
using System.Collections.Generic;
using System.Linq;
using Jotunn.Managers;
using UnityEngine;

namespace Jotunn.Utils;

/// <summary>
///     Pre-defined actions to use with the <see cref="T:Jotunn.Managers.UndoManager" />.
/// </summary>
public static class UndoActions
{
	private static class UndoHelper
	{
		private static Dictionary<ZDO, BinarySearchDictionary<int, float>> clonedFloats = new Dictionary<ZDO, BinarySearchDictionary<int, float>>();

		private static Dictionary<ZDO, BinarySearchDictionary<int, Vector3>> clonedVec3 = new Dictionary<ZDO, BinarySearchDictionary<int, Vector3>>();

		private static Dictionary<ZDO, BinarySearchDictionary<int, Quaternion>> clonedQuats = new Dictionary<ZDO, BinarySearchDictionary<int, Quaternion>>();

		private static Dictionary<ZDO, BinarySearchDictionary<int, int>> clonedInts = new Dictionary<ZDO, BinarySearchDictionary<int, int>>();

		private static Dictionary<ZDO, BinarySearchDictionary<int, long>> clonedLongs = new Dictionary<ZDO, BinarySearchDictionary<int, long>>();

		private static Dictionary<ZDO, BinarySearchDictionary<int, string>> clonedStrings = new Dictionary<ZDO, BinarySearchDictionary<int, string>>();

		private static Dictionary<ZDO, BinarySearchDictionary<int, byte[]>> clonedByteArrays = new Dictionary<ZDO, BinarySearchDictionary<int, byte[]>>();

		public static void CopyData(ZDO from, ZDO to)
		{
			bool flag = to.m_prefab != from.m_prefab;
			to.m_prefab = from.m_prefab;
			to.m_position = from.m_position;
			to.m_rotation = from.m_rotation;
			ApplyZDOExtraData(to.m_uid, from);
			ZNetScene instance = ZNetScene.instance;
			if (instance.m_instances.TryGetValue(to, out var value))
			{
				Transform transform = value.transform;
				transform.position = from.m_position;
				transform.rotation = Quaternion.Euler(from.m_rotation);
				transform.localScale = from.GetVec3("scale", Vector3.one);
				if (flag)
				{
					GameObject gameObject = ZNetScene.instance.CreateObject(to);
					if ((bool)gameObject)
					{
						UnityEngine.Object.Destroy(value.gameObject);
						ZNetScene.instance.m_instances[to] = gameObject.GetComponent<ZNetView>();
					}
				}
			}
			to.IncreaseDataRevision();
		}

		public static void ApplyZDOExtraData(ZDOID id, ZDO zdo)
		{
			ZDOExtraData.s_floats[id] = CloneBinarySearchDictionary<int, float>(clonedFloats[zdo]);
			ZDOExtraData.s_vec3[id] = CloneBinarySearchDictionary<int, Vector3>(clonedVec3[zdo]);
			ZDOExtraData.s_quats[id] = CloneBinarySearchDictionary<int, Quaternion>(clonedQuats[zdo]);
			ZDOExtraData.s_ints[id] = CloneBinarySearchDictionary<int, int>(clonedInts[zdo]);
			ZDOExtraData.s_longs[id] = CloneBinarySearchDictionary<int, long>(clonedLongs[zdo]);
			ZDOExtraData.s_strings[id] = CloneBinarySearchDictionary<int, string>(clonedStrings[zdo]);
			ZDOExtraData.s_byteArrays[id] = CloneBinarySearchDictionary<int, byte[]>(clonedByteArrays[zdo]);
		}

		public static ZDO Place(ZDO zdo)
		{
			GameObject prefab = ZNetScene.instance.GetPrefab(zdo.GetPrefab());
			if (!prefab)
			{
				throw new InvalidOperationException("Invalid prefab");
			}
			GameObject gameObject = UnityEngine.Object.Instantiate(prefab, zdo.GetPosition(), zdo.GetRotation());
			ZNetView component = gameObject.GetComponent<ZNetView>();
			if (!component)
			{
				throw new InvalidOperationException("No view");
			}
			ZDO zDO = component.GetZDO();
			component.SetLocalScale(zdo.GetVec3("scale", gameObject.transform.localScale));
			CopyData(zdo, zDO);
			return zDO;
		}

		public static ZDO[] Place(ZDO[] data)
		{
			return (from obj in data.Select(Place)
				where obj != null
				select obj).ToArray();
		}

		public static string Name(ZDO zdo)
		{
			return Utils.GetPrefabName(ZNetScene.instance.GetPrefab(zdo.GetPrefab()));
		}

		public static string Print(ZDO[] data)
		{
			if (data.Length == 1)
			{
				return Name(data.First());
			}
			IEnumerable<IGrouping<string, ZDO>> enumerable = data.GroupBy(Name);
			IGrouping<string, ZDO>[] array = (enumerable as IGrouping<string, ZDO>[]) ?? enumerable.ToArray();
			if (array.Length == 1)
			{
				return $"{array.First().Key} {array.First().Count()}x";
			}
			return $" objects {data.Length}x";
		}

		public static ZDO[] Remove(ZDO[] toRemove)
		{
			ZDO[] result = Clone(toRemove);
			foreach (ZDO zdo in toRemove)
			{
				RemoveZDO(zdo);
			}
			return result;
		}

		public static ZDO[] Clone(IEnumerable<ZDO> data)
		{
			return data.Select(CloneZDO).ToArray();
		}

		private static ZDO CloneZDO(ZDO zdo)
		{
			ZDO zDO = zdo.Clone();
			zDO.SaveClone = false;
			clonedFloats[zDO] = CloneBinarySearchDictionary(zDO.m_uid, ZDOExtraData.s_floats);
			clonedVec3[zDO] = CloneBinarySearchDictionary(zDO.m_uid, ZDOExtraData.s_vec3);
			clonedQuats[zDO] = CloneBinarySearchDictionary(zDO.m_uid, ZDOExtraData.s_quats);
			clonedInts[zDO] = CloneBinarySearchDictionary(zDO.m_uid, ZDOExtraData.s_ints);
			clonedLongs[zDO] = CloneBinarySearchDictionary(zDO.m_uid, ZDOExtraData.s_longs);
			clonedStrings[zDO] = CloneBinarySearchDictionary(zDO.m_uid, ZDOExtraData.s_strings);
			clonedByteArrays[zDO] = CloneBinarySearchDictionary(zDO.m_uid, ZDOExtraData.s_byteArrays);
			return zDO;
		}

		public static void RemoveZDO(ZDO zdo)
		{
			if (IsValid(zdo))
			{
				if (!zdo.IsOwner())
				{
					zdo.SetOwner(ZDOMan.GetSessionID());
				}
				if (ZNetScene.instance.m_instances.TryGetValue(zdo, out var value))
				{
					ZNetScene.instance.Destroy(value.gameObject);
				}
				else
				{
					ZDOMan.instance.DestroyZDO(zdo);
				}
			}
		}

		/// <summary>Helper to check object validity.</summary>
		public static bool IsValid(ZNetView view)
		{
			if ((bool)view)
			{
				return IsValid(view.GetZDO());
			}
			return false;
		}

		/// <summary>Helper to check object validity.</summary>
		public static bool IsValid(ZDO zdo)
		{
			return zdo?.IsValid() ?? false;
		}

		public static void ApplyData(Dictionary<Vector3, TerrainUndoData> data, Vector3 pos, float radius)
		{
			foreach (KeyValuePair<Vector3, TerrainUndoData> datum in data)
			{
				TerrainComp terrainComp = TerrainComp.FindTerrainCompiler(datum.Key);
				if ((bool)terrainComp)
				{
					HeightUndoData[] heights = datum.Value.Heights;
					foreach (HeightUndoData heightUndoData in heights)
					{
						terrainComp.m_smoothDelta[heightUndoData.Index] = heightUndoData.Smooth;
						terrainComp.m_levelDelta[heightUndoData.Index] = heightUndoData.Level;
						terrainComp.m_modifiedHeight[heightUndoData.Index] = heightUndoData.HeightModified;
					}
					PaintUndoData[] paints = datum.Value.Paints;
					foreach (PaintUndoData paintUndoData in paints)
					{
						terrainComp.m_modifiedPaint[paintUndoData.Index] = paintUndoData.PaintModified;
						terrainComp.m_paintMask[paintUndoData.Index] = paintUndoData.Paint;
					}
					Save(terrainComp);
				}
			}
			ClutterSystem.instance?.ResetGrass(pos, radius);
		}

		public static void Save(TerrainComp compiler)
		{
			compiler.GetComponent<ZNetView>()?.ClaimOwnership();
			compiler.m_operations++;
			compiler.m_lastOpPoint = Vector3.zero;
			compiler.m_lastOpRadius = 0f;
			compiler.Save();
			compiler.m_hmap.Poke(delayed: false);
		}

		public static BinarySearchDictionary<TKey, TValue> CloneBinarySearchDictionary<TKey, TValue>(BinarySearchDictionary<TKey, TValue> dict) where TKey : IComparable<TKey>
		{
			return dict.Clone() as BinarySearchDictionary<TKey, TValue>;
		}

		public static BinarySearchDictionary<TKey, TValue> CloneBinarySearchDictionary<TKey, TValue>(ZDOID id, Dictionary<ZDOID, BinarySearchDictionary<TKey, TValue>> dict) where TKey : IComparable<TKey>
		{
			return CloneBinarySearchDictionary<TKey, TValue>(dict.GetValueOrDefaultPiktiv(id, new BinarySearchDictionary<TKey, TValue>()));
		}
	}

	/// <summary>
	///     "Create" action for the <see cref="T:Jotunn.Managers.UndoManager" />. Can undo and redo ZDO creation.
	/// </summary>
	public class UndoCreate : UndoManager.IUndoAction
	{
		/// <summary>
		///     Current ZDO data of this action.
		/// </summary>
		public ZDO[] Data;

		/// <summary>
		///     Create new undo data for ZDO creation operations. Clones all ZDO data to prevent NREs.
		/// </summary>
		/// <param name="data">Enumerable of ZDOs which were created.</param>
		public UndoCreate(IEnumerable<ZDO> data)
		{
			Data = UndoHelper.Clone(data);
		}

		/// <summary>
		///     Description of the executed action.
		/// </summary>
		public string Description()
		{
			return "Created " + UndoHelper.Print(Data);
		}

		/// <summary>
		///     Remove stored ZDOs again.
		/// </summary>
		public virtual void Undo()
		{
			Data = UndoHelper.Remove(Data);
		}

		/// <summary>
		///     Success message.
		/// </summary>
		public string UndoMessage()
		{
			return "Undo: Removed " + UndoHelper.Print(Data);
		}

		/// <summary>
		///     Recreate stored ZDOs again.
		/// </summary>
		public virtual void Redo()
		{
			Data = UndoHelper.Place(Data);
		}

		/// <summary>
		///     Success message.
		/// </summary>
		public string RedoMessage()
		{
			return "Redo: Restored " + UndoHelper.Print(Data);
		}
	}

	/// <summary>
	///     "Remove" action for the <see cref="T:Jotunn.Managers.UndoManager" />. Can undo and redo ZDO removal.
	/// </summary>
	public class UndoRemove : UndoManager.IUndoAction
	{
		/// <summary>
		///     Current ZDO data of this action.
		/// </summary>
		public ZDO[] Data;

		/// <summary>
		///     Create new undo data for ZDO removal operations. Clones all ZDO data to prevent NREs.
		/// </summary>
		/// <param name="data">Enumerable of ZDOs which were removed.</param>
		public UndoRemove(IEnumerable<ZDO> data)
		{
			Data = UndoHelper.Clone(data);
		}

		/// <summary>
		///     Description of the executed action.
		/// </summary>
		public string Description()
		{
			return "Removed " + UndoHelper.Print(Data);
		}

		/// <summary>
		///     Recreate stored ZDOs again.
		/// </summary>
		public virtual void Undo()
		{
			Data = UndoHelper.Place(Data);
		}

		/// <summary>
		///     Success message.
		/// </summary>
		public string UndoMessage()
		{
			return "Undo: Restored " + UndoHelper.Print(Data);
		}

		/// <summary>
		///     Remove stored ZDOs again.
		/// </summary>
		public virtual void Redo()
		{
			Data = UndoHelper.Remove(Data);
		}

		/// <summary>
		///     Success message.
		/// </summary>
		public string RedoMessage()
		{
			return "Redo: Removed " + UndoHelper.Print(Data);
		}
	}

	/// <summary>
	///     Heightmap data wrapper
	/// </summary>
	public class HeightUndoData
	{
		/// <summary>
		///     "Smooth" member of the heightmap
		/// </summary>
		public float Smooth;

		/// <summary>
		///     "Level" member of the heightmap
		/// </summary>
		public float Level;

		/// <summary>
		///     "Index" member of the heightmap
		/// </summary>
		public int Index = -1;

		/// <summary>
		///     "HeightModified" member of the heightmap
		/// </summary>
		public bool HeightModified;
	}

	/// <summary>
	///     Paint data wrapper
	/// </summary>
	public class PaintUndoData
	{
		/// <summary>
		///     "PaintModified" member of the heightmap paint
		/// </summary>
		public bool PaintModified;

		/// <summary>
		///     "Paint" member of the heightmap paint
		/// </summary>
		public Color Paint = Color.black;

		/// <summary>
		///     "Index" member of the heightmap paint
		/// </summary>
		public int Index = -1;
	}

	/// <summary>
	///     Heightmap and Paint data collection
	/// </summary>
	public class TerrainUndoData
	{
		/// <summary>
		///     Collection of <see cref="T:Jotunn.Utils.UndoActions.HeightUndoData" />
		/// </summary>
		public HeightUndoData[] Heights = new HeightUndoData[0];

		/// <summary>
		///     Collection of <see cref="T:Jotunn.Utils.UndoActions.PaintUndoData" />
		/// </summary>
		public PaintUndoData[] Paints = new PaintUndoData[0];
	}

	/// <summary>
	///     "Terrain" action for the <see cref="T:Jotunn.Managers.UndoManager" />. Can undo and redo terrain modifications.
	/// </summary>
	public class UndoTerrain : UndoManager.IUndoAction
	{
		private readonly Dictionary<Vector3, TerrainUndoData> Before;

		private readonly Dictionary<Vector3, TerrainUndoData> After;

		private readonly Vector3 Position;

		private readonly float Radius;

		/// <summary>
		///     Create new undo data for terrain modifications.
		/// </summary>
		/// <param name="before">Terrain state before modification</param>
		/// <param name="after">Terrain state after modification</param>
		/// <param name="position">Position of the terrain modification center</param>
		/// <param name="radius">Radius of the terrain modification</param>
		public UndoTerrain(Dictionary<Vector3, TerrainUndoData> before, Dictionary<Vector3, TerrainUndoData> after, Vector3 position, float radius)
		{
			Before = before;
			After = after;
			Position = position;
			Radius = radius;
		}

		/// <summary>
		///     Description of the executed action.
		/// </summary>
		public string Description()
		{
			return "Changed terrain";
		}

		/// <summary>
		///     Sets terrain data to the stored values of the "before" state.
		/// </summary>
		public virtual void Undo()
		{
			UndoHelper.ApplyData(Before, Position, Radius);
		}

		/// <summary>
		///     Success message.
		/// </summary>
		public string UndoMessage()
		{
			return "Undoing terrain changes";
		}

		/// <summary>
		///     Sets terrain data to the stored values of the "after" state.
		/// </summary>
		public virtual void Redo()
		{
			UndoHelper.ApplyData(After, Position, Radius);
		}

		/// <summary>
		///     Success message.
		/// </summary>
		public string RedoMessage()
		{
			return "Redoing terrain changes";
		}
	}
}
