﻿namespace OhmPcApi
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.groupCpu = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblServerStatus = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblServerPort = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblServerIp = new System.Windows.Forms.Label();
            this.chkCpuEnable = new System.Windows.Forms.CheckBox();
            this.chkFrequency = new System.Windows.Forms.CheckBox();
            this.groupCpu.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtbLog
            // 
            this.rtbLog.BackColor = System.Drawing.Color.White;
            this.rtbLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbLog.Location = new System.Drawing.Point(12, 334);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.ReadOnly = true;
            this.rtbLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.rtbLog.Size = new System.Drawing.Size(339, 96);
            this.rtbLog.TabIndex = 0;
            this.rtbLog.Text = "";
            // 
            // groupCpu
            // 
            this.groupCpu.Controls.Add(this.chkFrequency);
            this.groupCpu.Controls.Add(this.chkCpuEnable);
            this.groupCpu.Location = new System.Drawing.Point(12, 55);
            this.groupCpu.Name = "groupCpu";
            this.groupCpu.Size = new System.Drawing.Size(339, 70);
            this.groupCpu.TabIndex = 1;
            this.groupCpu.TabStop = false;
            this.groupCpu.Text = "CPU";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "API Server Status:";
            // 
            // lblServerStatus
            // 
            this.lblServerStatus.AutoSize = true;
            this.lblServerStatus.Location = new System.Drawing.Point(114, 13);
            this.lblServerStatus.Name = "lblServerStatus";
            this.lblServerStatus.Size = new System.Drawing.Size(52, 13);
            this.lblServerStatus.TabIndex = 3;
            this.lblServerStatus.Text = "Initialising";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "API Server Port:";
            // 
            // lblServerPort
            // 
            this.lblServerPort.AutoSize = true;
            this.lblServerPort.Location = new System.Drawing.Point(114, 26);
            this.lblServerPort.Name = "lblServerPort";
            this.lblServerPort.Size = new System.Drawing.Size(13, 13);
            this.lblServerPort.TabIndex = 5;
            this.lblServerPort.Text = "?";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "API Server IP:";
            // 
            // lblServerIp
            // 
            this.lblServerIp.AutoSize = true;
            this.lblServerIp.Location = new System.Drawing.Point(114, 39);
            this.lblServerIp.Name = "lblServerIp";
            this.lblServerIp.Size = new System.Drawing.Size(13, 13);
            this.lblServerIp.TabIndex = 7;
            this.lblServerIp.Text = "?";
            // 
            // chkCpuEnable
            // 
            this.chkCpuEnable.AutoSize = true;
            this.chkCpuEnable.Location = new System.Drawing.Point(15, 19);
            this.chkCpuEnable.Name = "chkCpuEnable";
            this.chkCpuEnable.Size = new System.Drawing.Size(59, 17);
            this.chkCpuEnable.TabIndex = 0;
            this.chkCpuEnable.Text = "Enable";
            this.chkCpuEnable.UseVisualStyleBackColor = true;
            // 
            // chkFrequency
            // 
            this.chkFrequency.AutoSize = true;
            this.chkFrequency.Location = new System.Drawing.Point(15, 42);
            this.chkFrequency.Name = "chkFrequency";
            this.chkFrequency.Size = new System.Drawing.Size(76, 17);
            this.chkFrequency.TabIndex = 1;
            this.chkFrequency.Text = "Frequency";
            this.chkFrequency.UseVisualStyleBackColor = true;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 442);
            this.Controls.Add(this.lblServerIp);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblServerPort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblServerStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupCpu);
            this.Controls.Add(this.rtbLog);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OHM Mini Server";
            this.groupCpu.ResumeLayout(false);
            this.groupCpu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.GroupBox groupCpu;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lblServerStatus;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label lblServerPort;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label lblServerIp;
        private System.Windows.Forms.CheckBox chkFrequency;
        private System.Windows.Forms.CheckBox chkCpuEnable;
    }
}

