using System;
using System.Diagnostics;

namespace Jotunn;

/// <summary>
///     Helper class for C# Events.
/// </summary>
internal static class EventExtensions
{
	/// <summary>
	///     try/catch the delegate chain so that it doesnt break on the first failing Delegate.
	/// </summary>
	/// <param name="events"></param>
	public static void SafeInvoke(this Action events)
	{
		if (events == null)
		{
			return;
		}
		Delegate[] invocationList = events.GetInvocationList();
		for (int i = 0; i < invocationList.Length; i++)
		{
			Action action = (Action)invocationList[i];
			try
			{
				action();
			}
			catch (Exception ex)
			{
				Logger.LogWarning($"Exception thrown at event {new StackFrame(1).GetMethod().Name} in {action.Method.DeclaringType.Name}.{action.Method.Name}:\n{ex}");
			}
		}
	}

	/// <summary>
	///     try/catch the delegate chain so that it doesnt break on the first failing Delegate.
	/// </summary>
	/// <typeparam name="TArg1"></typeparam>
	/// <param name="events"></param>
	/// <param name="arg1"></param>
	public static void SafeInvoke<TArg1>(this Action<TArg1> events, TArg1 arg1)
	{
		if (events == null)
		{
			return;
		}
		Delegate[] invocationList = events.GetInvocationList();
		for (int i = 0; i < invocationList.Length; i++)
		{
			Action<TArg1> action = (Action<TArg1>)invocationList[i];
			try
			{
				action(arg1);
			}
			catch (Exception ex)
			{
				Logger.LogWarning($"Exception thrown at event {new StackFrame(1).GetMethod().Name} in {action.Method.DeclaringType.Name}.{action.Method.Name}:\n{ex}");
			}
		}
	}

	/// <summary>
	///     try/catch the delegate chain so that it doesnt break on the first failing Delegate.
	/// </summary>
	/// <typeparam name="TArg1"></typeparam>
	/// <typeparam name="TArg2"></typeparam>
	/// <param name="events"></param>
	/// <param name="arg1"></param>
	/// <param name="arg2"></param>
	public static void SafeInvoke<TArg1, TArg2>(this Action<TArg1, TArg2> events, TArg1 arg1, TArg2 arg2)
	{
		if (events == null)
		{
			return;
		}
		Delegate[] invocationList = events.GetInvocationList();
		for (int i = 0; i < invocationList.Length; i++)
		{
			Action<TArg1, TArg2> action = (Action<TArg1, TArg2>)invocationList[i];
			try
			{
				action(arg1, arg2);
			}
			catch (Exception ex)
			{
				Logger.LogWarning($"Exception thrown at event {new StackFrame(1).GetMethod().Name} in {action.Method.DeclaringType.Name}.{action.Method.Name}:\n{ex}");
			}
		}
	}

	/// <summary>
	///     try/catch the delegate chain so that it doesnt break on the first failing Delegate.
	/// </summary>
	/// <typeparam name="TEventArg"></typeparam>
	/// <param name="events"></param>
	/// <param name="sender"></param>
	/// <param name="arg1"></param>
	public static void SafeInvoke<TEventArg>(this EventHandler<TEventArg> events, object sender, TEventArg arg1)
	{
		if (events == null)
		{
			return;
		}
		Delegate[] invocationList = events.GetInvocationList();
		for (int i = 0; i < invocationList.Length; i++)
		{
			EventHandler<TEventArg> eventHandler = (EventHandler<TEventArg>)invocationList[i];
			try
			{
				eventHandler(sender, arg1);
			}
			catch (Exception ex)
			{
				Logger.LogWarning($"Exception thrown at event {new StackFrame(1).GetMethod().Name} in {eventHandler.Method.DeclaringType.Name}.{eventHandler.Method.Name}:\n{ex}");
			}
		}
	}
}
