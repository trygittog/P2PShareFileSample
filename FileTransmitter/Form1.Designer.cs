namespace FileTransmitter
{
    partial class MainFrom
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
            System.Windows.Forms.Label lable2;
            System.Windows.Forms.Label label4;
            this.buttonFileBrowse = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.textBoxUploadFilename = new System.Windows.Forms.TextBox();
            this.bottonUpload = new System.Windows.Forms.Button();
            this.laServerInfo = new System.Windows.Forms.Label();
            this.lableUploadtState = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tBRemoteServerIP = new System.Windows.Forms.TextBox();
            this.tBRemoteServerPort = new System.Windows.Forms.TextBox();
            this.tBLocalServerPort = new System.Windows.Forms.TextBox();
            this.tBLocalServerIP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.labelDownloadState = new System.Windows.Forms.Label();
            this.laDirname = new System.Windows.Forms.Label();
            this.buttonLaunchServer = new System.Windows.Forms.Button();
            this.buttonFolderBrowse = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            lable2 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lable2
            // 
            lable2.AutoSize = true;
            lable2.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            lable2.Location = new System.Drawing.Point(12, 90);
            lable2.Name = "lable2";
            lable2.Size = new System.Drawing.Size(124, 28);
            lable2.TabIndex = 3;
            lable2.Text = "文件名：";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            label4.Location = new System.Drawing.Point(11, 200);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(152, 28);
            label4.TabIndex = 16;
            label4.Text = "文件目录：";
            // 
            // buttonFileBrowse
            // 
            this.buttonFileBrowse.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonFileBrowse.Location = new System.Drawing.Point(1158, 85);
            this.buttonFileBrowse.Name = "buttonFileBrowse";
            this.buttonFileBrowse.Size = new System.Drawing.Size(113, 42);
            this.buttonFileBrowse.TabIndex = 0;
            this.buttonFileBrowse.Text = "浏览";
            this.buttonFileBrowse.UseVisualStyleBackColor = true;
            this.buttonFileBrowse.Click += new System.EventHandler(this.browse_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // textBoxUploadFilename
            // 
            this.textBoxUploadFilename.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxUploadFilename.Location = new System.Drawing.Point(142, 85);
            this.textBoxUploadFilename.Name = "textBoxUploadFilename";
            this.textBoxUploadFilename.Size = new System.Drawing.Size(1000, 42);
            this.textBoxUploadFilename.TabIndex = 1;
            // 
            // bottonUpload
            // 
            this.bottonUpload.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bottonUpload.Location = new System.Drawing.Point(790, 370);
            this.bottonUpload.Name = "bottonUpload";
            this.bottonUpload.Size = new System.Drawing.Size(227, 58);
            this.bottonUpload.TabIndex = 4;
            this.bottonUpload.Text = "上传";
            this.bottonUpload.UseVisualStyleBackColor = true;
            this.bottonUpload.Click += new System.EventHandler(this.upload_Click);
            // 
            // laServerInfo
            // 
            this.laServerInfo.AutoSize = true;
            this.laServerInfo.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.laServerInfo.Location = new System.Drawing.Point(12, 16);
            this.laServerInfo.Name = "laServerInfo";
            this.laServerInfo.Size = new System.Drawing.Size(490, 24);
            this.laServerInfo.TabIndex = 6;
            this.laServerInfo.Text = "远程服务器：            端口          ，";
            // 
            // lableUploadtState
            // 
            this.lableUploadtState.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lableUploadtState.Location = new System.Drawing.Point(786, 442);
            this.lableUploadtState.Name = "lableUploadtState";
            this.lableUploadtState.Size = new System.Drawing.Size(485, 150);
            this.lableUploadtState.TabIndex = 7;
            this.lableUploadtState.Text = "准备就绪";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(117, 141);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(466, 24);
            this.label1.TabIndex = 9;
            this.label1.Text = "允许的文件类型.txt|.rar|.pdf|.ppt|.doc";
            // 
            // tBRemoteServerIP
            // 
            this.tBRemoteServerIP.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tBRemoteServerIP.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tBRemoteServerIP.Location = new System.Drawing.Point(152, 12);
            this.tBRemoteServerIP.MaxLength = 15;
            this.tBRemoteServerIP.Name = "tBRemoteServerIP";
            this.tBRemoteServerIP.Size = new System.Drawing.Size(136, 33);
            this.tBRemoteServerIP.TabIndex = 10;
            this.tBRemoteServerIP.Text = "127.0.0.1";
            this.tBRemoteServerIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tBRemoteServerIP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxConnectIP_KeyPress);
            // 
            // tBRemoteServerPort
            // 
            this.tBRemoteServerPort.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tBRemoteServerPort.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tBRemoteServerPort.Location = new System.Drawing.Point(362, 12);
            this.tBRemoteServerPort.MaxLength = 5;
            this.tBRemoteServerPort.Name = "tBRemoteServerPort";
            this.tBRemoteServerPort.Size = new System.Drawing.Size(100, 33);
            this.tBRemoteServerPort.TabIndex = 11;
            this.tBRemoteServerPort.Text = "13000";
            this.tBRemoteServerPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tBRemoteServerPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPort_KeyPress);
            // 
            // tBLocalServerPort
            // 
            this.tBLocalServerPort.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tBLocalServerPort.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tBLocalServerPort.Location = new System.Drawing.Point(856, 12);
            this.tBLocalServerPort.MaxLength = 5;
            this.tBLocalServerPort.Name = "tBLocalServerPort";
            this.tBLocalServerPort.Size = new System.Drawing.Size(100, 33);
            this.tBLocalServerPort.TabIndex = 14;
            this.tBLocalServerPort.Text = "13000";
            this.tBLocalServerPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tBLocalServerPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxServerPort_KeyPress);
            // 
            // tBLocalServerIP
            // 
            this.tBLocalServerIP.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tBLocalServerIP.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tBLocalServerIP.Location = new System.Drawing.Point(646, 12);
            this.tBLocalServerIP.MaxLength = 15;
            this.tBLocalServerIP.Name = "tBLocalServerIP";
            this.tBLocalServerIP.Size = new System.Drawing.Size(136, 33);
            this.tBLocalServerIP.TabIndex = 13;
            this.tBLocalServerIP.Text = "127.0.0.1";
            this.tBLocalServerIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(504, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(754, 24);
            this.label2.TabIndex = 12;
            this.label2.Text = "本地服务器：            端口          。端口请设在1024-49151。";
            // 
            // labelDownloadState
            // 
            this.labelDownloadState.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelDownloadState.Location = new System.Drawing.Point(214, 442);
            this.labelDownloadState.Name = "labelDownloadState";
            this.labelDownloadState.Size = new System.Drawing.Size(500, 138);
            this.labelDownloadState.TabIndex = 19;
            this.labelDownloadState.Text = "准备就绪";
            // 
            // laDirname
            // 
            this.laDirname.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(214)))), ((int)(((byte)(214)))));
            this.laDirname.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.laDirname.Location = new System.Drawing.Point(147, 200);
            this.laDirname.Name = "laDirname";
            this.laDirname.Size = new System.Drawing.Size(995, 126);
            this.laDirname.TabIndex = 18;
            // 
            // buttonLaunchServer
            // 
            this.buttonLaunchServer.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonLaunchServer.Location = new System.Drawing.Point(218, 362);
            this.buttonLaunchServer.Name = "buttonLaunchServer";
            this.buttonLaunchServer.Size = new System.Drawing.Size(185, 66);
            this.buttonLaunchServer.TabIndex = 17;
            this.buttonLaunchServer.Text = "开启服务器";
            this.buttonLaunchServer.UseVisualStyleBackColor = true;
            this.buttonLaunchServer.Click += new System.EventHandler(this.buttonLaunchServer_Click);
            // 
            // buttonFolderBrowse
            // 
            this.buttonFolderBrowse.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonFolderBrowse.Location = new System.Drawing.Point(1158, 200);
            this.buttonFolderBrowse.Name = "buttonFolderBrowse";
            this.buttonFolderBrowse.Size = new System.Drawing.Size(113, 42);
            this.buttonFolderBrowse.TabIndex = 15;
            this.buttonFolderBrowse.Text = "浏览";
            this.buttonFolderBrowse.UseVisualStyleBackColor = true;
            this.buttonFolderBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.HelpRequest += new System.EventHandler(this.folderBrowserDialog1_HelpRequest);
            // 
            // MainFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1304, 601);
            this.Controls.Add(this.labelDownloadState);
            this.Controls.Add(this.laDirname);
            this.Controls.Add(this.buttonLaunchServer);
            this.Controls.Add(label4);
            this.Controls.Add(this.buttonFolderBrowse);
            this.Controls.Add(this.tBLocalServerPort);
            this.Controls.Add(this.tBLocalServerIP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tBRemoteServerPort);
            this.Controls.Add(this.tBRemoteServerIP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lableUploadtState);
            this.Controls.Add(this.laServerInfo);
            this.Controls.Add(this.bottonUpload);
            this.Controls.Add(this.textBoxUploadFilename);
            this.Controls.Add(this.buttonFileBrowse);
            this.Controls.Add(lable2);
            this.Name = "MainFrom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "P2P文件接收与上传";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonFileBrowse;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox textBoxUploadFilename;
        private System.Windows.Forms.Button bottonUpload;
        private System.Windows.Forms.Label laServerInfo;
        private System.Windows.Forms.Label lableUploadtState;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tBRemoteServerIP;
        private System.Windows.Forms.TextBox tBRemoteServerPort;
        private System.Windows.Forms.TextBox tBLocalServerPort;
        private System.Windows.Forms.TextBox tBLocalServerIP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelDownloadState;
        private System.Windows.Forms.Label laDirname;
        private System.Windows.Forms.Button buttonLaunchServer;
        private System.Windows.Forms.Button buttonFolderBrowse;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}

