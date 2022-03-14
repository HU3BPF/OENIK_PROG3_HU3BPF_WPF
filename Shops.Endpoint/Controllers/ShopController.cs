using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Shops.Data.Models;
using Shops.Logic;

namespace Shops.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly IShopManagementLogic _logic;
        public ShopController(IShopManagementLogic shoplogic)
        {
            _logic = shoplogic;
        }

        [HttpGet]
        public IEnumerable<Shop> Get()
        {
            return _logic.GetALL();
        }

        [HttpGet("{id}")]
        public Shop Get(int id)
        {
            return _logic.GetOne(id);
        }

        [HttpPost]
        public void Post([FromBody] Shop value)
        {
            _logic.ShopInsert(value);
        }

        [HttpPut()]
        public void Put([FromBody] Shop value)
        {
            _logic.ShopUpdate(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _logic.ShopRemove(_logic.GetOne(id));
        }
    }
}
