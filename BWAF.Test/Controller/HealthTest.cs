namespace BWAF.Test.Controller
{
    using BWAF.Api;
    using Microsoft.AspNetCore.Mvc.Testing;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Xunit;

    public class HealthTest: IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly HttpClient httpClient;
        public HealthTest(WebApplicationFactory<Startup> factory)
        {
            httpClient = factory.CreateDefaultClient();
        }

        [Fact]
        public async Task Health_Succesful()
        {
            var response = await httpClient.GetAsync("/health");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
