namespace TheClasses.Reflection
{
    using System;

    public class Raiser : ReflectionBase
    {
        #region Overrides of ReflectionBase

        public override int Mathelate(int i, int i1)
        {
            return (int) Math.Pow(i, i1);
        }

        #endregion Overrides of ReflectionBase
    }
}