using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClientTestOneWay
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnCallOneWayOperation_Click(object sender, EventArgs e)
        {
            try
            {
                StockService.StockServiceClient stockclient = new StockService.StockServiceClient();
                stockclient.DoBigAnalysisFast("MICROSOFT");
                MessageBox.Show("Done", "Info");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCallNonOneWay_Click(object sender, EventArgs e)
        {
            try
            {
                StockService.StockServiceClient stockclient = new StockService.StockServiceClient();
                stockclient.DoBigAnalysisSlow("YAHOO");
                MessageBox.Show("Done", "Info");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

      
    }
}
