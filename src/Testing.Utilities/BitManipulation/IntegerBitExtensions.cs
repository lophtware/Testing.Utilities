using System;

namespace Lophtware.Testing.Utilities.BitManipulation
{
	public static class IntegerBitExtensions
	{
		public static bool Bit(this uint value, int index)
		{
			return (value & (1 << index)) != 0;
		}

		public static uint NormalisedBits(this uint value, int firstIndex, int lastIndex)
		{
			var lsb = Math.Min(firstIndex, lastIndex);
			return value.Bits(firstIndex, lastIndex) >> lsb;
		}

		public static uint Bits(this uint value, int firstIndex, int lastIndex)
		{
			var msb = Math.Max(firstIndex, lastIndex);
			var lsb = Math.Min(firstIndex, lastIndex);
			var numberOfBits = msb - lsb + 1;
			var mask = (1 << numberOfBits) - 1;
			return (uint) (value & mask << lsb);
		}
	}
}
