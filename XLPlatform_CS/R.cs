using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using dotNetLab.Data.Embedded;

namespace XLPlatform
{
   public class R
    {
        public static MainPage mainPage = null;
        public static string Config_File_Name = "config";
      //  public static NativeDBBase Compact = null;
        public static string IP
        {
            get {
                string [] strArr = File.ReadAllLines("config");
                return strArr[0];
                 
            }
        }
        public static int Port
        {
            get
            {
                string[] strArr = File.ReadAllLines("config");
                return Convert.ToInt32(strArr[1]);
            }
        }
        
    }
}
