using FluentAssertions;
using NetworkUtility.Ping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkUtility.Test.PingTest
{
    public class NetworkServiceTest
    {
        public NetworkService _networkService { get; set; }
        public NetworkServiceTest()
        {
            _networkService = new NetworkService(); 
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
    }
}
