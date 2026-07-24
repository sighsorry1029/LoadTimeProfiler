using UnityEngine;

namespace Jotunn.Extensions;

/// <summary>
///     Convenience methods for Transforms
/// </summary>
public static class TransformExtensions
{
	public static Transform FindDeepChild(this Transform transform, string childName, IterativeSearchType searchType = (IterativeSearchType)1)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		return Utils.FindChild(transform, childName, searchType);
	}
}
