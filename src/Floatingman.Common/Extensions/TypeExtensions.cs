namespace Floatingman.Common.Extensions;

public static class TypeExtensions
{
    public static bool IsTypeOf<T>(this Type type)
    {
        return typeof(T).IsAssignableFrom(type);
    }
}