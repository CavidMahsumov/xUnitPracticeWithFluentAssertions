using NetworkUtility.DNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace NetworkUtility.Ping
{
    public class NetworkService
    {
        public DNSService _serviceDNS { get; set; }

        public NetworkService(DNSService serviceDNS)
        {
            _serviceDNS=serviceDNS;
        }
        public string SendPing()
        {
            var dnsSuccess = _serviceDNS.SendDNS();
            if (dnsSuccess)
                return "Success:Ping Sent!";
            return "Failed: Ping not sent";
        }
        public int PingTime(int num1,int num2) 
        {
            return num1+num2;
        }
        public DateTime LastPingDate()
        {
            return DateTime.Now;
        }
        public PingOptions GetPingOptions()
        {
            return new() {
                DontFragment = true,
                Ttl = 1
            };
        }
        public IEnumerable<PingOptions> MostRecentPings()
        {
            IEnumerable<PingOptions> pings = new[]
            {
                new PingOptions() {
                     DontFragment= true,
                     Ttl = 1
                },
                new PingOptions() {
                     DontFragment= true,
                     Ttl = 2
                },
                new PingOptions() {
                     DontFragment= true,
                     Ttl = 3
                }
            };
            return pings;
        }
    }
}
