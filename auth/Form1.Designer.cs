namespace auth
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbpassword = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.btnmake = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tbChooseRunExe = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbMachineCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbregcode = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "密码";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 184);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "有效期";
            // 
            // tbpassword
            // 
            this.tbpassword.Location = new System.Drawing.Point(27, 142);
            this.tbpassword.Name = "tbpassword";
            this.tbpassword.Size = new System.Drawing.Size(478, 21);
            this.tbpassword.TabIndex = 2;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(29, 199);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(476, 21);
            this.dateTimePicker1.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(27, 235);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "选择目录";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnmake
            // 
            this.btnmake.Location = new System.Drawing.Point(149, 325);
            this.btnmake.Name = "btnmake";
            this.btnmake.Size = new System.Drawing.Size(240, 36);
            this.btnmake.TabIndex = 7;
            this.btnmake.Text = "生成";
            this.btnmake.UseVisualStyleBackColor = true;
            this.btnmake.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 272);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "需要启动的应用程序";
            // 
            // tbChooseRunExe
            // 
            this.tbChooseRunExe.Location = new System.Drawing.Point(27, 287);
            this.tbChooseRunExe.Name = "tbChooseRunExe";
            this.tbChooseRunExe.Size = new System.Drawing.Size(478, 21);
            this.tbChooseRunExe.TabIndex = 8;
            this.tbChooseRunExe.Text = "pobo5\\system\\pobo.exe";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "机器识别码";
            // 
            // tbMachineCode
            // 
            this.tbMachineCode.Location = new System.Drawing.Point(27, 34);
            this.tbMachineCode.Multiline = true;
            this.tbMachineCode.Name = "tbMachineCode";
            this.tbMachineCode.Size = new System.Drawing.Size(478, 59);
            this.tbMachineCode.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 365);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "注册码";
            // 
            // tbregcode
            // 
            this.tbregcode.Location = new System.Drawing.Point(27, 394);
            this.tbregcode.Multiline = true;
            this.tbregcode.Name = "tbregcode";
            this.tbregcode.Size = new System.Drawing.Size(478, 72);
            this.tbregcode.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 515);
            this.Controls.Add(this.tbregcode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbMachineCode);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbChooseRunExe);
            this.Controls.Add(this.btnmake);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.tbpassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbpassword;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnmake;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbChooseRunExe;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbMachineCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbregcode;
    }
}

