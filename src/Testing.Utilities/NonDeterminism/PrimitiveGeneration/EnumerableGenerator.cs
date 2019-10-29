using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Lophtware.Testing.Utilities.NonDeterminism.PrimitiveGeneration
{
	[SuppressMessage("ReSharper", "UnusedMember.Global", Justification = CodeAnalysisJustification.PublishedApi)]
	public static class EnumerableGenerator
	{
		[SuppressMessage("ReSharper", "IteratorNeverReturns", Justification = CodeAnalysisJustification.ByDesign)]
		public static IEnumerable<T> Perpetual<T>(Func<T> createItem)
		{
			while (true)
				yield return createItem();
		}

		public static IEnumerable<T> AtLeastOneOf<T>(Func<T> createItem)
		{
			var numberOfItems = IntegerGenerator.WithinInclusiveRange(1, 10);
			return numberOfItems.Select(createItem);
		}

		public static IEnumerable<T> AnyNumberOf<T>(Func<T> createItem)
		{
			var numberOfItems = IntegerGenerator.WithinInclusiveRange(0, 10);
			return numberOfItems.Select(createItem);
		}
	}
}
