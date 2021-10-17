namespace TheClasses.Reflection
{
    public class Divider : ReflectionBase
    {
        #region Implementation of IReflectionBase

        public override int Mathelate(int i, int i1)
        {
            return i/i1;
        }

        #endregion Implementation of IReflectionBase
    }
}