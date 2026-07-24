using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

namespace AzuAnticheat.Internal;

internal class DicSingleton
{
	private delegate void FieldIssuer(object o);

	internal class RuleIssuer : Attribute
	{
		internal class SerializerIssuer<T>
		{
			private static object RestartGetter;

			public SerializerIssuer()
			{
				GetterIssuer.DeleteInitializer();
				base._002Ector();
				int num = 0;
				if (1 == 0)
				{
					num = 0;
				}
				switch (num)
				{
				case 0:
					break;
				}
			}

			internal static bool GetGetter()
			{
				return RestartGetter == null;
			}

			internal static object CalculateGetter()
			{
				return RestartGetter;
			}
		}

		public RuleIssuer(object P_0)
		{
		}
	}

	internal class ProducerIssuer
	{
		internal static string Sm8BuC1jVU(string P_0, string P_1)
		{
			byte[] bytes = Encoding.Unicode.GetBytes(P_0);
			byte[] key = new byte[32]
			{
				82, 102, 104, 110, 32, 77, 24, 34, 118, 181,
				51, 17, 18, 51, 12, 109, 10, 32, 77, 24,
				34, 158, 161, 41, 97, 28, 118, 181, 5, 25,
				1, 88
			};
			byte[] iV = tSQAj6vmw(Encoding.Unicode.GetBytes(P_1));
			MemoryStream memoryStream = new MemoryStream();
			SymmetricAlgorithm symmetricAlgorithm = dCmdi4ZMp();
			symmetricAlgorithm.Key = key;
			symmetricAlgorithm.IV = iV;
			CryptoStream cryptoStream = new CryptoStream(memoryStream, symmetricAlgorithm.CreateEncryptor(), CryptoStreamMode.Write);
			cryptoStream.Write(bytes, 0, bytes.Length);
			cryptoStream.Close();
			return Convert.ToBase64String(memoryStream.ToArray());
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	internal delegate uint ComparatorIssuer(IntPtr classthis, IntPtr comp, IntPtr info, [MarshalAs(UnmanagedType.U4)] uint flags, IntPtr nativeEntry, ref uint nativeSizeOfCode);

	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private delegate IntPtr DefinitionIssuer();

	internal struct ComposerIssuer
	{
		internal bool m_GlobalIssuer;

		internal byte[] mapIssuer;
	}

	internal class HelperIssuer
	{
		private BinaryReader m_ExceptionIssuer;

		public HelperIssuer(Stream P_0)
		{
			m_ExceptionIssuer = new BinaryReader(P_0);
		}

		[SpecialName]
		internal Stream bJfBUv9Xn2()
		{
			return m_ExceptionIssuer.BaseStream;
		}

		internal byte[] NgJB4TrEEu(int P_0)
		{
			return m_ExceptionIssuer.ReadBytes(P_0);
		}

		internal int j9iBpDRk8C(byte[] P_0, int P_1, int P_2)
		{
			return m_ExceptionIssuer.Read(P_0, P_1, P_2);
		}

		internal int nhTBv8xDiu()
		{
			return m_ExceptionIssuer.ReadInt32();
		}

		internal void RQiBcFBQMF()
		{
			m_ExceptionIssuer.Close();
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	private delegate IntPtr ItemIssuer(IntPtr hModule, string lpName, uint lpType);

	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private delegate IntPtr ContextIssuer(IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);

	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private delegate int MapperIssuer(IntPtr hProcess, IntPtr lpBaseAddress, [In][Out] byte[] buffer, uint size, out IntPtr lpNumberOfBytesWritten);

	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private delegate int IdentifierIssuer(IntPtr lpAddress, int dwSize, int flNewProtect, ref int lpflOldProtect);

	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private delegate IntPtr TokenIssuer(uint dwDesiredAccess, int bInheritHandle, uint dwProcessId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private delegate int CallbackIssuer(IntPtr ptr);

	[Flags]
	private enum RulesIssuer
	{

	}

	private static bool m_ParamsSingleton;

	private static bool listSingleton;

	private static Dictionary<int, int> _CollectionSingleton;

	private static List<int> threadSingleton;

	private static byte[] mappingSingleton;

	private static object objectSingleton;

	private static int[] m_ConsumerSingleton;

	private static SortedList specificationSingleton;

	private static int refSingleton;

	private static long _ObserverSingleton;

	internal static ComparatorIssuer m_AdapterSingleton;

	internal static ComparatorIssuer procSingleton;

	private static bool _BaseIssuer;

	[RuleIssuer(typeof(RuleIssuer.SerializerIssuer<object>[]))]
	private static bool _ReaderIssuer;

	private static ItemIssuer m_SetterIssuer;

	private static IntPtr _SingletonIssuer;

	private static IdentifierIssuer m_AuthenticationIssuer;

	private static int _InterceptorIssuer;

	private static byte[] _SchemaSingleton;

	private static object _ManagerSingleton;

	private static bool m_ConfigurationSingleton;

	private static ContextIssuer m_WriterIssuer;

	private static int _PropertySingleton;

	private static int m_PublisherIssuer;

	private static long _RoleIssuer;

	internal static RSACryptoServiceProvider queueSingleton;

	private static IntPtr m_FilterIssuer;

	private static int m_TokenizerSingleton;

	private static object m_ListenerSingleton;

	private static bool _PrototypeIssuer;

	internal static Assembly _PoolSingleton;

	private static List<string> m_AccountSingleton;

	private static MapperIssuer _InvocationIssuer;

	internal static Hashtable factoryIssuer;

	private static uint[] _DescriptorSingleton;

	private static TokenIssuer attributeIssuer;

	private static string _IssuerIssuer;

	private static IntPtr _StructSingleton;

	private static CallbackIssuer m_InterpreterIssuer;

	private static IntPtr classSingleton;

	private static bool m_DispatcherSingleton;

	static DicSingleton()
	{
		m_ParamsSingleton = false;
		_PoolSingleton = typeof(DicSingleton).Assembly;
		_DescriptorSingleton = new uint[64]
		{
			3614090360u, 3905402710u, 606105819u, 3250441966u, 4118548399u, 1200080426u, 2821735955u, 4249261313u, 1770035416u, 2336552879u,
			4294925233u, 2304563134u, 1804603682u, 4254626195u, 2792965006u, 1236535329u, 4129170786u, 3225465664u, 643717713u, 3921069994u,
			3593408605u, 38016083u, 3634488961u, 3889429448u, 568446438u, 3275163606u, 4107603335u, 1163531501u, 2850285829u, 4243563512u,
			1735328473u, 2368359562u, 4294588738u, 2272392833u, 1839030562u, 4259657740u, 2763975236u, 1272893353u, 4139469664u, 3200236656u,
			681279174u, 3936430074u, 3572445317u, 76029189u, 3654602809u, 3873151461u, 530742520u, 3299628645u, 4096336452u, 1126891415u,
			2878612391u, 4237533241u, 1700485571u, 2399980690u, 4293915773u, 2240044497u, 1873313359u, 4264355552u, 2734768916u, 1309151649u,
			4149444226u, 3174756917u, 718787259u, 3951481745u
		};
		m_DispatcherSingleton = false;
		listSingleton = false;
		queueSingleton = null;
		_CollectionSingleton = null;
		_ManagerSingleton = new object();
		m_TokenizerSingleton = 0;
		m_ListenerSingleton = new object();
		m_AccountSingleton = null;
		threadSingleton = null;
		mappingSingleton = new byte[0];
		_SchemaSingleton = new byte[0];
		_StructSingleton = IntPtr.Zero;
		classSingleton = IntPtr.Zero;
		objectSingleton = new string[0];
		m_ConsumerSingleton = new int[0];
		_PropertySingleton = 1;
		m_ConfigurationSingleton = false;
		specificationSingleton = new SortedList();
		refSingleton = 0;
		_ObserverSingleton = 0L;
		m_AdapterSingleton = null;
		procSingleton = null;
		_RoleIssuer = 0L;
		m_PublisherIssuer = 0;
		_BaseIssuer = false;
		_PrototypeIssuer = false;
		_InterceptorIssuer = 0;
		m_FilterIssuer = IntPtr.Zero;
		_ReaderIssuer = false;
		factoryIssuer = new Hashtable();
		m_SetterIssuer = null;
		m_WriterIssuer = null;
		_InvocationIssuer = null;
		m_AuthenticationIssuer = null;
		attributeIssuer = null;
		m_InterpreterIssuer = null;
		_SingletonIssuer = IntPtr.Zero;
		_IssuerIssuer = Encoding.Unicode.GetString(new byte[8] { 134, 123, 241, 8, 24, 98, 77, 199 });
		try
		{
			RSACryptoServiceProvider.UseMachineKeyStore = true;
		}
		catch
		{
		}
	}

	private void InterruptInitializer()
	{
	}

	internal static byte[] ixIrQkqvv(byte[] P_0)
	{
		uint[] array = new uint[16];
		uint num = (uint)((448 - P_0.Length * 8 % 512 + 512) % 512);
		if (num == 0)
		{
			num = 512u;
		}
		uint num2 = (uint)(P_0.Length + num / 8 + 8);
		ulong num3 = (ulong)P_0.Length * 8uL;
		byte[] array2 = new byte[num2];
		for (int i = 0; i < P_0.Length; i++)
		{
			array2[i] = P_0[i];
		}
		array2[P_0.Length] |= 128;
		for (int num4 = 8; num4 > 0; num4--)
		{
			array2[num2 - num4] = (byte)((num3 >> (8 - num4) * 8) & 0xFF);
		}
		uint num5 = (uint)(array2.Length * 8) / 32u;
		uint num6 = 1732584193u;
		uint num7 = 4023233417u;
		uint num8 = 2562383102u;
		uint num9 = 271733878u;
		for (uint num10 = 0u; num10 < num5 / 16; num10++)
		{
			uint num11 = num10 << 6;
			for (uint num12 = 0u; num12 < 61; num12 += 4)
			{
				array[num12 >> 2] = (uint)((array2[num11 + (num12 + 3)] << 24) | (array2[num11 + (num12 + 2)] << 16) | (array2[num11 + (num12 + 1)] << 8) | array2[num11 + num12]);
			}
			uint num13 = num6;
			uint num14 = num7;
			uint num15 = num8;
			uint num16 = num9;
			zV0TF1hwL(ref num6, num7, num8, num9, 0u, 7, 1u, array);
			zV0TF1hwL(ref num9, num6, num7, num8, 1u, 12, 2u, array);
			zV0TF1hwL(ref num8, num9, num6, num7, 2u, 17, 3u, array);
			zV0TF1hwL(ref num7, num8, num9, num6, 3u, 22, 4u, array);
			zV0TF1hwL(ref num6, num7, num8, num9, 4u, 7, 5u, array);
			zV0TF1hwL(ref num9, num6, num7, num8, 5u, 12, 6u, array);
			zV0TF1hwL(ref num8, num9, num6, num7, 6u, 17, 7u, array);
			zV0TF1hwL(ref num7, num8, num9, num6, 7u, 22, 8u, array);
			zV0TF1hwL(ref num6, num7, num8, num9, 8u, 7, 9u, array);
			zV0TF1hwL(ref num9, num6, num7, num8, 9u, 12, 10u, array);
			zV0TF1hwL(ref num8, num9, num6, num7, 10u, 17, 11u, array);
			zV0TF1hwL(ref num7, num8, num9, num6, 11u, 22, 12u, array);
			zV0TF1hwL(ref num6, num7, num8, num9, 12u, 7, 13u, array);
			zV0TF1hwL(ref num9, num6, num7, num8, 13u, 12, 14u, array);
			zV0TF1hwL(ref num8, num9, num6, num7, 14u, 17, 15u, array);
			zV0TF1hwL(ref num7, num8, num9, num6, 15u, 22, 16u, array);
			OYhB1hAtR(ref num6, num7, num8, num9, 1u, 5, 17u, array);
			OYhB1hAtR(ref num9, num6, num7, num8, 6u, 9, 18u, array);
			OYhB1hAtR(ref num8, num9, num6, num7, 11u, 14, 19u, array);
			OYhB1hAtR(ref num7, num8, num9, num6, 0u, 20, 20u, array);
			OYhB1hAtR(ref num6, num7, num8, num9, 5u, 5, 21u, array);
			OYhB1hAtR(ref num9, num6, num7, num8, 10u, 9, 22u, array);
			OYhB1hAtR(ref num8, num9, num6, num7, 15u, 14, 23u, array);
			OYhB1hAtR(ref num7, num8, num9, num6, 4u, 20, 24u, array);
			OYhB1hAtR(ref num6, num7, num8, num9, 9u, 5, 25u, array);
			OYhB1hAtR(ref num9, num6, num7, num8, 14u, 9, 26u, array);
			OYhB1hAtR(ref num8, num9, num6, num7, 3u, 14, 27u, array);
			OYhB1hAtR(ref num7, num8, num9, num6, 8u, 20, 28u, array);
			OYhB1hAtR(ref num6, num7, num8, num9, 13u, 5, 29u, array);
			OYhB1hAtR(ref num9, num6, num7, num8, 2u, 9, 30u, array);
			OYhB1hAtR(ref num8, num9, num6, num7, 7u, 14, 31u, array);
			OYhB1hAtR(ref num7, num8, num9, num6, 12u, 20, 32u, array);
			qqxN08fFI(ref num6, num7, num8, num9, 5u, 4, 33u, array);
			qqxN08fFI(ref num9, num6, num7, num8, 8u, 11, 34u, array);
			qqxN08fFI(ref num8, num9, num6, num7, 11u, 16, 35u, array);
			qqxN08fFI(ref num7, num8, num9, num6, 14u, 23, 36u, array);
			qqxN08fFI(ref num6, num7, num8, num9, 1u, 4, 37u, array);
			qqxN08fFI(ref num9, num6, num7, num8, 4u, 11, 38u, array);
			qqxN08fFI(ref num8, num9, num6, num7, 7u, 16, 39u, array);
			qqxN08fFI(ref num7, num8, num9, num6, 10u, 23, 40u, array);
			qqxN08fFI(ref num6, num7, num8, num9, 13u, 4, 41u, array);
			qqxN08fFI(ref num9, num6, num7, num8, 0u, 11, 42u, array);
			qqxN08fFI(ref num8, num9, num6, num7, 3u, 16, 43u, array);
			qqxN08fFI(ref num7, num8, num9, num6, 6u, 23, 44u, array);
			qqxN08fFI(ref num6, num7, num8, num9, 9u, 4, 45u, array);
			qqxN08fFI(ref num9, num6, num7, num8, 12u, 11, 46u, array);
			qqxN08fFI(ref num8, num9, num6, num7, 15u, 16, 47u, array);
			qqxN08fFI(ref num7, num8, num9, num6, 2u, 23, 48u, array);
			XOd7jZ0K7(ref num6, num7, num8, num9, 0u, 6, 49u, array);
			XOd7jZ0K7(ref num9, num6, num7, num8, 7u, 10, 50u, array);
			XOd7jZ0K7(ref num8, num9, num6, num7, 14u, 15, 51u, array);
			XOd7jZ0K7(ref num7, num8, num9, num6, 5u, 21, 52u, array);
			XOd7jZ0K7(ref num6, num7, num8, num9, 12u, 6, 53u, array);
			XOd7jZ0K7(ref num9, num6, num7, num8, 3u, 10, 54u, array);
			XOd7jZ0K7(ref num8, num9, num6, num7, 10u, 15, 55u, array);
			XOd7jZ0K7(ref num7, num8, num9, num6, 1u, 21, 56u, array);
			XOd7jZ0K7(ref num6, num7, num8, num9, 8u, 6, 57u, array);
			XOd7jZ0K7(ref num9, num6, num7, num8, 15u, 10, 58u, array);
			XOd7jZ0K7(ref num8, num9, num6, num7, 6u, 15, 59u, array);
			XOd7jZ0K7(ref num7, num8, num9, num6, 13u, 21, 60u, array);
			XOd7jZ0K7(ref num6, num7, num8, num9, 4u, 6, 61u, array);
			XOd7jZ0K7(ref num9, num6, num7, num8, 11u, 10, 62u, array);
			XOd7jZ0K7(ref num8, num9, num6, num7, 2u, 15, 63u, array);
			XOd7jZ0K7(ref num7, num8, num9, num6, 9u, 21, 64u, array);
			num6 += num13;
			num7 += num14;
			num8 += num15;
			num9 += num16;
		}
		byte[] array3 = new byte[16];
		Array.Copy(BitConverter.GetBytes(num6), 0, array3, 0, 4);
		Array.Copy(BitConverter.GetBytes(num7), 0, array3, 4, 4);
		Array.Copy(BitConverter.GetBytes(num8), 0, array3, 8, 4);
		Array.Copy(BitConverter.GetBytes(num9), 0, array3, 12, 4);
		return array3;
	}

	private static void zV0TF1hwL(ref uint P_0, uint P_1, uint P_2, uint P_3, uint P_4, ushort P_5, uint P_6, uint[] P_7)
	{
		P_0 = P_1 + L8HbSZZiZ(P_0 + ((P_1 & P_2) | (~P_1 & P_3)) + P_7[P_4] + _DescriptorSingleton[P_6 - 1], P_5);
	}

	private static void OYhB1hAtR(ref uint P_0, uint P_1, uint P_2, uint P_3, uint P_4, ushort P_5, uint P_6, uint[] P_7)
	{
		P_0 = P_1 + L8HbSZZiZ(P_0 + ((P_1 & P_3) | (P_2 & ~P_3)) + P_7[P_4] + _DescriptorSingleton[P_6 - 1], P_5);
	}

	private static void qqxN08fFI(ref uint P_0, uint P_1, uint P_2, uint P_3, uint P_4, ushort P_5, uint P_6, uint[] P_7)
	{
		P_0 = P_1 + L8HbSZZiZ(P_0 + (P_1 ^ P_2 ^ P_3) + P_7[P_4] + _DescriptorSingleton[P_6 - 1], P_5);
	}

	private static void XOd7jZ0K7(ref uint P_0, uint P_1, uint P_2, uint P_3, uint P_4, ushort P_5, uint P_6, uint[] P_7)
	{
		P_0 = P_1 + L8HbSZZiZ(P_0 + (P_2 ^ (P_1 | ~P_3)) + P_7[P_4] + _DescriptorSingleton[P_6 - 1], P_5);
	}

	private static uint L8HbSZZiZ(uint P_0, ushort P_1)
	{
		return (P_0 >> 32 - P_1) | (P_0 << (int)P_1);
	}

	internal static bool iMnYdccvt()
	{
		if (!m_DispatcherSingleton)
		{
			meSZlD86r();
			m_DispatcherSingleton = true;
		}
		return listSingleton;
	}

	internal DicSingleton()
	{
	}

	private void bdClc0XbY(byte[] P_0, byte[] P_1, byte[] P_2)
	{
		int num = P_2.Length % 4;
		int num2 = P_2.Length / 4;
		byte[] array = new byte[P_2.Length];
		int num3 = P_0.Length / 4;
		uint num4 = 0u;
		uint num5 = 0u;
		uint num6 = 0u;
		if (num > 0)
		{
			num2++;
		}
		uint num7 = 0u;
		for (int i = 0; i < num2; i++)
		{
			int num8 = i % num3;
			int num9 = i * 4;
			num7 = (uint)(num8 * 4);
			num5 = (uint)((P_0[num7 + 3] << 24) | (P_0[num7 + 2] << 16) | (P_0[num7 + 1] << 8) | P_0[num7]);
			uint num10 = 255u;
			int num11 = 0;
			if (i == num2 - 1 && num > 0)
			{
				num6 = 0u;
				num4 += num5;
				for (int j = 0; j < num; j++)
				{
					if (j > 0)
					{
						num6 <<= 8;
					}
					num6 |= P_2[^(1 + j)];
				}
			}
			else
			{
				num4 += num5;
				num7 = (uint)num9;
				num6 = (uint)((P_2[num7 + 3] << 24) | (P_2[num7 + 2] << 16) | (P_2[num7 + 1] << 8) | P_2[num7]);
			}
			uint num12 = num4;
			num4 = 0u;
			uint num13 = num12;
			uint num14 = 1848062510u;
			uint num15 = 1476206688u;
			uint num16 = 420830501u;
			uint num17 = 1438469537u;
			uint num18 = 1258253111u;
			num15 = num14 ^ (num16 + num14);
			uint num19 = num17 & 0xFF00FF;
			uint num20 = num17 & 0xFF00FF00u;
			num19 = ((num19 >> 8) | (num20 << 8)) + num16;
			num17 = (num17 << 14) | (num17 >> 18);
			ulong num21 = num15 * num15;
			if (num21 == 0)
			{
				num21--;
			}
			num14 = (uint)(num14 * num14 % num21);
			num17 = 102612 * (num17 & 0x3FFF) - (num17 >> 14);
			num15 = 78231 * (num15 & 0x3FFF) + (num15 >> 14);
			num15 = 56288 * num15 - num17;
			if ((double)num18 == 0.0)
			{
				num18--;
			}
			uint num22 = (uint)((double)num15 / (double)num18 + (double)num18);
			num18 = (uint)((ushort)num15 - 60372 + (int)num22 + (ushort)num15);
			num13 ^= num13 << 7;
			num13 += num14;
			num13 ^= num13 << 21;
			num13 += num16;
			num13 ^= num13 >> 17;
			num13 += num18;
			num13 = (((num15 << 13) + num14) ^ num14) + num13;
			num4 = num12 + (uint)(double)num13;
			if (i == num2 - 1 && num > 0)
			{
				uint num23 = num4 ^ num6;
				for (int k = 0; k < num; k++)
				{
					if (k > 0)
					{
						num10 <<= 8;
						num11 += 8;
					}
					array[num9 + k] = (byte)((num23 & num10) >> num11);
				}
			}
			else
			{
				uint num24 = num4 ^ num6;
				array[num9] = (byte)(num24 & 0xFF);
				array[num9 + 1] = (byte)((num24 & 0xFF00) >> 8);
				array[num9 + 2] = (byte)((num24 & 0xFF0000) >> 16);
				array[num9 + 3] = (byte)((num24 & 0xFF000000u) >> 24);
			}
		}
		mappingSingleton = array;
	}

	internal static SymmetricAlgorithm dCmdi4ZMp()
	{
		SymmetricAlgorithm symmetricAlgorithm = null;
		if (iMnYdccvt())
		{
			return new AesCryptoServiceProvider();
		}
		try
		{
			return new RijndaelManaged();
		}
		catch
		{
			return (SymmetricAlgorithm)Activator.CreateInstance("System.Core, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Security.Cryptography.AesCryptoServiceProvider").Unwrap();
		}
	}

	internal static void meSZlD86r()
	{
		try
		{
			listSingleton = CryptoConfig.AllowOnlyFipsAlgorithms;
		}
		catch
		{
		}
	}

	internal static byte[] tSQAj6vmw(byte[] P_0)
	{
		if (!iMnYdccvt())
		{
			return new MD5CryptoServiceProvider().ComputeHash(P_0);
		}
		return ixIrQkqvv(P_0);
	}

	internal static void BW1J5no3V(HashAlgorithm P_0, Stream P_1, uint P_2, byte[] P_3)
	{
		while (P_2 != 0)
		{
			int num = ((P_2 > (uint)P_3.Length) ? P_3.Length : ((int)P_2));
			P_1.Read(P_3, 0, num);
			Vxbm8RoEw(P_0, P_3, 0, num);
			P_2 -= (uint)num;
		}
	}

	internal static void Vxbm8RoEw(HashAlgorithm P_0, byte[] P_1, int P_2, int P_3)
	{
		P_0.TransformBlock(P_1, P_2, P_3, P_1, P_2);
	}

	internal static uint wLpLhLU0c(uint P_0, int P_1, long P_2, BinaryReader P_3)
	{
		for (int i = 0; i < P_1; i++)
		{
			P_3.BaseStream.Position = P_2 + (i * 40 + 8);
			uint num = P_3.ReadUInt32();
			uint num2 = P_3.ReadUInt32();
			P_3.ReadUInt32();
			uint num3 = P_3.ReadUInt32();
			if (num2 <= P_0 && P_0 < num2 + num)
			{
				return num3 + P_0 - num2;
			}
		}
		return 0u;
	}

	internal static void RZL5qN7wD()
	{
		if (queueSingleton != null)
		{
			return;
		}
		GetterIssuer.DeleteInitializer();
		RSACryptoServiceProvider.UseMachineKeyStore = true;
		queueSingleton = new RSACryptoServiceProvider();
		string location = typeof(DicSingleton).Assembly.Location;
		if (location == null || location.Length == 0)
		{
			return;
		}
		HashAlgorithm hashAlgorithm = null;
		string text = null;
		try
		{
			hashAlgorithm = SHA1.Create();
			text = CryptoConfig.MapNameToOID("SHA1");
			if (!File.Exists(location))
			{
				return;
			}
		}
		catch
		{
			return;
		}
		bool flag = false;
		try
		{
			HelperIssuer helperIssuer = new HelperIssuer(_PoolSingleton.GetManifestResourceStream("{11111-22222-20001-00000}"));
			helperIssuer.bJfBUv9Xn2().Position = 0L;
			byte[] array = helperIssuer.NgJB4TrEEu((int)helperIssuer.bJfBUv9Xn2().Length);
			byte[] rgbKey = new DicSingleton().GSO1X8FWg();
			byte[] rgbIV = new DicSingleton().YxaSqBxxb();
			SymmetricAlgorithm symmetricAlgorithm = dCmdi4ZMp();
			symmetricAlgorithm.Mode = CipherMode.CBC;
			ICryptoTransform transform = symmetricAlgorithm.CreateDecryptor(rgbKey, rgbIV);
			Stream stream = U8vtSKVpf();
			CryptoStream cryptoStream = new CryptoStream(stream, transform, CryptoStreamMode.Write);
			cryptoStream.Write(array, 0, array.Length);
			cryptoStream.FlushFinalBlock();
			queueSingleton.FromXmlString(Encoding.UTF8.GetString(JFu9RUCVx(stream)));
			stream.Close();
			cryptoStream.Close();
			helperIssuer.RQiBcFBQMF();
		}
		catch
		{
			flag = true;
		}
		if (!flag)
		{
			BinaryReader binaryReader = null;
			try
			{
				FileStream fileStream = new FileStream(location, FileMode.Open, FileAccess.Read, FileShare.Read);
				binaryReader = new BinaryReader(fileStream);
				byte[] array2 = new byte[65536];
				BW1J5no3V(hashAlgorithm, fileStream, 152u, array2);
				bool num = binaryReader.ReadUInt16() != 523;
				int num2 = (num ? 96 : 112);
				fileStream.Position = 152L;
				fileStream.Read(array2, 0, num2);
				array2[64] = 0;
				array2[65] = 0;
				array2[66] = 0;
				array2[67] = 0;
				Vxbm8RoEw(hashAlgorithm, array2, 0, num2);
				fileStream.Read(array2, 0, 128);
				array2[32] = 0;
				array2[33] = 0;
				array2[34] = 0;
				array2[35] = 0;
				array2[36] = 0;
				array2[37] = 0;
				array2[38] = 0;
				array2[39] = 0;
				Vxbm8RoEw(hashAlgorithm, array2, 0, 128);
				long position = fileStream.Position;
				fileStream.Position = 134L;
				int num3 = binaryReader.ReadUInt16();
				fileStream.Position = position;
				BW1J5no3V(hashAlgorithm, fileStream, (uint)(num3 * 40), array2);
				long position2 = fileStream.Position;
				if (num)
				{
					fileStream.Position = 360L;
				}
				else
				{
					fileStream.Position = 376L;
				}
				uint num4 = wLpLhLU0c(binaryReader.ReadUInt32(), num3, position, binaryReader);
				fileStream.Position = num4 + 32;
				uint num5 = binaryReader.ReadUInt32();
				uint num6 = binaryReader.ReadUInt32();
				long num7 = wLpLhLU0c(num5, num3, position, binaryReader);
				long num8 = num7 + num6;
				fileStream.Position = position2;
				for (int i = 0; i < num3; i++)
				{
					fileStream.Position = position + i * 40 + 16;
					uint num9 = binaryReader.ReadUInt32();
					uint num10 = binaryReader.ReadUInt32();
					fileStream.Position = num10;
					while (num9 != 0)
					{
						long position3 = fileStream.Position;
						if (num7 <= position3 && position3 < num8)
						{
							uint num11 = (uint)(num8 - position3);
							if (num11 >= num9)
							{
								break;
							}
							num9 -= num11;
							fileStream.Position += num11;
							continue;
						}
						if (position3 >= num8)
						{
							BW1J5no3V(hashAlgorithm, fileStream, num9, array2);
							break;
						}
						uint num12 = (uint)Math.Min(num7 - position3, num9);
						BW1J5no3V(hashAlgorithm, fileStream, num12, array2);
						num9 -= num12;
					}
				}
				hashAlgorithm.TransformFinalBlock(new byte[0], 0, 0);
				fileStream.Position = num7;
				byte[] array3 = binaryReader.ReadBytes((int)num6);
				Array.Reverse((Array)array3);
				flag = !queueSingleton.VerifyHash(hashAlgorithm.Hash, text, array3);
			}
			catch
			{
				flag = true;
			}
			try
			{
				binaryReader?.Close();
			}
			catch
			{
			}
		}
		if (flag)
		{
			throw new Exception(typeof(DicSingleton).Assembly.GetName().Name + " is tampered.");
		}
		flag = false;
	}

	public static void LJhFgotkP(RuntimeTypeHandle P_0)
	{
		try
		{
			Type typeFromHandle = Type.GetTypeFromHandle(P_0);
			if (_CollectionSingleton == null)
			{
				lock (_ManagerSingleton)
				{
					Dictionary<int, int> dictionary = new Dictionary<int, int>();
					BinaryReader binaryReader = new BinaryReader(typeof(DicSingleton).Assembly.GetManifestResourceStream("Process.Instance"));
					binaryReader.BaseStream.Position = 0L;
					byte[] array = binaryReader.ReadBytes((int)binaryReader.BaseStream.Length);
					binaryReader.Close();
					if (array.Length != 0)
					{
						int num = array.Length % 4;
						int num2 = array.Length / 4;
						byte[] array2 = new byte[array.Length];
						uint num3 = 0u;
						uint num4 = 0u;
						if (num > 0)
						{
							num2++;
						}
						uint num5 = 0u;
						for (int i = 0; i < num2; i++)
						{
							int num6 = i * 4;
							uint num7 = 255u;
							int num8 = 0;
							if (i == num2 - 1 && num > 0)
							{
								num4 = 0u;
								for (int j = 0; j < num; j++)
								{
									if (j > 0)
									{
										num4 <<= 8;
									}
									num4 |= array[^(1 + j)];
								}
							}
							else
							{
								num5 = (uint)num6;
								num4 = (uint)((array[num5 + 3] << 24) | (array[num5 + 2] << 16) | (array[num5 + 1] << 8) | array[num5]);
							}
							num3 = num3;
							num3 += Dily6JNJd(num3);
							if (i == num2 - 1 && num > 0)
							{
								uint num9 = num3 ^ num4;
								for (int k = 0; k < num; k++)
								{
									if (k > 0)
									{
										num7 <<= 8;
										num8 += 8;
									}
									array2[num6 + k] = (byte)((num9 & num7) >> num8);
								}
							}
							else
							{
								uint num10 = num3 ^ num4;
								array2[num6] = (byte)(num10 & 0xFF);
								array2[num6 + 1] = (byte)((num10 & 0xFF00) >> 8);
								array2[num6 + 2] = (byte)((num10 & 0xFF0000) >> 16);
								array2[num6 + 3] = (byte)((num10 & 0xFF000000u) >> 24);
							}
						}
						array = array2;
						array2 = null;
						int num11 = array.Length / 8;
						HelperIssuer helperIssuer = new HelperIssuer(new MemoryStream(array));
						for (int l = 0; l < num11; l++)
						{
							int key = helperIssuer.nhTBv8xDiu();
							int value = helperIssuer.nhTBv8xDiu();
							dictionary.Add(key, value);
						}
						helperIssuer.RQiBcFBQMF();
					}
					_CollectionSingleton = dictionary;
				}
			}
			FieldInfo[] fields = typeFromHandle.GetFields(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.GetField);
			for (int m = 0; m < fields.Length; m++)
			{
				try
				{
					FieldInfo fieldInfo = fields[m];
					int metadataToken = fieldInfo.MetadataToken;
					int num12 = _CollectionSingleton[metadataToken];
					bool flag = (num12 & 0x40000000) > 0;
					num12 &= 0x3FFFFFFF;
					MethodInfo methodInfo = (MethodInfo)typeof(DicSingleton).Module.ResolveMethod(num12, typeFromHandle.GetGenericArguments(), new Type[0]);
					if (methodInfo.IsStatic)
					{
						fieldInfo.SetValue(null, Delegate.CreateDelegate(fieldInfo.FieldType, methodInfo));
						continue;
					}
					ParameterInfo[] parameters = methodInfo.GetParameters();
					int num13 = parameters.Length + 1;
					Type[] array3 = new Type[num13];
					if (methodInfo.DeclaringType.IsValueType)
					{
						array3[0] = methodInfo.DeclaringType.MakeByRefType();
					}
					else
					{
						array3[0] = typeof(object);
					}
					for (int n = 0; n < parameters.Length; n++)
					{
						array3[n + 1] = parameters[n].ParameterType;
					}
					DynamicMethod dynamicMethod = new DynamicMethod(string.Empty, methodInfo.ReturnType, array3, typeFromHandle, skipVisibility: true);
					ILGenerator iLGenerator = dynamicMethod.GetILGenerator();
					for (int num14 = 0; num14 < num13; num14++)
					{
						switch (num14)
						{
						case 0:
							iLGenerator.Emit(OpCodes.Ldarg_0);
							break;
						case 1:
							iLGenerator.Emit(OpCodes.Ldarg_1);
							break;
						case 2:
							iLGenerator.Emit(OpCodes.Ldarg_2);
							break;
						case 3:
							iLGenerator.Emit(OpCodes.Ldarg_3);
							break;
						default:
							iLGenerator.Emit(OpCodes.Ldarg_S, num14);
							break;
						}
					}
					iLGenerator.Emit(OpCodes.Tailcall);
					iLGenerator.Emit(flag ? OpCodes.Callvirt : OpCodes.Call, methodInfo);
					iLGenerator.Emit(OpCodes.Ret);
					fieldInfo.SetValue(null, dynamicMethod.CreateDelegate(typeFromHandle));
				}
				catch
				{
				}
			}
		}
		catch (Exception)
		{
		}
	}

	private static uint OgQKl9yqF(uint P_0)
	{
		return (uint)"{11111-22222-10009-11112}".Length;
	}

	private static uint Dily6JNJd(uint P_0)
	{
		return 0u;
	}

	internal static void lhZuyDnKH()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void YHfxmZYAA(Stream P_0, int P_1)
	{
		int num = 130;
		byte[] array3 = default(byte[]);
		int num4 = default(int);
		byte[] array = default(byte[]);
		int num6 = default(int);
		int num3 = default(int);
		int num5 = default(int);
		int num7 = default(int);
		byte[] array4 = default(byte[]);
		byte[] publicKeyToken = default(byte[]);
		byte[] array5 = default(byte[]);
		byte[] array2 = default(byte[]);
		ICryptoTransform transform = default(ICryptoTransform);
		Stream stream = default(Stream);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 358:
					array3[12] = 132;
					num2 = 240;
					if (PublishExpression() != null)
					{
						num2 = 85;
					}
					continue;
				case 245:
					num4 = 56 + 20;
					num2 = 139;
					continue;
				case 300:
					array[14] = 11;
					num2 = 174;
					continue;
				case 31:
					num6 = 123 + 78;
					num2 = 113;
					if (InvokeExpression())
					{
						num2 = 268;
					}
					continue;
				case 13:
					array3[0] = (byte)num6;
					num2 = 37;
					if (!InvokeExpression())
					{
						num2 = 14;
					}
					continue;
				case 283:
					num3 = 127 - 3;
					num2 = 49;
					continue;
				case 252:
					num3 = 23 + 26;
					num2 = 4;
					if (InvokeExpression())
					{
						num2 = 4;
					}
					continue;
				case 206:
					array[25] = (byte)num3;
					num = 332;
					break;
				case 365:
					array[5] = 141;
					num2 = 18;
					continue;
				case 14:
					num5 = 222 - 74;
					num2 = 235;
					if (PublishExpression() != null)
					{
						num2 = 197;
					}
					continue;
				case 285:
					num5 = 24 + 3;
					num2 = 346;
					if (!InvokeExpression())
					{
						num2 = 141;
					}
					continue;
				case 222:
					num4 = 225 - 75;
					num2 = 262;
					continue;
				case 158:
					num3 = 145 - 48;
					num = 36;
					break;
				case 325:
					if (P_1 == -1)
					{
						num2 = 350;
						continue;
					}
					goto case 284;
				case 105:
				case 354:
					num7 = 0;
					num2 = 334;
					continue;
				case 37:
					array3[0] = 43;
					num2 = 126;
					continue;
				case 203:
					array[16] = 107;
					num2 = 42;
					continue;
				case 79:
					num3 = 12 + 37;
					num2 = 157;
					continue;
				case 362:
					array3[1] = 153;
					num2 = 25;
					continue;
				case 265:
					array[1] = 69;
					num2 = 339;
					continue;
				case 24:
					num3 = 91 + 24;
					num2 = 50;
					continue;
				case 53:
					array[13] = 96;
					num = 20;
					break;
				case 312:
					array[19] = (byte)num3;
					num2 = 254;
					continue;
				case 3:
					array3[8] = 82;
					num2 = 19;
					continue;
				case 273:
					num3 = 128 - 42;
					num2 = 224;
					continue;
				case 161:
					num6 = 16 + 90;
					num2 = 287;
					if (!InvokeExpression())
					{
						num2 = 236;
					}
					continue;
				case 246:
					num6 = 254 - 84;
					num2 = 269;
					if (PublishExpression() != null)
					{
						num2 = 23;
					}
					continue;
				case 303:
					num4 = 141 - 47;
					num2 = 368;
					continue;
				case 369:
					num5 = 220 - 73;
					num2 = 37;
					if (PublishExpression() == null)
					{
						num2 = 76;
					}
					continue;
				case 310:
					array[7] = (byte)num5;
					num2 = 146;
					continue;
				case 337:
					array[26] = (byte)num5;
					num2 = 86;
					continue;
				case 142:
					num5 = 75 + 56;
					num2 = 320;
					if (PublishExpression() != null)
					{
						num2 = 240;
					}
					continue;
				case 244:
					array[22] = (byte)num3;
					num2 = 144;
					if (PublishExpression() != null)
					{
						num2 = 64;
					}
					continue;
				case 88:
					array[19] = (byte)num3;
					num2 = 68;
					continue;
				case 262:
					array3[4] = (byte)num4;
					num2 = 95;
					if (InvokeExpression())
					{
						num2 = 185;
					}
					continue;
				case 359:
					num3 = 185 - 116;
					num2 = 153;
					if (PublishExpression() != null)
					{
						num2 = 138;
					}
					continue;
				case 149:
					array3[1] = (byte)num6;
					num2 = 360;
					continue;
				case 367:
					array3[1] = (byte)num6;
					num2 = 362;
					continue;
				case 97:
					array3[4] = (byte)num6;
					num2 = 164;
					if (InvokeExpression())
					{
						num2 = 329;
					}
					continue;
				case 124:
					num5 = 79 + 37;
					num2 = 128;
					continue;
				case 191:
					num3 = 6 + 80;
					num2 = 265;
					if (InvokeExpression())
					{
						num2 = 290;
					}
					continue;
				case 136:
					array3[8] = (byte)num6;
					num2 = 3;
					if (!InvokeExpression())
					{
						num2 = 0;
					}
					continue;
				case 139:
					array3[7] = (byte)num4;
					num2 = 138;
					continue;
				case 145:
					array4[9] = publicKeyToken[4];
					num2 = 204;
					continue;
				case 93:
					array[21] = 155;
					num2 = 1;
					if (PublishExpression() == null)
					{
						num2 = 89;
					}
					continue;
				case 340:
					array[14] = 76;
					num2 = 23;
					continue;
				case 113:
					num6 = 103 + 114;
					num2 = 149;
					if (PublishExpression() != null)
					{
						num2 = 97;
					}
					continue;
				case 52:
					num5 = 45 + 1;
					num2 = 211;
					continue;
				case 39:
					array[8] = 161;
					num2 = 46;
					continue;
				case 248:
					num3 = 126 + 10;
					num2 = 131;
					continue;
				case 127:
					num6 = 109 + 69;
					num2 = 255;
					continue;
				case 62:
					array[6] = 86;
					num2 = 182;
					continue;
				case 137:
					num3 = 14 + 88;
					num = 108;
					break;
				case 347:
					array[0] = 69;
					num2 = 151;
					if (PublishExpression() != null)
					{
						num2 = 45;
					}
					continue;
				case 166:
					array[19] = 218;
					num2 = 226;
					continue;
				case 95:
					num5 = 103 + 18;
					num2 = 237;
					if (!InvokeExpression())
					{
						num2 = 51;
					}
					continue;
				case 201:
					array[17] = 81;
					num2 = 7;
					if (InvokeExpression())
					{
						num2 = 80;
					}
					continue;
				case 353:
					num3 = 252 - 84;
					num2 = 155;
					continue;
				case 205:
					array[30] = (byte)num5;
					num2 = 213;
					continue;
				case 102:
					array3[14] = 63;
					num2 = 308;
					continue;
				case 141:
					num5 = 92 + 25;
					num2 = 45;
					continue;
				case 302:
					num5 = 99 + 120;
					num2 = 343;
					continue;
				case 305:
					array3[11] = 111;
					num2 = 132;
					if (PublishExpression() != null)
					{
						num2 = 69;
					}
					continue;
				case 43:
					array[15] = (byte)num3;
					num2 = 100;
					continue;
				case 308:
					num4 = 36 + 93;
					num2 = 85;
					continue;
				case 30:
					array[18] = (byte)num3;
					num2 = 10;
					continue;
				case 243:
				case 297:
					array5[num7] ^= array4[num7];
					num2 = 267;
					continue;
				case 307:
					array[27] = 219;
					num2 = 180;
					if (PublishExpression() != null)
					{
						num2 = 10;
					}
					continue;
				case 342:
					array4 = array3;
					num2 = 55;
					continue;
				case 57:
					if (publicKeyToken != null)
					{
						num2 = 317;
						if (PublishExpression() == null)
						{
							num2 = 327;
						}
						continue;
					}
					goto case 105;
				case 32:
					num4 = 48 + 59;
					num2 = 174;
					if (PublishExpression() == null)
					{
						num2 = 351;
					}
					continue;
				case 280:
					array[14] = (byte)num3;
					num2 = 233;
					continue;
				case 19:
					array3[8] = 133;
					num2 = 352;
					continue;
				case 185:
					num6 = 71 - 0;
					num2 = 97;
					continue;
				case 33:
					array[22] = 84;
					num2 = 109;
					continue;
				case 60:
					array[21] = 100;
					num2 = 123;
					continue;
				case 317:
					num4 = 75 + 56;
					num2 = 209;
					if (PublishExpression() == null)
					{
						num2 = 260;
					}
					continue;
				case 69:
					num5 = 174 - 58;
					num2 = 319;
					if (!InvokeExpression())
					{
						num2 = 66;
					}
					continue;
				case 209:
					array3[13] = 100;
					num = 156;
					break;
				case 153:
					array[10] = (byte)num3;
					num2 = 92;
					continue;
				case 186:
					array3[13] = 111;
					num2 = 209;
					if (!InvokeExpression())
					{
						num2 = 135;
					}
					continue;
				case 352:
					array3[9] = 96;
					num2 = 90;
					if (PublishExpression() != null)
					{
						num2 = 82;
					}
					continue;
				case 128:
					array[28] = (byte)num5;
					num = 302;
					break;
				case 152:
					array[23] = 6;
					num2 = 40;
					continue;
				case 357:
					array3[8] = (byte)num4;
					num2 = 361;
					continue;
				case 172:
					num3 = 125 - 41;
					num2 = 189;
					if (!InvokeExpression())
					{
						num2 = 172;
					}
					continue;
				case 214:
					array2 = mappingSingleton;
					num2 = 284;
					if (PublishExpression() != null)
					{
						num2 = 225;
					}
					continue;
				case 338:
					num6 = 3 + 70;
					num2 = 47;
					continue;
				case 321:
					array3[9] = 136;
					num2 = 286;
					continue;
				case 355:
					num3 = 111 - 72;
					num2 = 95;
					if (PublishExpression() == null)
					{
						num2 = 336;
					}
					continue;
				case 119:
					array[24] = 127;
					num2 = 257;
					continue;
				case 74:
					num3 = 183 - 61;
					num2 = 30;
					continue;
				case 103:
					array[17] = 114;
					num2 = 323;
					continue;
				case 68:
					array[19] = 187;
					num2 = 38;
					if (PublishExpression() != null)
					{
						num2 = 28;
					}
					continue;
				case 249:
					array[10] = 95;
					num2 = 252;
					if (PublishExpression() != null)
					{
						num2 = 73;
					}
					continue;
				case 230:
					array[4] = (byte)num3;
					num2 = 263;
					continue;
				case 323:
					array[17] = 88;
					num2 = 32;
					if (InvokeExpression())
					{
						num2 = 178;
					}
					continue;
				case 169:
					array[22] = 144;
					num2 = 33;
					continue;
				case 180:
					num5 = 101 + 64;
					num2 = 58;
					continue;
				case 1:
					array[11] = (byte)num3;
					num2 = 61;
					continue;
				case 253:
					array3[13] = (byte)num4;
					num2 = 91;
					continue;
				case 294:
					array[27] = 120;
					num2 = 52;
					continue;
				case 182:
					array[6] = 177;
					num2 = 200;
					continue;
				case 221:
					array3[11] = (byte)num6;
					num2 = 11;
					if (InvokeExpression())
					{
						num2 = 78;
					}
					continue;
				case 45:
					array[11] = (byte)num5;
					num2 = 282;
					if (!InvokeExpression())
					{
						num2 = 256;
					}
					continue;
				case 10:
					array[18] = 55;
					num2 = 67;
					if (PublishExpression() == null)
					{
						num2 = 248;
					}
					continue;
				case 311:
					array3[3] = 132;
					num2 = 170;
					continue;
				case 7:
					array4[1] = publicKeyToken[0];
					num = 140;
					break;
				case 204:
					array4[11] = publicKeyToken[5];
					num2 = 116;
					continue;
				case 318:
					array4[5] = publicKeyToken[2];
					num2 = 168;
					if (!InvokeExpression())
					{
						num2 = 136;
					}
					continue;
				case 225:
					num3 = 179 - 59;
					num2 = 206;
					continue;
				case 51:
					num3 = 152 - 50;
					num2 = 301;
					continue;
				case 198:
				case 334:
					if (num7 < array4.Length)
					{
						num2 = 297;
						continue;
					}
					goto case 325;
				case 264:
					num4 = 133 - 117;
					num2 = 81;
					continue;
				case 332:
					num5 = 41 + 99;
					num2 = 193;
					continue;
				case 108:
					array[17] = (byte)num3;
					num2 = 201;
					if (!InvokeExpression())
					{
						num2 = 133;
					}
					continue;
				case 181:
					array[15] = (byte)num3;
					num2 = 98;
					continue;
				case 187:
					array[3] = 152;
					num2 = 142;
					if (PublishExpression() != null)
					{
						num2 = 94;
					}
					continue;
				case 73:
					array3[5] = (byte)num4;
					num2 = 66;
					continue;
				case 104:
					array3[15] = 162;
					num2 = 246;
					if (PublishExpression() != null)
					{
						num2 = 118;
					}
					continue;
				case 324:
					array[9] = (byte)num5;
					num2 = 164;
					continue;
				case 207:
					array3[6] = 102;
					num2 = 188;
					continue;
				case 328:
					array[1] = (byte)num5;
					num = 191;
					break;
				case 78:
					array3[11] = 132;
					num2 = 10;
					if (PublishExpression() == null)
					{
						num2 = 127;
					}
					continue;
				case 86:
					array[26] = 236;
					num2 = 204;
					if (PublishExpression() == null)
					{
						num2 = 294;
					}
					continue;
				case 75:
					array[28] = (byte)num5;
					num2 = 117;
					if (PublishExpression() != null)
					{
						num2 = 15;
					}
					continue;
				case 44:
					array3[10] = 153;
					num2 = 291;
					continue;
				case 272:
					new DicSingleton().bdClc0XbY(array5, array4, array2);
					num2 = 61;
					if (PublishExpression() == null)
					{
						num2 = 72;
					}
					continue;
				case 292:
					array[31] = (byte)num5;
					num2 = 99;
					continue;
				case 360:
					num6 = 169 - 99;
					num2 = 99;
					if (InvokeExpression())
					{
						num2 = 306;
					}
					continue;
				case 256:
					array[3] = 91;
					num2 = 147;
					if (PublishExpression() != null)
					{
						num2 = 121;
					}
					continue;
				case 217:
					array[3] = (byte)num5;
					num2 = 70;
					continue;
				case 177:
					num6 = 144 - 48;
					num2 = 313;
					continue;
				case 316:
					array[20] = (byte)num5;
					num2 = 2;
					if (InvokeExpression())
					{
						num2 = 27;
					}
					continue;
				case 41:
					array3[3] = 172;
					num2 = 5;
					if (PublishExpression() == null)
					{
						num2 = 202;
					}
					continue;
				case 314:
					array[26] = 177;
					num = 197;
					break;
				case 98:
					array[15] = 118;
					num2 = 21;
					continue;
				case 56:
					num6 = 30 + 68;
					num2 = 136;
					continue;
				case 117:
					array[29] = 103;
					num2 = 184;
					continue;
				case 134:
					array5 = array;
					num2 = 341;
					if (!InvokeExpression())
					{
						num2 = 102;
					}
					continue;
				case 112:
					array[25] = 104;
					num = 261;
					break;
				case 228:
					num3 = 252 - 84;
					num2 = 299;
					continue;
				case 46:
					array[9] = 163;
					num2 = 273;
					if (!InvokeExpression())
					{
						num2 = 116;
					}
					continue;
				case 179:
					num3 = 13 + 30;
					num2 = 171;
					continue;
				case 162:
					array3[3] = 133;
					num2 = 33;
					if (InvokeExpression())
					{
						num2 = 41;
					}
					continue;
				case 118:
					num5 = 35 + 106;
					num2 = 316;
					continue;
				case 266:
					num3 = 90 - 12;
					num2 = 43;
					continue;
				case 263:
					num3 = 250 - 83;
					num = 106;
					break;
				case 237:
					array[7] = (byte)num5;
					num2 = 0;
					if (!InvokeExpression())
					{
						num2 = 0;
					}
					continue;
				case 94:
					num3 = 183 - 61;
					num2 = 176;
					if (PublishExpression() != null)
					{
						num2 = 151;
					}
					continue;
				case 218:
					array[31] = (byte)num3;
					num2 = 281;
					if (!InvokeExpression())
					{
						num2 = 201;
					}
					continue;
				case 59:
					array[29] = 239;
					num2 = 51;
					if (PublishExpression() != null)
					{
						num2 = 7;
					}
					continue;
				case 231:
					array[8] = (byte)num5;
					num2 = 220;
					continue;
				case 320:
					array[3] = (byte)num5;
					num2 = 199;
					if (!InvokeExpression())
					{
						num2 = 187;
					}
					continue;
				case 80:
					array[17] = 213;
					num2 = 103;
					continue;
				case 168:
					array4[7] = publicKeyToken[3];
					num2 = 19;
					if (PublishExpression() == null)
					{
						num2 = 145;
					}
					continue;
				case 269:
					array3[15] = (byte)num6;
					num2 = 29;
					continue;
				case 101:
					array[2] = 227;
					num2 = 243;
					if (PublishExpression() == null)
					{
						num2 = 256;
					}
					continue;
				case 235:
					array[12] = (byte)num5;
					num = 333;
					break;
				case 192:
					array3[0] = 102;
					num2 = 288;
					if (!InvokeExpression())
					{
						num2 = 163;
					}
					continue;
				case 301:
					array[30] = (byte)num3;
					num = 236;
					break;
				case 148:
					array[21] = (byte)num3;
					num2 = 8;
					continue;
				case 188:
					array3[6] = 144;
					num2 = 114;
					continue;
				case 132:
					num6 = 26 + 63;
					num2 = 221;
					continue;
				case 151:
					array[0] = 63;
					num2 = 265;
					continue;
				case 146:
					array[7] = 175;
					num2 = 18;
					if (PublishExpression() == null)
					{
						num2 = 159;
					}
					continue;
				case 71:
					array[12] = 82;
					num2 = 298;
					continue;
				case 236:
					array[30] = 112;
					num2 = 135;
					continue;
				case 281:
					array[31] = 68;
					num2 = 15;
					if (InvokeExpression())
					{
						num2 = 134;
					}
					continue;
				case 251:
					num4 = 52 + 61;
					num2 = 22;
					continue;
				case 329:
					num4 = 124 + 28;
					num2 = 73;
					continue;
				case 163:
					array[20] = (byte)num5;
					num = 355;
					break;
				case 11:
					array[25] = (byte)num3;
					num = 79;
					break;
				case 120:
					array[12] = (byte)num5;
					num2 = 210;
					if (PublishExpression() != null)
					{
						num2 = 81;
					}
					continue;
				case 126:
					array3[1] = 88;
					num2 = 105;
					if (InvokeExpression())
					{
						num2 = 194;
					}
					continue;
				case 18:
					array[6] = 128;
					num2 = 369;
					continue;
				case 157:
					array[25] = (byte)num3;
					num2 = 125;
					continue;
				case 212:
					array3[7] = (byte)num6;
					num2 = 219;
					continue;
				case 299:
					array[9] = (byte)num3;
					num = 335;
					break;
				case 227:
					array3[2] = 92;
					num2 = 264;
					continue;
				case 229:
					array3[5] = 23;
					num2 = 247;
					continue;
				case 326:
					array3[0] = (byte)num4;
					num2 = 21;
					if (PublishExpression() == null)
					{
						num2 = 143;
					}
					continue;
				case 100:
					array[16] = 167;
					num2 = 250;
					if (!InvokeExpression())
					{
						num2 = 138;
					}
					continue;
				case 261:
					num3 = 43 + 95;
					num2 = 11;
					continue;
				case 211:
					array[27] = (byte)num5;
					num2 = 271;
					continue;
				case 106:
					array[5] = (byte)num3;
					num2 = 54;
					if (PublishExpression() != null)
					{
						num2 = 31;
					}
					continue;
				case 175:
					array[12] = (byte)num5;
					num2 = 71;
					continue;
				case 257:
					array[24] = 27;
					num2 = 112;
					continue;
				case 268:
					array3[2] = (byte)num6;
					num2 = 79;
					if (PublishExpression() == null)
					{
						num2 = 227;
					}
					continue;
				case 346:
					array[10] = (byte)num5;
					num2 = 278;
					continue;
				case 171:
					array[28] = (byte)num3;
					num2 = 150;
					continue;
				case 12:
					num4 = 119 - 7;
					num = 196;
					break;
				case 17:
					num4 = 92 + 25;
					num = 357;
					break;
				case 368:
					array3[4] = (byte)num4;
					num2 = 117;
					if (InvokeExpression())
					{
						num2 = 122;
					}
					continue;
				case 40:
					num5 = 212 - 70;
					num2 = 13;
					if (PublishExpression() == null)
					{
						num2 = 238;
					}
					continue;
				case 242:
					array3[2] = 122;
					num = 31;
					break;
				case 335:
					num3 = 119 + 25;
					num2 = 309;
					continue;
				case 29:
					array3[15] = 2;
					num2 = 154;
					if (PublishExpression() == null)
					{
						num2 = 342;
					}
					continue;
				case 34:
					array3[9] = 220;
					num2 = 322;
					if (!InvokeExpression())
					{
						num2 = 91;
					}
					continue;
				case 183:
					num3 = 138 + 16;
					num = 230;
					break;
				case 276:
					array3[6] = (byte)num4;
					num2 = 245;
					continue;
				case 350:
				{
					SymmetricAlgorithm symmetricAlgorithm = dCmdi4ZMp();
					symmetricAlgorithm.Mode = CipherMode.CBC;
					transform = symmetricAlgorithm.CreateDecryptor(array5, array4);
					num2 = 270;
					if (!InvokeExpression())
					{
						num2 = 236;
					}
					continue;
				}
				case 364:
					array[26] = (byte)num3;
					num2 = 314;
					continue;
				case 135:
					array[30] = 238;
					num2 = 216;
					continue;
				case 72:
					return;
				case 184:
					array[29] = 38;
					num2 = 353;
					continue;
				case 274:
					array[23] = (byte)num3;
					num2 = 152;
					continue;
				case 216:
					num5 = 153 - 51;
					num2 = 205;
					continue;
				case 330:
					array[4] = (byte)num3;
					num2 = 81;
					if (InvokeExpression())
					{
						num2 = 87;
					}
					continue;
				case 284:
					if (_PoolSingleton.EntryPoint == null)
					{
						num2 = 26;
						continue;
					}
					goto case 272;
				case 309:
					array[9] = (byte)num3;
					num2 = 249;
					if (!InvokeExpression())
					{
						num2 = 112;
					}
					continue;
				case 2:
					array[27] = (byte)num5;
					num2 = 307;
					continue;
				case 26:
					m_TokenizerSingleton = 80;
					num = 272;
					break;
				case 4:
					array[10] = (byte)num3;
					num2 = 173;
					continue;
				case 339:
					array[1] = 138;
					num2 = 275;
					continue;
				case 240:
					array3[12] = 187;
					num2 = 251;
					continue;
				case 290:
					array[2] = (byte)num3;
					num2 = 94;
					if (!InvokeExpression())
					{
						num2 = 15;
					}
					continue;
				case 154:
					array[21] = (byte)num3;
					num2 = 26;
					if (InvokeExpression())
					{
						num2 = 60;
					}
					continue;
				case 164:
					num3 = 203 - 67;
					num2 = 111;
					if (PublishExpression() != null)
					{
						num2 = 11;
					}
					continue;
				case 16:
					array3[3] = (byte)num4;
					num2 = 162;
					continue;
				case 336:
					array[20] = (byte)num3;
					num2 = 93;
					continue;
				case 5:
					num5 = 233 - 77;
					num2 = 163;
					if (PublishExpression() != null)
					{
						num2 = 83;
					}
					continue;
				case 213:
					num5 = 129 - 17;
					num2 = 49;
					if (InvokeExpression())
					{
						num2 = 115;
					}
					continue;
				case 84:
					array3[0] = 115;
					num2 = 349;
					continue;
				case 50:
					array[0] = (byte)num3;
					num2 = 145;
					if (PublishExpression() == null)
					{
						num2 = 347;
					}
					continue;
				case 304:
					array[24] = 117;
					num2 = 119;
					if (PublishExpression() != null)
					{
						num2 = 6;
					}
					continue;
				case 115:
					array[30] = (byte)num5;
					num2 = 69;
					continue;
				case 111:
					array[9] = (byte)num3;
					num2 = 97;
					if (PublishExpression() == null)
					{
						num2 = 228;
					}
					continue;
				case 55:
					Array.Reverse((Array)array4);
					num2 = 315;
					if (PublishExpression() != null)
					{
						num2 = 106;
					}
					continue;
				case 278:
					array[10] = 47;
					num2 = 359;
					if (!InvokeExpression())
					{
						num2 = 290;
					}
					continue;
				case 15:
					array3[13] = 114;
					num2 = 6;
					continue;
				case 343:
					array[28] = (byte)num5;
					num2 = 179;
					continue;
				case 159:
					num5 = 154 - 51;
					num2 = 231;
					continue;
				case 348:
					array3[5] = 136;
					num2 = 32;
					continue;
				case 313:
					array3[3] = (byte)num6;
					num2 = 311;
					continue;
				case 277:
					array[16] = 134;
					num2 = 203;
					if (!InvokeExpression())
					{
						num2 = 163;
					}
					continue;
				case 140:
					array4[3] = publicKeyToken[1];
					num2 = 318;
					continue;
				case 288:
					num4 = 22 + 6;
					num2 = 326;
					continue;
				case 189:
					array[23] = (byte)num3;
					num2 = 145;
					if (PublishExpression() == null)
					{
						num2 = 160;
					}
					continue;
				case 76:
					array[6] = (byte)num5;
					num2 = 62;
					if (PublishExpression() != null)
					{
						num2 = 49;
					}
					continue;
				case 190:
					array[17] = (byte)num5;
					num2 = 74;
					continue;
				case 47:
					array3[4] = (byte)num6;
					num2 = 133;
					if (InvokeExpression())
					{
						num2 = 303;
					}
					continue;
				case 351:
					array3[5] = (byte)num4;
					num2 = 56;
					if (PublishExpression() == null)
					{
						num2 = 77;
					}
					continue;
				case 155:
					array[29] = (byte)num3;
					num2 = 59;
					continue;
				case 150:
					num5 = 89 - 63;
					num2 = 75;
					if (PublishExpression() != null)
					{
						num2 = 61;
					}
					continue;
				case 226:
					num3 = 254 - 84;
					num2 = 191;
					if (PublishExpression() == null)
					{
						num2 = 312;
					}
					continue;
				case 220:
					array[8] = 141;
					num2 = 39;
					continue;
				case 58:
					array[27] = (byte)num5;
					num2 = 35;
					continue;
				case 224:
					array[9] = (byte)num3;
					num = 239;
					break;
				case 241:
					array3[0] = (byte)num6;
					num = 192;
					break;
				case 133:
					num3 = 222 - 74;
					num2 = 274;
					continue;
				case 116:
					array4[13] = publicKeyToken[6];
					num2 = 67;
					if (!InvokeExpression())
					{
						num2 = 37;
					}
					continue;
				case 238:
					array[24] = (byte)num5;
					num2 = 304;
					if (!InvokeExpression())
					{
						num2 = 17;
					}
					continue;
				case 138:
					num4 = 211 - 70;
					num2 = 234;
					continue;
				case 156:
					array3[13] = 213;
					num2 = 15;
					continue;
				case 147:
					array[3] = 217;
					num2 = 187;
					continue;
				case 287:
					array3[6] = (byte)num6;
					num = 207;
					break;
				case 306:
					array3[1] = (byte)num6;
					num2 = 317;
					if (!InvokeExpression())
					{
						num2 = 58;
					}
					continue;
				case 8:
					array[22] = 94;
					num2 = 169;
					continue;
				case 174:
					num3 = 7 + 45;
					num2 = 52;
					if (PublishExpression() == null)
					{
						num2 = 167;
					}
					continue;
				case 25:
					array3[1] = 91;
					num2 = 113;
					continue;
				case 254:
					num3 = 242 - 80;
					num2 = 88;
					if (!InvokeExpression())
					{
						num2 = 83;
					}
					continue;
				case 87:
					array[4] = 96;
					num = 183;
					break;
				case 267:
					num7++;
					num2 = 130;
					if (InvokeExpression())
					{
						num2 = 198;
					}
					continue;
				case 322:
					array3[10] = 127;
					num2 = 107;
					continue;
				case 291:
					array3[10] = 102;
					num2 = 14;
					if (PublishExpression() == null)
					{
						num2 = 28;
					}
					continue;
				case 208:
					num5 = 230 - 76;
					num = 292;
					break;
				case 344:
					array[20] = 97;
					num2 = 5;
					continue;
				case 165:
					array3[8] = 102;
					num2 = 17;
					if (InvokeExpression())
					{
						num2 = 56;
					}
					continue;
				case 81:
					array3[2] = (byte)num4;
					num2 = 177;
					continue;
				case 345:
					array3[4] = 128;
					num2 = 338;
					continue;
				case 331:
					array3[7] = (byte)num4;
					num2 = 17;
					continue;
				case 219:
					num4 = 152 - 103;
					num2 = 331;
					if (!InvokeExpression())
					{
						num2 = 140;
					}
					continue;
				case 232:
					array[14] = 110;
					num2 = 340;
					continue;
				case 61:
					num3 = 200 - 66;
					num2 = 223;
					continue;
				case 125:
					array[25] = 140;
					num2 = 14;
					if (PublishExpression() == null)
					{
						num2 = 225;
					}
					continue;
				case 130:
				{
					HelperIssuer helperIssuer = new HelperIssuer(P_0);
					helperIssuer.bJfBUv9Xn2().Position = 0L;
					array2 = helperIssuer.NgJB4TrEEu((int)helperIssuer.bJfBUv9Xn2().Length);
					helperIssuer.RQiBcFBQMF();
					num2 = 1;
					if (PublishExpression() == null)
					{
						num2 = 129;
					}
					continue;
				}
				case 200:
					array[6] = 128;
					num2 = 283;
					if (!InvokeExpression())
					{
						num2 = 197;
					}
					continue;
				case 361:
					array3[8] = 157;
					num2 = 165;
					continue;
				case 282:
					num3 = 127 - 40;
					num2 = 1;
					if (!InvokeExpression())
					{
						num2 = 0;
					}
					continue;
				case 298:
					array[12] = 126;
					num2 = 363;
					continue;
				case 36:
					array[7] = (byte)num3;
					num2 = 95;
					if (!InvokeExpression())
					{
						num2 = 28;
					}
					continue;
				case 82:
					num6 = 153 - 51;
					num2 = 212;
					continue;
				case 42:
					array[16] = 29;
					num2 = 137;
					continue;
				case 64:
					array3[6] = 102;
					num2 = 161;
					if (!InvokeExpression())
					{
						num2 = 13;
					}
					continue;
				case 66:
					array3[5] = 123;
					num2 = 348;
					continue;
				case 196:
					array3[14] = (byte)num4;
					num2 = 104;
					continue;
				case 327:
					if (publicKeyToken.Length == 0)
					{
						num2 = 105;
						continue;
					}
					goto case 7;
				case 107:
					array3[10] = 129;
					num2 = 96;
					if (PublishExpression() != null)
					{
						num2 = 10;
					}
					continue;
				case 92:
					num5 = 14 + 103;
					num2 = 366;
					continue;
				case 239:
					num5 = 59 + 30;
					num2 = 324;
					continue;
				case 122:
					num6 = 144 - 48;
					num2 = 83;
					continue;
				case 83:
					array3[4] = (byte)num6;
					num2 = 222;
					continue;
				case 279:
					num3 = 181 - 60;
					num2 = 63;
					if (!InvokeExpression())
					{
						num2 = 56;
					}
					continue;
				case 89:
					num3 = 50 + 107;
					num2 = 154;
					continue;
				case 143:
					num6 = 165 - 55;
					num = 13;
					break;
				case 48:
					num3 = 161 - 53;
					num = 364;
					break;
				case 210:
					num3 = 234 - 78;
					num2 = 9;
					continue;
				case 234:
					array3[7] = (byte)num4;
					num2 = 16;
					if (InvokeExpression())
					{
						num2 = 82;
					}
					continue;
				case 341:
					array3 = new byte[16];
					num2 = 65;
					if (InvokeExpression())
					{
						num2 = 84;
					}
					continue;
				case 194:
					num6 = 243 - 81;
					num2 = 367;
					continue;
				case 121:
					array[22] = (byte)num5;
					num2 = 172;
					continue;
				case 91:
					array3[13] = 87;
					num = 102;
					break;
				case 54:
					num5 = 28 + 69;
					num2 = 258;
					continue;
				case 363:
					num5 = 96 + 37;
					num2 = 120;
					continue;
				case 270:
					stream = U8vtSKVpf();
					num2 = 65;
					continue;
				case 96:
					array3[10] = 105;
					num2 = 195;
					if (!InvokeExpression())
					{
						num2 = 98;
					}
					continue;
				case 293:
					array[23] = (byte)num3;
					num = 133;
					break;
				case 195:
					array3[10] = 164;
					num2 = 44;
					continue;
				case 23:
					num3 = 157 - 52;
					num = 280;
					break;
				case 295:
					array[14] = 167;
					num2 = 290;
					if (PublishExpression() == null)
					{
						num2 = 300;
					}
					continue;
				case 85:
					array3[14] = (byte)num4;
					num = 12;
					break;
				case 202:
					num6 = 24 + 101;
					num2 = 296;
					continue;
				case 123:
					num3 = 96 + 84;
					num2 = 148;
					continue;
				case 258:
					array[5] = (byte)num5;
					num2 = 365;
					if (!InvokeExpression())
					{
						num2 = 201;
					}
					continue;
				case 178:
					num5 = 151 - 63;
					num2 = 190;
					continue;
				case 223:
					array[12] = (byte)num3;
					num2 = 14;
					continue;
				case 99:
					num3 = 134 - 44;
					num2 = 218;
					if (!InvokeExpression())
					{
						num2 = 10;
					}
					continue;
				case 286:
					array3[9] = 166;
					num = 34;
					break;
				case 199:
					num5 = 168 - 55;
					num2 = 217;
					continue;
				case 38:
					array[20] = 73;
					num2 = 118;
					continue;
				case 271:
					num5 = 167 - 55;
					num2 = 0;
					if (PublishExpression() == null)
					{
						num2 = 2;
					}
					continue;
				case 22:
					array3[12] = (byte)num4;
					num2 = 268;
					if (PublishExpression() == null)
					{
						num2 = 356;
					}
					continue;
				case 349:
					num6 = 40 + 29;
					num2 = 241;
					if (!InvokeExpression())
					{
						num2 = 200;
					}
					continue;
				case 315:
					publicKeyToken = _PoolSingleton.GetName().GetPublicKeyToken();
					num2 = 57;
					continue;
				case 366:
					array[11] = (byte)num5;
					num = 141;
					break;
				case 247:
					array3[6] = 168;
					num2 = 64;
					continue;
				case 259:
					num3 = 162 - 54;
					num2 = 181;
					continue;
				case 77:
					array3[5] = 167;
					num2 = 3;
					if (PublishExpression() == null)
					{
						num2 = 229;
					}
					continue;
				case 20:
					array[13] = 51;
					num2 = 232;
					continue;
				case 90:
					array3[9] = 136;
					num2 = 321;
					continue;
				case 21:
					array[15] = 102;
					num = 266;
					break;
				case 160:
					num3 = 122 + 24;
					num2 = 293;
					continue;
				case 170:
					num4 = 21 + 64;
					num2 = 16;
					continue;
				case 260:
					array3[2] = (byte)num4;
					num2 = 242;
					if (!InvokeExpression())
					{
						num2 = 186;
					}
					continue;
				case 27:
					array[20] = 121;
					num2 = 344;
					continue;
				case 67:
					array4[15] = publicKeyToken[7];
					num2 = 354;
					continue;
				default:
					num5 = 225 - 75;
					num2 = 310;
					continue;
				case 70:
					num3 = 123 + 78;
					num2 = 330;
					continue;
				case 28:
					num4 = 198 - 66;
					num2 = 110;
					if (InvokeExpression())
					{
						num2 = 289;
					}
					continue;
				case 129:
					array = new byte[32];
					num2 = 24;
					continue;
				case 233:
					array[14] = 105;
					num2 = 295;
					continue;
				case 289:
					array3[11] = (byte)num4;
					num2 = 0;
					if (PublishExpression() == null)
					{
						num2 = 305;
					}
					continue;
				case 167:
					array[15] = (byte)num3;
					num2 = 161;
					if (InvokeExpression())
					{
						num2 = 259;
					}
					continue;
				case 356:
					array3[12] = 139;
					num2 = 186;
					continue;
				case 173:
					array[10] = 144;
					num2 = 285;
					if (PublishExpression() != null)
					{
						num2 = 216;
					}
					continue;
				case 49:
					array[6] = (byte)num3;
					num2 = 158;
					continue;
				case 296:
					array3[3] = (byte)num6;
					num2 = 188;
					if (PublishExpression() == null)
					{
						num2 = 345;
					}
					continue;
				case 275:
					num5 = 71 + 86;
					num2 = 328;
					if (!InvokeExpression())
					{
						num2 = 129;
					}
					continue;
				case 250:
					array[16] = 85;
					num2 = 277;
					continue;
				case 176:
					array[2] = (byte)num3;
					num2 = 23;
					if (PublishExpression() == null)
					{
						num2 = 101;
					}
					continue;
				case 110:
					array[26] = (byte)num3;
					num2 = 48;
					continue;
				case 319:
					array[31] = (byte)num5;
					num2 = 279;
					if (PublishExpression() != null)
					{
						num2 = 162;
					}
					continue;
				case 109:
					num3 = 41 + 8;
					num2 = 244;
					if (PublishExpression() != null)
					{
						num2 = 220;
					}
					continue;
				case 193:
					array[25] = (byte)num5;
					num2 = 215;
					continue;
				case 215:
					num3 = 31 + 97;
					num2 = 110;
					if (!InvokeExpression())
					{
						num2 = 110;
					}
					continue;
				case 255:
					array3[11] = (byte)num6;
					num2 = 358;
					continue;
				case 144:
					num5 = 75 - 51;
					num2 = 121;
					if (!InvokeExpression())
					{
						num2 = 40;
					}
					continue;
				case 333:
					num5 = 195 - 65;
					num2 = 169;
					if (InvokeExpression())
					{
						num2 = 175;
					}
					continue;
				case 131:
					array[18] = (byte)num3;
					num2 = 166;
					continue;
				case 197:
					num5 = 81 + 58;
					num2 = 337;
					continue;
				case 65:
				{
					CryptoStream cryptoStream = new CryptoStream(stream, transform, CryptoStreamMode.Write);
					cryptoStream.Write(array2, 0, array2.Length);
					cryptoStream.FlushFinalBlock();
					mappingSingleton = JFu9RUCVx(stream);
					stream.Close();
					cryptoStream.Close();
					num2 = 214;
					if (PublishExpression() != null)
					{
						num2 = 209;
					}
					continue;
				}
				case 114:
					num4 = 222 + 24;
					num2 = 276;
					continue;
				case 6:
					num4 = 7 + 8;
					num2 = 253;
					if (!InvokeExpression())
					{
						num2 = 120;
					}
					continue;
				case 63:
					array[31] = (byte)num3;
					num2 = 208;
					continue;
				case 9:
					array[13] = (byte)num3;
					num2 = 53;
					continue;
				case 35:
					array[27] = 228;
					num2 = 124;
					if (PublishExpression() != null)
					{
						num2 = 24;
					}
					continue;
				}
				break;
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static string gE3WbyDVW(int P_0)
	{
		if (mappingSingleton.Length == 0)
		{
			m_AccountSingleton = new List<string>();
			threadSingleton = new List<int>();
			YHfxmZYAA(_PoolSingleton.GetManifestResourceStream("Expression.Visitor"), P_0);
		}
		if (m_TokenizerSingleton < 75)
		{
			if (_PoolSingleton != new StackFrame(1).GetMethod().DeclaringType.Assembly)
			{
				throw new Exception();
			}
			m_TokenizerSingleton++;
		}
		lock (m_ListenerSingleton)
		{
			int num = BitConverter.ToInt32(mappingSingleton, P_0);
			if (num < threadSingleton.Count && threadSingleton[num] == P_0)
			{
				return m_AccountSingleton[num];
			}
			try
			{
				byte[] array = new byte[num];
				Array.Copy(mappingSingleton, P_0 + 4, array, 0, num);
				string text = Encoding.Unicode.GetString(array, 0, array.Length);
				m_AccountSingleton.Add(text);
				threadSingleton.Add(P_0);
				Array.Copy(BitConverter.GetBytes(m_AccountSingleton.Count - 1), 0, mappingSingleton, P_0, 4);
				return text;
			}
			catch
			{
			}
		}
		return "";
	}

	internal static string vnJ4444ap(string P_0)
	{
		"{11111-22222-50001-00000}".Trim();
		byte[] array = Convert.FromBase64String(P_0);
		return Encoding.Unicode.GetString(array, 0, array.Length);
	}

	private static int Htgp9sIYO()
	{
		return 5;
	}

	private static void APMv9fHZx()
	{
		try
		{
			RSACryptoServiceProvider.UseMachineKeyStore = true;
		}
		catch
		{
		}
	}

	private static Delegate grAcNKjtY(IntPtr P_0, Type P_1)
	{
		return (Delegate)typeof(Marshal).GetMethod("GetDelegateForFunctionPointer", new Type[2]
		{
			typeof(IntPtr),
			typeof(Type)
		}).Invoke(null, new object[2] { P_0, P_1 });
	}

	internal static object VWWIasJH3(object P_0)
	{
		try
		{
			if (File.Exists(((Assembly)P_0).Location))
			{
				return ((Assembly)P_0).Location;
			}
		}
		catch
		{
		}
		try
		{
			if (File.Exists(((Assembly)P_0).GetName().CodeBase.ToString().Replace("file:///", "")))
			{
				return ((Assembly)P_0).GetName().CodeBase.ToString().Replace("file:///", "");
			}
		}
		catch
		{
		}
		try
		{
			if (File.Exists(P_0.GetType().GetProperty("Location").GetValue(P_0, new object[0])
				.ToString()))
			{
				return P_0.GetType().GetProperty("Location").GetValue(P_0, new object[0])
					.ToString();
			}
		}
		catch
		{
		}
		return "";
	}

	[DllImport("kernel32", EntryPoint = "LoadLibrary")]
	public static extern IntPtr lWSg6nv0c(string P_0);

	[DllImport("kernel32", CharSet = CharSet.Ansi, EntryPoint = "GetProcAddress")]
	public static extern IntPtr FHUnODZTn(IntPtr P_0, string P_1);

	private static IntPtr Ro2kGG1HF(IntPtr P_0, string P_1, uint P_2)
	{
		if (m_SetterIssuer == null)
		{
			m_SetterIssuer = (ItemIssuer)Marshal.GetDelegateForFunctionPointer(FHUnODZTn(tmL0uXbJ0(), "Find ".Trim() + "ResourceA"), typeof(ItemIssuer));
		}
		return m_SetterIssuer(P_0, P_1, P_2);
	}

	private static IntPtr NmbGQIAQT(IntPtr P_0, uint P_1, uint P_2, uint P_3)
	{
		if (m_WriterIssuer == null)
		{
			m_WriterIssuer = (ContextIssuer)Marshal.GetDelegateForFunctionPointer(FHUnODZTn(tmL0uXbJ0(), "Virtual ".Trim() + "Alloc"), typeof(ContextIssuer));
		}
		return m_WriterIssuer(P_0, P_1, P_2, P_3);
	}

	private static int UT9fWWfdq(IntPtr P_0, IntPtr P_1, [In][Out] byte[] P_2, uint P_3, out IntPtr P_4)
	{
		if (_InvocationIssuer == null)
		{
			_InvocationIssuer = (MapperIssuer)Marshal.GetDelegateForFunctionPointer(FHUnODZTn(tmL0uXbJ0(), "Write ".Trim() + "Process ".Trim() + "Memory"), typeof(MapperIssuer));
		}
		return _InvocationIssuer(P_0, P_1, P_2, P_3, out P_4);
	}

	private static int LalDkYdkm(IntPtr P_0, int P_1, int P_2, ref int P_3)
	{
		if (m_AuthenticationIssuer == null)
		{
			m_AuthenticationIssuer = (IdentifierIssuer)Marshal.GetDelegateForFunctionPointer(FHUnODZTn(tmL0uXbJ0(), "Virtual ".Trim() + "Protect"), typeof(IdentifierIssuer));
		}
		return m_AuthenticationIssuer(P_0, P_1, P_2, ref P_3);
	}

	private static IntPtr B6APtTZw6(uint P_0, int P_1, uint P_2)
	{
		if (attributeIssuer == null)
		{
			attributeIssuer = (TokenIssuer)Marshal.GetDelegateForFunctionPointer(FHUnODZTn(tmL0uXbJ0(), "Open ".Trim() + "Process"), typeof(TokenIssuer));
		}
		return attributeIssuer(P_0, P_1, P_2);
	}

	private static int goGXtceuI(IntPtr P_0)
	{
		if (m_InterpreterIssuer == null)
		{
			m_InterpreterIssuer = (CallbackIssuer)Marshal.GetDelegateForFunctionPointer(FHUnODZTn(tmL0uXbJ0(), "Close ".Trim() + "Handle"), typeof(CallbackIssuer));
		}
		return m_InterpreterIssuer(P_0);
	}

	[SpecialName]
	private static IntPtr tmL0uXbJ0()
	{
		if (_SingletonIssuer == IntPtr.Zero)
		{
			_SingletonIssuer = lWSg6nv0c("kernel ".Trim() + "32.dll");
		}
		return _SingletonIssuer;
	}

	private static byte[] bumswtOOs(string P_0)
	{
		using FileStream fileStream = new FileStream(P_0, FileMode.Open, FileAccess.Read, FileShare.Read);
		int num = 0;
		int num2 = (int)fileStream.Length;
		byte[] array = new byte[num2];
		while (num2 > 0)
		{
			int num3 = fileStream.Read(array, num, num2);
			num += num3;
			num2 -= num3;
		}
		return array;
	}

	internal static Stream U8vtSKVpf()
	{
		return new MemoryStream();
	}

	internal static byte[] JFu9RUCVx(Stream P_0)
	{
		return ((MemoryStream)P_0).ToArray();
	}

	private static byte[] RvVMbHk5g(byte[] P_0)
	{
		Stream stream = U8vtSKVpf();
		SymmetricAlgorithm symmetricAlgorithm = dCmdi4ZMp();
		symmetricAlgorithm.Key = new byte[32]
		{
			226, 248, 235, 250, 180, 211, 13, 26, 169, 50,
			218, 9, 199, 18, 19, 236, 200, 220, 20, 66,
			124, 78, 172, 159, 185, 213, 16, 62, 220, 7,
			127, 50
		};
		symmetricAlgorithm.IV = new byte[16]
		{
			55, 37, 118, 252, 125, 158, 241, 60, 72, 120,
			230, 194, 251, 46, 6, 52
		};
		CryptoStream cryptoStream = new CryptoStream(stream, symmetricAlgorithm.CreateDecryptor(), CryptoStreamMode.Write);
		cryptoStream.Write(P_0, 0, P_0.Length);
		cryptoStream.Close();
		return JFu9RUCVx(stream);
	}

	private unsafe static int YmkakldoB(string P_0)
	{
		fixed (char* ptr = P_0)
		{
			int num = 5381;
			int num2 = num;
			char* ptr2 = ptr;
			int num3;
			while ((num3 = *ptr2) != 0)
			{
				num = ((num << 5) + num) ^ num3;
				num3 = ptr2[1];
				if (num3 == 0)
				{
					break;
				}
				num2 = ((num2 << 5) + num2) ^ num3;
				ptr2 += 2;
			}
			return num + num2 * 1566083941;
		}
	}

	internal static bool tsH3Tnnh0(string P_0, string P_1)
	{
		if (P_0 == P_1)
		{
			return true;
		}
		if (P_0 == null || P_1 == null)
		{
			return false;
		}
		bool flag = false;
		bool flag2 = false;
		int num = 0;
		int num2 = 0;
		if (P_0.StartsWith(_IssuerIssuer))
		{
			flag = true;
			num = (int)(P_0[4] | ((uint)P_0[5] << 8) | ((uint)P_0[6] << 16) | ((uint)P_0[7] << 24));
		}
		if (P_1.StartsWith(_IssuerIssuer))
		{
			flag2 = true;
			num2 = (int)(P_1[4] | ((uint)P_1[5] << 8) | ((uint)P_1[6] << 16) | ((uint)P_1[7] << 24));
		}
		if (!flag && !flag2)
		{
			return false;
		}
		if (!flag)
		{
			num = YmkakldoB(P_0);
		}
		if (!flag2)
		{
			num2 = YmkakldoB(P_1);
		}
		return num == num2;
	}

	private byte[] uGYoMfF6u()
	{
		return null;
	}

	private byte[] j8oVGIlNA()
	{
		return null;
	}

	private byte[] YxaSqBxxb()
	{
		_ = "{11111-22222-20001-00001}".Length;
		_ = 0;
		return new byte[2] { 1, 2 };
	}

	private byte[] GSO1X8FWg()
	{
		_ = "{11111-22222-20001-00002}".Length;
		_ = 0;
		return new byte[2] { 1, 2 };
	}

	private byte[] NvSELv1R8()
	{
		_ = "{11111-22222-30001-00001}".Length;
		_ = 0;
		return new byte[2] { 1, 2 };
	}

	private byte[] yILiQXMRJ()
	{
		_ = "{11111-22222-30001-00002}".Length;
		_ = 0;
		return new byte[2] { 1, 2 };
	}

	internal byte[] qLMwH3BbE()
	{
		_ = "{11111-22222-40001-00001}".Length;
		_ = 0;
		return new byte[2] { 1, 2 };
	}

	internal byte[] j4YOc7KDf()
	{
		_ = "{11111-22222-40001-00002}".Length;
		_ = 0;
		return new byte[2] { 1, 2 };
	}

	internal byte[] qq3REFGbx()
	{
		_ = "{11111-22222-50001-00001}".Length;
		_ = 0;
		return new byte[2] { 1, 2 };
	}

	internal byte[] RyyqlgOPB()
	{
		_ = "{11111-22222-50001-00002}".Length;
		_ = 0;
		return new byte[2] { 1, 2 };
	}

	internal static bool InvokeExpression()
	{
		return (object)null == null;
	}

	internal static object PublishExpression()
	{
		return null;
	}
}
