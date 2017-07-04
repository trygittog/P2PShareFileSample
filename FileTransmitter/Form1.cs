using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Net;

namespace FileTransmitter
{
    
    public partial class MainFrom : Form
    {
        P2PDownloader downloader;
        P2PSharerPeer sharer;
        public MainFrom()
        {
            InitializeComponent();
            //初始化文件浏览对话框
            openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();
            openFileDialog1.Filter = "所有文件|*.*|文本文件|*.txt|word文件|*.doc"
                      +"|演示文件|*.ppt|演示文件|*.pptx|PDF|*.pdf|压缩文件|*.rar";
            //初始化目录浏览对话框
            folderBrowserDialog1.SelectedPath= Directory.GetCurrentDirectory();
            //初始化文件名
            textBoxUploadFilename.Text = Directory.GetCurrentDirectory() + @"\新建文本文件.txt";
            //初始化文件目录
            laDirname.Text = Directory.GetCurrentDirectory();

        }

        private void browse_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            textBoxUploadFilename.Text = openFileDialog1.FileName;
            openFileDialog1.InitialDirectory = (Directory.GetParent(openFileDialog1.FileName).FullName);
            openFileDialog1.Reset();
        }

        private async void sharer_Click(object sender, EventArgs e)
        {
            //按下“发布资源”按钮
            if (bottonSharer.Text == "发布资源")
            {   
                //1.格式化数据并检验用户输入数据的合法性，包括文件类型合法性
                //1.1格式化文件名并检测文件合法性
                lableSharerState.Text = string.Empty;
                textBoxUploadFilename.Text = textBoxUploadFilename.Text.Trim();
                if (!File.Exists(textBoxUploadFilename.Text))
                {
                    lableSharerState.Text += "文件不存在。";
                    return;
                }
                int index = textBoxUploadFilename.Text.LastIndexOf(".");
                string fileExten = textBoxUploadFilename.Text.Substring(index + 1);
                if (!(fileExten == "txt" || fileExten == "pdf" || fileExten == "doc"
                    || fileExten == "rar" || fileExten == "ppt"))
                {
                    lableSharerState.Text = "不允许的文件类型。";
                    return;
                }
                //1.2远程服务器地址与端口的格式验证
                if (!TextValidate.IsIP(tBServerIP.Text))
                {
                    lableSharerState.Text += "远程服务器IP格式错误";
                    return;
                }
                if (!TextValidate.IsServerPort(tBServerPort.Text))
                {
                    lableSharerState.Text += "远程服务器端口错误";
                    return;
                }
                try
                {
                    sharer = new P2PSharerPeer();
                    IPEndPoint point = new IPEndPoint(IPAddress.Parse(tBServerIP.Text), Convert.ToInt32(tBServerPort.Text));
                    sharer.publish(point, textBoxUploadFilename.Text);
                    lableSharerState.Text += "发布成功";
                    bottonSharer.Text = "开始共享";
                }
                catch(Exception e1)
                {
                    lableSharerState.Text += e1.Message;
                }
            }
            //按钮“开始共享”按钮开启监听并传输文件
            else if(bottonSharer.Text == "开始共享")
            {
                try
                {
                    lableSharerState.Text += "\n开启监听";
                    await Task.Delay(10);
                    sharer.ListenAndAccept();
                    lableSharerState.Text += "\n有新连接";
                    sharer.SendFile();
                    lableSharerState.Text += "\n发送成功";
                    await Task.Delay(10);
                    sharer.close();
                    bottonSharer.Text = "发布资源";
                }
                catch(Exception e1)
                {
                    lableSharerState.Text += "\n"+e1.Message;
                }
            }
        }

        private void textBoxPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void textBoxServerPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            if (folderBrowserDialog1.SelectedPath != string.Empty)
            {
                laDirname.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private async void buttonDownloader_Click(object sender, EventArgs e)
        {
            //按下“获取资源”按钮
            if (buttonDownloader.Text == "获取资源")
            {
                labelDownloaderState.Text = string.Empty;
                if (!TextValidate.IsIP(tBServerIP.Text))
                {
                    labelDownloaderState.Text += "本地服务器IP格式错误";
                    return;
                }
                if (!TextValidate.IsServerPort(tBServerPort.Text))
                {
                    labelDownloaderState.Text += "本地服务器端口错误";
                    return;
                }
                try
                {   //向服务器获取资源信息
                    downloader = new P2PDownloader();
                    IPEndPoint point = new IPEndPoint(IPAddress.Parse(tBServerIP.Text), Convert.ToInt32(tBServerPort.Text));
                    labelDownloaderState.Text += downloader.GetResource(point);
                    buttonDownloader.Text = "开始下载";
                }
                catch (Exception e1)
                {
                    labelDownloaderState.Text += e1.Message;
                }
                return;
            }
            //按下“开始下载”按钮
            else if (buttonDownloader.Text == "开始下载")
            {
                //1.验证用户输入的数据：目录，远程服务终端名
                if (!Directory.Exists(laDirname.Text))
                {
                    labelDownloaderState.Text += "目录不存在！";
                    return;
                }
                //2.连接并下载
                try
                {
                    downloader.Connect();
                    labelDownloaderState.Text += "\n；连接完成，开始下载。";
                    await Task.Delay(10);
                    downloader.Download(laDirname.Text);
                    labelDownloaderState.Text += "\n下载完成";
                    await Task.Delay(10);
                    downloader.close();
                    labelDownloaderState.Text += "\n关闭连接";
                    buttonDownloader.Text = "获取资源";
                }
                catch (Exception e1)
                {
                    //2.3显示服务器运行中的错误
                    labelDownloaderState.Text += e1.Message;
                }
                return;
            }
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void textBoxConnectIP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != '.')
            {
                e.Handled = true;
            } 
        }

        private void buttonLaunchP2PServer_Click(object sender, EventArgs e)
        {
             if(buttonLaunchP2PServer.Text== "开启P2P服务器")
             {
                //检测服务器节点地址的格式
                laServerState.Text = string.Empty;
                if (!TextValidate.IsIP(tBServerIP.Text))
                {
                    laServerState.Text += "服务器IP错误";
                    return;
                }
                if (!TextValidate.IsServerPort(tBServerPort.Text))
                {
                    laServerState.Text += "服务器端口错误";
                    return;
                }
                buttonLaunchP2PServer.Text = "服务器已开启";
                buttonLaunchP2PServer.Enabled = false;
                IPEndPoint point = new IPEndPoint(IPAddress.Parse(tBServerIP.Text),Convert.ToInt32(tBServerPort.Text));
                bgThread.RunWorkerAsync(point);
                return;
            }
            
        }

        private void bgThread_DoWork(object sender, DoWorkEventArgs e)
        {
            P2PServer ser = new P2PServer((IPEndPoint)e.Argument);
            ser.Launch();
        }
        
    }
    public static class TextValidate
    {
        public static bool IsIP(string str)
        {
            string regexIpStr = @"[0-9]+\.[0-9]+\.[0-9]+\.[0-9]+";
            if (!Regex.IsMatch(str, regexIpStr))
            {
                return false;
            }
            return true;
        }
        public static bool IsServerPort(string str)
        {
            int portNum = Convert.ToInt32(str);
            if (portNum > 0 && 49151 >= portNum)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
