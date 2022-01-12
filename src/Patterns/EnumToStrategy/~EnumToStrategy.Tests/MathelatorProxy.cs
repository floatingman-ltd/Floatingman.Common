namespace EnumToStrategy.Tests
{
    using ServiceClass;
    using System.ServiceModel;

    internal class MathelatorProxy : ClientBase<IMathelatorService>, IMathelatorService
    {
        public MathelatorProxy(WSHttpBinding sec, EndpointAddress epa) : base(sec, epa)
        {
        }

        #region Implementation of IMathelatorService

        public int Mathelate(int v1, int v2)
        {
            return base.Channel.Mathelate(v1, v2);
        }

        #endregion Implementation of IMathelatorService
    }
}