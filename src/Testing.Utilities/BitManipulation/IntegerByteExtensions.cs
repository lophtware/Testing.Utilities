using System.Diagnostics.CodeAnalysis;

namespace Lophtware.Testing.Utilities.BitManipulation;

[SuppressMessage("ReSharper", "UnusedMember.Global", Justification = CodeAnalysisJustification.PublishedApi)]
public static class IntegerByteExtensions
{
	public static byte Byte(this uint value, int index)
	{
		var bitIndex = index * 8;
		var mask = 0xffu << bitIndex;
		return (byte) ((value & mask) >> bitIndex);
	}
}
