using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Shops.Logic;
using Shops.Logic.NonCrudClasses;

namespace Shops.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : Controller
    {
        private readonly IGoodsManagementLogic goodsManagementLogic;
        private readonly IShopManagementLogic shopManagementLogic;

        public StatController(IGoodsManagementLogic goodsManagementLogic, IShopManagementLogic shopManagementLogic)
        {
            this.goodsManagementLogic = goodsManagementLogic;
            this.shopManagementLogic = shopManagementLogic;
        }

        [HttpGet]
        public IEnumerable<BrandAveragerProductPrice> GetBrandAveragePrices()
        {
            return goodsManagementLogic.GetBrandAveragesPrice();
        }

        [HttpGet]
        public IEnumerable<BrandAverageProductRating> GetBrandAveragesRating()
        {
            return goodsManagementLogic.GetBrandAveragesRating();
        }

        [HttpGet]
        public IEnumerable<ShopNumberOfProduct> GetNumberOfProducts()
        {
            return shopManagementLogic.GetNumberOfProducts();
        }
    }
}
