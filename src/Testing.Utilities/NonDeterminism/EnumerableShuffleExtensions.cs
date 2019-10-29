using System.Collections.Generic;
using System.Linq;
using Lophtware.Testing.Utilities.NonDeterminism.PrimitiveGeneration;

namespace Lophtware.Testing.Utilities.NonDeterminism
{
	public static class EnumerableShuffleExtensions
	{
		public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> items)
		{
			return items.OrderBy(_ => IntegerGenerator.Any());
		}
	}
}
