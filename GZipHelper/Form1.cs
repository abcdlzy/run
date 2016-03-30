using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using GZipHelperLib;
using System.Windows.Forms;

namespace GZipHelper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBuild_Click(object sender, EventArgs e)
        {
            GZip.Compress(tbPacketDir.Text, tbPassword.Text, tbSaveLoc.Text);
        }

        private void btnChooseDir_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                tbPacketDir.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnRunExe_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                tbChooseRunExe.Text = openFileDialog1.FileName;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                tbSaveLoc.Text = saveFileDialog1.FileName;
            }
        }
    }
}
