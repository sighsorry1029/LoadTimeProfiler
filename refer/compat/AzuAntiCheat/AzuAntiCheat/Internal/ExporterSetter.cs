using System;
using System.IO;

namespace AzuAnticheat.Internal;

internal interface ExporterSetter
{
	T Deserialize<T>(string input);

	T Deserialize<T>(TextReader input);

	T Deserialize<T>(CandidateInterpreter parser);

	object? Deserialize(string input);

	object? Deserialize(TextReader input);

	object? Deserialize(CandidateInterpreter parser);

	object? Deserialize(string input, Type type);

	object? Deserialize(TextReader input, Type type);

	object? Deserialize(CandidateInterpreter parser, Type type);
}
