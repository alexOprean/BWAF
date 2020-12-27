namespace BWAF.Test.Controller
{
    using BWAF.Api;
    using BWAF.Data;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Net.Http;
    using Xunit;

    [TestCaseOrderer("BWAF.Test.Configuration.PriorityOrderer", "BWAF.Test")]
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
