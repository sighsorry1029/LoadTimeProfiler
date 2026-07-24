using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
internal interface ParamsFilter
{
	void Visit(BaseReader stream);

	void Visit(ListFilter document);

	void Visit(RefFilter scalar);

	void Visit(ProcFilter sequence);

	void Visit(ListenerFilter mapping);
}
