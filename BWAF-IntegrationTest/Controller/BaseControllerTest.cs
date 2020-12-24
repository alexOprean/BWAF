namespace BWAF_IntegrationTest.Controller
{
    using BWAF_API;
    using BWAF_DAL;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Net.Http;
    using Xunit;

    [TestCaseOrderer("BWAF_IntegrationTest.Configuration.PriorityOrderer", "BWAF-IntegrationTest")]
    public class BaseControllerTest : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        protected readonly HttpClient httpClient;
        protected readonly CustomWebApplicationFactory<Startup> factory;
        public BaseControllerTest(CustomWebApplicationFactory<Startup> factory)
        {
            this.factory = factory;
            httpClient = factory.CreateDefaultClient(new Uri("http://localhost/api/"));
        }
    }
}
