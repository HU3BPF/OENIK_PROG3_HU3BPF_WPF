using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Shops.Models;
using Shops.Endpoint.Services;
using Shops.Logic;

namespace Shops.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly IShopManagementLogic _logic;
        IHubContext<SignalRHub> hub;
        public ShopController(IShopManagementLogic shoplogic, IHubContext<SignalRHub> hub)
        {
            this._logic = shoplogic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Shop> Get()
        {
            return this._logic.GetALL();
        }

        [HttpGet("{id}")]
        public Shop Get(int id)
        {
            return this._logic.GetOne(id);
        }

        [HttpPost]
        public void Post([FromBody] Shop value)
        {
            this._logic.ShopInsert(value);
            this.hub.Clients.All.SendAsync("ShopCreated", value);
        }

        [HttpPut()]
        public void Put([FromBody] Shop value)
        {
            this._logic.ShopUpdate(value);
            this.hub.Clients.All.SendAsync("ShopUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var shopToDelete = this._logic.GetOne(id);
            this._logic.ShopRemove(shopToDelete);
            this.hub.Clients.All.SendAsync("shopDelete", shopToDelete);
        }
    }
}
