﻿namespace GZipHelper
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
            this.tbPacketDir = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnChooseDir = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnBuild = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.tbSaveLoc = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "需要打包的文件夹";
            // 
            // tbPacketDir
            // 
            this.tbPacketDir.Location = new System.Drawing.Point(25, 47);
            this.tbPacketDir.Name = "tbPacketDir";
            this.tbPacketDir.Size = new System.Drawing.Size(577, 21);
            this.tbPacketDir.TabIndex = 2;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnChooseDir
            // 
            this.btnChooseDir.Location = new System.Drawing.Point(618, 45);
            this.btnChooseDir.Name = "btnChooseDir";
            this.btnChooseDir.Size = new System.Drawing.Size(91, 23);
            this.btnChooseDir.TabIndex = 3;
            this.btnChooseDir.Text = "选择文件夹";
            this.btnChooseDir.UseVisualStyleBackColor = true;
            this.btnChooseDir.Click += new System.EventHandler(this.btnChooseDir_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "生成后保存的位置";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(618, 98);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(91, 23);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "选择位置";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnBuild
            // 
            this.btnBuild.Location = new System.Drawing.Point(250, 317);
            this.btnBuild.Name = "btnBuild";
            this.btnBuild.Size = new System.Drawing.Size(226, 46);
            this.btnBuild.TabIndex = 10;
            this.btnBuild.Text = "build";
            this.btnBuild.UseVisualStyleBackColor = true;
            this.btnBuild.Click += new System.EventHandler(this.btnBuild_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "密码";
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(25, 161);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(577, 21);
            this.tbPassword.TabIndex = 12;
            this.tbPassword.Text = "123456";
            // 
            // tbSaveLoc
            // 
            this.tbSaveLoc.Location = new System.Drawing.Point(25, 98);
            this.tbSaveLoc.Name = "tbSaveLoc";
            this.tbSaveLoc.Size = new System.Drawing.Size(577, 21);
            this.tbSaveLoc.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 386);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnBuild);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tbSaveLoc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnChooseDir);
            this.Controls.Add(this.tbPacketDir);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbPacketDir;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnChooseDir;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnBuild;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.TextBox tbSaveLoc;
    }
}

