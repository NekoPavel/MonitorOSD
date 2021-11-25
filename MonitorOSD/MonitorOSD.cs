using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonitorOSD
{
    public partial class MonitorOSD : Form
    {
        public MonitorOSD()
        {
            InitializeComponent();

        }
        //http://sysman.sll.se/SysMan/api/monitoring?target=LITLS13395850
        public MonitoringLookup GetOSDInfo(string pcName)
        {
            MonitoringLookup[] monitoringArray = JsonSerializer.Deserialize<MonitoringLookup[]>(NetResponseToString("http://sysman.sll.se/SysMan/api/monitoring?target=" + pcName));
            if (monitoringArray.Length > 0)
            {
                return monitoringArray[0];
            }
            else
            {
                return null;
            }
        }
        public string NetResponseToString(string uriString)
        {
            Uri uri = new Uri(uriString);
            WebRequest webRequest = WebRequest.Create(uri);

            webRequest.Credentials = CredentialCache.DefaultCredentials;
            WebResponse webResponse = webRequest.GetResponse();
            Stream receiveStream = webResponse.GetResponseStream();
            Encoding encode = System.Text.Encoding.GetEncoding("utf-8");
            StreamReader readStream = new StreamReader(receiveStream, encode);
            Char[] read = new Char[256];

            int count = readStream.Read(read, 0, 256);
            string output = "";
            while (count > 0)
            {
                String Str = new String(read, 0, count);
                output += Str;
                count = readStream.Read(read, 0, 256);
            }
            readStream.Close();
            webResponse.Close();
            return output;
        }
    }
}
