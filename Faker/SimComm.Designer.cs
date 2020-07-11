namespace Faker
{
    partial class FakerDlg
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FakerDlg));
            this.lbIP = new System.Windows.Forms.Label();
            this.lbPort = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.rcSendText = new System.Windows.Forms.RichTextBox();
            this.btnClearSend = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.cbxCommType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lbMsgType = new System.Windows.Forms.Label();
            this.cbxMsgType = new System.Windows.Forms.ComboBox();
            this.cbxIPAddress = new System.Windows.Forms.ComboBox();
            this.btnTryConn = new System.Windows.Forms.Button();
            this.txtURI = new System.Windows.Forms.TextBox();
            this.lbURI = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbxThreadCount = new System.Windows.Forms.ComboBox();
            this.btnMultiTask = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.rdBtnU8 = new System.Windows.Forms.RadioButton();
            this.rdBtnGBK = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.chkMQMode = new System.Windows.Forms.CheckBox();
            this.txtMsgHeadLength = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rcRecvText = new System.Windows.Forms.RichTextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lbStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStrip = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripEclipseTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.ckXMLFormat = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbIP
            // 
            this.lbIP.AutoSize = true;
            this.lbIP.Location = new System.Drawing.Point(6, 37);
            this.lbIP.Name = "lbIP";
            this.lbIP.Size = new System.Drawing.Size(98, 18);
            this.lbIP.TabIndex = 0;
            this.lbIP.Text = "服务器地址";
            // 
            // lbPort
            // 
            this.lbPort.AutoSize = true;
            this.lbPort.Location = new System.Drawing.Point(265, 37);
            this.lbPort.Name = "lbPort";
            this.lbPort.Size = new System.Drawing.Size(44, 18);
            this.lbPort.TabIndex = 2;
            this.lbPort.Text = "端口";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(316, 34);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(127, 28);
            this.txtPort.TabIndex = 1;
            this.txtPort.Text = "7289";
            this.txtPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPort_KeyPress);
            // 
            // rcSendText
            // 
            this.rcSendText.Location = new System.Drawing.Point(9, 19);
            this.rcSendText.Name = "rcSendText";
            this.rcSendText.Size = new System.Drawing.Size(949, 276);
            this.rcSendText.TabIndex = 9;
            this.rcSendText.Text = "";
            // 
            // btnClearSend
            // 
            this.btnClearSend.Location = new System.Drawing.Point(360, 31);
            this.btnClearSend.Name = "btnClearSend";
            this.btnClearSend.Size = new System.Drawing.Size(94, 34);
            this.btnClearSend.TabIndex = 14;
            this.btnClearSend.Text = "清空";
            this.btnClearSend.UseVisualStyleBackColor = true;
            this.btnClearSend.Click += new System.EventHandler(this.clearBtn_Click);
            // 
            // btnSend
            // 
            this.btnSend.AutoSize = true;
            this.btnSend.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSend.Location = new System.Drawing.Point(122, 31);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(94, 34);
            this.btnSend.TabIndex = 12;
            this.btnSend.Text = "发送";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.sendBtn_Click);
            // 
            // cbxCommType
            // 
            this.cbxCommType.DisplayMember = "1";
            this.cbxCommType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCommType.FormattingEnabled = true;
            this.cbxCommType.Items.AddRange(new object[] {
            "Socket",
            "HTTP",
            "MQ"});
            this.cbxCommType.Location = new System.Drawing.Point(110, 80);
            this.cbxCommType.Name = "cbxCommType";
            this.cbxCommType.Size = new System.Drawing.Size(149, 26);
            this.cbxCommType.TabIndex = 3;
            this.cbxCommType.Tag = "";
            this.cbxCommType.SelectedIndexChanged += new System.EventHandler(this.cbxCommType_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 18);
            this.label4.TabIndex = 10;
            this.label4.Text = "通讯方式";
            // 
            // lbMsgType
            // 
            this.lbMsgType.AutoSize = true;
            this.lbMsgType.Location = new System.Drawing.Point(265, 83);
            this.lbMsgType.Name = "lbMsgType";
            this.lbMsgType.Size = new System.Drawing.Size(80, 18);
            this.lbMsgType.TabIndex = 11;
            this.lbMsgType.Text = "报文类型";
            // 
            // cbxMsgType
            // 
            this.cbxMsgType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMsgType.FormattingEnabled = true;
            this.cbxMsgType.Items.AddRange(new object[] {
            "整型定长",
            "定长字节",
            "Http参数"});
            this.cbxMsgType.Location = new System.Drawing.Point(351, 80);
            this.cbxMsgType.Name = "cbxMsgType";
            this.cbxMsgType.Size = new System.Drawing.Size(121, 26);
            this.cbxMsgType.TabIndex = 4;
            this.cbxMsgType.SelectedIndexChanged += new System.EventHandler(this.cbxMsgType_SelectedIndexChanged);
            // 
            // cbxIPAddress
            // 
            this.cbxIPAddress.FormattingEnabled = true;
            this.cbxIPAddress.Items.AddRange(new object[] {
            "85.20.13.134",
            "85.20.13.136"});
            this.cbxIPAddress.Location = new System.Drawing.Point(110, 34);
            this.cbxIPAddress.Name = "cbxIPAddress";
            this.cbxIPAddress.Size = new System.Drawing.Size(149, 26);
            this.cbxIPAddress.TabIndex = 0;
            // 
            // btnTryConn
            // 
            this.btnTryConn.Location = new System.Drawing.Point(705, 74);
            this.btnTryConn.Name = "btnTryConn";
            this.btnTryConn.Size = new System.Drawing.Size(94, 34);
            this.btnTryConn.TabIndex = 6;
            this.btnTryConn.Text = "测试连接";
            this.btnTryConn.UseVisualStyleBackColor = true;
            this.btnTryConn.Click += new System.EventHandler(this.btnTryConn_Click);
            // 
            // txtURI
            // 
            this.txtURI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtURI.Location = new System.Drawing.Point(495, 32);
            this.txtURI.Name = "txtURI";
            this.txtURI.Size = new System.Drawing.Size(304, 28);
            this.txtURI.TabIndex = 2;
            this.txtURI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtURI_KeyPress);
            // 
            // lbURI
            // 
            this.lbURI.AutoSize = true;
            this.lbURI.Location = new System.Drawing.Point(449, 37);
            this.lbURI.Name = "lbURI";
            this.lbURI.Size = new System.Drawing.Size(35, 18);
            this.lbURI.TabIndex = 18;
            this.lbURI.Text = "URI";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbxThreadCount);
            this.groupBox1.Controls.Add(this.btnMultiTask);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.btnOpen);
            this.groupBox1.Controls.Add(this.btnSend);
            this.groupBox1.Controls.Add(this.btnClearSend);
            this.groupBox1.Location = new System.Drawing.Point(12, 452);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(702, 82);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "操作";
            // 
            // cbxThreadCount
            // 
            this.cbxThreadCount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxThreadCount.FormattingEnabled = true;
            this.cbxThreadCount.Items.AddRange(new object[] {
            "10",
            "50",
            "100",
            "500",
            "1000",
            "2000",
            "5000"});
            this.cbxThreadCount.Location = new System.Drawing.Point(594, 35);
            this.cbxThreadCount.Name = "cbxThreadCount";
            this.cbxThreadCount.Size = new System.Drawing.Size(79, 26);
            this.cbxThreadCount.TabIndex = 25;
            // 
            // btnMultiTask
            // 
            this.btnMultiTask.Location = new System.Drawing.Point(481, 31);
            this.btnMultiTask.Name = "btnMultiTask";
            this.btnMultiTask.Size = new System.Drawing.Size(94, 34);
            this.btnMultiTask.TabIndex = 15;
            this.btnMultiTask.Text = "开始循环";
            this.btnMultiTask.UseVisualStyleBackColor = true;
            this.btnMultiTask.Click += new System.EventHandler(this.btnMultiTask_Click);
            // 
            // btnSave
            // 
            this.btnSave.AutoSize = true;
            this.btnSave.Location = new System.Drawing.Point(236, 31);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(94, 34);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.AutoSize = true;
            this.btnOpen.Location = new System.Drawing.Point(12, 31);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(94, 34);
            this.btnOpen.TabIndex = 11;
            this.btnOpen.Text = "打开";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // rdBtnU8
            // 
            this.rdBtnU8.AutoSize = true;
            this.rdBtnU8.Location = new System.Drawing.Point(66, 38);
            this.rdBtnU8.Name = "rdBtnU8";
            this.rdBtnU8.Size = new System.Drawing.Size(78, 22);
            this.rdBtnU8.TabIndex = 17;
            this.rdBtnU8.TabStop = true;
            this.rdBtnU8.Text = "UTF-8";
            this.rdBtnU8.UseVisualStyleBackColor = true;
            this.rdBtnU8.MouseClick += new System.Windows.Forms.MouseEventHandler(this.rdBtnU8_MouseClick);
            // 
            // rdBtnGBK
            // 
            this.rdBtnGBK.AutoSize = true;
            this.rdBtnGBK.Location = new System.Drawing.Point(6, 38);
            this.rdBtnGBK.Name = "rdBtnGBK";
            this.rdBtnGBK.Size = new System.Drawing.Size(60, 22);
            this.rdBtnGBK.TabIndex = 16;
            this.rdBtnGBK.TabStop = true;
            this.rdBtnGBK.Text = "GBK";
            this.rdBtnGBK.UseVisualStyleBackColor = true;
            this.rdBtnGBK.MouseClick += new System.Windows.Forms.MouseEventHandler(this.rdbtnGBK_MouseClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Controls.Add(this.chkMQMode);
            this.groupBox2.Controls.Add(this.txtMsgHeadLength);
            this.groupBox2.Controls.Add(this.btnTryConn);
            this.groupBox2.Controls.Add(this.lbIP);
            this.groupBox2.Controls.Add(this.lbPort);
            this.groupBox2.Controls.Add(this.lbURI);
            this.groupBox2.Controls.Add(this.txtPort);
            this.groupBox2.Controls.Add(this.txtURI);
            this.groupBox2.Controls.Add(this.cbxCommType);
            this.groupBox2.Controls.Add(this.cbxIPAddress);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cbxMsgType);
            this.groupBox2.Controls.Add(this.lbMsgType);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(972, 127);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "服务端参数";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Faker.Properties.Resources.lgirl;
            this.pictureBox1.Location = new System.Drawing.Point(836, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(122, 96);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseEnter += new System.EventHandler(this.pictureBox1_MouseEnter);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            // 
            // chkMQMode
            // 
            this.chkMQMode.AutoSize = true;
            this.chkMQMode.Location = new System.Drawing.Point(614, 83);
            this.chkMQMode.Name = "chkMQMode";
            this.chkMQMode.Size = new System.Drawing.Size(88, 22);
            this.chkMQMode.TabIndex = 19;
            this.chkMQMode.Text = "取消息";
            this.chkMQMode.UseVisualStyleBackColor = true;
            this.chkMQMode.CheckedChanged += new System.EventHandler(this.chkMQMode_CheckedChanged);
            // 
            // txtMsgHeadLength
            // 
            this.txtMsgHeadLength.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.txtMsgHeadLength.Location = new System.Drawing.Point(495, 80);
            this.txtMsgHeadLength.MaxLength = 2;
            this.txtMsgHeadLength.Name = "txtMsgHeadLength";
            this.txtMsgHeadLength.Size = new System.Drawing.Size(99, 28);
            this.txtMsgHeadLength.TabIndex = 5;
            this.txtMsgHeadLength.Text = "报文头长度";
            this.txtMsgHeadLength.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtMsgHeadLength_MouseClick);
            this.txtMsgHeadLength.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMsgHeadLength_KeyPress);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rcSendText);
            this.groupBox3.Location = new System.Drawing.Point(12, 145);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(972, 301);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "发送报文";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rcRecvText);
            this.groupBox4.Location = new System.Drawing.Point(6, 550);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(978, 362);
            this.groupBox4.TabIndex = 18;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "接收报文";
            // 
            // rcRecvText
            // 
            this.rcRecvText.Location = new System.Drawing.Point(13, 27);
            this.rcRecvText.Name = "rcRecvText";
            this.rcRecvText.Size = new System.Drawing.Size(951, 319);
            this.rcRecvText.TabIndex = 19;
            this.rcRecvText.Text = "";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.rdBtnU8);
            this.groupBox5.Controls.Add(this.rdBtnGBK);
            this.groupBox5.Location = new System.Drawing.Point(724, 452);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(155, 82);
            this.groupBox5.TabIndex = 15;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "报文编码";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbStatus,
            this.toolStripStatusLabel1,
            this.toolStripProgressBar1,
            this.toolStrip,
            this.toolStripEclipseTime});
            this.statusStrip1.Location = new System.Drawing.Point(0, 911);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(996, 29);
            this.statusStrip1.TabIndex = 23;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = false;
            this.lbStatus.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(180, 24);
            this.lbStatus.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 24);
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(180, 23);
            // 
            // toolStrip
            // 
            this.toolStrip.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(4, 24);
            // 
            // toolStripEclipseTime
            // 
            this.toolStripEclipseTime.Name = "toolStripEclipseTime";
            this.toolStripEclipseTime.Size = new System.Drawing.Size(0, 24);
            // 
            // ckXMLFormat
            // 
            this.ckXMLFormat.AutoSize = true;
            this.ckXMLFormat.Location = new System.Drawing.Point(887, 490);
            this.ckXMLFormat.Name = "ckXMLFormat";
            this.ckXMLFormat.Size = new System.Drawing.Size(97, 22);
            this.ckXMLFormat.TabIndex = 24;
            this.ckXMLFormat.Text = "xml美化";
            this.ckXMLFormat.UseVisualStyleBackColor = true;
            this.ckXMLFormat.CheckedChanged += new System.EventHandler(this.ckXMLFormat_CheckedChanged);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FakerDlg
            // 
            this.AcceptButton = this.btnTryConn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(996, 940);
            this.Controls.Add(this.ckXMLFormat);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FakerDlg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "模拟交易_v0.1  ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSimDlg_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbIP;
        private System.Windows.Forms.Label lbPort;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.RichTextBox rcSendText;
        private System.Windows.Forms.Button btnClearSend;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.ComboBox cbxCommType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbMsgType;
        private System.Windows.Forms.ComboBox cbxMsgType;
        private System.Windows.Forms.ComboBox cbxIPAddress;
        private System.Windows.Forms.Button btnTryConn;
        private System.Windows.Forms.TextBox txtURI;
        private System.Windows.Forms.Label lbURI;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RichTextBox rcRecvText;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.RadioButton rdBtnU8;
        private System.Windows.Forms.RadioButton rdBtnGBK;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lbStatus;
        private System.Windows.Forms.TextBox txtMsgHeadLength;
        private System.Windows.Forms.CheckBox ckXMLFormat;
        private System.Windows.Forms.CheckBox chkMQMode;
        private System.Windows.Forms.Button btnMultiTask;
        private System.Windows.Forms.ComboBox cbxThreadCount;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripEclipseTime;
    }
}

