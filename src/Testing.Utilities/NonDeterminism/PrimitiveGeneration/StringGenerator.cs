using System.Diagnostics.CodeAnalysis;

namespace Lophtware.Testing.Utilities.NonDeterminism.PrimitiveGeneration;

[SuppressMessage("ReSharper", "UnusedMember.Global", Justification = CodeAnalysisJustification.PublishedApi)]
public static class StringGenerator
{
	public static string AnyWhitespace() => new([.. AnyReasonableLength().Select(CharacterGenerator.AnyWhitespace)]);

	private static int AnyReasonableLength() => IntegerGenerator.WithinInclusiveRange(1, 10);

	public static string AnyNonNullNonWhitespaceNonEmpty()
	{
		var str = AnyNonNull();
		return !string.IsNullOrWhiteSpace(str) ? str : AnyNonNullNonWhitespaceNonEmpty();
	}

	[SuppressMessage("ReSharper", "MemberCanBePrivate.Global", Justification = CodeAnalysisJustification.PublishedApi)]
	public static string AnyNonNull() => new([.. AnyReasonableLength().Select(CharacterGenerator.AnyNonSurrogate)]);
}
