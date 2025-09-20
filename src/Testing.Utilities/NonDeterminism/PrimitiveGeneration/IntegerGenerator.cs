using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Lophtware.Testing.Utilities.NonDeterminism.PrimitiveGeneration;

[SuppressMessage("ReSharper", "UnusedMember.Global", Justification = CodeAnalysisJustification.PublishedApi)]
public static class IntegerGenerator
{
	public static int AnyNegative() => WithinInclusiveRange(int.MinValue, 0);

	public static int WithinInclusiveRange(int min, int max)
	{
		return max == int.MaxValue
			? (int) LongGenerator.WithinInclusiveRange(min, max)
			: WithinExclusiveRange(min, max + 1);
	}

	private static int WithinExclusiveRange(int min, int halfOpenMax) => Random.Generator.Next(min, halfOpenMax);

	public static int AnyPositive() => WithinInclusiveRange(0, int.MaxValue);

	public static int AnyExcept(params int[] except)
	{
		var value = Any();
		return !except.Contains(value) ? value : AnyExcept(except);
	}

	public static int Any() => Random.Generator.Next();

	public static int GreaterThan(int value)
	{
		if (value == int.MaxValue)
			throw new ArgumentOutOfRangeException(nameof(value), value, "Cannot get an integer greater than int.MaxValue");

		return WithinInclusiveRange(value, int.MaxValue);
	}

	public static int LessThan(int value) => WithinExclusiveRange(int.MinValue, value);

	public static uint AnyUnsigned() => AnyUnsignedLessThanOrEqualTo(uint.MaxValue);

	[SuppressMessage("ReSharper", "MemberCanBePrivate.Global", Justification = CodeAnalysisJustification.PublishedApi)]
	public static uint AnyUnsignedLessThanOrEqualTo(uint max) => (uint) LongGenerator.WithinInclusiveRange(uint.MinValue, max);
}
