using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameHungTrung
{
    class Program
    {
        static void Main(string[] args)
        {
            HungTrung ht = new HungTrung();
            Application.Run(ht);
            Console.ReadLine();
        }
    }
}
