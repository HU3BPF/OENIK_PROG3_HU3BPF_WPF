using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Shops.Endpoint.Services;
using Shops.Logic;
using Shops.Models.NonCrudClasses;

namespace Shops.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : Controller
    {
        private readonly IGoodsManagementLogic goodsManagementLogic;
        private readonly IShopManagementLogic shopManagementLogic;
        IHubContext<SignalRHub> hub;

        public StatController(IGoodsManagementLogic goodsManagementLogic, IShopManagementLogic shopManagementLogic, IHubContext<SignalRHub> hub)
        {
            this.goodsManagementLogic = goodsManagementLogic;
            this.shopManagementLogic = shopManagementLogic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<BrandAveragerProductPrice> BrandAveragerProductPrice()
        {
            return this.goodsManagementLogic.GetBrandAveragesPrice();
        }

        [HttpGet]
        public IEnumerable<BrandAverageProductRating> BrandAverageProductRating()
        {
            return this.goodsManagementLogic.GetBrandAveragesRating();
        }

        [HttpGet]
        public IEnumerable<ShopNumberOfProduct> ShopNumberOfProduct()
        {
            return this.shopManagementLogic.GetNumberOfProducts();
        }

        [HttpGet]
        public IEnumerable<ShopAveragePrice> ShopAveragePrice()
        {
            return this.shopManagementLogic.GetShopAveragePrice();
        }

        [HttpGet]
        public IEnumerable<ShopAverageRating> ShopAverageRating()
        {
            return this.shopManagementLogic.GetShopAverageRating();
        }
    }
}
