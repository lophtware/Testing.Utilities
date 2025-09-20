using System;
using System.Linq;

namespace Lophtware.Testing.Utilities.NonDeterminism.PrimitiveGeneration;

public class DoubleGenerator
{
	private static readonly double Epsilon = double.Epsilon;

	public static double Any() => WithinInclusiveRange(double.MinValue, double.MaxValue);

	public static double WithinInclusiveRange(double min, double max)
	{
		if (!double.IsFinite(min))
			throw new ArgumentOutOfRangeException(nameof(min), min, "Minimum must be a finite value");

		if (!double.IsFinite(max))
			throw new ArgumentOutOfRangeException(nameof(max), max, "Maximum must be a finite value");

		if (min > max)
			throw new ArgumentOutOfRangeException(nameof(min), min, "Minimum must be less than or equal to maximum");

		if (max >= double.MaxValue)
		{
			var shim = Random.Generator.NextDouble() > 0.99 ? Epsilon : 0;
			return double.Min(max, WithinExclusiveRange(min, max) + shim);
		}
		else
			return double.Min(max, WithinExclusiveRange(min, max + Epsilon));
	}

	public static double WithinExclusiveRange(double min, double halfOpenMax)
	{
		if (min >= halfOpenMax)
			throw new ArgumentOutOfRangeException(nameof(min), min, "Minimum must be less than maximum");

		var halfOpenMaxLimit = halfOpenMax <= double.MinValue ? double.MinValue : halfOpenMax - Epsilon;
		var fraction = Random.Generator.NextDouble();
		return double.Max(min, double.Min(halfOpenMaxLimit, min + (halfOpenMax - min) * fraction));
	}

	public static double AnyPositive() => WithinInclusiveRange(0, double.MaxValue);

	public static double AnyNegative() => WithinExclusiveRange(double.MinValue, 0);

	public static double AnyNonZero() => AnyExceptExact(double.NegativeZero, 0);

	public static double AnyExceptExact(params double[] except)
	{
		var value = Any();
		return except.All(x => x != value) ? value : AnyExceptExact(except);
	}
}
