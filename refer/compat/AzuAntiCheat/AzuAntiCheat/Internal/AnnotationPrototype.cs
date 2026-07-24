using System.Collections.Generic;

namespace AzuAnticheat.Internal;

internal delegate PagePrototype AnnotationPrototype(InstancePrototype typeInspector, OrderPrototype typeResolver, IEnumerable<StatusPrototype> typeConverters, int maximumRecursion);
