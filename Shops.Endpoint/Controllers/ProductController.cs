namespace Shops.Endpoint.Controllers
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using Shops.Data.Models;
    using Shops.Logic;

    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IGoodsManagementLogic _logic;
        public ProductController(IGoodsManagementLogic productLogic)
        {
            _logic = productLogic;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _logic.ProductGetALL();
        }

        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return _logic.ProductGetOne(id);
        }

        [HttpPost]
        public void Post([FromBody] Product value)
        {
            _logic.ProductInsert(value);
        }

        [HttpPut()]
        public void Put([FromBody] Product value)
        {
            _logic.ProductUpdate(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _logic.ProductRemove(_logic.ProductGetOne(id));
        }
    }
}
