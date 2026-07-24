using System;

namespace AzuAnticheat.Internal;

internal interface ComposerAttribute
{
	Type BaseType { get; }

	bool TryDiscriminate(CandidateInterpreter buffer, out Type? suggestedType);
}
