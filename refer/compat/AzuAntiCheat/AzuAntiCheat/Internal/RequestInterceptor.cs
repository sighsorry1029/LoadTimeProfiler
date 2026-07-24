using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

internal sealed class RequestInterceptor : IDisposable
{
	[_003C877df971_002D5efe_002D4ba8_002D9ac5_002D6779bfedd869_003ENullable(1)]
	private readonly IDictionary<Type, object> _ParamInterceptor;

	internal static RequestInterceptor CallUtils;

	[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
	public T Get<T>() where T : class, new()
	{
		if (!_ParamInterceptor.TryGetValue(typeof(T), out var value))
		{
			value = new T();
			_ParamInterceptor.Add(typeof(T), value);
		}
		return (T)value;
	}

	public void OnDeserialization()
	{
		foreach (UtilsInterceptor item in _ParamInterceptor.Values.OfType<UtilsInterceptor>())
		{
			item.OnDeserialization();
		}
	}

	public void Dispose()
	{
		foreach (IDisposable item in _ParamInterceptor.Values.OfType<IDisposable>())
		{
			item.Dispose();
		}
	}

	public RequestInterceptor()
	{
		GetterIssuer.DeleteInitializer();
		_ParamInterceptor = new Dictionary<Type, object>();
		base._002Ector();
		int num = 0;
		if (_003CModule_003E_007Bb2a70179_002D5de1_002D47fc_002D9d3b_002De343ff0d1452_007D.m_4ffd0bf5b4034c69ae0f41bda16a446b != 0)
		{
			num = 0;
		}
		switch (num)
		{
		case 0:
			break;
		}
	}

	internal static bool ConcatUtils()
	{
		return CallUtils == null;
	}

	internal static RequestInterceptor MapUtils()
	{
		return CallUtils;
	}
}
