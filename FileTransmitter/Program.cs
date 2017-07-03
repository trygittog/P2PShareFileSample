using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Text;

namespace FileTransmitter
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainFrom());
        }
    }
    public class P2PClient
    {
        Socket p2pclient;

        public P2PClient()
        {
            p2pclient = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);
            return;
        }
        public void Connect(string destIP, int destport)
        {
            byte[] b = new byte[8];
            long l = Convert.ToInt64;
            IPEndPoint destIPEP = new IPEndPoint(IPAddress.Parse(destIP), destport);
            try { p2pclient.Connect(destIPEP); }
            catch(Exception e)
            {
                throw e;
            }
        }
        public void uploadFile(string filepath)
        {
            FileStream fs = File.Open(filepath, FileMode.Open, FileAccess.Read);

            //指定数据流头部的文件信息
            //解析文件名和后缀名
            string fn = filepath.Substring(filepath.LastIndexOf(@"\") + 1);
            string fileExten = fn.Substring(fn.IndexOf(".")+1);
            string fileName = fn.Substring(0, fn.IndexOf(".")-1);
            //存入数组
            byte[] bfileName = new byte[60];//60byte
            bfileName = Encoding.UTF8.GetBytes(fileName.PadRight(60));
            byte[] bfileExten = new byte[4];//4byte
            bfileExten = Encoding.UTF8.GetBytes(fileExten.PadRight(4));
            byte[] bfileLength = new byte[20];//20byte
            bfileLength = Encoding.UTF8.GetBytes(fs.Length.ToString().PadRight(20));
            //文件内容
            byte[] filedata = new byte[fs.Length];
            fs.Read(filedata, 0, filedata.Length);
            fs.Close();
            //合并字节数组
            byte[] p2pdata = new byte[84 + filedata.Length];
            bfileName.CopyTo(p2pdata, 0);
            bfileExten.CopyTo(p2pdata, 60);
            bfileLength.CopyTo(p2pdata, 64);
            filedata.CopyTo(p2pdata, 84);

            //发送文件
            p2pclient.Send(p2pdata, p2pdata.Length, 0);

            //2.接收
            //声明接收返回内容的字符串  
            string recvStr = "";

            //声明字节数组，一次接收数据的长度为 1024 字节  
            byte[] recvBytes = new byte[1024];

            //返回实际接收内容的字节数  
            int bytes = 0;

            //循环读取，直到接收完所有数据  
            while (true)
            {
                bytes = p2pclient.Receive(recvBytes, recvBytes.Length, 0);
                //读取完成后退出循环  
                if (bytes <= 0) break;

                //将读取的字节数转换为字符串  
                recvStr += Encoding.UTF8.GetString(recvBytes, 0, bytes);
            }
            
        }
        public void close()
        {
            //禁用 Socket  
            p2pclient.Shutdown(SocketShutdown.Both);
            //关闭 Socket  
            p2pclient.Close();
        }
    }
   

    public class P2PServer
    {
        Socket p2pServer;
        Socket p2pRecClient;
        string Storedir;
        public IPEndPoint ClientInfo;//最新连接的客户端
        public P2PServer(string localIP, int localport,string dirpath)
        {
            p2pServer = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);
            
            IPEndPoint localIPEP = new IPEndPoint(IPAddress.Parse(localIP), localport);
            p2pServer.Bind(localIPEP);
            Storedir = dirpath;
        }

  
        public  void ListenAndAccept()
        {
            p2pServer.Listen(1);
            p2pRecClient = p2pServer.Accept();
            ClientInfo = (IPEndPoint)p2pRecClient.RemoteEndPoint;
        }
        public void Download()
        {
            try
            {
                //1.接收
                //声明字节数组，一次接收数据的长度为 1024 字节  
                byte[] recvBytes = new byte[1024];
                //返回实际接收内容的字节数  
                int bytescount = 0;

                //接收的文件信息
                bytescount = p2pRecClient.Receive(recvBytes, 60, 0);
                string fileName = Encoding.UTF8.GetString(recvBytes,0, bytescount).Trim();//60bytes
                bytescount = p2pRecClient.Receive(recvBytes, 4, 0);
                string fileExten = Encoding.UTF8.GetString(recvBytes, 0, bytescount).Trim();//4bytes
                if (!(fileExten == "txt" || fileExten == "pdf" || fileExten == "doc"
                    || fileExten == "rar" || fileExten == "ppt"))
                {
                    p2pRecClient.Close();
                    throw new Exception("文件类型非法，拒绝接收");
                }
                bytescount = p2pRecClient.Receive(recvBytes, 20, 0);
                string strFileLength = Encoding.UTF8.GetString(recvBytes, 0, bytescount);//4bytes
                int fileLength = Convert.ToInt32(strFileLength.Trim());
                //创建文件流，然后让文件流来根据路径创建一个文件
                string filefullname = Storedir + @"\" + fileName + @"." + fileExten;
                FileStream fs = new FileStream(filefullname, FileMode.CreateNew);
                //接收文件内容
                int ReceivedLength = 0;
                while (ReceivedLength < fileLength)
                {
                    bytescount = p2pRecClient.Receive(recvBytes, recvBytes.Length, 0);
                    ReceivedLength += bytescount;
                    fs.Write(recvBytes, 0, bytescount);
                }
                fs.Flush();
                fs.Close();
           
                //2.发送
                byte[] bdata = Encoding.UTF8.GetBytes("接收完成！");
                p2pRecClient.Send(bdata, bdata.Length, 0);
                p2pRecClient.Close();
            }
            catch(Exception e)
            {
                throw e;
            }


        }
        public void close()
        {
            p2pServer.Close();
        }
    }
    
}
