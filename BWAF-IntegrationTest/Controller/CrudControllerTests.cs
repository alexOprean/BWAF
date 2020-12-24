namespace BWAF_IntegrationTest.Controller
{
    using BWAF_API;
    using BWAF_DAL.Models;
    using System.Collections.Generic;
    using System.Net.Http.Json;
    using System.Threading.Tasks;
    using System.Linq;
    using Xunit;
    using BWAF_IntegrationTest.Attributes;
    using BWAF_Core.ViewModels;

    public class CrudControllerTests: BaseControllerTest
    {
        public CrudControllerTests(CustomWebApplicationFactory<Startup> factory): base(factory) {}

        [Fact, Priority(1)]
        public async Task GetAllEntities_Success()
        {
            IEnumerable<Entity> response = await httpClient.GetFromJsonAsync<IEnumerable<Entity>>("crud/get/all");

            Assert.Equal(3, response.Count());
        }

        [Fact, Priority(2)]
        public async Task Post_Success()
        {
            string name = "TestName";
            EntityViewModel entityViewModel = new EntityViewModel { Name = name };
            await httpClient.PostAsJsonAsync<EntityViewModel>("crud/create", entityViewModel);

            IEnumerable<Entity> response = await httpClient.GetFromJsonAsync<IEnumerable<Entity>>("crud/get/all");

            Assert.Equal(4, response.Count());
            bool isAdded = response.Any(x => x.Name == name);
            Assert.True(isAdded);
        }

        [Fact, Priority(3)]
        public async Task Put_Success()
        {
            string name = "TestName";
            EntityViewModel entityViewModel = new EntityViewModel { Id = 1, Name = name };
            await httpClient.PutAsJsonAsync<EntityViewModel>("crud/update", entityViewModel);

            IEnumerable<Entity> response = await httpClient.GetFromJsonAsync<IEnumerable<Entity>>("crud/get/all");

            Assert.Equal(4, response.Count());
            Entity entity = response.FirstOrDefault(x => x.Id == 1);
            Assert.NotNull(entity);
            Assert.Equal(name, entity.Name);
        }

        [Fact, Priority(4)]
        public async Task Delete_Success()
        {
            await httpClient.DeleteAsync("crud/delete?id=1");

            IEnumerable<Entity> response = await httpClient.GetFromJsonAsync<IEnumerable<Entity>>("crud/get/all");

            Assert.Equal(3, response.Count());
            Entity entity = response.FirstOrDefault(x => x.Id == 1);
            Assert.Null(entity);
        }
        
    }
}
