using FakeItEasy;
using FluentAssertions;
using FluentAssertions.Extensions;
using NetworkUtility.DNS;
using NetworkUtility.Ping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NetworkUtility.Test.PingTest
{
    public class NetworkServiceTest
    {
        public NetworkService _networkService { get; set; }

        private readonly DNSService _dnsService;
        public NetworkServiceTest()
        {

            _dnsService = A.Fake<DNSService>();
            _networkService = new NetworkService(_dnsService); 
        }

        [Fact]
        public void NetworkService_SendPing_ReturnString()
        {
            var result= _networkService.SendPing();

            result.Should().NotBeNullOrWhiteSpace();
            result.Should().Be("Success:Ping Sent!");
            result.Should().Contain("Success", Exactly.Once());
        }
        [Theory]
        [InlineData(1,1,2)]
        [InlineData(2,2,4)]
        public void NetworkService_PingTime_ReturnInt(int a,int b,int expected)
        {
            var result=_networkService.PingTime(a,b);

            result.Should().Be(expected);
            result.Should().BeGreaterThanOrEqualTo(2);
            result.Should().NotBeInRange(-10000, 0);


        }
        [Fact]
        public void NetworkService_LastPingDate_ReturnDateTime()
        {
            var result = _networkService.LastPingDate();

            result.Should().BeAfter(1.January(2010));
            result.Should().BeBefore(1.January(2030));
        }

        [Fact]
        public void NetworkService_GetPingOptions_ReturnPingOptions()
        {

            var result = _networkService.GetPingOptions();

            result.Should().NotBeNull();
            result.Should().BeOfType<PingOptions>();
        }

        [Fact]
        public void NetworkService_MostRecentPings_ReturnObject()
        {
            PingOptions pingOptions = new PingOptions() {
                DontFragment = true,
                Ttl = 1
            };

            var result=_networkService.MostRecentPings();

            //result.Should().BeOfType<IEnumerable<PingOptions>>();
            result.Should().NotBeNull();
            result.Should().ContainEquivalentOf(pingOptions);
            result.Should().Contain(x => x.DontFragment == true);

        }
    }
}
