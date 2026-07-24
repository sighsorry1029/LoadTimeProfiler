namespace AzuAnticheat.Internal;

internal delegate TT ProducerSetter<T, TT>(T wrapped) where TT : T;
