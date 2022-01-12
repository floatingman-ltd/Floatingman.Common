using System;
using System.Diagnostics;
using Floatingman.Common.Functional;

using Unit = System.ValueTuple;

namespace Floatingman.Common.Instrumentation
{
    public static class RunTime
    {
        public static void Of(Action action) => Of<Unit>(action.ToFunc());
        public static T Of<T>(Func<T> f)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            T t = f();
            stopWatch.Stop();
            // this should be replaced with a logging function
            Console.WriteLine($"{nameof(f)} executed in {stopWatch.ElapsedMilliseconds}ms");
            return t;
        }
    }
}