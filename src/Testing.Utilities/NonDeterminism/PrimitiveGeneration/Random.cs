using System;

namespace Lophtware.Testing.Utilities.NonDeterminism.PrimitiveGeneration
{
	public static class Random
	{
		public static System.Random Generator => instance ?? (instance = new System.Random());

		[ThreadStatic]
		private static System.Random instance;
	}
}
