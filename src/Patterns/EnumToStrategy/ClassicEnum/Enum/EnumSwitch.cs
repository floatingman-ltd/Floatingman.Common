namespace TheClasses.Enum
{
    using System;

    public class EnumSwitch
    {
        public int Mathelate(Activity action, int i, int i1)
        {
            switch (action)
            {
                case Activity.Add:
                    return i + i1;

                case Activity.Divide:
                    return i/i1;

                case Activity.Multiply:
                    return i*i1;

                case Activity.Subtract:
                    return i - i1;

                case Activity.Nothing:
                default:
                    throw new InvalidOperationException("Must do something");
            }
        }
    }
}