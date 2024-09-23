using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLCHMT.Report
{
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
            panel.Controls.Clear();
            frmBaoCao uc = new frmBaoCao();
            uc.Dock = System.Windows.Forms.DockStyle.Fill;
            panel.Controls.Add(uc);
        }
    }
}
