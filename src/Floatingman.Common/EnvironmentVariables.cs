using System;

namespace Floatingman.Common
{
    public static class EnvironmentVariables
    {
        public static string GetEnvironmentValue(string key)
        {
            return Environment.GetEnvironmentVariable(key, EnvironmentVariableTarget.Process);
        }

        //public static string GetEnvironmentVariable(string name)
        //{
        //    return name + ": " + GetEnvironmentValue(name);
        //}
    }
}