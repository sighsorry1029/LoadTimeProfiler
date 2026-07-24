namespace AzuAnticheat.Internal;

internal interface ExpressionInterpreter
{
	TestsInterpreter CurrentPosition { get; }

	SystemSingleton? Current { get; }

	bool MoveNext();

	bool MoveNextWithoutConsuming();

	void ConsumeCurrent();
}
