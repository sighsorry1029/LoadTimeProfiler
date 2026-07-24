using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using HarmonyLib;
using UnityEngine;

namespace TimeoutLimit;

public static class CodeMatcherExtensions
{
	public static CodeMatcher GetPosition(this CodeMatcher codeMatcher, out int position)
	{
		position = codeMatcher.Pos;
		return codeMatcher;
	}

	public static CodeMatcher AddLabel(this CodeMatcher codeMatcher, out Label label)
	{
		label = default(Label);
		codeMatcher.AddLabels(new Label[1] { label });
		return codeMatcher;
	}

	public static CodeMatcher GetLabels(this CodeMatcher codeMatcher, out List<Label> label)
	{
		label = codeMatcher.Labels;
		return codeMatcher;
	}

	public static CodeMatcher GetOperand(this CodeMatcher codeMatcher, out object operand)
	{
		operand = codeMatcher.Operand;
		return codeMatcher;
	}

	internal static CodeMatcher Print(this CodeMatcher codeMatcher, string message)
	{
		Debug.Log(message);
		return codeMatcher;
	}

	internal static CodeMatcher Print(this CodeMatcher codeMatcher, int before, int after)
	{
		for (int i = -before; i <= after; i++)
		{
			int num = i;
			int num2 = codeMatcher.Pos + num;
			if (num2 > 0)
			{
				if (num2 >= codeMatcher.Length)
				{
					break;
				}
				try
				{
					CodeInstruction codeInstruction = codeMatcher.InstructionAt(num);
					Debug.Log($"[{num}] " + codeInstruction.ToString());
				}
				catch (Exception ex)
				{
					Debug.Log(ex.Message);
				}
			}
		}
		return codeMatcher;
	}

	public static bool IsVirtCall(this CodeInstruction i, string declaringType, string name)
	{
		return i.opcode == OpCodes.Callvirt && i.operand is MethodInfo methodInfo && methodInfo.DeclaringType?.Name == declaringType && methodInfo.Name == name;
	}
}
