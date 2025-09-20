using System.Diagnostics.CodeAnalysis;

namespace Lophtware.Testing.Utilities.NonDeterminism.PrimitiveGeneration;

[SuppressMessage("ReSharper", "UnusedMember.Global", Justification = CodeAnalysisJustification.PublishedApi)]
public static class StringWhitespaceExtensions
{
	public static string WrapInWhitespace(this string str) =>
		StringGenerator.AnyWhitespace() + str + StringGenerator.AnyWhitespace();
}
