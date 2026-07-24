using System;
using System.Collections.Generic;

namespace AzuAnticheat.Internal;

internal class AuthenticationAttribute : CandidateInterpreter
{
	private readonly LinkedList<ClientSingleton> m_AttributeAttribute;

	private LinkedListNode<ClientSingleton>? interpreterAttribute;

	private static AuthenticationAttribute CancelIssuer;

	public ClientSingleton? Current
	{
		get
		{
			int num = 1;
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 1:
				{
					LinkedListNode<ClientSingleton>? linkedListNode = interpreterAttribute;
					if (linkedListNode == null)
					{
						num2 = 0;
						if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_330a845200124514b4ec15dee3ecefaa != 0)
						{
							num2 = 0;
						}
						break;
					}
					return linkedListNode.Value;
				}
				default:
					return null;
				}
			}
		}
	}

	public AuthenticationAttribute(CandidateInterpreter parserToBuffer, int maxDepth, int maxLength)
	{
		GetterIssuer.DeleteInitializer();
		base._002Ector();
		m_AttributeAttribute = new LinkedList<ClientSingleton>();
		m_AttributeAttribute.AddLast(parserToBuffer.Consume<FacadeSingleton>());
		int num = 0;
		do
		{
			ClientSingleton clientSingleton = parserToBuffer.Consume<ClientSingleton>();
			num += clientSingleton.NestingIncrease;
			m_AttributeAttribute.AddLast(clientSingleton);
			if (maxDepth > -1 && num > maxDepth)
			{
				throw new ArgumentOutOfRangeException(DicSingleton.gE3WbyDVW(-32559551 ^ -32531909), DicSingleton.gE3WbyDVW(0x554A128B ^ 0x554AA611));
			}
			if (maxLength > -1 && m_AttributeAttribute.Count > maxLength)
			{
				throw new ArgumentOutOfRangeException(DicSingleton.gE3WbyDVW(0x7FAAD78F ^ 0x7FAA63F5), DicSingleton.gE3WbyDVW(-1389846755 ^ -1389876285));
			}
		}
		while (num >= 0);
		interpreterAttribute = m_AttributeAttribute.First;
	}

	public bool MoveNext()
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			default:
				return interpreterAttribute != null;
			case 1:
				interpreterAttribute = interpreterAttribute?.Next;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_11cc2605cc5e485bbc16e8fb301f6add == 0)
				{
					num2 = 0;
				}
				break;
			}
		}
	}

	public void Reset()
	{
		int num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			default:
				return;
			case 1:
				interpreterAttribute = m_AttributeAttribute.First;
				num2 = 0;
				if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_91887e48b8104e7da08b48f73b607337 != 0)
				{
					num2 = 0;
				}
				break;
			case 0:
				return;
			}
		}
	}

	internal static bool ReflectIssuer()
	{
		return CancelIssuer == null;
	}

	internal static AuthenticationAttribute CollectIssuer()
	{
		return CancelIssuer;
	}
}
