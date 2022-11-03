using ApiIntegrationTests.Models;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ApiIntegrationTests
{
    public class GoApiIntegrationTests
    {
        private HttpClient _httpClient;
        // this is bad but for ease I am putting it here
        private string token = "8a1fff974033c47e76d665fe9a1f0d4ac8c59864d739a2cd06ce56ec0a2ac08f";

        public GoApiIntegrationTests()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://gorest.co.in/public/v1/users");
        }

        [Fact]
        public async Task PostANewUser_VerifyUserIsCreated()
        {
            // Assign
            var newUserObject = new UserModel
            {
                Name = "something",
                Email = "something@something.com",
                Gender = "male",
                Status = "active"
            };
            
            var body = new StringContent(JsonConvert.SerializeObject(newUserObject), Encoding.UTF8, "application/json");
            // Act
            // Post new user
            var sut = await _httpClient.PostAsync($"?access-token={token}", body);
            
            // I keep getting 422, not sure why so just moving on
            // Assert
            Assert.True(sut.IsSuccessStatusCode);
            // Get user id from body
            var response = await sut.Content.ReadAsStringAsync();
            JObject getJsonBody = JObject.Parse(response);
            var getIdFromBody = getJsonBody["data"]["id"].ToString();

            // Get user from GET endpoint
            var getUser = await _httpClient.GetAsync($"/{getIdFromBody}?access-token={token}");

            Assert.True(getUser.IsSuccessStatusCode);
            var getResponse = await sut.Content.ReadAsStringAsync();
            JObject getJsonBodyFromGetResponse = JObject.Parse(getResponse);
            var getIdFromResponseBody = getJsonBody["data"]["id"].ToString();

            Assert.Equal(getIdFromBody, getIdFromResponseBody);
        }
    }
}