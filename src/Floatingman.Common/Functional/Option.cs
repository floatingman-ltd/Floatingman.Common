using System;
using System.Diagnostics.CodeAnalysis;

namespace Floatingman.Common.Functional
{
    public struct Option<T> where T : notnull
    {
        private readonly bool isSome;
        private readonly T value;

        private Option(T value)
        {
            this.value = value;
            isSome = this.value is { };
        }

        public static Option<T> None => default;

        public static Option<T> Some(T value) => new Option<T>(value);

        public bool IsSome([MaybeNullWhen(false)] out T value)
        {
            value = this.value;
            return isSome;
        }

        public R Match<R>(Func<R> None, Func<T, R> Some)
            => isSome ? Some(value) : None();

    }

    public static class OptionExtensions
    {
        public static Option<R> Bind<T, R>(this Option<T> option, Func<T, Option<R>> f)
            => option.Match(
                () => Option<R>.None,
                (t) => f(t));

        public static Option<R> Map<T, R>(this Option<T> option, Func<T, R> f)
                    => option.Match(
                () => Option<R>.None,
                (t) => Option<R>.Some(f(t)));
    }
}