using System;

namespace Lophtware.Testing.Utilities.NonDeterminism.PrimitiveGeneration
{
    public class DecimalGenerator
    {
        public static decimal Any()
        {
            // produces [0.0, 1.0)
            return (decimal)Random.Generator.NextDouble();
        }

        public static decimal WithinExclusiveRange(decimal min, decimal max)
        {
            if (min >= max) throw new ArgumentException("min must be less than max");

            // generate a decimal in [0,1)
            decimal fraction = (decimal)Random.Generator.NextDouble();
            return min + (max - min) * fraction;
        }

        public static decimal WithinInclusiveRange(decimal min, decimal max)
        {
            if (min > max) throw new ArgumentException("min must be less than or equal to max");
            return WithinExclusiveRange(min, max + (decimal)double.Epsilon);
        }

        public static decimal AnyPositive()
        {
            return WithinInclusiveRange(0m, decimal.MaxValue);
        }

        public static decimal AnyNegative()
        {
            return WithinInclusiveRange(decimal.MinValue, -(decimal)double.Epsilon);
        }

        public static decimal NonZero()
        {
            return Random.Generator.Next(2) == 0
                ? AnyNegative()
                : AnyPositive();
        }
    }
}
