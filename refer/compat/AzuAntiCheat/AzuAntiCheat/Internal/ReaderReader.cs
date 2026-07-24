using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)]
[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
internal static class ReaderReader
{
	private static ReaderReader InterruptAuthentication;

	public static PropertyInfo AsProperty(this LambdaExpression propertyAccessor)
	{
		PropertyInfo propertyInfo = TryGetMemberExpression<PropertyInfo>(propertyAccessor);
		if (propertyInfo == null)
		{
			throw new ArgumentException(DicSingleton.gE3WbyDVW(-359091888 ^ -359086156), DicSingleton.gE3WbyDVW(0x5A1B57A3 ^ 0x5A1B20C1));
		}
		return propertyInfo;
	}

	[return: _003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(2)]
	private static TMemberInfo TryGetMemberExpression<[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(0)] TMemberInfo>(LambdaExpression lambdaExpression) where TMemberInfo : MemberInfo
	{
		if (lambdaExpression.Parameters.Count != 1)
		{
			return null;
		}
		Expression expression = lambdaExpression.Body;
		if (expression is UnaryExpression unaryExpression)
		{
			if (unaryExpression.NodeType != ExpressionType.Convert)
			{
				return null;
			}
			expression = unaryExpression.Operand;
		}
		if (expression is MemberExpression memberExpression)
		{
			if (memberExpression.Expression != lambdaExpression.Parameters[0])
			{
				return null;
			}
			return memberExpression.Member as TMemberInfo;
		}
		return null;
	}

	internal static bool DeleteAuthentication()
	{
		return InterruptAuthentication == null;
	}

	internal static ReaderReader FillAuthentication()
	{
		return InterruptAuthentication;
	}
}
