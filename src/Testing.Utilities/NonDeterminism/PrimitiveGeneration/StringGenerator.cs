using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Lophtware.Testing.Utilities.NonDeterminism.PrimitiveGeneration
{
	[SuppressMessage("ReSharper", "UnusedMember.Global", Justification = CodeAnalysisJustification.PublishedApi)]
	public static class StringGenerator
	{
		public static string AnyWhitespace()
		{
			return new string(AnyReasonableLength().Select(CharacterGenerator.AnyWhitespace).ToArray());
		}

		private static int AnyReasonableLength()
		{
			return IntegerGenerator.WithinInclusiveRange(1, 10);
		}

		public static string AnyNonNullNonWhitespaceNonEmpty()
		{
			var str = AnyNonNull();
			return !string.IsNullOrWhiteSpace(str) ? str : AnyNonNullNonWhitespaceNonEmpty();
		}

		[SuppressMessage("ReSharper", "MemberCanBePrivate.Global", Justification = CodeAnalysisJustification.PublishedApi)]
		public static string AnyNonNull()
		{
			return new string(AnyReasonableLength().Select(CharacterGenerator.AnyNonSurrogate).ToArray());
		}
	}
}
