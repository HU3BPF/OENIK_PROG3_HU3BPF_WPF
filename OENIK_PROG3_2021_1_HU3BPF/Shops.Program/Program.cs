// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Shops.Program
{
    using ConsoleTools;
    using Shops.Data.Models;
    using Shops.Logic;
    using Shops.Repository;

    /// <summary>
    /// The main Program.
    /// </summary>
    internal class Program
    {
        private static void Main()
        {
            ShopsDbContext ctx = new ShopsDbContext();
            RepositoryShop shopRepo = new RepositoryShop(ctx);
            BrandRepository brandRepo = new BrandRepository(ctx);
            RepositoryProduct productRepo = new RepositoryProduct(ctx);

            ShopManagementLogic shopLogic = new ShopManagementLogic(shopRepo, productRepo);
            GoodsManagementLogic goodsManagementLogic = new GoodsManagementLogic(brandRepo, productRepo);

            var menu = new ConsoleMenu()
                .Add("Get All Product", () => ProductFactory.GetAllProduct(goodsManagementLogic))
                .Add("Gets One Product", () => ProductFactory.GetONeProduct(goodsManagementLogic))
                .Add("Remove One Product", () => ProductFactory.RemoveOneProduct(goodsManagementLogic))
                .Add("Update One Product", () => ProductFactory.ChangeOneProduct(goodsManagementLogic))
                .Add("Insert One Product", () => ProductFactory.InsertOneProduct(goodsManagementLogic))
                .Add("Get All Product By Brand", () => ProductFactory.GetAllProductByBrand(goodsManagementLogic))
                .Add("Get All Brand", () => BrandFactory.GetAllBrand(goodsManagementLogic))
                .Add("Gets One Brand", () => BrandFactory.GetOneBrand(goodsManagementLogic))
                .Add("Remove One Brand", () => BrandFactory.RemoveOneBrand(goodsManagementLogic))
                .Add("Update One Brand", () => BrandFactory.ChangeOneBrand(goodsManagementLogic))
                .Add("Insert One Brand", () => BrandFactory.InsertOneBrand(goodsManagementLogic))
                .Add("Get All shop", () => ShopFactory.GetAllShop(shopLogic))
                .Add("Gets One shop", () => ShopFactory.GetOneShop(shopLogic))
                .Add("Remove One shop", () => ShopFactory.RemoveOneShop(shopLogic))
                .Add("Update One shop", () => ShopFactory.ChangeOneShop(shopLogic))
                .Add("Insert One shop", () => ShopFactory.InsertOneShop(shopLogic))
                .Add("Get Average Brand Price", () => BrandFactory.BrandAveragePrice(goodsManagementLogic))
                .Add("Get Average Brand Rating", () => BrandFactory.BrandAverageRating(goodsManagementLogic))
                .Add("Get Shop Number Of Products", () => ShopFactory.GetNumberOfProducts(shopLogic))
                .Add("Get Average Brand Price Async", () => BrandFactory.BrandAveragePriceAsync(goodsManagementLogic))
                .Add("Get Average Brand Rating Async", () => BrandFactory.BrandAverageRatingAsync(goodsManagementLogic))
                .Add("Get Shop Number Of Products Async", () => ShopFactory.GetNumberOfProductsAsync(shopLogic))
                .Add("Close", ConsoleMenu.Close);
            menu.Show();
            ctx.Dispose();
        }
    }
}
