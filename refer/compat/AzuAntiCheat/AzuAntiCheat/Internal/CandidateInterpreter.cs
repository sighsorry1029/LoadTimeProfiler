namespace AzuAnticheat.Internal;

internal interface CandidateInterpreter
{
	ClientSingleton? Current { get; }

	bool MoveNext();
}
