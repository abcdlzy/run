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
            MessageBox.Show("完成");
        }

        private void btnChooseDir_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                tbPacketDir.Text = folderBrowserDialog1.SelectedPath;
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                tbSaveLoc.Text = folderBrowserDialog1.SelectedPath;
            }
        }
    }
}
