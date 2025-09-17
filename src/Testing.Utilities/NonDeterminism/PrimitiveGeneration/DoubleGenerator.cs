using System;

namespace Lophtware.Testing.Utilities.NonDeterminism.PrimitiveGeneration
{
    public class DoubleGenerator
    {
        public static double Any()
        {
            return Random.Generator.NextDouble();
        }

        public static double WithinExclusiveRange(double min, double max)
        {
            if (min >= max) throw new ArgumentException("min must be less than max");
            return min + (max - min) * Random.Generator.NextDouble();
        }

        public static double WithinInclusiveRange(double min, double max)
        {
            if (min > max) throw new ArgumentException("min must be less than or equal to max");
            if (double.IsPositiveInfinity(max))
            {
                // fallback if you want to cap to double.MaxValue
                max = double.MaxValue;
            }
            return WithinExclusiveRange(min, BitConverter.Int64BitsToDouble(BitConverter.DoubleToInt64Bits(max) + 1));
        }

        public static double AnyPositive()
        {
            return WithinInclusiveRange(0.0, double.MaxValue);
        }

        public static double AnyNegative()
        {
            return WithinInclusiveRange(double.MinValue, -double.Epsilon);
        }

        public static double NonZero()
        {
            // 50% chance negative, 50% chance positive
            return Random.Generator.Next(2) == 0
                ? AnyNegative()
                : AnyPositive();
        }
    }
}
