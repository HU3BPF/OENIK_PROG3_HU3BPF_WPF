namespace Shops.Endpoint.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Shops.Data.Models;
    using Shops.Logic;
    using System.Collections.Generic;

    [Route("[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IGoodsManagementLogic _logic;
        public BrandController(IGoodsManagementLogic brandLogic)
        {
            _logic = brandLogic;
        }

        [HttpGet]
        public IEnumerable<Brand> Get()
        {
            return _logic.BrandGetALL();
        }

        [HttpGet("{id}")]
        public Brand Get(int id)
        {
            return _logic.BrandGetOne(id);
        }

        [HttpPost]
        public void Post([FromBody] Brand value)
        {
            _logic.BrandInsert(value);
        }

        [HttpPut()]
        public void Put([FromBody] Brand value)
        {
            _logic.BrandUpdate(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _logic.BrandRemove(_logic.BrandGetOne(id));
        }
    }
}
