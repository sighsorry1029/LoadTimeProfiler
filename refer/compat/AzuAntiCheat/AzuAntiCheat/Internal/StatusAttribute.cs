using System;
using System.Linq.Expressions;
using System.Reflection;

namespace AzuAnticheat.Internal;

internal static class StatusAttribute
{
	private static StatusAttribute ChangeAttribute;

	public static PropertyInfo AsProperty(this LambdaExpression propertyAccessor)
	{
		PropertyInfo propertyInfo = TryGetMemberExpression<PropertyInfo>(propertyAccessor);
		if (propertyInfo == null)
		{
			throw new ArgumentException(DicSingleton.gE3WbyDVW(-830028630 ^ -830033330), DicSingleton.gE3WbyDVW(--708144185 ^ 0x2A351B5B));
		}
		return propertyInfo;
	}

	[return: RegSingleton]
	private static TMemberInfo TryGetMemberExpression<TMemberInfo>(LambdaExpression lambdaExpression) where TMemberInfo : MemberInfo
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

	internal static bool CreateAttribute()
	{
		return ChangeAttribute == null;
	}

	internal static StatusAttribute RunAttribute()
	{
		return ChangeAttribute;
	}
}
