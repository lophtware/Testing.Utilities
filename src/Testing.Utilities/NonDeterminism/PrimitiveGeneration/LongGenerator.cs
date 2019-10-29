using System.Diagnostics.CodeAnalysis;

namespace Lophtware.Testing.Utilities.NonDeterminism.PrimitiveGeneration
{
	[SuppressMessage("ReSharper", "UnusedMember.Global", Justification = CodeAnalysisJustification.PublishedApi)]
	public static class LongGenerator
	{
		public static long Any()
		{
			return Random.Generator.NextLong();
		}

		public static long WithinInclusiveRange(long min, long max)
		{
			return Random.Generator.NextLong(min, checked(max + 1));
		}
	}
}
