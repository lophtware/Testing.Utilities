using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Lophtware.Testing.Utilities.BitManipulation
{
	[SuppressMessage("ReSharper", "UnusedMember.Global", Justification = CodeAnalysisJustification.PublishedApi)]
	public static class ByteEnumerableExtensions
	{
		public static byte Byte(this IEnumerable<byte> bytes, int index)
		{
			return bytes.Skip(index).First();
		}
	}
}
