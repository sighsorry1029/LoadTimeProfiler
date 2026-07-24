using System.Reflection;

namespace Jotunn.Entities;

/// <summary>
///     Main interface for adding custom status effects to the game.<br />
///     All custom status effects have to be wrapped inside this class to add it to Jötunns <see cref="T:Jotunn.Managers.ItemManager" />.
/// </summary>
public class CustomStatusEffect : CustomEntity
{
	/// <summary>
	///     The <see cref="T:StatusEffect" /> for this custom status effect.
	/// </summary>
	public StatusEffect StatusEffect { get; }

	/// <summary>
	///     Indicator if references from <see cref="T:Jotunn.Entities.Mock`1" />s will be replaced at runtime.
	/// </summary>
	public bool FixReference { get; set; }

	/// <summary>
	///     Custom status effect from a <see cref="T:StatusEffect" />.<br />
	///     Can fix references for <see cref="T:Jotunn.Entities.Mock`1" />s.
	/// </summary>
	/// <param name="statusEffect">A preloaded <see cref="T:StatusEffect" /></param>
	/// <param name="fixReference">If true references for <see cref="T:Jotunn.Entities.Mock`1" /> objects get resolved at runtime by Jötunn.</param>
	public CustomStatusEffect(StatusEffect statusEffect, bool fixReference)
		: base(Assembly.GetCallingAssembly())
	{
		StatusEffect = statusEffect;
		FixReference = fixReference;
	}

	/// <summary>
	///     Checks if a custom status effect is valid (i.e. has a <see cref="T:StatusEffect" />).
	/// </summary>
	/// <returns>true if all criteria is met</returns>
	public bool IsValid()
	{
		if (StatusEffect != null)
		{
			return StatusEffect.IsValid();
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
		return StringExtensionMethods.GetStableHashCode(StatusEffect.name);
	}

	/// <inheritdoc />
	public override string ToString()
	{
		return StatusEffect.name;
	}
}
