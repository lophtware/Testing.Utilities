using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Lophtware.Testing.Utilities.NonDeterminism.PrimitiveGeneration;

[SuppressMessage("ReSharper", "UnusedMember.Global", Justification = CodeAnalysisJustification.PublishedApi)]
public static class ShortGenerator
{
	public static ushort AnyUnsignedExcept(params ushort[] except)
	{
		var value = AnyUnsigned();
		return !except.Contains(value) ? value : AnyUnsignedExcept(except);
	}

	[SuppressMessage("ReSharper", "MemberCanBePrivate.Global", Justification = CodeAnalysisJustification.PublishedApi)]
	public static ushort AnyUnsigned() => UnsignedWithinInclusiveRange(ushort.MinValue, ushort.MaxValue);

	[SuppressMessage("ReSharper", "MemberCanBePrivate.Global", Justification = CodeAnalysisJustification.PublishedApi)]
	public static ushort UnsignedWithinInclusiveRange(ushort min, ushort max) =>
		(ushort) IntegerGenerator.WithinInclusiveRange(min, max);

	public static ushort UnsignedGreaterThan(ushort value) =>
		UnsignedWithinInclusiveRange(checked((ushort) (value + 1)), ushort.MaxValue);

	public static ushort UnsignedGreaterThanOrEqualTo(ushort value) => UnsignedWithinInclusiveRange(value, ushort.MaxValue);

	public static ushort UnsignedLessThan(ushort value) => UnsignedWithinExclusiveRange(ushort.MinValue, value);

	[SuppressMessage("ReSharper", "MemberCanBePrivate.Global", Justification = CodeAnalysisJustification.PublishedApi)]
	public static ushort UnsignedWithinExclusiveRange(ushort min, ushort halfOpenMax) =>
		UnsignedWithinInclusiveRange(min, checked((ushort) (halfOpenMax - 1)));

	public static ushort UnsignedLessThanOrEqualTo(ushort value) => UnsignedWithinInclusiveRange(ushort.MinValue, value);
}
