namespace XLPlatform
{
    partial class MainPage
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pgb_Downloading = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.txb_FolderPath = new System.Windows.Forms.TextBox();
            this.txb_FileName = new System.Windows.Forms.TextBox();
            this.btn_BeginDownload = new System.Windows.Forms.Button();
            this.btn_StopDownload = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_FileSize = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_ViewFolderPath = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_Speed = new System.Windows.Forms.Label();
            this.txb_Url = new System.Windows.Forms.TextBox();
            this.lnk_Config = new System.Windows.Forms.LinkLabel();
            this.lbl_Percent = new System.Windows.Forms.Label();
            this.lbl_Status = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbl_IP = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "当前任务";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "文件保存文件夹：";
            // 
            // pgb_Downloading
            // 
            this.pgb_Downloading.Location = new System.Drawing.Point(111, 354);
            this.pgb_Downloading.Name = "pgb_Downloading";
            this.pgb_Downloading.Size = new System.Drawing.Size(405, 23);
            this.pgb_Downloading.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(64, 195);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "文件名";
            // 
            // txb_FolderPath
            // 
            this.txb_FolderPath.Location = new System.Drawing.Point(111, 152);
            this.txb_FolderPath.Name = "txb_FolderPath";
            this.txb_FolderPath.Size = new System.Drawing.Size(405, 21);
            this.txb_FolderPath.TabIndex = 2;
            // 
            // txb_FileName
            // 
            this.txb_FileName.Location = new System.Drawing.Point(111, 219);
            this.txb_FileName.Name = "txb_FileName";
            this.txb_FileName.Size = new System.Drawing.Size(405, 21);
            this.txb_FileName.TabIndex = 2;
            // 
            // btn_BeginDownload
            // 
            this.btn_BeginDownload.Location = new System.Drawing.Point(408, 418);
            this.btn_BeginDownload.Name = "btn_BeginDownload";
            this.btn_BeginDownload.Size = new System.Drawing.Size(90, 34);
            this.btn_BeginDownload.TabIndex = 3;
            this.btn_BeginDownload.Text = "开始下载";
            this.btn_BeginDownload.UseVisualStyleBackColor = true;
            // 
            // btn_StopDownload
            // 
            this.btn_StopDownload.Location = new System.Drawing.Point(504, 418);
            this.btn_StopDownload.Name = "btn_StopDownload";
            this.btn_StopDownload.Size = new System.Drawing.Size(90, 34);
            this.btn_StopDownload.TabIndex = 3;
            this.btn_StopDownload.Text = "停止下载";
            this.btn_StopDownload.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(64, 288);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "文件大小：";
            // 
            // lbl_FileSize
            // 
            this.lbl_FileSize.AutoSize = true;
            this.lbl_FileSize.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_FileSize.Location = new System.Drawing.Point(139, 301);
            this.lbl_FileSize.Name = "lbl_FileSize";
            this.lbl_FileSize.Size = new System.Drawing.Size(0, 20);
            this.lbl_FileSize.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(64, 354);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "进度：";
            // 
            // btn_ViewFolderPath
            // 
            this.btn_ViewFolderPath.Location = new System.Drawing.Point(533, 152);
            this.btn_ViewFolderPath.Name = "btn_ViewFolderPath";
            this.btn_ViewFolderPath.Size = new System.Drawing.Size(50, 26);
            this.btn_ViewFolderPath.TabIndex = 3;
            this.btn_ViewFolderPath.Text = "...";
            this.btn_ViewFolderPath.UseVisualStyleBackColor = true;
            this.btn_ViewFolderPath.Click += new System.EventHandler(this.btn_ViewFolderPath_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(303, 288);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "下载速度：";
            // 
            // lbl_Speed
            // 
            this.lbl_Speed.AutoSize = true;
            this.lbl_Speed.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Speed.Location = new System.Drawing.Point(384, 292);
            this.lbl_Speed.Name = "lbl_Speed";
            this.lbl_Speed.Size = new System.Drawing.Size(0, 20);
            this.lbl_Speed.TabIndex = 0;
            // 
            // txb_Url
            // 
            this.txb_Url.Location = new System.Drawing.Point(118, 85);
            this.txb_Url.Name = "txb_Url";
            this.txb_Url.Size = new System.Drawing.Size(405, 21);
            this.txb_Url.TabIndex = 2;
            // 
            // lnk_Config
            // 
            this.lnk_Config.AutoSize = true;
            this.lnk_Config.Location = new System.Drawing.Point(64, 429);
            this.lnk_Config.Name = "lnk_Config";
            this.lnk_Config.Size = new System.Drawing.Size(29, 12);
            this.lnk_Config.TabIndex = 4;
            this.lnk_Config.TabStop = true;
            this.lnk_Config.Text = "配置";
            this.lnk_Config.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk_Config_LinkClicked);
            // 
            // lbl_Percent
            // 
            this.lbl_Percent.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Percent.ForeColor = System.Drawing.Color.DarkGreen;
            this.lbl_Percent.Location = new System.Drawing.Point(533, 354);
            this.lbl_Percent.Name = "lbl_Percent";
            this.lbl_Percent.Size = new System.Drawing.Size(61, 23);
            this.lbl_Percent.TabIndex = 5;
            // 
            // lbl_Status
            // 
            this.lbl_Status.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Status.ForeColor = System.Drawing.Color.DarkRed;
            this.lbl_Status.Location = new System.Drawing.Point(111, 429);
            this.lbl_Status.Name = "lbl_Status";
            this.lbl_Status.Size = new System.Drawing.Size(239, 23);
            this.lbl_Status.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(475, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "当前IP:";
            // 
            // lbl_IP
            // 
            this.lbl_IP.AutoSize = true;
            this.lbl_IP.Location = new System.Drawing.Point(531, 29);
            this.lbl_IP.Name = "lbl_IP";
            this.lbl_IP.Size = new System.Drawing.Size(0, 12);
            this.lbl_IP.TabIndex = 0;
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 475);
            this.Controls.Add(this.lbl_Status);
            this.Controls.Add(this.lbl_Percent);
            this.Controls.Add(this.lnk_Config);
            this.Controls.Add(this.btn_StopDownload);
            this.Controls.Add(this.btn_ViewFolderPath);
            this.Controls.Add(this.btn_BeginDownload);
            this.Controls.Add(this.txb_FileName);
            this.Controls.Add(this.txb_Url);
            this.Controls.Add(this.txb_FolderPath);
            this.Controls.Add(this.pgb_Downloading);
            this.Controls.Add(this.lbl_Speed);
            this.Controls.Add(this.lbl_FileSize);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_IP);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.Name = "MainPage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar pgb_Downloading;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txb_FolderPath;
          public System.Windows.Forms.TextBox txb_FileName;
        private System.Windows.Forms.Button btn_BeginDownload;
        private System.Windows.Forms.Button btn_StopDownload;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_FileSize;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_ViewFolderPath;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl_Speed;
        private System.Windows.Forms.TextBox txb_Url;
        private System.Windows.Forms.LinkLabel lnk_Config;
        private System.Windows.Forms.Label lbl_Percent;
        private System.Windows.Forms.Label lbl_Status;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbl_IP;
    }
}

