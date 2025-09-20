using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Lophtware.Testing.Utilities.NonDeterminism.PrimitiveGeneration;

[SuppressMessage("ReSharper", "UnusedMember.Global", Justification = CodeAnalysisJustification.PublishedApi)]
public static class EnumGenerator
{
	public static T Any<T>() where T : struct, Enum => EnumFrom<T>(IntegerGenerator.Any());

	private static T EnumFrom<T>(int value) => (T) Enum.ToObject(typeof(T), value);

	public static T AnyUndefined<T>() where T : struct, Enum => AnyExcept(EnumValues<T>().ToArray());

	[SuppressMessage("ReSharper", "MemberCanBePrivate.Global", Justification = CodeAnalysisJustification.PublishedApi)]
	public static T AnyExcept<T>(params T[] except) where T : struct, Enum =>
		EnumFrom<T>(IntegerGenerator.AnyExcept([.. ValuesAsIntegers(except)]));

	private static IEnumerable<int> ValuesAsIntegers<T>(IEnumerable<T> except) where T : struct, Enum =>
		except.Select(x => Convert.ToInt32(x));

	private static IEnumerable<T> EnumValues<T>() where T : struct, Enum => Enum.GetValues(typeof(T)).Cast<T>();

	public static T AnyDefinedExcept<T>(params T[] except) where T : struct, Enum
	{
		var value = AnyDefined<T>();
		return !except.Contains(value) ? value : AnyDefinedExcept(except);
	}

	[SuppressMessage("ReSharper", "MemberCanBePrivate.Global", Justification = CodeAnalysisJustification.PublishedApi)]
	public static T AnyDefined<T>() where T : struct, Enum => EnumValues<T>().AnyItem();
}
