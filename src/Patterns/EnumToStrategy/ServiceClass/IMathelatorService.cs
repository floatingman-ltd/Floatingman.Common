namespace ServiceClass
{
    using System.ServiceModel;

    [ServiceContract()]
    public interface IMathelatorService
    {
        [OperationContract()]
        int Mathelate(int v1, int v2);
    }
}