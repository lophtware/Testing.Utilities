using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Lophtware.Testing.Utilities.NonDeterminism.PrimitiveGeneration;

[SuppressMessage("ReSharper", "UnusedMember.Global", Justification = CodeAnalysisJustification.PublishedApi)]
public static class ByteGenerator
{
	public static byte AnyExcept(params byte[] except)
	{
		var value = Any();
		return !except.Contains(value) ? value : AnyExcept(except);
	}

	[SuppressMessage("ReSharper", "MemberCanBePrivate.Global", Justification = CodeAnalysisJustification.PublishedApi)]
	public static byte Any() => WithinInclusiveRange(byte.MinValue, byte.MaxValue);

	private static byte WithinInclusiveRange(byte min, byte max) => (byte) Random.Generator.Next(min, max + 1);

	public static byte WithinExclusiveRange(byte min, byte halfOpenMax) => WithinInclusiveRange(min, checked((byte) (halfOpenMax - 1)));
}
