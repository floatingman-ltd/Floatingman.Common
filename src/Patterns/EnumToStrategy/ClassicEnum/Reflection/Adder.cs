namespace TheClasses.Reflection
{
    public class Adder : ReflectionBase
    {
        #region Implementation of IReflectionBase

        public override int Mathelate(int i, int i1)
        {
            return i + i1;
        }

        #endregion Implementation of IReflectionBase
    }
}