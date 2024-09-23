using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;

namespace AsyncMathServer
{
    // NOTE: If you change the class name "MathServer" here, you must also update the reference to "MathServer" in App.config.
    public class MathServer : IMathServer
    {

        #region IMathServer Members

        public int AddSlow(int A, int B)
        {
            Thread.Sleep(4000);
            return A + B;
        }

        public int AddFast(int A, int B)
        {
            Thread.Sleep(4000);
            return A + B;
        }
        #endregion
    }
}
