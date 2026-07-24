using System.Reflection;
using Jotunn.Configs;

namespace Jotunn.Entities;

/// <summary>
///     Main interface for adding custom recipes to the game.<br />
///     All custom recipes have to be wrapped inside this class to add it to Jötunns <see cref="T:Jotunn.Managers.ItemManager" />.
/// </summary>
public class CustomRecipe : CustomEntity
{
	/// <summary>
	///     The <see cref="T:Recipe" /> for this custom recipe.
	/// </summary>
	public Recipe Recipe { get; }

	/// <summary>
	///     Indicator if references from <see cref="T:Jotunn.Entities.Mock`1" />s will be replaced at runtime.
	/// </summary>
	public bool FixReference { get; set; }

	/// <summary>
	///     Indicator if references from <see cref="T:Jotunn.Entities.MockRequirement" />s will be replaced at runtime.
	/// </summary>
	public bool FixRequirementReferences { get; set; }

	/// <summary>
	///     Custom recipe from a <see cref="T:Recipe" />.<br />
	///     Can fix references for <see cref="T:Jotunn.Entities.Mock`1" />s and <see cref="T:Jotunn.Entities.MockRequirement" />s or not.
	/// </summary>
	/// <param name="recipe">The <see cref="T:Recipe" /> for a custom item.</param>
	/// <param name="fixReference">If true references for <see cref="T:Jotunn.Entities.Mock`1" /> objects get resolved at runtime by Jötunn.</param>
	/// <param name="fixRequirementReferences">If true references for <see cref="T:Jotunn.Entities.MockRequirement" />s get resolved at runtime by Jötunn.</param>
	public CustomRecipe(Recipe recipe, bool fixReference, bool fixRequirementReferences)
		: base(Assembly.GetCallingAssembly())
	{
		Recipe = recipe;
		FixReference = fixReference;
		FixRequirementReferences = fixRequirementReferences;
	}

	/// <summary>
	///     Custom recipe from a <see cref="T:Jotunn.Configs.RecipeConfig" />.<br />
	///     The <see cref="T:Recipe" /> is created automatically by Jötunn at runtime.
	/// </summary>
	/// <param name="recipeConfig">The <see cref="T:Jotunn.Configs.RecipeConfig" /> for a custom recipe.</param>
	public CustomRecipe(RecipeConfig recipeConfig)
		: base(Assembly.GetCallingAssembly())
	{
		Recipe = recipeConfig.GetRecipe();
		FixReference = true;
		FixRequirementReferences = true;
	}

	/// <summary>
	///     Checks if a custom status effect is valid (i.e. has a <see cref="T:Recipe" />).
	/// </summary>
	/// <returns>true if all criteria is met</returns>
	public bool IsValid()
	{
		if (Recipe != null && Recipe.IsValid())
		{
			return Recipe.m_item != null;
		}
		return false;
	}

	/// <inheritdoc />
	public override bool Equals(object obj)
	{
		return obj.GetHashCode() == GetHashCode();
	}

	/// <inheritdoc />
	public override int GetHashCode()
	{
		return StringExtensionMethods.GetStableHashCode(Recipe.name);
	}

	/// <inheritdoc />
	public override string ToString()
	{
		return Recipe.name;
	}
}
