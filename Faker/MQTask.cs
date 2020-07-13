using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Runtime.InteropServices;
using IBM.WMQ.PCF;
using IBM.WMQ;
namespace Faker
{
    class MQTask : TaskExecuter
    {
        static MQQueueManager qMgr;
        static MQQueue queue;
        static string qmgrName;
        static string queueName;
        string sendMsg;
        bool msgMode;
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);


        public MQTask(MQTaskInfo mi)
        {
            sendMsg = mi.sendMsg;
            msgMode = mi.msgMode;
        }

       
        //MQ通讯
        public string execute()
        {            
            try
            {
                initMQEnvironment();

            }
            catch (Exception ex)
            {
               return "初始化MQ环境失败：" + ex.Message;
            }
            if (msgMode)
            {
                string mqMsg = getMessage(queueName);
                return mqMsg;
            }
            else
            {
               
                string result = sendMessage(sendMsg, queueName);
                return result;
            }
        }

        public void initMQEnvironment()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\MQ.ini";
            MQEnvironment.Hostname = GetConfigPara("MQConfig", "HostIP", path);
            MQEnvironment.Channel = GetConfigPara("MQConfig", "Channel", path);
            MQEnvironment.Port = Convert.ToInt32(GetConfigPara("MQConfig", "Port", path));
            MQEnvironment.UserId = "mqm";
            MQEnvironment.Password = "mqm";
            string ccsid = GetConfigPara("MQConfig", "MQCCSID", path);
            Environment.SetEnvironmentVariable("MQCCSID", ccsid);//字符编码
            qmgrName = GetConfigPara("MQConfig", "MQQueueManager", path);
            queueName = GetConfigPara("MQConfig", "MQQueueName", path);
            qMgr = new MQQueueManager(qmgrName);
        }

        string sendMessage(string message, string queueName)
        {
            try
            {
                queue = qMgr.AccessQueue(queueName, MQC.MQOO_OUTPUT | MQC.MQOO_INPUT_SHARED | MQC.MQOO_INQUIRE);
            }
            catch (MQException e)
            {
               return ("打开队列失败：" + e.Message);
            }
            var mqMsg = new MQMessage();
            mqMsg.WriteString(message);
            var putOptions = new MQPutMessageOptions();
            try
            {
                queue.Put(mqMsg, putOptions);
               return ("消息放置完毕");
            }
            catch (MQException mqe)
            {
                return ("发送异常终止：" + mqe.Message);
            }
            finally
            {
                try
                {
                    qMgr.Disconnect();

                }
                catch (MQException e)
                {

                }
            }

        }

        string getMessage(string queueName)
        {
            try
            {
                queue = qMgr.AccessQueue(queueName, MQC.MQOO_OUTPUT | MQC.MQOO_INPUT_SHARED | MQC.MQOO_INQUIRE);
            }
            catch (MQException e)
            {
                return ("打开队列失败：" + e.Message);
            }
            try
            {
                MQMessage message = new MQMessage();
                queue.Get(message);
                string s = message.ReadString(message.MessageLength);
                return s;
            }
            catch (MQException mqe)
            {
               // return ("获取异常终止：" + mqe.Message);
            }
            finally
            {
                try
                {
                    qMgr.Disconnect();

                }
                catch (MQException e)
                {

                }

            }
            return "";

        }

        public static string GetConfigPara(string field, string Key, string filepath)
        {
            StringBuilder temp = new StringBuilder(500);
            int i = GetPrivateProfileString(field, Key, "", temp, 500, filepath);
            return temp.ToString();
        }

    }
}
