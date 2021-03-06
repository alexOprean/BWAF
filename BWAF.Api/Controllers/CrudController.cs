namespace BWAF.Api.Controllers
{
    using BWAF.Api.Attributes;
    using BWAF.Core.Interfaces;
    using BWAF.Core.ViewModels;
    using BWAF.Data.Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [Performance()]
    [Route("api/[controller]")]
    [ApiController]
    public class CrudController : ControllerBase
    {
        private ICrudServices crudServices;

        public CrudController(ICrudServices crudServices)
        {
            this.crudServices = crudServices;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateEntity([FromBody]EntityViewModel entityViewModel)
        {
            await crudServices.Create(entityViewModel);
            return Ok();
        }

        [HttpGet]
        [Route("get/all")]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<Entity> entities =  await crudServices.GetAll();
            return Ok(entities);
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateEntity([FromBody] EntityViewModel entityViewModel)
        {
            await crudServices.Update(entityViewModel);
            return Ok();
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteEntity([FromQuery] long id)
        {
            await crudServices.Delete(id);
            return Ok();
        }
    }
}
