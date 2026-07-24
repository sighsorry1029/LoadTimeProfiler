namespace AzuAnticheat.Internal;

internal interface RequestSingleton
{
	void Visit(StateSingleton e);

	void Visit(ServerSingleton e);

	void Visit(WrapperSingleton e);

	void Visit(TestsSingleton e);

	void Visit(TaskSingleton e);

	void Visit(BridgeSingleton e);

	void Visit(ExporterSingleton e);

	void Visit(MessageSingleton e);

	void Visit(FacadeSingleton e);

	void Visit(ParamSingleton e);

	void Visit(DecoratorSingleton e);
}
