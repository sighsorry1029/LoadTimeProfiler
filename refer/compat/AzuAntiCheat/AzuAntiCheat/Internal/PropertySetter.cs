using System.Collections.Generic;

namespace AzuAnticheat.Internal;

internal delegate DatabaseSetter PropertySetter(AdvisorSetter typeInspector, ConnectionSetter typeResolver, IEnumerable<StrategySetter> typeConverters, int maximumRecursion);
