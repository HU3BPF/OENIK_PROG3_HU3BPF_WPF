namespace Shops.Endpoint.Controllers
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.SignalR;
    using Shops.Models;
    using Shops.Endpoint.Services;
    using Shops.Logic;

    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IGoodsManagementLogic _logic;
        IHubContext<SignalRHub> hub;

        public ProductController(IGoodsManagementLogic productLogic, IHubContext<SignalRHub> hub)
        {
            this._logic = productLogic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return this._logic.ProductGetALL();
        }

        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return this._logic.ProductGetOne(id);
        }

        [HttpPost]
        public void Post([FromBody] Product value)
        {
            this._logic.ProductInsert(value);
            this.hub.Clients.All.SendAsync("ProductCreated", value);
        }

        [HttpPut()]
        public void Put([FromBody] Product value)
        {
            this._logic.ProductUpdate(value);
            this.hub.Clients.All.SendAsync("ProductUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var ProductDelete = this._logic.ProductGetOne(id);
            this._logic.ProductRemove(ProductDelete);
            this.hub.Clients.All.SendAsync("ProductDeleted", ProductDelete);
        }
    }
}
