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
            this.bottonSharer = new System.Windows.Forms.Button();
            this.laServerInfo = new System.Windows.Forms.Label();
            this.lableSharerState = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tBServerIP = new System.Windows.Forms.TextBox();
            this.tBServerPort = new System.Windows.Forms.TextBox();
            this.labelDownloaderState = new System.Windows.Forms.Label();
            this.laDirname = new System.Windows.Forms.Label();
            this.buttonDownloader = new System.Windows.Forms.Button();
            this.buttonFolderBrowse = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.buttonLaunchP2PServer = new System.Windows.Forms.Button();
            this.bgThread = new System.ComponentModel.BackgroundWorker();
            this.label2 = new System.Windows.Forms.Label();
            this.laServerState = new System.Windows.Forms.Label();
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
            // bottonSharer
            // 
            this.bottonSharer.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bottonSharer.Location = new System.Drawing.Point(978, 367);
            this.bottonSharer.Name = "bottonSharer";
            this.bottonSharer.Size = new System.Drawing.Size(227, 58);
            this.bottonSharer.TabIndex = 4;
            this.bottonSharer.Text = "发布资源";
            this.bottonSharer.UseVisualStyleBackColor = true;
            this.bottonSharer.Click += new System.EventHandler(this.sharer_Click);
            // 
            // laServerInfo
            // 
            this.laServerInfo.AutoSize = true;
            this.laServerInfo.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.laServerInfo.Location = new System.Drawing.Point(12, 16);
            this.laServerInfo.Name = "laServerInfo";
            this.laServerInfo.Size = new System.Drawing.Size(526, 24);
            this.laServerInfo.TabIndex = 6;
            this.laServerInfo.Text = "P2P公共服务器：            端口          。";
            // 
            // lableSharerState
            // 
            this.lableSharerState.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lableSharerState.Location = new System.Drawing.Point(936, 441);
            this.lableSharerState.Name = "lableSharerState";
            this.lableSharerState.Size = new System.Drawing.Size(323, 150);
            this.lableSharerState.TabIndex = 7;
            this.lableSharerState.Text = "准备就绪";
            this.lableSharerState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // tBServerIP
            // 
            this.tBServerIP.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tBServerIP.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tBServerIP.Location = new System.Drawing.Point(192, 12);
            this.tBServerIP.MaxLength = 15;
            this.tBServerIP.Name = "tBServerIP";
            this.tBServerIP.Size = new System.Drawing.Size(136, 33);
            this.tBServerIP.TabIndex = 10;
            this.tBServerIP.Text = "127.0.0.1";
            this.tBServerIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tBServerIP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxConnectIP_KeyPress);
            // 
            // tBServerPort
            // 
            this.tBServerPort.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tBServerPort.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tBServerPort.Location = new System.Drawing.Point(402, 12);
            this.tBServerPort.MaxLength = 5;
            this.tBServerPort.Name = "tBServerPort";
            this.tBServerPort.Size = new System.Drawing.Size(100, 33);
            this.tBServerPort.TabIndex = 11;
            this.tBServerPort.Text = "13000";
            this.tBServerPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tBServerPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPort_KeyPress);
            // 
            // labelDownloaderState
            // 
            this.labelDownloaderState.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelDownloaderState.Location = new System.Drawing.Point(13, 430);
            this.labelDownloaderState.Name = "labelDownloaderState";
            this.labelDownloaderState.Size = new System.Drawing.Size(286, 161);
            this.labelDownloaderState.TabIndex = 19;
            this.labelDownloaderState.Text = "准备就绪";
            this.labelDownloaderState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // buttonDownloader
            // 
            this.buttonDownloader.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonDownloader.Location = new System.Drawing.Point(65, 359);
            this.buttonDownloader.Name = "buttonDownloader";
            this.buttonDownloader.Size = new System.Drawing.Size(185, 66);
            this.buttonDownloader.TabIndex = 17;
            this.buttonDownloader.Text = "获取资源";
            this.buttonDownloader.UseVisualStyleBackColor = true;
            this.buttonDownloader.Click += new System.EventHandler(this.buttonDownloader_Click);
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
            // buttonLaunchP2PServer
            // 
            this.buttonLaunchP2PServer.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonLaunchP2PServer.Location = new System.Drawing.Point(497, 365);
            this.buttonLaunchP2PServer.Name = "buttonLaunchP2PServer";
            this.buttonLaunchP2PServer.Size = new System.Drawing.Size(217, 63);
            this.buttonLaunchP2PServer.TabIndex = 20;
            this.buttonLaunchP2PServer.Text = "开启P2P服务器";
            this.buttonLaunchP2PServer.UseVisualStyleBackColor = true;
            this.buttonLaunchP2PServer.Click += new System.EventHandler(this.buttonLaunchP2PServer_Click);
            // 
            // bgThread
            // 
            this.bgThread.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgThread_DoWork);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(532, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(358, 29);
            this.label2.TabIndex = 21;
            this.label2.Text = "端口请设置在1024-49151。";
            // 
            // laServerState
            // 
            this.laServerState.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.laServerState.Location = new System.Drawing.Point(444, 441);
            this.laServerState.Name = "laServerState";
            this.laServerState.Size = new System.Drawing.Size(323, 150);
            this.laServerState.TabIndex = 22;
            this.laServerState.Text = "准备就绪";
            this.laServerState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1305, 619);
            this.Controls.Add(this.laServerState);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonLaunchP2PServer);
            this.Controls.Add(this.labelDownloaderState);
            this.Controls.Add(this.laDirname);
            this.Controls.Add(this.buttonDownloader);
            this.Controls.Add(label4);
            this.Controls.Add(this.buttonFolderBrowse);
            this.Controls.Add(this.tBServerPort);
            this.Controls.Add(this.tBServerIP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lableSharerState);
            this.Controls.Add(this.laServerInfo);
            this.Controls.Add(this.bottonSharer);
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
        private System.Windows.Forms.Button bottonSharer;
        private System.Windows.Forms.Label laServerInfo;
        private System.Windows.Forms.Label lableSharerState;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tBServerIP;
        private System.Windows.Forms.TextBox tBServerPort;
        private System.Windows.Forms.Label labelDownloaderState;
        private System.Windows.Forms.Label laDirname;
        private System.Windows.Forms.Button buttonDownloader;
        private System.Windows.Forms.Button buttonFolderBrowse;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button buttonLaunchP2PServer;
        private System.ComponentModel.BackgroundWorker bgThread;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label laServerState;
    }
}

