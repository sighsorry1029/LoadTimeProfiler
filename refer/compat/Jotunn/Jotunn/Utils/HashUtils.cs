using System.Security.Cryptography;
using System.Text;

namespace Jotunn.Utils;

/// <summary>
///     A util class for computing various hashes
/// </summary>
public static class HashUtils
{
	/// <summary>
	///     Compute a SHA256 hash from a given string
	/// </summary>
	/// <param name="rawData"></param>
	/// <returns></returns>
	public static string ComputeSha256Hash(string rawData)
	{
		using SHA256 sHA = SHA256.Create();
		byte[] array = sHA.ComputeHash(Encoding.UTF8.GetBytes(rawData));
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < array.Length; i++)
		{
			stringBuilder.Append(array[i].ToString("x2"));
		}
		return stringBuilder.ToString();
	}
}
