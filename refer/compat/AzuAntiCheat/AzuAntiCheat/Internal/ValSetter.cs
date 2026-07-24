namespace AzuAnticheat.Internal;

internal interface ValSetter
{
	void Emit(PageSetter eventInfo, MockInterpreter emitter);

	void Emit(InstanceSetter eventInfo, MockInterpreter emitter);

	void Emit(RecordSetter eventInfo, MockInterpreter emitter);

	void Emit(ParameterSetter eventInfo, MockInterpreter emitter);

	void Emit(StatusSetter eventInfo, MockInterpreter emitter);

	void Emit(AttrSetter eventInfo, MockInterpreter emitter);
}
