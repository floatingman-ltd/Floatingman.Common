using System.Collections.Immutable;
using Floatingman.Common.Functional.Option;
using Unit = System.ValueTuple;

namespace Floatingman.Common.Functional
{
    using static Functional;

    public static partial class Functional
    {
        public static None None => None.Default;

        public static Option<T> Some<T>(T value)
        {
            return new Some<T>(value);
        }

        public static IEnumerable<T> List<T>(params T[] items)
        {
            return items.ToImmutableList();
        }
    }

    public struct Option<T> where T : notnull
    {
        private readonly bool _isSome;
        private readonly T _value;

        private Option(T value)
        {
            _isSome = true;
            _value = value;
        }

        // converters
        public static implicit operator Option<T>(None _)
        {
            return new Option<T>();
        }

        public static implicit operator Option<T>(Some<T> some)
        {
            return new Option<T>(some.Value);
        }

        public static implicit operator Option<T>(T value)
        {
            return value == null ? None : Some(value);
        }

        public R Match<R>(Func<R> None, Func<T, R> Some)
        {
            return _isSome ? Some(_value) : None();
        }

        public IEnumerable<T> AsEnumerable()
        {
            if (_isSome) yield return _value;
        }
    }

    namespace Option
    {
        public struct None
        {
            internal static readonly None Default = new();
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
        public static Option<R> Bind<T, R>(this Option<T> opt, Func<T, Option<R>> f)
        {
            return opt.Match(
                () => None,
                t => f(t));
        }

        public static IEnumerable<R> Bind<T, R>(this Option<T> opt, Func<T, IEnumerable<R>> f)
        {
            return opt.AsEnumerable().Bind(f);
        }

        public static Option<Unit> ForEach<T>(this Option<T> opt, Action<T> f)
        {
            return Map(opt, f.ToFunc());
        }

        public static Option<R> Map<T, R>(this None _, Func<T, R> f)
        {
            return None;
        }

        public static Option<R> Map<T, R>(this Some<T> some, Func<T, R> f)
        {
            return Some(f(some.Value));
        }

        public static Option<R> Map<T, R>(this Option<T> opt, Func<T, R> f)
        {
            return opt.Match(
                () => None,
                t => Some(f(t)));
        }

        public static Option<T> Where<T>(this Option<T> opt, Func<T, bool> predicate)
        {
            return opt.Match(
                () => None,
                t => predicate(t) ? opt : None);
        }
    }
}