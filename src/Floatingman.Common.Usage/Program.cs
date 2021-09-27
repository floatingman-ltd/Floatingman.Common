using System;

namespace Floatingman.Common.Usage
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");
            Option_Match();
        }

        static void Option_Match(){
            greet(Option<string>.None);
        }

        static string greet(Option<string> greetee) =>
               greetee.Match(
                   None: () => "Who?",
                   Some: (name) => $"Ahh, hello {name}");
    }
}
