﻿// <copyright file="Program.cs" company="PlaceholderCompany">
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

            RepositoryManufacturer manufacturerRepo = new RepositoryManufacturer(ctx);
            BrandRepository brandRepo = new BrandRepository(ctx);
            RepositoryProduct productRepo = new RepositoryProduct(ctx);

            ShopLogic manufacturerLogic = new ShopLogic(manufacturerRepo);
            BrandLogic brandLogic = new BrandLogic(brandRepo);
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
                .Add("Get All shop", () => ShopMethods.GetAllShop(manufacturerLogic))
                .Add("Get One shop", () => ShopMethods.GetOneShop(manufacturerLogic))
                .Add("Remove One shop", () => ShopMethods.RemoveOneShop(manufacturerLogic))
                .Add("Update One shop", () => ShopMethods.ChangeOneShop(manufacturerLogic))
                .Add("Insert One shop", () => ShopMethods.InsertOneShop(manufacturerLogic))
                .Add("Close", ConsoleMenu.Close);
            menu.Show();
        }
    }
}