using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Security.Permissions;

namespace AzuAnticheat.Internal;

internal static class ResolverInvocation
{
	internal static ResolverInvocation ExcludeProxy;

	public static T ChangeType<T>(object? value)
	{
		return (T)ChangeType(value, typeof(T));
	}

	public static T ChangeType<T>(object? value, IFormatProvider provider)
	{
		return (T)ChangeType(value, typeof(T), provider);
	}

	public static T ChangeType<T>(object? value, CultureInfo culture)
	{
		return (T)ChangeType(value, typeof(T), culture);
	}

	public static object? ChangeType(object? value, Type destinationType)
	{
		return ChangeType(value, destinationType, CultureInfo.InvariantCulture);
	}

	public static object? ChangeType(object? value, Type destinationType, IFormatProvider provider)
	{
		return ChangeType(value, destinationType, new BaseSetter(CultureInfo.CurrentCulture, provider));
	}

	public static object? ChangeType(object? value, Type destinationType, CultureInfo culture)
	{
		if (value == null || InterceptorSetter.IsDbNull(value))
		{
			if (!InterceptorSetter.IsValueType(destinationType))
			{
				return null;
			}
			return Activator.CreateInstance(destinationType);
		}
		Type type = value.GetType();
		if (destinationType == type || destinationType.IsAssignableFrom(type))
		{
			return value;
		}
		if (InterceptorSetter.IsGenericType(destinationType) && destinationType.GetGenericTypeDefinition() == typeof(Nullable<>))
		{
			Type destinationType2 = destinationType.GetGenericArguments()[0];
			object obj = ChangeType(value, destinationType2, culture);
			return Activator.CreateInstance(destinationType, obj);
		}
		if (InterceptorSetter.IsEnum(destinationType))
		{
			if (!(value is string value2))
			{
				return value;
			}
			return Enum.Parse(destinationType, value2, ignoreCase: true);
		}
		if (destinationType == typeof(bool))
		{
			if (DicSingleton.gE3WbyDVW(0x23D015CA ^ 0x23D032D8).Equals(value))
			{
				return false;
			}
			if (DicSingleton.gE3WbyDVW(-1335677307 ^ -1335669637).Equals(value))
			{
				return true;
			}
		}
		TypeConverter converter = TypeDescriptor.GetConverter(type);
		if (converter != null && converter.CanConvertTo(destinationType))
		{
			return converter.ConvertTo(null, culture, value, destinationType);
		}
		TypeConverter converter2 = TypeDescriptor.GetConverter(destinationType);
		if (converter2 != null && converter2.CanConvertFrom(type))
		{
			return converter2.ConvertFrom(null, culture, value);
		}
		Type[] array = new Type[2] { type, destinationType };
		for (int i = 0; i < array.Length; i++)
		{
			foreach (MethodInfo publicStaticMethod2 in InterceptorSetter.GetPublicStaticMethods(array[i]))
			{
				if (!publicStaticMethod2.IsSpecialName || (!(publicStaticMethod2.Name == DicSingleton.gE3WbyDVW(-1180565667 ^ -1180591015)) && !(publicStaticMethod2.Name == DicSingleton.gE3WbyDVW(0xB026CF2 ^ 0xB020FEC))) || !destinationType.IsAssignableFrom(publicStaticMethod2.ReturnParameter.ParameterType))
				{
					continue;
				}
				ParameterInfo[] parameters = publicStaticMethod2.GetParameters();
				if (parameters.Length != 1 || !parameters[0].ParameterType.IsAssignableFrom(type))
				{
					continue;
				}
				try
				{
					return publicStaticMethod2.Invoke(null, new object[1] { value });
				}
				catch (TargetInvocationException ex)
				{
					throw InterceptorSetter.Unwrap(ex);
				}
			}
		}
		if (type == typeof(string))
		{
			try
			{
				MethodInfo publicStaticMethod = InterceptorSetter.GetPublicStaticMethod(destinationType, DicSingleton.gE3WbyDVW(-1398029315 ^ -1398038331), typeof(string), typeof(IFormatProvider));
				if (publicStaticMethod != null)
				{
					return publicStaticMethod.Invoke(null, new object[2] { value, culture });
				}
				publicStaticMethod = InterceptorSetter.GetPublicStaticMethod(destinationType, DicSingleton.gE3WbyDVW(-1891833728 ^ -1891857480), typeof(string));
				if (publicStaticMethod != null)
				{
					return publicStaticMethod.Invoke(null, new object[1] { value });
				}
			}
			catch (TargetInvocationException ex2)
			{
				throw InterceptorSetter.Unwrap(ex2);
			}
		}
		if (destinationType == typeof(TimeSpan))
		{
			return TimeSpan.Parse((string)ChangeType(value, typeof(string), CultureInfo.InvariantCulture));
		}
		return Convert.ChangeType(value, destinationType, CultureInfo.InvariantCulture);
	}

	[PermissionSet(SecurityAction.LinkDemand, Name = "FullTrust")]
	public static void RegisterTypeConverter<TConvertible, TConverter>() where TConverter : TypeConverter
	{
		if (!TypeDescriptor.GetAttributes(typeof(TConvertible)).OfType<TypeConverterAttribute>().Any((TypeConverterAttribute a) => a.ConverterTypeName == typeof(TConverter).AssemblyQualifiedName))
		{
			TypeDescriptor.AddAttributes(typeof(TConvertible), new TypeConverterAttribute(typeof(TConverter)));
		}
	}

	internal static bool InterruptProxy()
	{
		return ExcludeProxy == null;
	}

	internal static ResolverInvocation DeleteProxy()
	{
		return ExcludeProxy;
	}
}
