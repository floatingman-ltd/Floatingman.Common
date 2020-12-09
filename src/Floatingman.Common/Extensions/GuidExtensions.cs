using System;

namespace Floatingman.Common.Extensions
{
    public static class GuidExtensions
    {
        public static bool IsEmpty(this Guid value)
        {
            return value == Guid.Empty;
        }
    }
}