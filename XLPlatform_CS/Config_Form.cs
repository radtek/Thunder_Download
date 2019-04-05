using System;
using System.Collections.Generic;
using System.ComponentModel;
 
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XLPlatform
{
    public partial class Config_Form : Form
    {
        public Config_Form()
        {
            InitializeComponent();
            this.txb_IP.Text = R.IP ;
            this.txb_Port.Text = R.Port.ToString() ;
        }

        private void btn_Apply_Click(object sender, EventArgs e)
        {
           File.WriteAllText(R.Config_File_Name,
               String.Format("{0}\r\n{1}" ,txb_IP.Text.Trim(),txb_Port.Text.Trim(),
               Encoding.Default));
           
            R.mainPage.TcpCommunicationTower = new TCPCommunicationTower();
        }
    }
}
