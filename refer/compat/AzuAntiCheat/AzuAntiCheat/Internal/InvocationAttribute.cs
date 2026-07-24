using System;
using System.Collections.Generic;

namespace AzuAnticheat.Internal;

internal interface InvocationAttribute
{
	void AddTypeDiscriminator(ComposerAttribute discriminator);

	void AddKeyValueTypeDiscriminator<T>(string discriminatorKey, IDictionary<string, Type> valueTypeMapping);

	void AddUniqueKeyTypeDiscriminator<T>(IDictionary<string, Type> uniqueKeyTypeMapping);
}
