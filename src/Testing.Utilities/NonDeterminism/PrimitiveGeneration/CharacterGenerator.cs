using System.Collections.Generic;
using System.Linq;

namespace Lophtware.Testing.Utilities.NonDeterminism.PrimitiveGeneration
{
	public static class CharacterGenerator
	{
		public static char AnyWhitespace()
		{
			return PerpetualNonSurrogate().First(char.IsWhiteSpace);
		}

		private static IEnumerable<char> PerpetualNonSurrogate()
		{
			return EnumerableGenerator.Perpetual(AnyNonSurrogate);
		}

		public static char AnyNonSurrogate()
		{
			return PerpetualAny().First(ch => !char.IsSurrogate(ch));
		}

		private static IEnumerable<char> PerpetualAny()
		{
			return EnumerableGenerator.Perpetual(Any);
		}

		private static char Any()
		{
			return (char) IntegerGenerator.WithinInclusiveRange(char.MinValue, char.MaxValue);
		}
	}
}
