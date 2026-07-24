using System.Reflection;
using Jotunn.Configs;
using Jotunn.Managers;
using Jotunn.Utils;
using UnityEngine;

namespace Jotunn.Entities;

/// <summary>
///     Main interface for adding custom items to the game.<br />
///     All custom items have to be wrapped inside this class to add it to Jötunns <see cref="T:Jotunn.Managers.ItemManager" />.
/// </summary>
public class CustomItem : CustomEntity
{
	private string fallbackItemName;

	/// <summary>
	///     The prefab for this custom item.
	/// </summary>
	public GameObject ItemPrefab { get; }

	/// <summary>
	///     The <see cref="T:ItemDrop" /> component for this custom item as a shortcut.
	/// </summary>
	public ItemDrop ItemDrop { get; }

	/// <summary>
	///     The <see cref="T:Jotunn.Entities.CustomRecipe" /> associated with this custom item. Is needed to craft
	///     this item on a workbench or from the players crafting menu.
	/// </summary>
	public CustomRecipe Recipe { get; set; }

	/// <summary>
	///     Indicator if references from <see cref="T:Jotunn.Entities.Mock`1" />s will be replaced at runtime.
	/// </summary>
	public bool FixReference { get; set; }

	/// <summary>
	///     Texture holding the variants different styles.
	/// </summary>
	internal Texture2D StyleTex { get; set; }

	/// <summary>
	///     Indicator if references from configs should get replaced
	/// </summary>
	internal bool FixConfig { get; set; }

	private string ItemName
	{
		get
		{
			if (!ItemPrefab)
			{
				return fallbackItemName;
			}
			return ItemPrefab.name;
		}
	}

	/// <summary>
	///     Custom item from a prefab.<br />
	///     Can fix references for <see cref="T:Jotunn.Entities.Mock`1" />s and the <see cref="T:Recipe" />.
	/// </summary>
	/// <param name="itemPrefab">The prefab for this custom item.</param>
	/// <param name="fixReference">If true references for <see cref="T:Jotunn.Entities.Mock`1" /> objects get resolved at runtime by Jötunn.</param>
	public CustomItem(GameObject itemPrefab, bool fixReference)
		: base(Assembly.GetCallingAssembly())
	{
		ItemPrefab = itemPrefab;
		ItemDrop = itemPrefab.GetComponent<ItemDrop>();
		FixReference = fixReference;
	}

	/// <summary>
	///     Custom item from a prefab with a <see cref="T:Recipe" /> made from a <see cref="T:Jotunn.Configs.ItemConfig" />.<br />
	///     Can fix references for <see cref="T:Jotunn.Entities.Mock`1" />s.
	/// </summary>
	/// <param name="itemPrefab">The prefab for this custom item.</param>
	/// <param name="fixReference">If true references for <see cref="T:Jotunn.Entities.Mock`1" /> objects get resolved at runtime by Jötunn.</param>
	/// <param name="itemConfig">The item config for this custom item.</param>
	public CustomItem(GameObject itemPrefab, bool fixReference, ItemConfig itemConfig)
		: base(Assembly.GetCallingAssembly())
	{
		ItemPrefab = itemPrefab;
		ItemDrop = itemPrefab.GetComponent<ItemDrop>();
		FixReference = fixReference;
		ApplyItemConfig(itemConfig);
	}

	/// <summary>
	///     Custom item created as an "empty" primitive.<br />
	///     At least the name and the Icon of the <see cref="T:ItemDrop" /> must be edited after creation.
	/// </summary>
	/// <param name="name">Name of the new prefab. Must be unique.</param>
	/// <param name="addZNetView">If true a ZNetView component will be added to the prefab for network sync.</param>
	public CustomItem(string name, bool addZNetView)
		: base(Assembly.GetCallingAssembly())
	{
		ItemPrefab = PrefabManager.Instance.CreateEmptyPrefab(name, addZNetView);
		ItemDrop = ItemPrefab.AddComponent<ItemDrop>();
		ItemDrop.m_itemData.m_shared = new ItemDrop.ItemData.SharedData();
		ItemDrop.m_itemData.m_shared.m_name = name;
	}

	/// <summary>
	///     Custom item created as an "empty" primitive with a <see cref="T:Recipe" /> made from a <see cref="T:Jotunn.Configs.ItemConfig" />.
	/// </summary>
	/// <param name="name">Name of the new prefab. Must be unique.</param>
	/// <param name="addZNetView">If true a ZNetView component will be added to the prefab for network sync.</param>
	/// <param name="itemConfig">The item config for this custom item.</param>
	public CustomItem(string name, bool addZNetView, ItemConfig itemConfig)
		: base(Assembly.GetCallingAssembly())
	{
		ItemPrefab = PrefabManager.Instance.CreateEmptyPrefab(name, addZNetView);
		ItemDrop = ItemPrefab.AddComponent<ItemDrop>();
		ItemDrop.m_itemData.m_shared = new ItemDrop.ItemData.SharedData();
		ItemDrop.m_itemData.m_shared.m_name = name;
		ApplyItemConfig(itemConfig);
	}

	/// <summary>
	///     Custom item created as a copy of a vanilla Valheim prefab.
	/// </summary>
	/// <param name="name">The new name of the prefab after cloning.</param>
	/// <param name="basePrefabName">The name of the base prefab the custom item is cloned from.</param>
	public CustomItem(string name, string basePrefabName)
		: base(Assembly.GetCallingAssembly())
	{
		GameObject gameObject = PrefabManager.Instance.CreateClonedPrefab(name, basePrefabName);
		if ((bool)gameObject)
		{
			ItemPrefab = gameObject;
			ItemDrop = ItemPrefab.GetComponent<ItemDrop>();
		}
	}

	/// <summary>
	///     Custom item created as a copy of a vanilla Valheim prefab with a <see cref="T:Recipe" /> made from a <see cref="T:Jotunn.Configs.ItemConfig" />.
	/// </summary>
	/// <param name="name">The new name of the prefab after cloning.</param>
	/// <param name="basePrefabName">The name of the base prefab the custom item is cloned from.</param>
	/// <param name="itemConfig">The item config for this custom item.</param>
	public CustomItem(string name, string basePrefabName, ItemConfig itemConfig)
		: base(Assembly.GetCallingAssembly())
	{
		GameObject gameObject = PrefabManager.Instance.CreateClonedPrefab(name, basePrefabName);
		if ((bool)gameObject)
		{
			ItemPrefab = gameObject;
			ItemDrop = gameObject.GetComponent<ItemDrop>();
			ApplyItemConfig(itemConfig);
		}
	}

	/// <summary>
	///     Custom item from a prefab loaded from an <see cref="T:UnityEngine.AssetBundle" /> with a <see cref="T:Recipe" /> made from a <see cref="T:Jotunn.Configs.ItemConfig" />.<br />
	///     Can fix references for <see cref="T:Jotunn.Entities.Mock`1" />s.
	/// </summary>
	/// <param name="assetBundle">A preloaded <see cref="T:UnityEngine.AssetBundle" /></param>
	/// <param name="assetName">Name of the prefab in the bundle.</param>
	/// <param name="fixReference">If true references for <see cref="T:Jotunn.Entities.Mock`1" /> objects get resolved at runtime by Jötunn.</param>
	/// <param name="itemConfig">The item config for this custom item.</param>
	public CustomItem(AssetBundle assetBundle, string assetName, bool fixReference, ItemConfig itemConfig)
		: base(Assembly.GetCallingAssembly())
	{
		fallbackItemName = assetName;
		if (AssetUtils.TryLoadPrefab(base.SourceMod, assetBundle, assetName, out var prefab))
		{
			ItemPrefab = prefab;
			ItemDrop = ItemPrefab.GetComponent<ItemDrop>();
			FixReference = fixReference;
			ApplyItemConfig(itemConfig);
		}
	}

	/// <summary>
	///     Checks if a custom item is valid (i.e. has a prefab, an <see cref="P:Jotunn.Entities.CustomItem.ItemDrop" /> and an icon, if it should be craftable).
	/// </summary>
	/// <returns>true if all criteria is met</returns>
	public bool IsValid()
	{
		bool result = true;
		if (!ItemPrefab)
		{
			Logger.LogError(base.SourceMod, $"CustomItem '{this}' has no prefab");
			result = false;
		}
		if ((bool)ItemPrefab && !ItemPrefab.IsValid())
		{
			result = false;
		}
		if (!ItemDrop)
		{
			Logger.LogError(base.SourceMod, $"CustomItem '{this}' has no ItemDrop component");
			result = false;
		}
		int? num = ((!ItemDrop) ? ((int?)null) : ItemDrop.m_itemData?.m_shared?.m_icons?.Length);
		if (Recipe != null && (!num.HasValue || num == 0))
		{
			Logger.LogError(base.SourceMod, $"CustomItem '{this}' has no icon");
			result = false;
		}
		return result;
	}

	/// <summary>
	///     Helper method to determine if a prefab with a given name is a custom item created with Jötunn.
	/// </summary>
	/// <param name="prefabName">Name of the prefab to test.</param>
	/// <returns>true if the prefab is added as a custom item to the <see cref="T:Jotunn.Managers.ItemManager" />.</returns>
	public static bool IsCustomItem(string prefabName)
	{
		return ItemManager.Instance.Items.ContainsKey(prefabName);
	}

	/// <inheritdoc />
	public override bool Equals(object obj)
	{
		return obj.GetHashCode() == GetHashCode();
	}

	/// <inheritdoc />
	public override int GetHashCode()
	{
		return StringExtensionMethods.GetStableHashCode(ItemName);
	}

	/// <inheritdoc />
	public override string ToString()
	{
		return ItemName;
	}

	internal void FixVariants()
	{
		Sprite[] array = ((!ItemDrop) ? null : ItemDrop.m_itemData?.m_shared?.m_icons);
		if (array == null || array.Length == 0 || !StyleTex)
		{
			return;
		}
		foreach (Renderer renderer in ShaderHelper.GetRenderers(ItemPrefab))
		{
			Material[] materials = renderer.materials;
			foreach (Material material in materials)
			{
				material.shader = PrefabManager.Cache.GetPrefab<Shader>("Custom/Creature");
				if (material.HasProperty("_StyleTex"))
				{
					ItemDrop.m_itemData.m_shared.m_variants = array.Length;
					renderer.gameObject.GetOrAddComponent<ItemStyle>();
					material.EnableKeyword("_USESTYLES_ON");
					material.SetFloat("_Style", 0f);
					material.SetFloat("_UseStyles", 1f);
					material.SetTexture("_StyleTex", StyleTex);
				}
			}
		}
	}

	private void ApplyItemConfig(ItemConfig itemConfig)
	{
		itemConfig.Apply(ItemPrefab);
		FixConfig = true;
		StyleTex = itemConfig.StyleTex;
		AssignRecipeFromConfig(itemConfig);
	}

	private void AssignRecipeFromConfig(ItemConfig itemConfig)
	{
		Recipe recipe = itemConfig.GetRecipe();
		if (recipe != null)
		{
			Recipe = new CustomRecipe(recipe, fixReference: true, fixRequirementReferences: true);
		}
	}
}
