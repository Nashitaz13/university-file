using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Configuration;
using System.Threading;
using System.Messaging;

namespace EssentialWCF
{
    [ServiceContract]
    public interface IStockService
    {
        [OperationContract(IsOneWay = true)]
        void DoBigAnalysisFast(string ticker);

        [OperationContract]
        void DoBigAnalysisSlow(string ticker);
    }
    public class StockService : IStockService
    {
        public void DoBigAnalysisFast(string ticker)
        {
            Console.WriteLine("{0}: received {1}", System.DateTime.Now, ticker);
            Thread.Sleep(10000); // to make this function take long time
        }
        public void DoBigAnalysisSlow(string ticker)
        {
            Console.WriteLine("{0}: received {1}", System.DateTime.Now, ticker);
            Thread.Sleep(10000); // to make this function take long time
        }
    }

    public class program
    {
        // Host the service within this EXE console application.
        public static void Main()
        {
            // Create the queue if necessary
            //string queueName = ConfigurationManager.AppSettings["queueName"];
            //if (!MessageQueue.Exists(queueName))
            //    MessageQueue.Create(queueName, true);

            ServiceHost serviceHost = new ServiceHost(typeof(StockService));
            serviceHost.Open();

            Console.WriteLine("Service endpoints:");
            ServiceDescription desc = serviceHost.Description;
            foreach (ServiceEndpoint endpoint in desc.Endpoints)
            {
                Console.WriteLine("Endpoint - address:  {0}", endpoint.Address);
                Console.WriteLine("           binding:  {0}", endpoint.Binding.Name);
                Console.WriteLine("           contract: {0}", endpoint.Contract.Name);
            }

            // The service can now be accessed.
            Console.WriteLine("The service is ready.");
            Console.WriteLine("Press <ENTER> to terminate.\n\n");
            Console.ReadLine();

            // Close the ServiceHostBase to shutdown the service.
            serviceHost.Close();
        }
    }

}
