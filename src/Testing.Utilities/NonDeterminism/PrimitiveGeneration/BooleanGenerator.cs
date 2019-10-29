using System;
using System.Diagnostics.CodeAnalysis;

namespace Lophtware.Testing.Utilities.NonDeterminism.PrimitiveGeneration
{
	[SuppressMessage("ReSharper", "UnusedMember.Global", Justification = CodeAnalysisJustification.PublishedApi)]
	public static class BooleanGenerator
	{
		public static T Either<T>(Func<T> falseValue, Func<T> trueValue)
		{
			return Any() ? trueValue() : falseValue();
		}

		[SuppressMessage("ReSharper", "MemberCanBePrivate.Global", Justification = CodeAnalysisJustification.PublishedApi)]
		public static bool Any()
		{
			return Random.Generator.Next() % 2 == 0;
		}
	}
}
