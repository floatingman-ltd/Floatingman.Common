namespace MathelatorServiceHost
{
    using ServiceClass;
    using System;
    using System.ServiceModel;

    internal class Program
    {
        private static void Main(string[] args)
        {
            Uri httpUrl = new Uri("http://localhost:9001/MathelatorService/");
            ServiceHost host = new ServiceHost(typeof (Adder), httpUrl);
            host.AddServiceEndpoint(typeof (IMathelatorService), new WSHttpBinding(), "Adder");

            host.Open();

            Console.WriteLine("Host is running... Press <Enter> key to stop");
            Console.ReadLine();
        }
    }
}