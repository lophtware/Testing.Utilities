using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Lophtware.Testing.Utilities
{
	[SuppressMessage("ReSharper", "UnusedMember.Global", Justification = CodeAnalysisJustification.PublishedApi)]
	public static class IntegerEnumerableExtensions
	{
		public static IEnumerable<T> Select<T>(this int count, Func<T> createItem)
		{
			return count.Select(_ => createItem());
		}

		[SuppressMessage("ReSharper", "MemberCanBePrivate.Global", Justification = CodeAnalysisJustification.PublishedApi)]
		public static IEnumerable<T> Select<T>(this int count, Func<int, T> createItem)
		{
			for (var i = 0; i < count; i++)
				yield return createItem(i);
		}

		public static void Repeat(this int count, Action<int> action)
		{
			for (var i = 0; i < count; i++)
				action(i);
		}
	}
}
