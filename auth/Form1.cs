using GZipHelperLib.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;

using System.Windows.Forms;

namespace auth
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string recStr=AESTools.Decrypt(tbMachineCode.Text, "afsdfaserfwegdvdcxzc123123e2efasf!@#!@#$@#$521");
            string regcode = AESTools.Encrypt(tbpassword.Text+ "★"+ dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss") + "★" +tbChooseRunExe.Text, recStr);
            tbregcode.Text = regcode;
        }
    }
}
