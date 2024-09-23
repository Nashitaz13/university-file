using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Sound_2
{
    public partial class Form1 : Form
    {   
        [DllImport("winmm.dll")]
        private static extern int mciSendString(string strCommand, StringBuilder strReturn, int iReturnLength, IntPtr hwndCallback);

        private bool fileOpenning = false;        
        private bool isScrolling = false;        
        private string command;
        private string fileName;
        private StringBuilder sbf = new StringBuilder();
        private Timer timer;
        

        public Form1()
        {
            InitializeComponent();
            PlayBtn.Enabled = false;
            StopBtn.Enabled = false;
            PauseBtn.Enabled = false;

            timer = new Timer();
            timer.Enabled = true;
            timer.Tick +=new EventHandler(timer_Tick);
            timer.Stop();

        }

        public void timer_Tick(object sender, EventArgs e)
        {
            if (!isScrolling)
                trackBar.Value = CurrentMilisecond;
        }

        public string GetStatus()
        {   
            mciSendString("status MediaFile mode", sbf, sbf.Capacity, IntPtr.Zero);
            return sbf.ToString();
        }

        public int GetLength()
        {               
            mciSendString("status MediaFile length", sbf, sbf.Capacity, IntPtr.Zero);
            try
            {
                return (int)Math.Floor(Convert.ToDouble(sbf.ToString().Trim()));
            }
            catch 
            { 
                return 0; 
            }            
        }

        public int CurrentMilisecond
        {
            get
            {
                mciSendString("status MediaFile position", sbf, sbf.Capacity, IntPtr.Zero);
                try
                {
                    return (int)Math.Floor(Convert.ToDouble(sbf.ToString().Trim()));
                }
                catch 
                { 
                    return 0; 
                }
            }
            set
            {
                Seek(value);
            }
        }

        public void Seek(int miliseconds)
        {
            if (GetStatus().Equals("playing", StringComparison.OrdinalIgnoreCase))
            {
                command = "play MediaFile from " + miliseconds;
                mciSendString(command, null, 0, IntPtr.Zero);
            }
            else
            {
                command = "seek MediaFile to " + miliseconds;
                mciSendString(command, null, 0, IntPtr.Zero);
            }
        }

        private void OpenBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Media File(*.mpg,*.dat,*.avi,*.wmv,*.wav,*.mp3)|*.wav;*.mp3;*.mpg;*.dat;*.avi;*.wmv";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK);            
            {
                if (GetStatus().Equals("playing", StringComparison.OrdinalIgnoreCase))
                {
                    command = "close MediaFile";
                    mciSendString(command, null, 0, IntPtr.Zero);
                }

                fileName = dialog.FileName;
                fileOpenning = true;

                StopBtn.Enabled = false;
                PauseBtn.Enabled = false;
                PlayBtn.Enabled = true;  
            }
        }

        private void PlayBtn_Click(object sender, EventArgs e)
        {
            if (fileOpenning)
            {
                command = "open \"" + fileName + "\" type mpegvideo alias MediaFile style child parent " + picBox.Handle.ToInt32();
                mciSendString(command, null, 0, IntPtr.Zero);
                command = "put MediaFile window at 0 0 " + picBox.Width + " " + picBox.Height;

                command = "play MediaFile";
                mciSendString(command, null, 0, IntPtr.Zero);

                this.Text = fileName;

                trackBar.Minimum = 0;
                trackBar.Maximum = GetLength();
                timer.Start();

                PlayBtn.Enabled = false;
                PauseBtn.Enabled = true;
                StopBtn.Enabled = true;
            }
            else
            {
                MessageBox.Show("Xin vui lòng chọn một file audio/video");
            }
        }

        private void StopBtn_Click(object sender, EventArgs e)
        {
            if (fileOpenning)
            {   
                command = "close MediaFile";
                mciSendString(command, null, 0, IntPtr.Zero);

                StopBtn.Enabled = false;
                PauseBtn.Enabled = false;
                PlayBtn.Enabled = true;                
            }
        }

        private void PauseBtn_Click(object sender, EventArgs e)
        {   
            if (fileOpenning)
            {   
                command = "pause MediaFile";
                mciSendString(command, null, 0, IntPtr.Zero);
                
                PauseBtn.Enabled = false;
                StopBtn.Enabled = true;
                PlayBtn.Enabled = true;                
            }
        }

        private void trackBar_MouseDown(object sender, MouseEventArgs e)
        {
            isScrolling = true;
        }

        private void trackBar_MouseUp(object sender, MouseEventArgs e)
        {
            isScrolling = false;
            CurrentMilisecond = trackBar.Value;
        }
    }
}
