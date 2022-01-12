using System;
using Floatingman.Common.Functional;

using Unit = System.ValueTuple;

using static Floatingman.Common.Functional.Functional;
namespace Floatingman.Common.Usage
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");
            Option_Match();
        }

        static void Option_Match()
        {
            greet(None);
        }

        static string greet(Option<string> greetee) =>
               greetee.Match(
                   None: () => "Who?",
                   Some: (name) => $"Ahh, hello {name}");
    }
}
