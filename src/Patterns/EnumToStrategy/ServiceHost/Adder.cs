﻿namespace MathelatorServiceHost
{
    using ServiceClass;

    public class Adder : IMathelatorService
    {
        #region Implementation of IMathelatorService

        public int Mathelate(int v1, int v2)
        {
            return v1 + v2;
        }

        #endregion Implementation of IMathelatorService
    }
}