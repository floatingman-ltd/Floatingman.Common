namespace Floatingman.Common.Functional;

public static class Functions
{
    public static TResult Using<TDisposable, TResult>(TDisposable disposable, Func<TDisposable, TResult> function)
        where TDisposable : IDisposable
    {
        using (disposable)
        {
            return function(disposable);
        }
    }
}