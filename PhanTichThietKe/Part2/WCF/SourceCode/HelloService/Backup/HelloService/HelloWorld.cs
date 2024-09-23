using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HelloService
{
    // NOTE: If you change the class name "HelloWorld" here, you must also update the reference to "HelloWorld" in App.config.
    public class HelloWorld : IHelloWorld
    {
        #region IHelloWorld Members
        public string SayHello(string inputName)
        {
            return "Chào bạn " + inputName;
        }
        #endregion
    }
}
