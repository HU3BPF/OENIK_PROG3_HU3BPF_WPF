// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MobileWebshop.Program
{
    using ConsoleTools;
    using MobileWebshop.Data.Models;
    using MobileWebshop.Logic;
    using MobileWebshop.Repository;

    /// <summary>
    /// The main Program.
    /// </summary>
    internal class Program
    {
        private static void Main()
        {
            ShopDbContext ctx = new ShopDbContext();

            RepositoryShop shopRepo = new RepositoryShop(ctx);
            BrandRepository brandRepo = new BrandRepository(ctx);
            RepositoryProduct productRepo = new RepositoryProduct(ctx);

            ShopLogic shopLogic = new ShopLogic(shopRepo, productRepo);
            BrandLogic brandLogic = new BrandLogic(brandRepo, productRepo);
            ProductLogic productLogic = new ProductLogic(productRepo);

            var menu = new ConsoleMenu()
                .Add("Get All Product", () => ProductMethods.GetAllProduct(productLogic))
                .Add("Get One Product", () => ProductMethods.GetONeProduct(productLogic))
                .Add("Remove One Product", () => ProductMethods.RemoveOneProduct(productLogic))
                .Add("Update One Product", () => ProductMethods.ChangeOneProduct(productLogic))
                .Add("Insert One Product", () => ProductMethods.InsertOneProduct(productLogic))
                .Add("Get All Brand", () => BrandMethods.GetAllBrand(brandLogic))
                .Add("Get One Brand", () => BrandMethods.GetOneBrand(brandLogic))
                .Add("Remove One Brand", () => BrandMethods.RemoveOneBrand(brandLogic))
                .Add("Update One Brand", () => BrandMethods.ChangeOneBrand(brandLogic))
                .Add("Insert One Brand", () => BrandMethods.InsertOneBrand(brandLogic))
                .Add("Get All shop", () => ShopMethods.GetAllShop(shopLogic))
                .Add("Get One shop", () => ShopMethods.GetOneShop(shopLogic))
                .Add("Remove One shop", () => ShopMethods.RemoveOneShop(shopLogic))
                .Add("Update One shop", () => ShopMethods.ChangeOneShop(shopLogic))
                .Add("Insert One shop", () => ShopMethods.InsertOneShop(shopLogic))
                .Add("Get average Brand Price", () => BrandMethods.BrandAveragePrice(brandLogic))
                .Add("Get average Brand Rating", () => BrandMethods.BrandAverageRating(brandLogic))
                .Add("Get Shop Number Of Products", () => ShopMethods.GetNumberOfProducts(shopLogic))
                .Add("Get average Brand Price Async", () => BrandMethods.BrandAveragePriceAsync(brandLogic))
                .Add("Get average Brand Rating Async", () => BrandMethods.BrandAverageRatingAsync(brandLogic))
                .Add("Get Shop Number Of Products Async", () => ShopMethods.GetNumberOfProductsAsync(shopLogic))
                .Add("Close", ConsoleMenu.Close);
            menu.Show();
        }
    }
}
