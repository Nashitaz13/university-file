﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BB
{
    public partial class MH_Xem_BaoBieu : Form
    {
        public MH_Xem_BaoBieu()
        {
            InitializeComponent();
        }

        private void MH_Xem_BaoBieu_Load(object sender, EventArgs e)
        {

            this.CRV.RefreshReport();
        }
    }
}