using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Reflection;

namespace Lophtware.Testing.Utilities
{
	[SuppressMessage("ReSharper", "UnusedMember.Global", Justification = CodeAnalysisJustification.PublishedApi)]
	public static class Info
	{
		public static MethodInfo OfMethod<TSubject, TValue>(Expression<Func<TSubject, TValue>> call)
		{
			return MethodInfo(call.Body);
		}

		private static MethodInfo MethodInfo(Expression call)
		{
			return ((MethodCallExpression) call).Method;
		}

		public static MethodInfo OfMethod<TValue>(Expression<Func<TValue>> call)
		{
			return MethodInfo(call.Body);
		}

		public static MethodInfo OfMethod<TSubject>(Expression<Action<TSubject>> call)
		{
			return MethodInfo(call.Body);
		}

		public static MethodInfo OfMethod(Expression<Action> call)
		{
			return MethodInfo(call.Body);
		}

		public static PropertyInfo OfProperty<TSubject, TValue>(Expression<Func<TSubject, TValue>> accessor)
		{
			return PropertyInfo(accessor.Body);
		}

		private static PropertyInfo PropertyInfo(Expression accessor)
		{
			return (PropertyInfo) ((MemberExpression) accessor).Member;
		}

		public static ConstructorInfo OfConstructor<TSubject>(Expression<Func<TSubject>> constructor)
		{
			return ConstructorInfo(constructor.Body);
		}

		private static ConstructorInfo ConstructorInfo(Expression constructor)
		{
			return ((NewExpression) constructor).Constructor;
		}
	}
}
