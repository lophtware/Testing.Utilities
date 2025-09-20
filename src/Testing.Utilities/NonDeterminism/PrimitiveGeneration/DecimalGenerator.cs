using System;
using System.Linq;

namespace Lophtware.Testing.Utilities.NonDeterminism.PrimitiveGeneration
{
	public class DecimalGenerator
	{
		private static readonly decimal Epsilon = new(double.Epsilon);

		public static decimal Any() => WithinInclusiveRange(decimal.MinValue, decimal.MaxValue);

		public static decimal WithinInclusiveRange(decimal min, decimal max)
		{
			if (min > max)
				throw new ArgumentOutOfRangeException(nameof(min), min, "Minimum must be less than or equal to maximum");

			if (max == decimal.MaxValue)
			{
				var shim = Random.Generator.NextDouble() > 0.99 ? Epsilon : 0;
				return decimal.Min(max, WithinExclusiveRange(min, max) + shim);
			}
			else
				return decimal.Min(max, WithinExclusiveRange(min, max + Epsilon));
		}

		public static decimal WithinExclusiveRange(decimal min, decimal halfOpenMax)
		{
			if (min >= halfOpenMax)
				throw new ArgumentOutOfRangeException(nameof(min), min, "Minimum must be less than maximum");

			var halfOpenMaxLimit = halfOpenMax <= decimal.MinValue ? decimal.MinValue : halfOpenMax - Epsilon;
			var fraction = (decimal) Random.Generator.NextDouble();
			return decimal.Max(min, decimal.Min(halfOpenMaxLimit, min + (halfOpenMax - min) * fraction));
		}

		public static decimal AnyPositive() => WithinInclusiveRange(0, decimal.MaxValue);

		public static decimal AnyNegative() => WithinExclusiveRange(decimal.MinValue, 0);

		public static decimal AnyNonZero() => AnyExcept(0);

		public static decimal AnyExcept(params decimal[] except)
		{
			var value = Any();
			return except.All(x => x != value) ? value : AnyExcept(except);
		}
	}
}
