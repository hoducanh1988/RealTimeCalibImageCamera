using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _ocrRealTime.Function {
    public class Camera : Telnet {

        public Camera(string Hostname, int Port) : base(Hostname, Port) { }

        public bool Login(int LoginTimeOutMs) {
            int oldTimeOutMs = TimeOutMs;
            TimeOutMs = LoginTimeOutMs;
            string s = Read();
            if (!s.TrimEnd().EndsWith(":"))
                throw new Exception("Failed to connect : no login prompt");
            WriteLine(myGlobal.defaultsetting.telnetuser);

            s += Read();
            if (!s.TrimEnd().EndsWith(":"))
                throw new Exception("Failed to connect : no password prompt");
            WriteLine(myGlobal.defaultsetting.telnetpass);

            s += Read();
            TimeOutMs = oldTimeOutMs;
            return true;
        }

        public bool getMacAddress() {
            try {
                string _macincamera = "";
                int count = 0;

            //Get MAC from camera
            REP:
                count++;
                base.WriteLine("ifconfig");
                Thread.Sleep(500);
                string data = base.Read();
                if (!data.Contains("eth0") || !data.Contains("lo")) {
                    if (count < 3) goto REP;
                }
                else {
                    data = data.Split(new string[] { "eth0" }, StringSplitOptions.None)[1];
                    data = data.Split(new string[] { "lo" }, StringSplitOptions.None)[0];
                    data = data.Split(new string[] { "Link encap:Ethernet  HWaddr" }, StringSplitOptions.None)[1];
                    data = data.Trim();
                    _macincamera = data.Substring(0, 17).Replace(":", "").Trim();
                    myGlobal.testinfo.macaddress = _macincamera;
                }
                return System.Text.RegularExpressions.Regex.IsMatch(_macincamera,"[0-9,A-F]{12}");
            } catch {
                return false;
            }
        }

        

    }
}
