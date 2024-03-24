using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkUtility.Ping
{
    public class NetworkService
    {
        public string SendPing()
        {
            return "Success:Ping Sent!";
        }
        public int PingTime(int num1,int num2) 
        {
            return num1+num2;
        }
    }
}
