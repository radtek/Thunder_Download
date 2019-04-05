namespace XLPlatform
{
    partial class Config_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
        	this.label1 = new System.Windows.Forms.Label();
        	this.label2 = new System.Windows.Forms.Label();
        	this.ltb_DownloadFileNameList = new System.Windows.Forms.ListBox();
        	this.txb_IP = new System.Windows.Forms.TextBox();
        	this.txb_Port = new System.Windows.Forms.TextBox();
        	this.btn_Apply = new System.Windows.Forms.Button();
        	this.label3 = new System.Windows.Forms.Label();
        	this.textBox1 = new System.Windows.Forms.TextBox();
        	this.label4 = new System.Windows.Forms.Label();
        	this.textBox2 = new System.Windows.Forms.TextBox();
        	this.label5 = new System.Windows.Forms.Label();
        	this.label6 = new System.Windows.Forms.Label();
        	this.label7 = new System.Windows.Forms.Label();
        	this.SuspendLayout();
        	// 
        	// label1
        	// 
        	this.label1.AutoSize = true;
        	this.label1.Location = new System.Drawing.Point(27, 24);
        	this.label1.Name = "label1";
        	this.label1.Size = new System.Drawing.Size(17, 12);
        	this.label1.TabIndex = 0;
        	this.label1.Text = "IP";
        	// 
        	// label2
        	// 
        	this.label2.AutoSize = true;
        	this.label2.Location = new System.Drawing.Point(233, 24);
        	this.label2.Name = "label2";
        	this.label2.Size = new System.Drawing.Size(29, 12);
        	this.label2.TabIndex = 0;
        	this.label2.Text = "端口";
        	// 
        	// ltb_DownloadFileNameList
        	// 
        	this.ltb_DownloadFileNameList.Dock = System.Windows.Forms.DockStyle.Bottom;
        	this.ltb_DownloadFileNameList.FormattingEnabled = true;
        	this.ltb_DownloadFileNameList.ItemHeight = 12;
        	this.ltb_DownloadFileNameList.Location = new System.Drawing.Point(0, 122);
        	this.ltb_DownloadFileNameList.Name = "ltb_DownloadFileNameList";
        	this.ltb_DownloadFileNameList.Size = new System.Drawing.Size(545, 352);
        	this.ltb_DownloadFileNameList.TabIndex = 1;
        	// 
        	// txb_IP
        	// 
        	this.txb_IP.Location = new System.Drawing.Point(74, 21);
        	this.txb_IP.Name = "txb_IP";
        	this.txb_IP.Size = new System.Drawing.Size(129, 21);
        	this.txb_IP.TabIndex = 2;
        	this.txb_IP.Text = "127.0.0.1";
        	// 
        	// txb_Port
        	// 
        	this.txb_Port.Location = new System.Drawing.Point(289, 21);
        	this.txb_Port.Name = "txb_Port";
        	this.txb_Port.Size = new System.Drawing.Size(129, 21);
        	this.txb_Port.TabIndex = 2;
        	this.txb_Port.Text = "8080";
        	// 
        	// btn_Apply
        	// 
        	this.btn_Apply.Location = new System.Drawing.Point(438, 33);
        	this.btn_Apply.Name = "btn_Apply";
        	this.btn_Apply.Size = new System.Drawing.Size(84, 38);
        	this.btn_Apply.TabIndex = 3;
        	this.btn_Apply.Text = "应用";
        	this.btn_Apply.UseVisualStyleBackColor = true;
        	this.btn_Apply.Click += new System.EventHandler(this.btn_Apply_Click);
        	// 
        	// label3
        	// 
        	this.label3.AutoSize = true;
        	this.label3.Location = new System.Drawing.Point(233, 63);
        	this.label3.Name = "label3";
        	this.label3.Size = new System.Drawing.Size(77, 12);
        	this.label3.TabIndex = 0;
        	this.label3.Text = "消息循环间隔";
        	// 
        	// textBox1
        	// 
        	this.textBox1.Location = new System.Drawing.Point(314, 60);
        	this.textBox1.Name = "textBox1";
        	this.textBox1.Size = new System.Drawing.Size(71, 21);
        	this.textBox1.TabIndex = 2;
        	this.textBox1.Text = "1000";
        	// 
        	// label4
        	// 
        	this.label4.AutoSize = true;
        	this.label4.Location = new System.Drawing.Point(27, 63);
        	this.label4.Name = "label4";
        	this.label4.Size = new System.Drawing.Size(65, 12);
        	this.label4.TabIndex = 0;
        	this.label4.Text = "缓冲区大小";
        	// 
        	// textBox2
        	// 
        	this.textBox2.Location = new System.Drawing.Point(98, 57);
        	this.textBox2.Name = "textBox2";
        	this.textBox2.Size = new System.Drawing.Size(90, 21);
        	this.textBox2.TabIndex = 2;
        	this.textBox2.Text = "40960";
        	// 
        	// label5
        	// 
        	this.label5.AutoSize = true;
        	this.label5.Location = new System.Drawing.Point(194, 64);
        	this.label5.Name = "label5";
        	this.label5.Size = new System.Drawing.Size(29, 12);
        	this.label5.TabIndex = 0;
        	this.label5.Text = "字节";
        	// 
        	// label6
        	// 
        	this.label6.Location = new System.Drawing.Point(391, 62);
        	this.label6.Name = "label6";
        	this.label6.Size = new System.Drawing.Size(41, 18);
        	this.label6.TabIndex = 4;
        	this.label6.Text = "毫秒";
        	// 
        	// label7
        	// 
        	this.label7.Location = new System.Drawing.Point(12, 96);
        	this.label7.Name = "label7";
        	this.label7.Size = new System.Drawing.Size(100, 23);
        	this.label7.TabIndex = 5;
        	this.label7.Text = "批量任务列表";
        	// 
        	// Config_Form
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(545, 474);
        	this.Controls.Add(this.label7);
        	this.Controls.Add(this.label6);
        	this.Controls.Add(this.btn_Apply);
        	this.Controls.Add(this.textBox2);
        	this.Controls.Add(this.textBox1);
        	this.Controls.Add(this.txb_Port);
        	this.Controls.Add(this.txb_IP);
        	this.Controls.Add(this.ltb_DownloadFileNameList);
        	this.Controls.Add(this.label4);
        	this.Controls.Add(this.label5);
        	this.Controls.Add(this.label3);
        	this.Controls.Add(this.label2);
        	this.Controls.Add(this.label1);
        	this.Name = "Config_Form";
        	this.Text = "Config_Form";
        	this.ResumeLayout(false);
        	this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txb_IP;
        private System.Windows.Forms.TextBox txb_Port;
        private System.Windows.Forms.Button btn_Apply;
        public System.Windows.Forms.ListBox ltb_DownloadFileNameList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}