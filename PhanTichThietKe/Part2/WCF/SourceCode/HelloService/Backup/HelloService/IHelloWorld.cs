using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HelloService
{
    // NOTE: If you change the interface name "IHelloWorld" here, you must also update the reference to "IHelloWorld" in App.config.
    [ServiceContract]
    public interface IHelloWorld
    {
        [OperationContract]
        string SayHello(string inputName);
    }
}
