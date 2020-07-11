using System;
using System.IO;
using System.Net;
using System.Text;

namespace Faker
{
    internal class HttpParamTask : TaskExecuter
    {
        private string uri;
        private string sendMsg;

        public HttpParamTask(HttpParamTaskInfo hi)
        {
            uri = hi.uri;
            sendMsg = hi.sendMsg;
        }

        public string execute()
        {
            string strResponse = doPost(uri, sendMsg);
            return strResponse;
        }

        //http参数报文
        public string doPost(string url, string content)
        {
            string result = "";
            try
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                req.Method = "POST";
                req.ContentType = "application/x-www-form-urlencoded";

                #region 添加Post 参数

                byte[] data = Encoding.UTF8.GetBytes(content);
                req.ContentLength = data.Length;
                using (Stream reqStream = req.GetRequestStream())
                {
                    reqStream.Write(data, 0, data.Length);
                    reqStream.Close();
                }

                #endregion 添加Post 参数

                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                Stream stream = resp.GetResponseStream();
                //获取响应内容
                using (StreamReader reader = new StreamReader(stream, Encoding.Default))
                {
                    result = reader.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                result = e.Message;
            }
            return result;
        }
    }
}