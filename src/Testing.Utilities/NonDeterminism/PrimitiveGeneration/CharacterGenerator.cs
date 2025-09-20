using System.Collections.Generic;
using System.Linq;

namespace Lophtware.Testing.Utilities.NonDeterminism.PrimitiveGeneration;

public static class CharacterGenerator
{
	public static char AnyWhitespace() => PerpetualNonSurrogate().First(char.IsWhiteSpace);

	private static IEnumerable<char> PerpetualNonSurrogate() => EnumerableGenerator.Perpetual(AnyNonSurrogate);

	public static char AnyNonSurrogate() => PerpetualAny().First(ch => !char.IsSurrogate(ch));

	private static IEnumerable<char> PerpetualAny() => EnumerableGenerator.Perpetual(Any);

	private static char Any() => (char) IntegerGenerator.WithinInclusiveRange(char.MinValue, char.MaxValue);
}
