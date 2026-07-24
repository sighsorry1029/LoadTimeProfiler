using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
internal interface DispatcherFactory
{
	void Visit(TagFactory e);

	void Visit(PublisherSetter e);

	void Visit(RoleSetter e);

	void Visit(DicFactory e);

	void Visit(ProcessorFactory e);

	void Visit(ClassFactory e);

	void Visit(RefFactory e);

	void Visit(SpecificationFactory e);

	void Visit(QueueFactory e);

	void Visit(ListFactory e);

	void Visit(StubFactory e);
}
