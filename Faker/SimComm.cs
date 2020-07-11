using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace Faker
{
    public partial class FakerDlg : Form
    {
        private int i;
        private IPAddress ipAddr;
        private IPEndPoint ipEnd;
        private Socket socket;
        private DateTime dtStart, dtEnd;
        public bool bStopLoop = false;
        public bool bSingleMode = true;

        public delegate void RichTextDelegate(string text);

        public delegate bool GetStopSignal();

        public RichTextDelegate richTextDelegate;
        private GetStopSignal getStopSignal;

        public FakerDlg()
        {
            InitializeComponent();
            richTextDelegate = delegate (string text)
            {
                this.rcRecvText.AppendText(text + "\r\n");
                notifyProgressBar();
                rcRecvText.ScrollToCaret();
            };
            getStopSignal = delegate ()
            {
                if (bStopLoop == true)
                    return true;
                else
                    return false;
            };
        }

        private void notifyProgressBar()
        {
            if (bSingleMode) return;
            toolStripProgressBar1.Value += 1;
            lbStatus.Text = "已发送：" + Convert.ToString(toolStripProgressBar1.Value);
            dtEnd = DateTime.Now;
            toolStripEclipseTime.Text = "时间： " + DateTime.Now.ToString("T");
            if (toolStripProgressBar1.Value == toolStripProgressBar1.Maximum)
            {
                btnMultiTask.Text = "开始循环";
                toolStripProgressBar1.Value = 0;
                TimeSpan tsp = DateTime.Now.Subtract(dtStart);
                toolStripEclipseTime.Text += " 共耗时：" + tsp.Seconds.ToString() + "秒";
                MessageBox.Show("完成发送，共发送交易笔数" + Convert.ToString(toolStripProgressBar1.Maximum));
            }
        }

        //发送报文
        private void sendBtn_Click(object sender, EventArgs e)
        {
            if (checkServerParam() == false)
                return;
            try
            {
                string ip = cbxIPAddress.Text.Trim();
                string port = txtPort.Text.Trim();
                string sendMsg = rcSendText.Text.Trim();
                bool isGBK = rdBtnGBK.Checked;
                string msgHeadLen = txtMsgHeadLength.Text.Trim();
                string uri = txtURI.Text.Trim();
                bool msgMode = chkMQMode.Checked;//取消息true;
                string recvMsg = "";
                bSingleMode = true;
                TaskExecuter tasker;

                switch (cbxMsgType.Text)
                {
                    case "整型定长":
                        FixedHeadTaskInfo fixedHeadTaskInfo = new FixedHeadTaskInfo(ip, port, sendMsg, isGBK);
                        tasker = new FixedHeadTask(fixedHeadTaskInfo);
                        recvMsg = tasker.execute();
                        break;

                    case "定长字节":
                        FixedByteTaskInfo fixedByteTaskInfo = new FixedByteTaskInfo(ip, port, sendMsg, isGBK, msgHeadLen);
                        tasker = new FixedByteTask(fixedByteTaskInfo);
                        recvMsg = tasker.execute();
                        break;

                    case "不定长字节":
                        ByteTaskInfo byteTaskInfo = new ByteTaskInfo(ip, port, sendMsg, isGBK);
                        tasker = new ByteTask(byteTaskInfo);
                        recvMsg = tasker.execute();
                        break;

                    case "HTTP参数":
                        HttpParamTaskInfo httpParamTaskInfo = new HttpParamTaskInfo(uri, sendMsg);
                        tasker = new HttpParamTask(httpParamTaskInfo);
                        recvMsg = tasker.execute();
                        break;

                    case "MQ报文":
                        MQTaskInfo mqTaskInfo = new MQTaskInfo(sendMsg, msgMode);
                        tasker = new MQTask(mqTaskInfo);
                        recvMsg = tasker.execute();
                        break;
                }
                richTextDelegate(recvMsg);
                lbStatus.Text = "发送完毕";
            }
            catch (SocketException ex)
            {
                MessageBox.Show("连接失败，失败原因：" + ex.Message);
                return;
            }
        }

        //检查服务器端连接参数  //todo 还需要看看uri可用性
        public Boolean checkServerParam()
        {
            if (txtPort.Enabled == true && txtPort.Text.Trim() == "")
            {
                MessageBox.Show("端口不能为空");
                return false;
            }

            if (rcSendText.Text.Trim() == "")
            {
                MessageBox.Show("消息不能为空");
                return false;
            }

            if (txtMsgHeadLength.Enabled == true && txtMsgHeadLength.Text.Trim() == "")
            {
                MessageBox.Show("消息头长度不能为空");
                return false;
            }

            if (txtMsgHeadLength.Enabled == true && txtMsgHeadLength.Text.IndexOf("（") > 0)
            {
                MessageBox.Show("消息头长度设置不正确");
                return false;
            }

            if (txtURI.Enabled == true && txtURI.Text.Trim() == "")
            {
                MessageBox.Show("HTTP参数报文，URI不能为空");
                return false;
            }

            if ((!rdBtnGBK.Checked) && (!rdBtnU8.Checked))
            {
                MessageBox.Show("请选择报文编码");
                return false;
            }
            return true;
        }

        //清空文本消息框
        private void clearBtn_Click(object sender, EventArgs e)
        {
            rcSendText.Clear();
            rcRecvText.Clear();
            lbStatus.Text = "清空完毕";
        }

        //初始化对话框
        private void Form1_Load(object sender, EventArgs e)
        {
            cbxIPAddress.SelectedIndex = 0;
            cbxCommType.SelectedIndex = 0;
            cbxMsgType.SelectedIndex = 0;
            txtMsgHeadLength.MaxLength = 2;
            txtMsgHeadLength.Enabled = false;
            txtURI.Enabled = false;
            cbxThreadCount.SelectedIndex = 0;
            Image lboy = Properties.Resources.lboy;
            pictureBox1.Image = lboy;
        }

        //socket连接服务器
        public Socket connectSocket()
        {
            if ((socket == null) || (!socket.Connected))
            {
                string ip = cbxIPAddress.Text.Trim();
                int port = Convert.ToInt32(txtPort.Text.Trim());
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

        //关闭对话框
        private void btnClose_Click(object sender, EventArgs e)
        {
            if ((socket != null) && (socket.Connected))
            {
                MessageBox.Show("当期有活动连接");
                return;
            }
            Close();
        }

        //打开文件
        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;
            dialog.Title = "请选择发送报文txt文本文件";
            dialog.Filter = "文本文件(*.txt)|*.txt";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = dialog.FileName;
                Encoding en = EncodingType.GetType(fileName);
                string text = System.IO.File.ReadAllText(fileName, en).Trim();
                rcSendText.Text = text;
                if (en.EncodingName.IndexOf("UTF") > 0)
                    rdBtnU8.Select();
                if (en.EncodingName.IndexOf("GB") > 0)
                    rdBtnGBK.Select();
            }
        }

        //保存消息
        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "文本文件(*.txt)|*.txt|All files(*.*)|*.*";
            dialog.RestoreDirectory = true;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = (FileStream)dialog.OpenFile();
                try
                {
                    string fileName = dialog.FileName.ToString();
                    string strSend = DateTime.Now.ToString("F") + " 发送：\r\n" + rcSendText.Text + "\r\n";
                    string strRecv = DateTime.Now.ToString("F") + " 接收:  \r\n" + rcRecvText.Text + "\r\n";
                    string msg = strSend + strRecv;
                    byte[] data = Encoding.Default.GetBytes(msg);
                    fs.Write(data, 0, data.Length);
                    fs.Flush();
                    fs.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    lbStatus.Text = ex.Message;
                    fs.Close();
                    return;
                }
                lbStatus.Text = "保存完毕";
            }
        }

        //更改文本编码GBK
        private void rdbtnGBK_MouseClick(object sender, MouseEventArgs e)
        {
            rcSendText.Text = EncodingType.UTF8ToGBK(rcSendText.Text.Trim());
            rcSendText.Update();
        }

        //更改文件编码为u8
        private void rdBtnU8_MouseClick(object sender, MouseEventArgs e)
        {
            rcSendText.Text = EncodingType.GBKToUTF8(rcSendText.Text.Trim());
            rcSendText.Update();
        }

        //更改通讯类型
        private void cbxCommType_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxMsgType.Items.Clear();
            chkMQMode.Checked = false;
            if (cbxCommType.SelectedIndex == 0)
            {
                cbxMsgType.Items.AddRange(new string[] { "整型定长", "定长字节", "不定长字节" });
                chkMQMode.Enabled = false;
            }
            if (cbxCommType.SelectedIndex == 1)
            {
                cbxMsgType.Items.AddRange(new string[] { "HTTP参数" });
                chkMQMode.Enabled = false;
            }
            if (cbxCommType.SelectedIndex == 2)
            {
                cbxMsgType.Items.AddRange(new string[] { "MQ报文" });
                chkMQMode.Enabled = true;
            }
            cbxMsgType.SelectedIndex = 0;
        }

        //设置定长字节报文头长度
        private void txtMsgHeadLength_MouseClick(object sender, MouseEventArgs e)
        {
            txtMsgHeadLength.Clear();
            txtMsgHeadLength.ForeColor = Color.Black;
            lbStatus.Text = "定长字节报文头长度，单位字节";
        }

        //更改消息类型
        private void cbxMsgType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxMsgType.Text == "定长字节")
            {
                txtMsgHeadLength.Enabled = true;
            }
            else
            {
                txtMsgHeadLength.Enabled = false;
            }

            if (cbxMsgType.Text == "HTTP参数")
            {
                txtURI.Enabled = true;
                cbxIPAddress.Enabled = false;
                txtPort.Enabled = false;
            }
            else
            {
                txtURI.Enabled = false;
                cbxIPAddress.Enabled = true;
                txtPort.Enabled = true;
            }
            if (cbxMsgType.Text == "MQ报文")
            {
                lbStatus.Text = "请确认MQ.ini文件配置正确";
                cbxIPAddress.Enabled = false;
                txtPort.Enabled = false;
                txtURI.Enabled = false;
            }
            else
            {
                lbStatus.Text = "";
            }
        }

        //控制报文头长度只能为数字
        private void txtMsgHeadLength_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8)
                e.Handled = true;
            if (e.KeyChar == (char)13)
                SendKeys.Send("{Tab}");
        }

        //关闭对话框
        private void frmSimDlg_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((socket != null) && (socket.Connected))
            {
                MessageBox.Show("当期有活动连接");
                e.Cancel = true;
                return;
            }
            DialogResult result;
            result = MessageBox.Show("确定退出吗？", "退出",
                                        MessageBoxButtons.OKCancel,
                                        MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                Application.ExitThread();
            }
            else
            {
                e.Cancel = true;
            }
        }

        //控制文本框回车改为tab
        private void keyTab(KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                SendKeys.Send("{Tab}");
        }

        //控制文本框回车改为tab
        private void txtPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyTab(e);
        }

        //控制文本框回车改为tab
        private void txtURI_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyTab(e);
        }

        //xml格式化
        private void ckXMLFormat_CheckedChanged(object sender, EventArgs e)
        {
            string str = rcSendText.Text.Trim();
            if (str == "" || str == null) return;
            if (ckXMLFormat.Checked)
            {
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.LoadXml(str);
                MemoryStream mstream = new MemoryStream();
                XmlTextWriter writer = new XmlTextWriter(mstream, null);
                writer.Formatting = Formatting.Indented;

                xmldoc.WriteTo(writer);
                writer.Flush();
                writer.Close();

                Encoding encoding;
                if (rdBtnGBK.Checked)
                    encoding = Encoding.GetEncoding("GBK");
                else
                    encoding = Encoding.GetEncoding("UTF-8");
                string strReturn = encoding.GetString(mstream.ToArray()).Trim();
                mstream.Close();
                rcSendText.Text = strReturn;
            }
        }

        //连接测试
        private void btnTryConn_Click(object sender, EventArgs e)
        {
            try
            {
                switch (cbxCommType.SelectedIndex)
                {
                    case 0:
                        if (txtPort.Text.Trim() == "")
                        {
                            MessageBox.Show("端口号不能为空");
                            return;
                        }
                        connectSocket();
                        closeSocket();
                        MessageBox.Show("连接成功");
                        lbStatus.Text = "连接成功";
                        break;

                    default:
                        MessageBox.Show("连接测试仅限于Socket方式");
                        break;
                }
            }
            catch (SocketException ex)
            {
                MessageBox.Show("连接失败，失败原因：" + ex.Message);
                lbStatus.Text = "连接失败";
                return;
            }
        }

        private void chkMQMode_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMQMode.Checked)
            {
                btnSend.Text = "取消息";
            }
            else
            {
                btnSend.Text = "发送";
            }
        }

        private void btnMultiTask_Click(object sender, EventArgs e)
        {
            if (checkServerParam() == false)
                return;
            if (btnMultiTask.Text == "开始循环")
            {
                bStopLoop = false;
                bSingleMode = false;
                btnMultiTask.Text = "停止循环";
                toolStripProgressBar1.Value = 0;
                dtStart = DateTime.Now;
                toolStripProgressBar1.Maximum = Convert.ToInt32(cbxThreadCount.Text);
                startMultiTaskThread();
            }
            else
            {
                bStopLoop = true;
                btnMultiTask.Text = "开始循环";
            }
        }

        public void startMultiTaskThread()
        {
            string msgType = cbxMsgType.Text.Trim();
            int count = Int32.Parse(cbxThreadCount.Text.Trim());
            if (msgType.Equals("整型定长"))
            {
                FixedHeadTaskInfo fixedHeadTasknfo = new FixedHeadTaskInfo(cbxIPAddress.Text.Trim(), txtPort.Text.Trim(), rcSendText.Text.Trim(), rdBtnGBK.Checked);
                //启动工作者线程
                for (int i = 0; i < count; i++)//不能在这里终止，循环速度太快。所以在子线程里判断状态
                {
                    ThreadPool.QueueUserWorkItem(new WaitCallback(FixedHeadTaskWorkerThread), fixedHeadTasknfo);
                }
            }
            if (msgType.Equals("定长字节"))
            {
                FixedByteTaskInfo fixedByteTasknfo = new FixedByteTaskInfo(cbxIPAddress.Text.Trim(), txtPort.Text.Trim(), rcSendText.Text.Trim(), rdBtnGBK.Checked, txtMsgHeadLength.Text.Trim());
                //启动工作者线程
                for (int i = 0; i < count; i++)
                    ThreadPool.QueueUserWorkItem(new WaitCallback(FixedByteTaskWorkerThread), fixedByteTasknfo);
            }

            if (msgType.Equals("不定长字节"))
            {
                ByteTaskInfo byteTasknfo = new ByteTaskInfo(cbxIPAddress.Text.Trim(), txtPort.Text.Trim(), rcSendText.Text.Trim(), rdBtnGBK.Checked);
                //启动工作者线程
                for (int i = 0; i < count; i++)
                    ThreadPool.QueueUserWorkItem(new WaitCallback(byteTaskWorkerThread), byteTasknfo);
            }

            if (msgType.Equals("HTTP参数"))
            {
                HttpParamTaskInfo httpParamTaskInfo = new HttpParamTaskInfo(txtURI.Text.Trim(), rcSendText.Text.Trim());
                //启动工作者线程
                for (int i = 0; i < count; i++)
                    ThreadPool.QueueUserWorkItem(new WaitCallback(HttpParamTaskWorkerThread), httpParamTaskInfo);
            }
            if (msgType.Equals("MQ报文"))
            {
                MQTaskInfo mqTaskInfo = new MQTaskInfo(rcSendText.Text.Trim(), chkMQMode.Checked);
                //启动工作者线程
                for (int i = 0; i < count; i++)
                    ThreadPool.QueueUserWorkItem(new WaitCallback(MQTaskWorkerThread), mqTaskInfo);
            }

            Console.WriteLine("线程放置完成，立即执行！");
        }

        private bool stopLoop()
        {
            IAsyncResult isr = this.BeginInvoke(getStopSignal);
            bool bStopLoop = (bool)this.EndInvoke(isr);
            return bStopLoop;
        }

        private void FixedHeadTaskWorkerThread(object obj)
        {
            if (stopLoop()) return;
            FixedHeadTaskInfo fixedHeadTaskInfo = (FixedHeadTaskInfo)obj;
            FixedHeadTask fixedHeadTask = new FixedHeadTask(fixedHeadTaskInfo);
            string recvMsg = fixedHeadTask.execute();
            if (this.IsHandleCreated)
                this.BeginInvoke(richTextDelegate, Thread.CurrentThread.ManagedThreadId + "   " + recvMsg);
            Thread.Sleep(1000);
        }

        private void FixedByteTaskWorkerThread(object obj)
        {
            if (stopLoop()) return;

            FixedByteTaskInfo fixedByteTaskInfo = (FixedByteTaskInfo)obj;
            FixedByteTask fixedByteTask = new FixedByteTask(fixedByteTaskInfo);
            string recvMsg = fixedByteTask.execute();
            if (this.IsHandleCreated)
                this.BeginInvoke(richTextDelegate, Thread.CurrentThread.ManagedThreadId + "   " + recvMsg);
            Thread.Sleep(1000);
        }

        private void byteTaskWorkerThread(object obj)
        {
            if (stopLoop()) return;

            ByteTaskInfo byteTaskInfo = (ByteTaskInfo)obj;
            ByteTask byteTask = new ByteTask(byteTaskInfo);
            string recvMsg = byteTask.execute();
            if (this.IsHandleCreated)
                this.BeginInvoke(richTextDelegate, Thread.CurrentThread.ManagedThreadId + "   " + recvMsg);
            Thread.Sleep(1000);
        }

        private void HttpParamTaskWorkerThread(object obj)
        {
            if (stopLoop()) return;

            HttpParamTaskInfo httpParamTaskInfo = (HttpParamTaskInfo)obj;
            HttpParamTask httpParamTask = new HttpParamTask(httpParamTaskInfo);
            string recvMsg = httpParamTask.execute();
            if (this.IsHandleCreated)
                this.BeginInvoke(richTextDelegate, Thread.CurrentThread.ManagedThreadId + "   " + recvMsg);
            Thread.Sleep(1000);
        }

        private void MQTaskWorkerThread(object obj)
        {
            if (stopLoop()) return;

            MQTaskInfo mqTaskInfo = (MQTaskInfo)obj;
            MQTask mqTask = new MQTask(mqTaskInfo);
            string recvMsg = mqTask.execute();
            if (this.IsHandleCreated)
                this.BeginInvoke(richTextDelegate, Thread.CurrentThread.ManagedThreadId + "   " + recvMsg);
            Thread.Sleep(1000);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Text = Text.Substring(1) + Text.Substring(0, 1);
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            Image lgirl = Properties.Resources.lgirl;
            pictureBox1.Image = lgirl;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            Image lboy = Properties.Resources.lboy;
            pictureBox1.Image = lboy;
        }
    }

    public struct FixedHeadTaskInfo
    {
        public string ip;
        public string port;
        public string sendMsg;
        public bool isGBK;

        public FixedHeadTaskInfo(string _ip, string _port, string _msg, bool _isGBK)
        {
            ip = _ip;
            port = _port;
            sendMsg = _msg;
            isGBK = _isGBK;
        }
    }

    public struct FixedByteTaskInfo
    {
        public string ip;
        public string port;
        public string sendMsg;
        public bool isGBK;
        public string headLen;

        public FixedByteTaskInfo(string _ip, string _port, string _msg, bool _isGBK, string _headLen)
        {
            ip = _ip;
            port = _port;
            sendMsg = _msg;
            isGBK = _isGBK;
            headLen = _headLen;
        }
    }

    public struct ByteTaskInfo
    {
        public string ip;
        public string port;
        public string sendMsg;
        public bool isGBK;

        public ByteTaskInfo(string _ip, string _port, string _msg, bool _isGBK)
        {
            ip = _ip;
            port = _port;
            sendMsg = _msg;
            isGBK = _isGBK;
        }
    }

    public struct HttpParamTaskInfo
    {
        public string uri;
        public string sendMsg;

        public HttpParamTaskInfo(string _uri, string _sendMsg)
        {
            uri = _uri;
            sendMsg = _sendMsg;
        }
    }

    public struct MQTaskInfo
    {
        public string sendMsg;
        public bool msgMode;

        public MQTaskInfo(string _sendMsg, bool _msgMode)
        {
            sendMsg = _sendMsg;
            msgMode = _msgMode;
        }
    }
}