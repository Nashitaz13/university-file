using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAddAsync_Click(object sender, EventArgs e)
        {
            try
            {
                MathServer.MathServerClient mathClient = new MathServer.MathServerClient();
                lblStatus.Text = "Server is computing, you drag slider!";
                
                mathClient.AddSlowCompleted += new EventHandler<Client.MathServer.AddSlowCompletedEventArgs>(mathClient_AddSlowCompleted);
                mathClient.AddSlowAsync(int.Parse(txtA.Text), int.Parse(txtB.Text));                
                
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        void mathClient_AddSlowCompleted(object sender, Client.MathServer.AddSlowCompletedEventArgs e)
        {
            int result = e.Result;
            txtAdd.Text = result.ToString();
            lblStatus.Text = "";
        }


        private void btnAddSync_Click(object sender, EventArgs e)
        {
            try
            {
                lblStatus.Text = "Server is computing, you cannot drag slider!";
                lblStatus.Update(); //Repaint the label immeadiately

                MathServer.MathServerClient mathClient = new MathServer.MathServerClient();                    
                int result = mathClient.AddFast(int.Parse(txtA.Text), int.Parse(txtB.Text));                                
                txtAdd.Text = result.ToString();
                lblStatus.Text = "";
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        
    }
}
