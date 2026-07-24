namespace AzuAnticheat.Internal;

internal interface CodeAttribute
{
	void Visit(FacadeAttribute stream);

	void Visit(TemplateAttribute document);

	void Visit(UtilsAttribute scalar);

	void Visit(ParserAttribute sequence);

	void Visit(ResolverAttribute mapping);
}
