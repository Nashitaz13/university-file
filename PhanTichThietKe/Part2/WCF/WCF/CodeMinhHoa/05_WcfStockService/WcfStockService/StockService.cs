using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Runtime.Serialization;
using System.Configuration;
using System.Threading;

namespace WcfStockService
{
    [ServiceContract(CallbackContract = typeof(IClientCallback))]
    public interface IStockService
    {
        [OperationContract(IsOneWay = true)]
        void RegisterForUpdates(string ticker);
    }

    public interface IClientCallback
    {
        [OperationContract(IsOneWay = true)]
        void PriceUpdate(string ticker, double price);
    }

    public class StockService : IStockService
    {
        public void RegisterForUpdates(string ticker)
        {
            // This is NOT a good notification algorithm as it’s creating 
            // one thread per client.  It should be inverted so it’s creating 
            // one thread per ticker instead.
            Update bgWorker = new Update();
            bgWorker.callback = OperationContext.Current.GetCallbackChannel<IClientCallback>();
            Thread t = new Thread(new ThreadStart(bgWorker.SendUpdateToClient));
            t.IsBackground = true;
            t.Start();
        }
    }

    public class Update
    {
        public IClientCallback callback = null;
        public void SendUpdateToClient()
        {
            Random w = new Random();
            Random p = new Random();
            for (int i=0;i<10;i++)
            {
                Thread.Sleep(w.Next(5000)); // assume updates from somewhere
                try
                {
                    callback.PriceUpdate("msft", 100.00+p.NextDouble()*10);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error sending cache to client: {0}",ex.Message);
                }
            }
        }
    }
}