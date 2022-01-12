﻿namespace DividerServiceHost
{
    using ServiceClass;
    using System;
    using System.ServiceModel;

    internal class Program
    {
        private static void Main(string[] args)
        {
            Uri httpUrl = new Uri("http://localhost:9001/MathelatorService/Divider");
            ServiceHost host = new ServiceHost(typeof (Divider), httpUrl);
            host.AddServiceEndpoint(typeof (IMathelatorService), new WSHttpBinding(), "");

            host.Open();

            Console.WriteLine("Host is running... Press <Enter> key to stop");
            Console.ReadLine();
        }
    }
}