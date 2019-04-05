using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;

using System.Text;
using System.Threading;
using System.Windows.Forms;
using dotNetLab.Common; 
namespace XLPlatform
{
    public partial class MainPage : PageBase
    {
        private dotNetLab.Common.Timer timer1;
        String strSaveFileName_WithExt_td = null;
        String strFileSize = null;
        public delegate void DoRefreshLayoutCallback(int nCode,Object value);
       public DoRefreshLayoutCallback DoRefreshLayout;
        private String strPreviousFileName = null;
        public Config_Form configform;
      public  TCPCommunicationTower TcpCommunicationTower;
       public bool bisDownloaded = true;
       public BegineDownloadCallback phone_invoke;
        int nTimeoutCount = 0;
          const int CODE_FILE_SIZE = 1;
         const  int CODE_BTN_BEGIN = 2;
          const int CODE_BTN_END = 3;
          const int CODE_DOWNLOAD_SPEED = 4;
          const int CODE_PRGRESS_BAR = 5;
       public const int CODE_LBL_STATUS = 6;
       public const int CODE_LBL_IP = 7;
        public  void InitThunderEngine()
        {
            bool b = XLPlatformEx.InitXunLei();
            if(!b)
            {
                dotNetLab.Data.Tipper.Tip_Info_Error("云加速组件初始化失败");
            }
             
        }
        
       public  void KillThunderPlatform()
        {
           
            Process[] process =  Process.GetProcessesByName("MiniThunderPlatform");
            foreach (var item in process)
            {
                item.Kill();
            }
            

        }
       private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.TcpCommunicationTower.Dispose();
        }

        void RefreshLayout(int nCode,Object value)
        {
            switch (nCode) 
           {
                    case CODE_FILE_SIZE: this.lbl_FileSize.Text = value.ToString();
                        break;
                        case CODE_BTN_BEGIN: this.Btn_BeginDownload_Click(null,null);
                            break; 
                            case  CODE_BTN_END:Btn_StopDownload_Click(null,null);
                                break;
                                case CODE_DOWNLOAD_SPEED: this.lbl_Speed.Text = value.ToString();
                                    break;
                                    case CODE_PRGRESS_BAR: this.pgb_Downloading.Value = (int)value;
                                        lbl_Percent.Text = string.Format("{0}%", pgb_Downloading.Value);
                                        break;
                case CODE_LBL_STATUS:
                    this.lbl_Status.Text = value.ToString();
                        break;

           }
            
        }
        void PhoneInvoke(string str)   
        {
            Clipboard.SetText(str);
            Btn_BeginDownload_Click(null, null);
        }
        String AssignSpeed_Size(double lf, String Extra)
        {
            String Unit = "B";

            if ((lf / 1024) >= 1)
            {
                if ((lf / 1024 / 1024) >= 1)
                {
                    if ((lf / 1024 / 1024 / 1024) >= 1)
                    {
                        Unit = String.Format("{0} GB{1}", Math.Round(lf / 1024 / 1024 / 1024, 3), Extra);
                    }
                    else
                    {
                        Unit = String.Format("{0} MB{1}", Math.Round(lf / 1024 / 1024), Extra);
                    }
                }
                else
                    Unit = String.Format("{0} KB{1}", Math.Round(lf / 1024), Extra);

            }
            else
            {
                Unit = String.Format("{0} B{1}", lf, Extra);
            }
            return Unit;

        }
        
        private void QueryTaskTimer_Tick()
        {
            XLPlatformEx.GatherDownloadInfo();
            this.Invoke(DoRefreshLayout, CODE_PRGRESS_BAR, (int) (XLPlatformEx.DownloadingPercent() * 100));
            this.Invoke(DoRefreshLayout, CODE_DOWNLOAD_SPEED, AssignSpeed_Size(XLPlatformEx.ProvideSpeed(), "/s"));

            if (pgb_Downloading.Value == 100)
                this.Invoke(DoRefreshLayout, CODE_BTN_END, null);
                
            if(lbl_FileSize.Text=="0 B")
            {
               if(File.Exists(strSaveFileName_WithExt_td))
                {
                       Invoke(DoRefreshLayout,CODE_FILE_SIZE, AssignSpeed_Size(XLPlatformEx.ProvideFileSize(),""));
                }
               else
                {
                    nTimeoutCount++;
                    if(nTimeoutCount>80)
                    {
                        nTimeoutCount = 0;
                        this.Invoke(DoRefreshLayout, CODE_BTN_END, null);
                         
                    }
                }
            }
        }

       
        public void Btn_StopDownload_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            this.btn_BeginDownload.Enabled = true;
            XLPlatformEx.EndDownload();
            this.btn_StopDownload.Enabled = false;
            this.bisDownloaded = true;
        }

        public void Btn_BeginDownload_Click(object sender, EventArgs e)
        {
            if (sender != null)
                InitThunderEngine();
            this.bisDownloaded = false;
        	this.txb_Url.Text = Clipboard.GetText() ;
            if (txb_FileName.Text == this.strPreviousFileName)
            {
                txb_FileName.Text = null;
            }
        	if(String.IsNullOrWhiteSpace(txb_FileName.Text))
        	{
        		int n = txb_Url.Text.LastIndexOf('/') ;
        	    txb_FileName.Text = txb_Url.Text.Substring(n+1) ;
        	  
        	}
            this.lbl_FileSize.Text = AssignSpeed_Size(XLPlatformEx.ProvideFileSize(), "");
            if (XLPlatformEx.ProvideFileSize() == 0)
            {
                
                this.strSaveFileName_WithExt_td = this.txb_FolderPath.Text + txb_FileName.Text + ".td";
            }
             
            timer1.Start();
            this.btn_BeginDownload.Enabled = false;
            this.btn_StopDownload.Enabled = true;
            
           bool b = XLPlatformEx.BeginDownload(Clipboard.GetText(), txb_FolderPath.Text.Trim(), txb_FileName.Text.Trim());
           if(!b)
           {
           	lbl_Status.Text="下载失败，是否下载文件夹失效？";
           }
            XLPlatformEx.Download();
            strPreviousFileName = txb_FileName.Text;
        }

        protected override void PrepareCtrls()
        {
            InitializeComponent();
            configform = new Config_Form();
            this.btn_StopDownload.Enabled = false;
           
        }

        protected override void PrepareEvents()
        {
            this.FormClosing += Form1_FormClosing;
            this.btn_BeginDownload.Click += Btn_BeginDownload_Click;
            this.btn_StopDownload.Click += Btn_StopDownload_Click;
        }

        protected override void Prepare()
        {
            base.Prepare();
            this.lbl_IP.Text =  TcpCommunicationTower.IP;
        }

        protected override void PrepareData()
        {
         
            if (File.Exists("config.txt"))
            {
                String[] strArr = File.ReadAllLines("config.txt", Encoding.Default);
                if (strArr.Length > 0)
                    this.txb_FolderPath.Text = strArr[0];

            }
            timer1 = new dotNetLab.Common.Timer();
            timer1.Interval = 800;
            timer1.Tick += QueryTaskTimer_Tick;
            
            this.phone_invoke = PhoneInvoke;
            DoRefreshLayout = RefreshLayout;
            TcpCommunicationTower = new TCPCommunicationTower();

        }

        private void btn_ViewFolderPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fd = new FolderBrowserDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                this.txb_FolderPath.Text = fd.SelectedPath + "\\";
            }
            fd.Dispose();
           // folDER
        }

        private void lnk_Config_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            configform.ShowDialog();
        }
    }
}
