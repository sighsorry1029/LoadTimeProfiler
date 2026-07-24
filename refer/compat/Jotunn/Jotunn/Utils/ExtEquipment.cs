using System;
using System.Collections.Generic;
using HarmonyLib;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using UnityEngine;

namespace Jotunn.Utils;

internal class ExtEquipment : MonoBehaviour
{
	private static bool Enabled;

	private static readonly Dictionary<VisEquipment, ExtEquipment> Instances = new Dictionary<VisEquipment, ExtEquipment>();

	private Humanoid MyHumanoid;

	private int NewRightItemVariant;

	private int CurrentRightItemVariant;

	private int NewRightBackItemVariant;

	private int CurrentRightBackItemVariant;

	private int NewChestVariant;

	private int CurrentChestVariant;

	public static void Enable()
	{
		if (!Enabled)
		{
			Enabled = true;
			Main.Harmony.PatchAll(typeof(ExtEquipment));
		}
	}

	[HarmonyPatch(typeof(VisEquipment), "Awake")]
	[HarmonyPostfix]
	private static void VisEquipment_Awake(VisEquipment __instance)
	{
		if (!__instance.gameObject.TryGetComponent<ExtEquipment>(out var _))
		{
			__instance.gameObject.AddComponent<ExtEquipment>();
		}
	}

	/// <summary>
	///     Get non-vanilla variant indices from the ZDO
	/// </summary>
	[HarmonyPatch(typeof(VisEquipment), "UpdateEquipmentVisuals")]
	[HarmonyPrefix]
	private static void VisEquipment_UpdateEquipmentVisuals(VisEquipment __instance)
	{
		if ((bool)__instance.m_nview)
		{
			ZDO zDO = __instance.m_nview.GetZDO();
			if (zDO != null && Instances.TryGetValue(__instance, out var value))
			{
				value.NewRightItemVariant = zDO.GetInt("RightItemVariant");
				value.NewChestVariant = zDO.GetInt("ChestItemVariant");
				value.NewRightBackItemVariant = zDO.GetInt("RightBackItemVariant");
			}
		}
	}

	/// <summary>
	///     Check for variant changes and pass the variant to AttachItem
	/// </summary>
	[HarmonyPatch(typeof(VisEquipment), "SetRightHandEquipped")]
	[HarmonyILManipulator]
	private static void VisEquipment_SetRightHandEquiped(ILContext il)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Expected O, but got Unknown
		ExtEquipment instance = null;
		ILCursor val = new ILCursor(il);
		if (val.TryGotoNext((MoveType)2, new Func<Instruction, bool>[1]
		{
			(Instruction x) => ILPatternMatchingExt.MatchLdarg(x, 1)
		}))
		{
			val.Emit(OpCodes.Ldarg_0);
			val.EmitDelegate<Func<int, VisEquipment, int>>((Func<int, VisEquipment, int>)delegate(int hash, VisEquipment self)
			{
				if (Instances.TryGetValue(self, out instance) && hash != 0 && instance.CurrentRightItemVariant != instance.NewRightItemVariant)
				{
					instance.CurrentRightItemVariant = instance.NewRightItemVariant;
					return hash + instance.CurrentRightItemVariant;
				}
				return hash;
			});
		}
		if (val.TryGotoNext((MoveType)2, new Func<Instruction, bool>[4]
		{
			(Instruction x) => ILPatternMatchingExt.MatchLdarg(x, 0),
			(Instruction x) => ILPatternMatchingExt.MatchLdarg(x, 0),
			(Instruction x) => ILPatternMatchingExt.MatchLdarg(x, 1),
			(Instruction x) => ILPatternMatchingExt.MatchLdcI4(x, 0)
		}))
		{
			val.EmitDelegate<Func<int, int>>((Func<int, int>)((int variant) => (!(instance != null)) ? variant : instance.CurrentRightItemVariant));
		}
	}

	/// <summary>
	///     Check for variant changes and pass the variant to AttachBackItem
	/// </summary>
	[HarmonyPatch(typeof(VisEquipment), "SetBackEquipped")]
	[HarmonyILManipulator]
	private static void VisEquipment_SetBackEquiped(ILContext il)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Expected O, but got Unknown
		ExtEquipment instance = null;
		ILCursor val = new ILCursor(il);
		if (val.TryGotoNext((MoveType)2, new Func<Instruction, bool>[1]
		{
			(Instruction x) => ILPatternMatchingExt.MatchLdarg(x, 2)
		}))
		{
			val.Emit(OpCodes.Ldarg_0);
			val.EmitDelegate<Func<int, VisEquipment, int>>((Func<int, VisEquipment, int>)delegate(int hash, VisEquipment self)
			{
				if (Instances.TryGetValue(self, out instance) && hash != 0 && instance.CurrentRightBackItemVariant != instance.NewRightBackItemVariant)
				{
					instance.CurrentRightBackItemVariant = instance.NewRightBackItemVariant;
					return hash + instance.CurrentRightBackItemVariant;
				}
				return hash;
			});
		}
		if (val.TryGotoNext((MoveType)2, new Func<Instruction, bool>[4]
		{
			(Instruction x) => ILPatternMatchingExt.MatchLdarg(x, 0),
			(Instruction x) => ILPatternMatchingExt.MatchLdarg(x, 0),
			(Instruction x) => ILPatternMatchingExt.MatchLdarg(x, 2),
			(Instruction x) => ILPatternMatchingExt.MatchLdcI4(x, 0)
		}))
		{
			val.EmitDelegate<Func<int, int>>((Func<int, int>)((int variant) => (!(instance != null)) ? variant : instance.CurrentRightBackItemVariant));
		}
	}

	/// <summary>
	///     Check for variant changes and pass the variant to AttachArmor
	/// </summary>
	[HarmonyPatch(typeof(VisEquipment), "SetChestEquipped")]
	[HarmonyILManipulator]
	private static void VisEquipment_SetChestEquiped(ILContext il)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Expected O, but got Unknown
		ExtEquipment instance = null;
		ILCursor val = new ILCursor(il);
		if (val.TryGotoNext((MoveType)2, new Func<Instruction, bool>[1]
		{
			(Instruction x) => ILPatternMatchingExt.MatchLdarg(x, 1)
		}))
		{
			val.Emit(OpCodes.Ldarg_0);
			val.EmitDelegate<Func<int, VisEquipment, int>>((Func<int, VisEquipment, int>)delegate(int hash, VisEquipment self)
			{
				if (Instances.TryGetValue(self, out instance) && hash != 0 && instance.CurrentChestVariant != instance.NewChestVariant)
				{
					instance.CurrentChestVariant = instance.NewChestVariant;
					return hash + instance.CurrentChestVariant;
				}
				return hash;
			});
		}
		if (val.TryGotoNext((MoveType)2, new Func<Instruction, bool>[4]
		{
			(Instruction x) => ILPatternMatchingExt.MatchLdarg(x, 0),
			(Instruction x) => ILPatternMatchingExt.MatchLdarg(x, 0),
			(Instruction x) => ILPatternMatchingExt.MatchLdarg(x, 1),
			(Instruction x) => ILPatternMatchingExt.MatchLdcI4(x, -1)
		}))
		{
			val.EmitDelegate<Func<int, int>>((Func<int, int>)((int variant) => (!(instance != null)) ? variant : instance.CurrentChestVariant));
		}
	}

	/// <summary>
	///     Store the variant index of the right hand item to the ZDO if the variant has changed
	/// </summary>
	[HarmonyPatch(typeof(VisEquipment), "SetRightItem")]
	[HarmonyPrefix]
	private static void VisEquipment_SetRightItem(VisEquipment __instance, string name)
	{
		if (Instances.TryGetValue(__instance, out var value) && (bool)value.MyHumanoid && value.MyHumanoid.m_rightItem != null && (!(__instance.m_rightItem == name) || value.MyHumanoid.m_rightItem.m_variant != value.CurrentRightItemVariant))
		{
			value.NewRightItemVariant = value.MyHumanoid.m_rightItem.m_variant;
			if ((bool)__instance.m_nview)
			{
				__instance.m_nview.GetZDO()?.Set("RightItemVariant", (!string.IsNullOrEmpty(name)) ? value.NewRightItemVariant : 0);
			}
		}
	}

	/// <summary>
	///     Store the variant index of the right back item to the ZDO if the variant has changed
	/// </summary>
	[HarmonyPatch(typeof(VisEquipment), "SetRightBackItem")]
	[HarmonyPrefix]
	private static void VisEquipment_SetRightBackItem(VisEquipment __instance, string name)
	{
		if (Instances.TryGetValue(__instance, out var value) && (bool)value.MyHumanoid && value.MyHumanoid.m_hiddenRightItem != null && (!(__instance.m_rightBackItem == name) || value.MyHumanoid.m_hiddenRightItem.m_variant != value.CurrentRightBackItemVariant))
		{
			value.NewRightBackItemVariant = value.MyHumanoid.m_hiddenRightItem.m_variant;
			if ((bool)__instance.m_nview)
			{
				__instance.m_nview.GetZDO()?.Set("RightBackItemVariant", (!string.IsNullOrEmpty(name)) ? value.NewRightBackItemVariant : 0);
			}
		}
	}

	/// <summary>
	///     Store the variant index of the chest item to the ZDO if the variant has changed
	/// </summary>
	[HarmonyPatch(typeof(VisEquipment), "SetChestItem")]
	[HarmonyPrefix]
	private static void VisEquipment_SetChestItem(VisEquipment __instance, string name)
	{
		if (Instances.TryGetValue(__instance, out var value) && (bool)value.MyHumanoid && value.MyHumanoid.m_chestItem != null && (!(__instance.m_chestItem == name) || value.MyHumanoid.m_chestItem.m_variant != value.CurrentChestVariant))
		{
			value.NewChestVariant = value.MyHumanoid.m_chestItem.m_variant;
			if ((bool)__instance.m_nview)
			{
				__instance.m_nview.GetZDO()?.Set("ChestItemVariant", (!string.IsNullOrEmpty(name)) ? value.NewChestVariant : 0);
			}
		}
	}

	private void Awake()
	{
		MyHumanoid = base.gameObject.GetComponent<Humanoid>();
		Instances.Add(base.gameObject.GetComponent<VisEquipment>(), this);
	}

	private void OnDestroy()
	{
		Instances.Remove(base.gameObject.GetComponent<VisEquipment>());
	}
}
