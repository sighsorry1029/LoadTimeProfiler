using System;

namespace AzuAnticheat.Internal;

[Obsolete("Please use IYamlConvertible instead")]
internal interface PolicySetter
{
	void ReadYaml(CandidateInterpreter parser);

	void WriteYaml(MockInterpreter emitter);
}
