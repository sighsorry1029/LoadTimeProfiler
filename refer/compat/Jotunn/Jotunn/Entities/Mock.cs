using Jotunn.Managers;
using UnityEngine;

namespace Jotunn.Entities;

/// <summary>
///     Helper class for creating Mocks of a given vanilla Component.
/// </summary>
/// <typeparam name="T">Type of the mocked <see cref="T:UnityEngine.Component" /></typeparam>
public static class Mock<T> where T : Component
{
	/// <summary>
	///     Create a new Mock of type T : Component
	/// </summary>
	/// <param name="name">Name of the original component</param>
	/// <returns>Mocked <see cref="T:UnityEngine.Component" /></returns>
	public static T Create(string name)
	{
		return MockManager.Instance.CreateMockedPrefab<T>(name);
	}
}
