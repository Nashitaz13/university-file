using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;

namespace Sound
{
    public partial class Sound : Form
    {
        private SoundPlayer player = new SoundPlayer();        

        public Sound()
        {
            InitializeComponent();
            PlayBtn.Enabled = false;
            StopBtn.Enabled = false;
        }

        private void OpenBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog opnDlg = new OpenFileDialog();
            opnDlg.Filter = "WAV files (*.wav)|*.wav";

            if (opnDlg.ShowDialog() == DialogResult.OK)
            {   
                try
                {
                    player.Stop();
                    player.SoundLocation = opnDlg.FileName;

                    PlayBtn.Enabled = true;
                    StopBtn.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }     
        }

        private void PlayBtn_Click(object sender, EventArgs e)
        {   
            player.PlayLooping();

            PlayBtn.Enabled = false;
            StopBtn.Enabled = true;
        }

        private void StopBtn_Click(object sender, EventArgs e)
        {
            player.Stop();

            PlayBtn.Enabled = true;
            StopBtn.Enabled = false;
        }
    }
}
