﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace Faker
{
    class FixedByteTask:TaskExecuter
    {
        IPAddress ipAddr;
        IPEndPoint ipEnd;
        Socket socket;
        string IP;
        string Port;
        string sendMsg;
        bool isGBK;
        string headLen;

        public FixedByteTask(FixedByteTaskInfo si)
        {
            IP = si.ip;
            Port = si.port;
            sendMsg = si.sendMsg;
            isGBK = si.isGBK;
            headLen = si.headLen;
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
            int iMsgHeadLength = Convert.ToInt32(headLen.Trim());//消息头长度
            //消息体长度左补0
            string strSendMessageHead = Convert.ToString(arrSendMessage.Length).PadLeft(iMsgHeadLength, '0');//初始化消息头字节            
            byte[] arrSendMessageHead = Encoding.Default.GetBytes(strSendMessageHead);//消息头转为字节
            socket.Send(arrSendMessageHead);//发送消息头
            socket.Send(arrSendMessage);//发送数据


            byte[] arrRecvMessageHead = new byte[iMsgHeadLength];//定义消息头字节
            socket.Receive(arrRecvMessageHead);//接收消息头
            int iRecvMessageLength = Convert.ToInt32(Encoding.Default.GetString(arrRecvMessageHead));

            byte[] arrRecvMessage = new byte[iRecvMessageLength];
            socket.Receive(arrRecvMessage);//接收消息体

            string recvMsg = "";
            if (isGBK)
            {
                recvMsg = Encoding.Default.GetString(arrRecvMessage, 0, arrRecvMessage.Length); //消息字节数组  //GBK字节数组     
            }else
            {
                recvMsg = Encoding.UTF8.GetString(arrRecvMessage, 0, arrRecvMessage.Length); //消息字节数组  //UTF8字节数组     
            }

            return recvMsg.Trim();
        }
        

    }
}
