// <copyright file="ShopMethods.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MobileWebshop.Program
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using MobileShops.Logic.NonCrudLogic;
    using MobileWebshop.Data.Models;
    using MobileWebshop.Logic;

    /// <summary>
    /// Shop entity methods.
    /// </summary>
    internal static class ShopMethods
    {
        /// <summary>
        /// Get all Shop.
        /// </summary>
        /// <param name="logic">Shop logic.</param>
        internal static void GetAllShop(ShopLogic logic)
        {
            Console.Clear();
            foreach (var item in logic.GetALL())
            {
                Console.WriteLine(item.ToString());
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Get ONe Shop.
        /// </summary>
        /// <param name="logic">Shop logic.</param>
        internal static void GetOneShop(ShopLogic logic)
        {
            NumberFormatInfo provider = new NumberFormatInfo();
            Console.Clear();
            Console.WriteLine("Write the Shop ID".ToString());
            try
            {
                int id = int.Parse(Console.ReadLine(), provider); // Rossz id esetén rossz!!!.
                Console.Clear();
                Console.WriteLine(logic.GetOne(id)?.ToString());
            }
            catch (FormatException exception)
            {
                Console.WriteLine(exception.Message);
                Console.WriteLine("Press any key to contnue.".ToString());
                Console.ReadKey();
                GetOneShop(logic);
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Remove one Shop.
        /// </summary>
        /// <param name="logic">Shop logic.</param>
        internal static void RemoveOneShop(ShopLogic logic)
        {
            NumberFormatInfo provider = new NumberFormatInfo();
            Shop shop = new Shop();
            Console.Clear();
            Console.WriteLine("Write the Shop ID".ToString());
            try
            {
                int id = int.Parse(Console.ReadLine(), provider); // Rossz id esetén rossz!!!.
                shop = logic?.GetOne(id);
                Console.WriteLine(shop?.ToString());
                logic?.ShopRemove(shop);
                Console.WriteLine("Shop Deleted".ToString());
            }
            catch (FormatException exception)
            {
                Console.WriteLine(exception.Message);
                Console.WriteLine("Press any key to contnue.".ToString());
                Console.ReadKey();
                RemoveOneShop(logic);
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Change One Shop.
        /// </summary>
        /// <param name="logic">Shop Logic.</param>
        internal static void ChangeOneShop(ShopLogic logic)
        {
            NumberFormatInfo provider = new NumberFormatInfo();
            Shop shop = new Shop();
            Shop newShop = new Shop();
            Console.Clear();
            Console.WriteLine("Write the Shop ID".ToString());
            try
            {
                int id = int.Parse(Console.ReadLine(), provider); // Rossz id esetén rossz!!!.
                shop = logic?.GetOne(id);
                Console.WriteLine($"Old Shop: \n{shop?.ToString()}");
                newShop = NewManufacturer(shop);
                Console.WriteLine($"New Shop: \n{newShop?.ToString()}");
                logic?.ShopUpdate(newShop);
                Console.WriteLine("Shop Updated".ToString());
            }
            catch (FormatException exception)
            {
                Console.WriteLine(exception.Message);
                Console.WriteLine("Press any key to contnue.".ToString());
                Console.ReadKey();
                ChangeOneShop(logic);
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Insert One Shop.
        /// </summary>
        /// <param name="logic">Shop Logic.</param>
        internal static void InsertOneShop(ShopLogic logic)
        {
            NumberFormatInfo provider = new NumberFormatInfo();
            Shop newShop = new Shop();
            Console.Clear();
            Console.WriteLine("Write the Shop ID".ToString());
            try
            {
                newShop = NewManufacturer();
                Console.WriteLine($"New Shop: \n{newShop?.ToString()}");
                logic?.ShopInsert(newShop);
                Console.WriteLine("Shop Inserted".ToString());
            }
            catch (FormatException exception)
            {
                Console.WriteLine(exception.Message);
                Console.WriteLine("Press any key to contnue.".ToString());
                Console.ReadKey();
                InsertOneShop(logic);
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Shop number of products.
        /// </summary>
        /// /// <param name="logic">Shop logic.</param>
        internal static void GetNumberOfProducts(ShopLogic logic)
        {
            Console.Clear();
            IList<ShopNumberOfProduct> shops = logic.GetNumberOfProducts();
            foreach (ShopNumberOfProduct item in shops)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine("Press any key to contnue.".ToString());
            Console.ReadKey();
        }

        /// <summary>
        /// Shop number of products.
        /// </summary>
        /// /// <param name="logic">Shop logic.</param>
        internal static void GetNumberOfProductsAsync(ShopLogic logic)
        {
            Console.Clear();
            IList<ShopNumberOfProduct> shops = logic.GetNumberOfProductsAsync().Result;
            foreach (ShopNumberOfProduct item in shops)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine("Press any key to contnue.".ToString());
            Console.ReadKey();
        }

        /// <summary>
        /// Set new Shop.
        /// </summary>
        /// <param name="oldShop">Old Shop.</param>
        /// <returns>New Shop.</returns>
        private static Shop NewManufacturer(Shop oldShop)
        {
            Shop newShop = new Shop();
            NumberFormatInfo provider = new NumberFormatInfo();
            newShop.ShopId = oldShop.ShopId;
            Console.WriteLine("Shop new Name".ToString());
            newShop.ShopName = Console.ReadLine();
            Console.WriteLine("Shop new Reliability".ToString());
            newShop.ShopReliability = int.Parse(Console.ReadLine(), provider);
            Console.WriteLine("Shop new Number of workers".ToString());
            newShop.ShopNumberOfWorker = int.Parse(Console.ReadLine(), provider);
            Console.WriteLine("Shop new Leader.".ToString());
            newShop.ShopLeader = Console.ReadLine();
            Console.WriteLine("Shop new location".ToString());
            newShop.ShopLocation = Console.ReadLine();
            Console.WriteLine("Shop new Annual Profit".ToString());
            newShop.ShopAnnualProfit = int.Parse(Console.ReadLine(), provider);
            newShop.Brands = oldShop.Brands;
            return newShop;
        }

        /// <summary>
        /// Set new Shop.
        /// </summary>
        /// <returns>New Shop.</returns>
        private static Shop NewManufacturer()
        {
            Shop newShop = new Shop();
            NumberFormatInfo provider = new NumberFormatInfo();
            Console.WriteLine("Shop new Name".ToString());
            newShop.ShopName = Console.ReadLine();
            Console.WriteLine("Shop new Reliability".ToString());
            newShop.ShopReliability = int.Parse(Console.ReadLine(), provider);
            Console.WriteLine("Shop new Number of workers".ToString());
            newShop.ShopNumberOfWorker = int.Parse(Console.ReadLine(), provider);
            Console.WriteLine("Shop new Leader.".ToString());
            newShop.ShopLeader = Console.ReadLine();
            Console.WriteLine("Shop new location".ToString());
            newShop.ShopLocation = Console.ReadLine();
            Console.WriteLine("Shop new Annual Profit".ToString());
            newShop.ShopAnnualProfit = int.Parse(Console.ReadLine(), provider);
            return newShop;
        }
    }
}
