using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

using Unit = System.ValueTuple;

namespace Floatingman.Common.Functional
{

    public static class IEnumerableExtensions
    {
        public static IEnumerable<R> Map<T, R>(this IEnumerable<T> l, Func<T, R> f) => l.Select(x => f(x));
        public static IEnumerable<Unit> ForEach<T>(this IEnumerable<T> l, Action<T> f) => l.Map(f.ToFunc()).ToImmutableList();

        public static IEnumerable<R> Bind<T, R>(this IEnumerable<T> l, Func<T, IEnumerable<R>> f)
        {
            foreach (T t in l)
                foreach (R r in f(t))
                    yield return r;
        }

        public static IEnumerable<R> Bind<T, R>(this IEnumerable<T> l, Func<T, Option<R>> f) => l.Bind(t => f(t).AsEnumerable());

    }
}