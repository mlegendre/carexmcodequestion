using Microsoft.VisualBasic;
using System;
using System.Net.Http;
using Xunit;

namespace ApiIntegrationTests
{
    public class GoApiIntegrationTests
    {
        private HttpClient _httpClient;

        public GoApiIntegrationTests()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("");
        }

        [Fact]
        public void Test1()
        {

        }
    }
}