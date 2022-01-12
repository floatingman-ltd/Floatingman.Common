using Unit = System.ValueTuple;
using System;

namespace Floatingman.Common.Functional
{
    // This allows Unit() to behave as expected.
    using static Functional;

    public static partial class Functional
    {
        public static Unit Unit() => default(Unit);
    }

    public static class UnitExtensions
    {
        public static Func<Unit> ToFunc(this Action action) => () => { action(); return Unit(); };
        public static Func<T, Unit> ToFunc<T>(this Action<T> action) => (t) => { action(t); return Unit(); };
    };

}