using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace FileTransmitter
{
    
    public partial class MainFrom : Form
    {
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

        private async void upload_Click(object sender, EventArgs e)
        {
            //1.格式化数据并检验用户输入数据的合法性，包括文件类型合法性
            //1.1格式化文件名并检测文件合法性
            lableUploadtState.Text = string.Empty;
            textBoxUploadFilename.Text=textBoxUploadFilename.Text.Trim();
            if (!File.Exists(textBoxUploadFilename.Text))
            {
                lableUploadtState.Text = "文件不存在。";
                return;
            }
            int index = textBoxUploadFilename.Text.LastIndexOf(".");
            string fileExten = textBoxUploadFilename.Text.Substring(index + 1);
            if (!(fileExten == "txt" || fileExten == "pdf" || fileExten == "doc"
                || fileExten == "rar" || fileExten == "ppt"))
            {
                lableUploadtState.Text = "不允许的文件类型。" ;
                return;
            }
            //1.2远程服务器地址与端口的格式验证
            if(!TextValidate.IsIP(tBRemoteServerIP.Text))
            {
                lableUploadtState.Text += "远程服务器IP格式错误";
                return;
            }
            if (!TextValidate.IsServerPort(tBRemoteServerPort.Text))
            {
                lableUploadtState.Text += "远程服务器端口错误";
                return;
            }
            //2准备与开始上传
            //2.1关闭按钮
            bottonUpload.Enabled = false;
            buttonLaunchServer.Enabled = false;
            await Task.Delay(10);
            //2.2开始上传
            try
            {
                P2PClient p2pclient = new P2PClient();
                lableUploadtState.Text += "正在连接:" + tBRemoteServerIP.Text + ":" + tBRemoteServerPort.Text;
                await Task.Delay(10);
                //TCP连接
                p2pclient.Connect(tBRemoteServerIP.Text, Convert.ToInt32(tBRemoteServerPort.Text));
                lableUploadtState.Text += "\n连接完成，正在传输";
                await Task.Delay(10);
                //传输文件
                p2pclient.uploadFile(textBoxUploadFilename.Text);
                p2pclient.close();
                lableUploadtState.Text += "\n完成，连接关闭";
            }
            //2.3上传错误时显示错误信息
            catch(Exception e1)
            {
                lableUploadtState.Text = e1.Message;
            }
            //2.4开启按钮
            bottonUpload.Enabled = true;
            buttonLaunchServer.Enabled = true;
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

        private async void buttonLaunchServer_Click(object sender, EventArgs e)
        {
            //1.验证用户输入的数据：目录，远程服务终端名
            labelDownloadState.Text = string.Empty;
            if (!Directory.Exists(laDirname.Text))
            {
                labelDownloadState.Text += "目录不存在！";
                return;
            }
            //1.1本地服务器地址与端口的格式验证
            if (!TextValidate.IsIP(tBLocalServerIP.Text))
            {
                labelDownloadState.Text += "本地服务器IP格式错误";
                return;
            }
            if (!TextValidate.IsServerPort(tBLocalServerPort.Text))
            {
                labelDownloadState.Text += "本地服务器端口错误";
                return;
            }
            //2.准备工作与开启服务器
            //2.1关闭按钮，以免误操作带来的逻辑混乱
            bottonUpload.Enabled = false;
            buttonLaunchServer.Enabled = false;
            await Task.Delay(10);
            //2.2开启服务器
            try
            {
                //绑定本地终端节点
                P2PServer server = new P2PServer(tBLocalServerIP.Text, Convert.ToInt32(tBLocalServerPort.Text), laDirname.Text);
                labelDownloadState.Text += "开启监听";
                await Task.Delay(10);
                //监听并接受连接
                server.ListenAndAccept();
                labelDownloadState.Text += "\n接受到新连接：" + server.ClientInfo.ToString();
                await Task.Delay(10);
                //下载数据
                server.Download();
                labelDownloadState.Text += "\n下载完成";
                await Task.Delay(10);
                server.close();
                labelDownloadState.Text += "\n关闭连接";
            }
            //2.3显示服务器运行中的错误
            catch(Exception e1)
            {
                labelDownloadState.Text += e1.Message;
            }
            //2.4开启按钮
            bottonUpload.Enabled = true;
            buttonLaunchServer.Enabled = true;
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
