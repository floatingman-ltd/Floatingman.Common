// https://www.enterprise-software-development.eu/posts/2019/11/19/option-type.html

using System;

namespace Floatingman.Common.Functional
{

  public static class OptionExtensions
  {
    public static U Match<T, U>(this Option<T> option,
        Func<T, U> onIsSome, Func<U> onIsNone) where T : notnull =>
            option.IsSome(out var value) ? onIsSome(value) : onIsNone();

    public static Option<U> Bind<T, U>(this Option<T> option, Func<T, Option<U>> binder)
        where T : notnull where U : notnull =>
            option.Match(
                onIsSome: binder,
                onIsNone: () => Option<U>.None);

    public static Option<U> Map<T, U>(this Option<T> option, Func<T, U> mapper)
        where T : notnull where U : notnull =>
            option.Bind(
                value => Option<U>.Some(mapper(value)));

    public static Option<T> Filter<T>(this Option<T> option, Predicate<T> predicate)
        where T : notnull =>
            option.Bind(
                value => predicate(value) ? option : Option<T>.None);

    public static T DefaultValue<T>(this Option<T> option, T defaultValue)
        where T : notnull =>
            option.Match(
                onIsSome: value => value,
                onIsNone: () => defaultValue);
  }
}