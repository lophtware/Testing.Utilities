using System;

namespace Lophtware.Testing.Utilities.NonDeterminism.PrimitiveGeneration;

public static class Random
{
	public static System.Random Generator => instance ??= new();

	[ThreadStatic]
	private static System.Random instance;
}
