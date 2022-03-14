namespace Shops.Endpoint.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.SignalR;
    using Shops.Models;
    using Shops.Endpoint.Services;
    using Shops.Logic;
    using System.Collections.Generic;

    [Route("[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IGoodsManagementLogic _logic;
        IHubContext<SignalRHub> hub;
        public BrandController(IGoodsManagementLogic brandLogic, IHubContext<SignalRHub> hub)
        {
            this._logic = brandLogic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Brand> Get()
        {
            return this._logic.BrandGetALL();
        }

        [HttpGet("{id}")]
        public Brand Get(int id)
        {
            return this._logic.BrandGetOne(id);
        }

        [HttpPost]
        public void Post([FromBody] Brand value)
        {
            this._logic.BrandInsert(value);
            this.hub.Clients.All.SendAsync("BrandCreated", value);
        }

        [HttpPut()]
        public void Put([FromBody] Brand value)
        {
            this._logic.BrandUpdate(value);
            this.hub.Clients.All.SendAsync("BrandUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        { 
            var BrandToDelete = this._logic.BrandGetOne(id);
            this._logic.BrandRemove(BrandToDelete);
            this.hub.Clients.All.SendAsync("BrandDeleted", BrandToDelete);
        }
    }
}
