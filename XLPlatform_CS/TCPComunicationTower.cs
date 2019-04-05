using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using dotNetLab.Network;
using System.Net.Sockets;
using System.IO;
using System.Web;

namespace XLPlatform
{
    public class TCPCommunicationTower : TServer
    {
        public const byte REMOTE_DOWNLOAD = 51;
        public const byte REMOTE_DELETEFILE = 52;
        public const byte REMOTE_MULTIDOWNLOAD = 53;
        public const byte REMOTE_QUERY_AVAILABLE_MOVIE_NAMES = 54;
        static int i = 0;
        private List<String> lst_Data;
        public TCPCommunicationTower()
        {
            this.en = Encoding.UTF8;
            this.Route = RouteMessage;
             lst_Data = new List<string>();
            this.IP = R.IP;
            this.Port = R.Port;
            this.LoopGapTime = 1000;
            this.nBufferSize = 40800;
            //  Dns.GetHostByName(Dns.GetHostName())
          bool b = this.Boot(this.IP);
          if(!b)
          {
          	this.Dispose() ;
          }
          else
            {
               
            }
        }

        private void NativeDownloader_ClientDisconnected(string ClientInfo)
        {
            Console.WriteLine(string.Format("{0}: 已经断开", ClientInfo));
        }

        private void NativeDownloader_ClientConnected(int nIndex)
        {
            Console.WriteLine(string.Format("{0}: 已经连接",GetClientIP(nIndex)));
        }

        public void RouteMessage(int nIndex_Client, byte[] byts)
        {
            switch (TCPBase.FetchMSGMark(byts))
            {
                case REMOTE_DOWNLOAD:
                    DownloadMovie(); break;
                case REMOTE_DELETEFILE:
                    DeleteMovie(); break;
                case REMOTE_MULTIDOWNLOAD:
                    MultiDownload( nIndex_Client,byts); break;
                case REMOTE_QUERY_AVAILABLE_MOVIE_NAMES:
                    Query_Available_Movie_Names(nIndex_Client, byts);
                    break;
            }

        }

        private void Query_Available_Movie_Names(int nIndex_Client, byte[] byts)
        {
            StringBuilder sb = new StringBuilder();
           String strFolderPath =  this.ProvideString(byts, MARKPOSITION, (int)TCPBase.FetchDataLenByts(byts));
            String []  strArrX = File.ReadAllLines("map", Encoding.Default);
            List<String> list = strArrX.ToList();
            int nHowManyItems = 0;
            if (list.Contains(strFolderPath.ToLower()))
            {
                int n = list.IndexOf(strFolderPath.ToLower());
                strFolderPath = list[n + 1];
            }
            else
                return;
            String[] strArr = null;
            try
            {

             strArr = Directory.GetFiles(strFolderPath);
            }
            catch
            {
                R.mainPage.Invoke(R.mainPage.DoRefreshLayout, MainPage.CODE_LBL_STATUS, "未能找到E盘");
                Send(nIndex_Client, REMOTE_QUERY_AVAILABLE_MOVIE_NAMES, en.GetBytes("NG"));
                KillClientThread(nIndex_Client);
                return;
            }
            for (int i = 0; i < strArr.Length; i++)
            {
                string ext = Path.GetExtension(strArr[i]).ToLower();
                 
                if (ext.Contains("mp4"))
                {
                    sb.AppendFormat("{0}^", Path.GetFileName(strArr[i]));
                }
                else if(ext.Contains("mkv"))
                {
                    sb.AppendFormat("{0}^", Path.GetFileName(strArr[i]));
                }
                else if(ext.Contains("rmvb"))
                {
                    sb.AppendFormat("{0}^", Path.GetFileName(strArr[i]));
                }
                else if(ext.Contains("avi"))
                {
                    sb.AppendFormat("{0}^", Path.GetFileName(strArr[i]));
                }
                else if(ext.Contains("flv"))
                {
                    sb.AppendFormat("{0}^", Path.GetFileName(strArr[i]));
                }
                else if(ext.Contains("f4v"))
                {
                    sb.AppendFormat("{0}^", Path.GetFileName(strArr[i]));
                }
                else if(ext.Contains("mov"))
                {
                    sb.AppendFormat("{0}^", Path.GetFileName(strArr[i]));
                }
                else if (ext.Contains("wmv"))
                {
                    sb.AppendFormat("{0}^", Path.GetFileName(strArr[i]));
                }


            }
            if (sb.Length > 1)
            {
                sb.Remove(sb.Length - 1, 1);
                string[] strTest = sb.ToString().Split('^');
                nHowManyItems = strTest.Length;
                Send(nIndex_Client, REMOTE_QUERY_AVAILABLE_MOVIE_NAMES, en.GetBytes(sb.ToString()));
            }
            else
            {
               
                Send(nIndex_Client, REMOTE_QUERY_AVAILABLE_MOVIE_NAMES, en.GetBytes("NG"));
            }

            KillClientThread(nIndex_Client);
            R.mainPage.Invoke(R.mainPage.DoRefreshLayout, MainPage.CODE_LBL_STATUS, String.Format("已经发送{0}条数据",nHowManyItems));
        }

        public void DownloadMovie()
        {
           
        }
        public void DeleteMovie()
        {

        }
        public void MultiDownload(int nIndex, byte[] byts)
        {
            
                int n = (int)FetchDataLenByts(byts);
                StringBuilder sb = new StringBuilder(en.GetString(byts, TCPBase.MARKPOSITION, n));
                 
                if (sb != null || string.IsNullOrWhiteSpace(sb.ToString()))
                {
                    if (sb.ToString() == "OK")
                    {
                        Console.WriteLine("OK");
                        return;
                    }
                    
                    Send(nIndex, REMOTE_MULTIDOWNLOAD, en.GetBytes("OK"));
                }
            
                Console.WriteLine("开始进入线程");
                String[] strArr = sb.ToString().Split('^');
                R.mainPage.configform.ltb_DownloadFileNameList.Items.Clear();
                R.mainPage.configform.ltb_DownloadFileNameList.Items.AddRange(strArr);
            for (int j = 0; j < strArr.Length; j++)
            {
                if (!lst_Data.Contains(strArr[j]))
                {
                    lst_Data.Add(strArr[j]);
                }
            }
            lock (this)
            {
                R.mainPage.InitThunderEngine();
                for (int i = 0; i < lst_Data.Count; i++)
                {
                    if (R.mainPage.bisDownloaded)
                    {
                        try
                        {
                            R.mainPage.bisDownloaded = false;
                            R.mainPage.Invoke(R.mainPage.phone_invoke, lst_Data[i]);
                            while(!R.mainPage.bisDownloaded)
                            {
                                Thread.Sleep(1000);
                            }
                            R.mainPage.Invoke(R.mainPage.DoRefreshLayout, MainPage.CODE_LBL_STATUS, String.Format("第{0}号下载已经完毕", i));
                            lst_Data.RemoveAt(i);
                            i--;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                     }
                    
                }
                KillClientThread(nIndex);
                R.mainPage.KillThunderPlatform();

            }


        }

        protected override void ImplementClientCon_DisCon_Delegate()
        {
            this.ClientConnected += NativeDownloader_ClientConnected;
            this.ClientDisconnected += NativeDownloader_ClientDisconnected;
        }
    }
}
