using System;
using System.ServiceModel;

namespace Client
{
    // Define class which implemegnts callback interface of duplex contract
    public class CallbackHandler : StockServiceRef.IStockServiceCallback
    {
        static InstanceContext site = new InstanceContext(new CallbackHandler());
        static StockServiceRef.StockServiceClient proxy = new StockServiceRef.StockServiceClient(site);

        //  called from the service
        public void PriceUpdate(string ticker, double price)
        {
            Console.WriteLine("Received alert at : {0}. {1}:{2}", System.DateTime.Now, ticker, price);
        }

        class Program
        {
            static void Main(string[] args)
            {
                string ticker = "MSFT";
                if (args.Length>0)
                    ticker = args[0];
                proxy.RegisterForUpdates(ticker);
                Console.WriteLine("Hit enter then any key to exit");
                Console.ReadLine();
            }
        }
    }
}


