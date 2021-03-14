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
            // Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\MobileWebshopDb.mdf;Integrated Security=True;MultipleActiveResultSets=True
            MobileDbContext ctx = new MobileDbContext();
            RepositoryProduct repo = new RepositoryProduct(ctx);
            ProductLogic logic = new ProductLogic(repo);

            var menu = new ConsoleMenu().Add("Using logic", () => AveragesUsingLogic(logic))
                .Add("Close", ConsoleMenu.Close);
            menu.Show();
            Console.WriteLine(args);
        }

        private static void AveragesUsingLogic(ProductLogic logic)
        {
            foreach (var item in logic.GetAllProducts())
            {
                Console.WriteLine(item.ProductName);
            }

            Console.ReadLine();
        }
    }
}
