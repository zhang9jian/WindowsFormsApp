using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiTaskForm
{
    public partial class MultiTaskForm : Form
    {
        public delegate void SetRichTextCallbackDelegate(string text);

        public SetRichTextCallbackDelegate setRichTextCallbackDelegate;

        public MultiTaskForm()
        {
            InitializeComponent();
            // setRichTextCallbackDelegate = new SetRichTextCallbackDelegate(setRichTextCallback);
            setRichTextCallbackDelegate = delegate (string text)
            {
                this.richTextBox1.AppendText(text + "\r\n");
                richTextBox1.ScrollToCaret();
            };
        }

        /*  public void setRichTextCallback(string text)
          {
              this.richTextBox1.AppendText(text + "\r\n");
              richTextBox1.ScrollToCaret();
          }
        */

        private void btnStart_Click(object sender, EventArgs e)
        {
            startTask();
        }

        public void startTask()
        {
            Thread t = new Thread(new ThreadStart(delegate
            {
                start();
            }));
            t.IsBackground = true;
            t.Start();
        }

        public void start()
        {
            var maxCount = 1000;
            List<int> list = new List<int>();
            for (int i = 0; i < 100; i++)
            {
                list.Add(i);
            }

            Action<int> action = (i) =>
            {
                if (this.IsHandleCreated)
                    this.BeginInvoke(setRichTextCallbackDelegate, i.ToString() + " " + DateTime.Now.Ticks.ToString());
                Thread.Sleep(new Random(i).Next(100, 300));
            };

            List<Task> taskList = new List<Task>();
            foreach (var i in list)
            {
                int k = i;

                taskList.Add(Task.Run(() => action.Invoke(k)));
                if (taskList.Count > maxCount)
                {
                    Task.WaitAny(taskList.ToArray());
                    taskList = taskList.Where(at => at.Status != TaskStatus.RanToCompletion).ToList();
                }
            }
            //异步等待其全部执行完毕，不阻塞线程
            Task wTask = Task.WhenAll(taskList.ToArray());
            // wTask.ContinueWith()

            //死等线程全部执行完毕，阻塞后面的线程
            Task.WaitAll(taskList.ToArray());
        }

        private void btnStartThreadPool_Click(object sender, EventArgs e)
        {
            startThread();
        }

        public void startThread()
        {
            //启动工作者线程
            for (int i = 0; i < 100; i++)
                ThreadPool.QueueUserWorkItem(new WaitCallback(RunWorkerThread), i);
            Console.WriteLine("线程放置完成，立即执行！");
        }

        private void RunWorkerThread(object obj)
        {
            if (this.IsHandleCreated)
                this.BeginInvoke(setRichTextCallbackDelegate, obj.ToString() + " " + DateTime.Now.Ticks.ToString());
            Thread.Sleep(new Random((int)obj).Next(100, 300));
        }
    }
}