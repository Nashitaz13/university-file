using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AsyncMathServer
{
    // NOTE: If you change the interface name "IMathServer" here, you must also update the reference to "IMathServer" in App.config.
    [ServiceContract]
    public interface IMathServer
    {
        [OperationContract]
        int AddSlow(int A, int B);

        [OperationContract]
        int AddFast(int A, int B);
    }
}
