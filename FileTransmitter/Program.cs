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
    //资源共享者类
    public class P2PSharerPeer
    {
        Socket sharerServer;//发布资源信息，开启监听的socket
        Socket sharerSender;//与具体的客户端发送数据的socket
        FileInfo fileInfo;//发布的文件信息
        public IPEndPoint localIPEP { get; private set; }//本地节点信息
        public IPEndPoint serverIPEP { get; private set; }
        public IPEndPoint downloaderIPEP { get; private set; }
        public P2PSharerPeer()
        {
            sharerServer = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);
            return;
        }
        //将指定文件发布到服务器中
        public void publish(IPEndPoint server, string filepath)
        {
            serverIPEP = server;
            try
            {
                //向P2P公共服务器发布资源/
                fileInfo = new FileInfo(filepath);
                //组织发送数据的格式：请求类型(pub发布)；文件名；文件长度。
                byte[] bmode= Encoding.UTF8.GetBytes("pub");
                byte[] bfilename = new byte[60];
                bfilename = Encoding.UTF8.GetBytes(fileInfo.Name.PadRight(60));
                byte[] blength = new byte[20];
                blength=Encoding.UTF8.GetBytes(fileInfo.Length.ToString().PadRight(20));
                byte[] bdata = new byte[83];
                bmode.CopyTo(bdata, 0);
                bfilename.CopyTo(bdata, 3);
                blength.CopyTo(bdata, 63);

                sharerServer.Connect(serverIPEP);
                sharerServer.Send(bdata, bdata.Length,0);
                localIPEP = (IPEndPoint)sharerServer.LocalEndPoint;
                //关闭套接字并重建
                sharerServer.Close();
                sharerServer = new Socket(AddressFamily.InterNetwork,
                                  SocketType.Stream, ProtocolType.Tcp);
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        public void ListenAndAccept()
        {
            sharerServer.Bind(localIPEP);
            sharerServer.Listen(1);
            sharerSender = sharerServer.Accept();
            downloaderIPEP = (IPEndPoint)sharerSender.RemoteEndPoint;
        }
        
        public void SendFile()
        {
            FileStream fs = File.Open(fileInfo.FullName, FileMode.Open, FileAccess.Read);

            //文件信息存入字节数组
            //文件名：60字节
            byte[] bfilename = new byte[60];
            bfilename = Encoding.UTF8.GetBytes(fileInfo.Name.PadRight(60));
            //文件长度20字节
            byte[] blength = new byte[20];
            blength = Encoding.UTF8.GetBytes(fs.Length.ToString().PadRight(20));     
            //文件内容存入字节数组
            byte[] filedata = new byte[fs.Length];
            fs.Read(filedata, 0, filedata.Length);
            fs.Close();
            //合并字节数组
            byte[] netdata = new byte[80 + filedata.Length];
            bfilename.CopyTo(netdata, 0);
            blength.CopyTo(netdata, 60);
            filedata.CopyTo(netdata,80);

            //发送文件
            sharerSender.Send(netdata, netdata.Length, 0);
        }
        public void close()
        {
            //关闭 Socket  
            sharerServer.Close();
            sharerSender.Close();
        }
    }
   
    
    //下载者类
    public class P2PDownloader
    {
        Socket downloader;
        ResourceInfo resourceInfo;
        public DirectoryInfo StorageDir { get; private set; }
        public IPEndPoint LocalIPEP { get; private set; }
        public IPEndPoint ServerIPEP { get; private set; }
     
        public P2PDownloader()
        {
            downloader = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);
           
        }
        //向服务器获取资源，返回说明资源的字符串
        public string GetResource(IPEndPoint server)
        {
            ServerIPEP = server;
            downloader.Connect(ServerIPEP);
            //将请求数据放入字节数组中
            byte[] bmode=Encoding.UTF8.GetBytes("get");
            downloader.Send(bmode, 0);

            //声明字节数组缓冲区
            byte[] buffer=new byte[1024];
            //声明返回的字节数
            int bcount;
            //声明接受到的字符串(经过格式化)
            string str;
            bcount = downloader.Receive(buffer, 3, 0);
            str = Encoding.UTF8.GetString(buffer, 0, bcount).Trim();
            if (str != "gok")
            {
                throw new Exception("获取资源时发生错误！");
            }
            //解码文件名:60byte
            bcount = downloader.Receive(buffer, 60, 0);
            string filename = Encoding.UTF8.GetString(buffer, 0, bcount).Trim();
            resourceInfo.FileName = filename;
            //解码文件长度:20byte
            bcount = downloader.Receive(buffer, 20, 0);
            string length = Encoding.UTF8.GetString(buffer, 0, bcount).Trim();
            resourceInfo.Length = Convert.ToInt32(length);
            //解码共享者IP:15byte
            bcount = downloader.Receive(buffer, 15, 0);
            string ip = Encoding.UTF8.GetString(buffer, 0, bcount).Trim();
            //解码共享者端口:5byte
            bcount = downloader.Receive(buffer, 5, 0);
            string port = Encoding.UTF8.GetString(buffer, 0, bcount).Trim();
            resourceInfo.SharerIPEP = new IPEndPoint(IPAddress.Parse(ip), Convert.ToInt32(port));
            //断开连接
            downloader.Close();
            downloader = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);
            
            //返回资源信息
            string str3;
            str3="来自"+resourceInfo.SharerIPEP.ToString()+"的文件:"
           + resourceInfo.FileName + "("+resourceInfo.Length.ToString() + "bytes)";
            return str3;
        }
        
        public void Connect()
        {
            try
            {
                downloader.Connect(resourceInfo.SharerIPEP);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        
        public void Download(string dirpath)
        {
            try
            {
                StorageDir = new DirectoryInfo(dirpath);
                //接收的文件信息
                //解码文件名
                //1.接收
                //声明字节数组，一次接收数据的长度为 1024 字节  
                byte[] recvBytes = new byte[1024];
                //返回实际接收内容的字节数  
                int bcount = 0;
                bcount = downloader.Receive(recvBytes, 60, 0);
                string fileName = Encoding.UTF8.GetString(recvBytes, 0, bcount).Trim();//4bytes
                string exten= fileName.Substring(fileName.LastIndexOf(".")+1);
                if (!(exten == "txt" || exten == "pdf" || exten == "doc"
                    || exten == "rar" || exten == "ppt"))
                {
                    downloader.Close();
                    throw new Exception("文件类型非法，拒绝接收");
                }
                if (resourceInfo.FileName != fileName)
                {
                    throw new Exception("接收时文件信息错误，请重试");
                }
                //解码文件长度20bytes
                bcount = downloader.Receive(recvBytes, 20, 0);
                string strFileLength = Encoding.UTF8.GetString(recvBytes, 0, bcount);//4bytes
                int fileLength = Convert.ToInt32(strFileLength.Trim());
                if(resourceInfo.Length!= fileLength)
                {
                    throw new Exception("接收时文件信息错误，请重试");
                }
                //创建文件流，然后让文件流来根据路径创建一个文件
                string filefullname = StorageDir + @"\" + resourceInfo.FileName;
                FileStream fs = new FileStream(filefullname, FileMode.CreateNew);
                //接收文件内容
                int recvedLength = 0;
                while (recvedLength < resourceInfo.Length)
                {
                    bcount = downloader.Receive(recvBytes, recvBytes.Length, 0);
                    recvedLength += bcount;
                    fs.Write(recvBytes, 0, bcount);
                }
                fs.Flush();
                fs.Close();
            }
            catch(Exception e)
            {
                throw e;
            }


        }
        public void close()
        {
            downloader.Shutdown(SocketShutdown.Both);
            downloader.Close();
        }
    }
    public class P2PServer
    {
        Socket p2pServer;
        ResourceInfo resInfo;

        public P2PServer(IPEndPoint serverIPEP)
        {
            p2pServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            p2pServer.Bind(serverIPEP);
        }
        public void Launch()
        {
            try
            {
                p2pServer.Listen(10);
                while (true)
                {
                    //1.分析并回应请求
                    Socket subSock = p2pServer.Accept();
                    //接受数据缓冲区大小
                    byte[] buffer = new byte[1024];
                    //接收的字节数
                    int bcount = 0;
                    //接收到的字符串
                    string str;
                    bcount = subSock.Receive(buffer, 3, 0);
                    str = Encoding.UTF8.GetString(buffer, 0, bcount);
                    //回应数据下载者的获取资源请求
                    if (str == "get")
                    {
                        //组织“种子”信息，对齐到字节
                        //请求类型
                        byte[] bmode = Encoding.UTF8.GetBytes("gok");
                        //文件名：
                        byte[] bfilename = new byte[60];
                        bfilename = Encoding.UTF8.GetBytes(resInfo.FileName.PadRight(60));
                        //文件长度
                        byte[] blength = new byte[20];
                        blength = Encoding.UTF8.GetBytes(resInfo.Length.ToString().PadRight(20));
                        //IP
                        byte[] bip = new byte[15];
                        bip = Encoding.UTF8.GetBytes(resInfo.SharerIPEP.Address.ToString().PadRight(15));
                        //端口
                        byte[] bport = new byte[5];
                        bport = Encoding.UTF8.GetBytes(resInfo.SharerIPEP.Port.ToString().PadRight(5));
                        //合并字节数组
                        byte[] dbyte = new byte[103];
                        bmode.CopyTo(dbyte, 0);
                        bfilename.CopyTo(dbyte, 3);
                        blength.CopyTo(dbyte, 63);
                        bip.CopyTo(dbyte, 83);
                        bport.CopyTo(dbyte, 98);
                        //发送
                        subSock.Send(dbyte, dbyte.Length, 0);
                        subSock.Close();
                    }
                    //保存资源共享者的“种子”信息
                    else if (str == "pub")
                    {
                        //解码文件名
                        bcount = subSock.Receive(buffer, 60, 0);
                        string filename = Encoding.UTF8.GetString(buffer, 0, bcount).Trim();
                        resInfo.FileName = filename;
                        //解码文件长度
                        bcount = subSock.Receive(buffer, 20, 0);
                        string length = Encoding.UTF8.GetString(buffer, 0, bcount).Trim();
                        resInfo.Length = Convert.ToInt32(length);
                        //读取共享者的端点信息
                        resInfo.SharerIPEP = (IPEndPoint)subSock.RemoteEndPoint;
                        subSock.Close();
                    }
                    else
                    {
                        throw new Exception("服务器接收到错误消息");
                    }

                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
    //提供资源信息
    public struct ResourceInfo
    {
        public string FileName;
        public int Length;
        public IPEndPoint SharerIPEP;
    }
}
