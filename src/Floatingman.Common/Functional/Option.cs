using System;
using Unit = System.ValueTuple;
namespace Floatingman.Common.Functional
{
    using static Functional;

    public static partial class Functional
    {
        public static Option<T> Some<T>(T value) => new Option.Some<T>(value);
        public static Option.None None => Option.None.Default;
    }

    public struct Option<T>
     where T : notnull
    {
        readonly bool isSome;
        readonly T value;

        private Option(T value)
        {
            isSome = true;
            this.value = value;
        }

        // converters
        public static implicit operator Option<T>(Option.None _) => new Option<T>();
        public static implicit operator Option<T>(Option.Some<T> some) => new Option<T>(some.Value);

        public static implicit operator Option<T>(T value) => value == null ? None : Some(value);

        public R Match<R>(Func<R> None, Func<T, R> Some) => isSome ? Some(value) : None();
    }

    namespace Option
    {
        public struct None
        {
            internal static readonly None Default = new None();
        }

        public struct Some<T> where T : notnull
        {
            internal T Value { get; }

            internal Some(T value)
            {
                Value = value;
            }
        }
    }

    public static class OptionExtensions
    {
        public static Option<R> Map<T, R>(this Option.None _, Func<T, R> f) => None;

        public static Option<R> Map<T, R>(this Option.Some<T> some, Func<T, R> f) => Some(f(some.Value));

        public static Option<R> Map<T, R>
            (this Option<T> option, Func<T, R> f)
            => option.Match(
                () => None,
                (t) => Some(f(t)));

        public static Option<R> Bind<T, R>
            (this Option<T> option, Func<T, Option<R>> f)
            => option.Match(
                () => None,
                (t) => f(t));
    }

}