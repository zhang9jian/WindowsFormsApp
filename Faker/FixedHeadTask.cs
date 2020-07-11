using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Faker
{
    internal class FixedHeadTask : TaskExecuter
    {
        private IPAddress ipAddr;
        private IPEndPoint ipEnd;
        private Socket socket;
        private string IP;
        private string Port;
        private string sendMsg;
        private bool isGBK;

        public FixedHeadTask(FixedHeadTaskInfo si)
        {
            IP = si.ip;
            Port = si.port;
            sendMsg = si.sendMsg;
            isGBK = si.isGBK;
        }

        public string comm()
        {
            string strSendMessage = sendMsg;// rcSendText.Text.Trim();//消息文本
            byte[] arrSendMessage = new byte[1024];
            if (isGBK)
            {
                arrSendMessage = Encoding.Default.GetBytes(strSendMessage); //消息字节数组  //GBK字节数组
            }
            else
            //  if (!isGBK)
            {
                arrSendMessage = Encoding.UTF8.GetBytes(strSendMessage); //消息字节数组  //GBK字节数组
            }

            byte[] arrSendMessageHeadLWord = new byte[4];//定义消息头字节长度
            arrSendMessageHeadLWord = BitConverter.GetBytes(arrSendMessage.Length);//初始化消息头字节
            byte[] arrMessageHead = arrSendMessageHeadLWord.Reverse().ToArray();//有低字节序转为高字节序
            socket.Send(arrMessageHead);//发送消息头
            socket.Send(arrSendMessage);//发送数据

            byte[] arrRecvMessageHeadHWord = new byte[4];//定义消息头字节
            socket.Receive(arrRecvMessageHeadHWord);//接收消息头
            byte[] arrRecvMessageHead = arrRecvMessageHeadHWord.Reverse().ToArray();//由高字节转为低字节
            int iRecvMessageHeadLen = BitConverter.ToInt32(arrRecvMessageHead, 0);//由字节转为int

            byte[] arrRecvMessage = new byte[iRecvMessageHeadLen];//定义消息体长度
            socket.Receive(arrRecvMessage);//接收消息体

            if (!isGBK)
            {
                arrSendMessage = Encoding.UTF8.GetBytes(strSendMessage); //消息字节数组  //GBK字节数组
            }

            string recvMsg = "";
            if (isGBK)
            {
                recvMsg = Encoding.Default.GetString(arrRecvMessage, 0, arrRecvMessage.Length); //消息字节数组  //GBK字节数组
            }
            else
            {
                recvMsg = Encoding.UTF8.GetString(arrRecvMessage, 0, arrRecvMessage.Length); //消息字节数组  //GBK字节数组
            }
            return recvMsg.Trim();
        }

        public string execute()
        {
            connectSocket(IP, Port);
            string recvMsg = comm();
            closeSocket();
            return recvMsg;
        }

        public Socket connectSocket(string strIP, string strPort)
        {
            if ((socket == null) || (!socket.Connected))
            {
                string ip = strIP.Trim();
                int port = Convert.ToInt32(strPort.Trim());
                ipAddr = IPAddress.Parse(ip);//接收端所在IP
                ipEnd = new IPEndPoint(ipAddr, port);//接收端所监听的接口
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);//初始化一个Socket对象
                socket.Connect(ipEnd);
            }
            return socket;
        }

        //关闭socket
        private void closeSocket()
        {
            if ((socket != null) || (socket.Connected))
            {
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
                socket = null;
            }
        }
    }
}