namespace AzuAnticheat.Internal;

internal interface MethodInterpreter
{
	bool EndOfInput { get; }

	char Peek(int offset);

	void Skip(int length);
}
