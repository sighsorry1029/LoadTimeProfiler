namespace AzuAnticheat.Internal;

internal interface AdvisorReader
{
	bool EndOfInput { get; }

	char Peek(int offset);

	void Skip(int length);
}
