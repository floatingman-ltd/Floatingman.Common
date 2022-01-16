using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

using static Floatingman.Common.Functional.Functional;

using Unit = System.ValueTuple;

namespace Floatingman.Common.Functional
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<R> Bind<T, R>(this IEnumerable<T> l, Func<T, IEnumerable<R>> f)
        {
            foreach (T t in l)
                foreach (R r in f(t))
                    yield return r;
        }

        public static IEnumerable<R> Bind<T, R>(this IEnumerable<T> l, Func<T, Option<R>> f)
            => l.Bind(t => f(t).AsEnumerable());

        public static IEnumerable<Unit> ForEach<T>(this IEnumerable<T> l, Action<T> f)
            => l.Map(f.ToFunc()).ToImmutableList();

        public static Option<T> Head<T>(this IEnumerable<T> l)
        {
            if (l == null) return None;
            var enumerator = l.GetEnumerator();
            return enumerator.MoveNext() ? Some(enumerator.Current) : None;
        }

        public static IEnumerable<R> Map<T, R>(this IEnumerable<T> l, Func<T, R> f)
            => l.Select(x => f(x));

        public static R Match<T, R>(this IEnumerable<T> l, Func<R> Empty, Func<T, IEnumerable<T>, R> Otherwise)
            => l.Head().Match(
                None: Empty,
                Some: head => Otherwise(head, l.Skip(1)));

    }
}