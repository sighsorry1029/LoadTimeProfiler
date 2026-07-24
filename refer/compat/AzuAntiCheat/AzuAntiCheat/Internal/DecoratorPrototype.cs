using System.Runtime.CompilerServices;

namespace AzuAnticheat.Internal;

[_003C689ea8ea_002D77d7_002D4013_002Dbfe3_002D548ebef69eb9_003ENullableContext(1)]
internal interface DecoratorPrototype
{
	void Emit(IdentifierPrototype eventInfo, ModelReader emitter);

	void Emit(IndexerPrototype eventInfo, ModelReader emitter);

	void Emit(WatcherPrototype eventInfo, ModelReader emitter);

	void Emit(ResolverPrototype eventInfo, ModelReader emitter);

	void Emit(CandidatePrototype eventInfo, ModelReader emitter);

	void Emit(RegistryPrototype eventInfo, ModelReader emitter);
}
