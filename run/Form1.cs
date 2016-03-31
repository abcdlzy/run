using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GZipHelperLib;
using System.Diagnostics;
using System.Threading;
using GZipHelperLib.Tools;
using System.IO;

namespace run
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

            
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            string readRegCode = FileTools.ReadFiletoString(System.IO.Directory.GetCurrentDirectory() +"\\reg");
            if (readRegCode == null || readRegCode == "")
            {
                this.Hide();
                Form2 f2 = new Form2();
                f2.Show();
            }
            else
            {
                try {
                    HardwareInfo hardwareInfo = new HardwareInfo();
                    string getregcode = readRegCode;
                    string hardDiskID = hardwareInfo.GetCpuID() + "#" + hardwareInfo.GetHostName() + "#" + hardwareInfo.GetMacAddress() + "#" + hardwareInfo.GetHardDiskID();
                    string list = AESTools.Decrypt(getregcode, hardDiskID);
                    string[] reginfo = list.Split('★');
                    authinfo.password = reginfo[0];
                    authinfo.date = Convert.ToDateTime(reginfo[1]);
                    
                    if (authinfo.date <= NTP.GetNetworkTime())
                    {
                        MessageBox.Show("过期了");
                        this.Hide();
                        Form2 f2 = new Form2();
                        f2.Show();
                        return;
                    }
                    authinfo.runpath = reginfo[2];
                }
                catch
                {
                    MessageBox.Show("获取注册信息出错");
                    System.Environment.Exit(0);
                }
               
                    string temp = System.Environment.GetEnvironmentVariable("TEMP");
                    GZip.Decompress(System.IO.Directory.GetCurrentDirectory() + "\\bin", System.IO.Directory.GetCurrentDirectory() + "\\s", authinfo.password, temp + "\\runsystem\\");

                    this.Hide();

                    MonitorProcess monitor_process = new MonitorProcess();
                    monitor_process.Process_Event += new MonitorProcess.Event_Handler(monitor_process.on_Process_Event);
                    monitor_process.Process_Exit += new MonitorProcess.Event_Handler(monitor_process.On_Process_Exit);
                    monitor_process.run();
                
            }

        }
    }

    class MonitorProcess
    {

        bool finished = false;//用于标识进程开启与否
                              //委托的声明
        public delegate void Event_Handler(object sender, EventArgs strEventArg);
        //用委托声明两个事件
        public event Event_Handler Process_Event;
        public event Event_Handler Process_Exit;
        public void run()
        {
            Process.Start(System.Environment.GetEnvironmentVariable("TEMP") + "\\runsystem\\"+authinfo.runpath);
            int flag = 0;
            do
            {
                if (finished == false)
                {
                    //获取系统的所有进程
                    System.Diagnostics.Process[] processes = System.Diagnostics.Process.GetProcesses();
                    for (int i = 0; i < processes.Length; i++)
                    {
                        if (String.Compare(processes[i].ProcessName, Path.GetFileNameWithoutExtension(System.Environment.GetEnvironmentVariable("TEMP") + "\\runsystem\\" + authinfo.runpath), true) == 0)
                        {
                            Process_Event(this, new EventArgs());//产生事件
                            finished = true;
                            break;
                        }
                    }
                }
                if (finished == true)
                {
                    System.Diagnostics.Process[] processes = System.Diagnostics.Process.GetProcesses();
                    for (int i = 0; i < processes.Length; i++)
                    {
                        if (String.Compare(processes[i].ProcessName, Path.GetFileNameWithoutExtension(System.Environment.GetEnvironmentVariable("TEMP") + "\\runsystem\\" + authinfo.runpath), true) == 0)
                        {
                            flag = 1;
                            break;
                        }
                    }
                    if (flag == 0)
                    {
                        Process_Exit(this, new EventArgs());//产生事件
                        finished = false;
                    }
                    else flag = 0;
                }

                Thread.Sleep(1000);

            }
            while (true);


        }
        //进程启动时的处理函数
        public void on_Process_Event(object sender, EventArgs strEventArg)
        {
            Console.WriteLine("已启动！");
            
        }
        //进程结束时的处理函数
        public void On_Process_Exit(object sender, EventArgs strEventArg)
        {
            Console.WriteLine("已退出");
            GZip.cleanDecompressFiles(System.IO.Directory.GetCurrentDirectory() + "\\s", authinfo.password, System.Environment.GetEnvironmentVariable("TEMP") + "\\runsystem\\");

            System.Environment.Exit(0);
        }
    }
}
