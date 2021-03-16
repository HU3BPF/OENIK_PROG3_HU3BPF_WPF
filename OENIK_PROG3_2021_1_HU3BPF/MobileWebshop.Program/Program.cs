// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MobileWebshop.Program
{
    using System;
    using ConsoleTools;
    using MobileWebshop.Data.Models;
    using MobileWebshop.Logic;
    using MobileWebshop.Repository;

    /// <summary>
    /// The main Program.
    /// </summary>
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.CursorVisible = false;

            // Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\MobileWebshopDb.mdf;Integrated Security=True;MultipleActiveResultSets=True
            MobileDbContext ctx = new MobileDbContext();

            RepositoryManufacturer manufacturerRepo = new RepositoryManufacturer(ctx);
            BrandRepository brandRepo = new BrandRepository(ctx);
            RepositoryProduct productRepo = new RepositoryProduct(ctx);

            ManufacturerLogic manufacturerLogic = new ManufacturerLogic(manufacturerRepo);
            BrandLogic brandLogic = new BrandLogic(brandRepo);
            ProductLogic productLogic = new ProductLogic(productRepo);

            var menu = new ConsoleMenu().Add("GetAllProduct", () => GetAllProduct(productLogic));
            menu.Add("GetAllBrand", () => GetAllBrand(brandLogic));
            menu.Add("GetAllManufacturer", () => GetAllManufacturer(manufacturerLogic)).Add("Close", ConsoleMenu.Close);
            menu.Show();
            Console.WriteLine(args);
        }

        private static void GetAllProduct(ProductLogic logic)
        {
            foreach (var item in logic.GetALL())
            {
                Console.WriteLine(item.ProductName);
            }

            Console.ReadLine();
        }

        private static void GetAllBrand(BrandLogic logic)
        {
            foreach (var item in logic.GetALL())
            {
                Console.WriteLine(item.BrandName);
            }

            Console.ReadLine();
        }

        private static void GetAllManufacturer(ManufacturerLogic logic)
        {
            foreach (var item in logic.GetALL())
            {
                Console.WriteLine(item.ManufacturerName);
            }

            Console.ReadLine();
        }
    }
}
