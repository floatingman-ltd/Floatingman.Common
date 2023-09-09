using Unit = System.ValueTuple;

namespace Floatingman.Common.Functional;

// This allows Unit() to behave as expected.
using static Functional;

public static partial class Functional
{
    public static Unit Unit()
    {
        return default;
    }
}

public static class UnitExtensions
{
    public static Func<Unit> ToFunc(this Action action)
    {
        return () =>
        {
            action();
            return Unit();
        };
    }

    public static Func<T, Unit> ToFunc<T>(this Action<T> action)
    {
        return t =>
        {
            action(t);
            return Unit();
        };
    }
}