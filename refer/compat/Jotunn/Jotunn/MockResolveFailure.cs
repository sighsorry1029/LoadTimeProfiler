using System;
using System.Collections.Generic;
using BepInEx;
using Jotunn.Utils;

namespace Jotunn;

/// <summary>
///     Failure that is tracked for a mock prefab which could not be resolved to a real prefab or other type.
/// </summary>
public class MockResolveFailure
{
	/// <summary>
	///     Accumulated list of the tracked MockResolveFailure.
	/// </summary>
	public static List<MockResolveFailure> MockResolveFailures { get; } = new List<MockResolveFailure>();

	/// <summary>
	///     Additional message to display when printing warnings.
	/// </summary>
	public string Message { get; private set; }

	/// <summary>
	///     Name of the type that could not be resolved. Mock prefix is already removed.
	/// </summary>
	public string FailedMockName { get; private set; }

	/// <summary>
	///     Path within the prefab that could not be resolved.
	/// </summary>
	public string FailedMockPath { get; private set; }

	/// <summary>
	///     Type of the prefab that could not be resolved.
	/// </summary>
	public Type MockType { get; private set; }

	/// <summary>
	///     Creates a new instance of the <see cref="T:Jotunn.MockResolveFailure" /> class.
	/// </summary>
	public MockResolveFailure(string message, string failedMockName, string failedMockPath, Type mockType)
	{
		Message = message;
		FailedMockName = failedMockName;
		FailedMockPath = failedMockPath;
		MockType = mockType;
	}

	/// <summary>
	///     Creates a new instance of the <see cref="T:Jotunn.MockResolveFailure" /> class.
	/// </summary>
	public MockResolveFailure(string message, string failedMockName, IEnumerable<string> failedMockPath, Type mockType)
	{
		Message = message;
		FailedMockName = failedMockName;
		FailedMockPath = string.Join<string>("->", failedMockPath);
		MockType = mockType;
	}

	private string ConstructMessage()
	{
		if (string.IsNullOrEmpty(FailedMockPath))
		{
			return ("Mock '" + FailedMockName + "' " + MockType.Name + " could not be resolved. " + Message).Trim();
		}
		return ("Mock " + MockType.Name + " at '" + FailedMockName + "' with child path '" + FailedMockPath + "' could not be resolved. " + Message).Trim();
	}

	/// <summary>
	///     Prints warning messages for all the tracked MockResolveFailure.
	/// </summary>
	public static void PrintMockResolveFailures(string prefabName)
	{
		if (MockResolveFailures.Count == 0)
		{
			return;
		}
		BepInPlugin sourceMod = ModQuery.GetPrefab(prefabName)?.SourceMod;
		int num = Math.Min(5, MockResolveFailures.Count);
		string arg = (string.IsNullOrEmpty(prefabName) ? "" : ("for '" + prefabName + "'"));
		string arg2 = ((MockResolveFailures.Count > num) ? $"(logging first {num} issues)" : "");
		Logger.LogWarning(sourceMod, $"{MockResolveFailures.Count} mocks {arg} could not be resolved. {arg2}".Replace("  ", " ").Trim());
		foreach (MockResolveFailure item in MockResolveFailures.GetRange(0, num))
		{
			Logger.LogWarning(sourceMod, item.ConstructMessage());
		}
	}
}
