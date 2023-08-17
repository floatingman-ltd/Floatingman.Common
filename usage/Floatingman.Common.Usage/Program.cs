// See https://aka.ms/new-console-template for more information

using Floatingman.Common.Functional;
using Unit = System.ValueTuple;
using static Floatingman.Common.Functional.Functional;

namespace Floatingman.Common.Usage;

internal static class Program
{
    private static void Main(string[] args)
    {
        // Console.WriteLine("Hello World!");
        Option_Match();
    }

    private static void Option_Match()
    {
        greet(None);
    }

    private static string greet(Option<string> greetee)
    {
        return greetee.Match(
            () => "Who?",
            name => $"Ahh, hello {name}");
    }
}