namespace AzuAnticheat.Internal;

internal interface DatabaseSetter
{
	void Traverse<TContext>(ImporterSetter graph, ErrorSetter<TContext> visitor, TContext context);
}
