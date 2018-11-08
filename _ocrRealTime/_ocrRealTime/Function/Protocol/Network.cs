﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace _ocrRealTime.Function {
    public class Network {

        public static bool PingNetwork(string _IPaddress) {
            try {
                Ping pingSender = new Ping();
                IPAddress address = IPAddress.Parse(_IPaddress);

                // Create a buffer of 32 bytes of data to be transmitted.
                string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
                byte[] buffer = Encoding.ASCII.GetBytes(data);
                // Wait 1 seconds for a reply.
                int timeout = 1000;
                // Set options for transmission:
                // The data can go through 64 gateways or routers
                // before it is destroyed, and the data packet
                // cannot be fragmented.
                PingOptions options = new PingOptions(64, true);
                PingReply reply = pingSender.Send(address, timeout, buffer, options);

                return reply.Status == IPStatus.Success;
            }
            catch {
                return false;
            }
        }

        public static bool PingToIP(string _ip) {
            try {
                Ping myPing = new Ping();
                PingReply reply = myPing.Send(_ip, 1000);
                if (reply == null) return false;
                return reply.Status == IPStatus.Success;
            }
            catch {
                return false;
            }
        }

    }
}
