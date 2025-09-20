using System.Diagnostics.CodeAnalysis;

namespace Lophtware.Testing.Utilities.BitManipulation;
[SuppressMessage("ReSharper", "UnusedMember.Global", Justification = CodeAnalysisJustification.PublishedApi)]
public static class ByteBitExtensions
{
	public static bool Bit(this byte value, int index) => ((uint) value).Bit(index);

	public static byte Bit(this byte value, int index, bool isSet)
	{
		var mask = 1 << index;
		return isSet
			? (byte) (value | mask)
			: (byte) (value & ~mask);
	}

	public static byte NormalisedBits(this byte value, int firstIndex, int lastIndex) =>
		(byte) ((uint) value).NormalisedBits(firstIndex, lastIndex);

	public static byte Bits(this byte value, int firstIndex, int lastIndex) =>
		(byte) ((uint) value).Bits(firstIndex, lastIndex);
}
