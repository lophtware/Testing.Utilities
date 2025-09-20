using System.Collections.Generic;
using System.Linq;

namespace Lophtware.Testing.Utilities.NonDeterminism;

public static class EnumerableAnyItemExtensions
{
	public static T AnyItem<T>(this IEnumerable<T> items) => items.Shuffle().First();
}
