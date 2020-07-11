using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Faker
{
    internal class ByteTask : TaskExecuter
    {
        private IPAddress ipAddr;
        private IPEndPoint ipEnd;
        private Socket socket;
        private string IP;
        private string Port;
        private string sendMsg;
        private bool isGBK;

        public ByteTask(ByteTaskInfo si)
        {
            IP = si.ip;
            Port = si.port;
            sendMsg = si.sendMsg;
            isGBK = si.isGBK;
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

        public string comm()
        {
            string strSendMessage = sendMsg;//消息文本
            byte[] arrSendMessage = new byte[1024];
            if (isGBK)
            {
                arrSendMessage = Encoding.Default.GetBytes(strSendMessage); //消息字节数组 GBK字节数组
            }
            else
            {
                arrSendMessage = Encoding.UTF8.GetBytes(strSendMessage); //消息字节数组 UTF8字节数组
            }
            socket.Send(arrSendMessage);//发送数据

            byte[] arrRecvMessage = new byte[1024 * 5];
            socket.Receive(arrRecvMessage);//接收消息体

            string recvMsg = "";
            if (isGBK)
            {
                recvMsg = Encoding.Default.GetString(arrRecvMessage, 0, arrRecvMessage.Length); //消息字节数组  //GBK字节数组
            }
            else
            {
                recvMsg = Encoding.UTF8.GetString(arrRecvMessage, 0, arrRecvMessage.Length); //消息字节数组  //UTF8字节数组
            }

            return recvMsg.Trim();
        }
    }
}