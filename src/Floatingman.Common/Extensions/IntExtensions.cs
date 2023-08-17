using Floatingman.Common.Functional;
using static Floatingman.Common.Functional.Functional;

namespace Floatingman.Common.Extensions;

public static class IntExtensions
{
    public static Option<int> Parse(string s)
    {
        return int.TryParse(s, out var r) ? Some(r) : None;
    }
}