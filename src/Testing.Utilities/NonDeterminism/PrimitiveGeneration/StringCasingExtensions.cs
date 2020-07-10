using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Lophtware.Testing.Utilities.NonDeterminism.PrimitiveGeneration
{
	[SuppressMessage("ReSharper", "UnusedMember.Global", Justification = CodeAnalysisJustification.PublishedApi)]
	public static class StringCasingExtensions
	{
		public static string AnyCase(this string str)
		{
			return new string(str.Select(ch =>
				BooleanGenerator.Either(
					() => char.ToUpperInvariant(ch),
					() => char.ToLowerInvariant(ch)))
				.ToArray());
		}
	}
}
