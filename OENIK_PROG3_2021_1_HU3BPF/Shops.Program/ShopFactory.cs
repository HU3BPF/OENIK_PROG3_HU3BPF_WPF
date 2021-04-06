// <copyright file="ShopFactory.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Shops.Program
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading.Tasks;
    using Shops.Data.Models;
    using Shops.Logic;
    using Shops.Logic.NonCrudClasses;

    /// <summary>
    /// Shop entity methods.
    /// </summary>
    internal static class ShopFactory
    {
        /// <summary>
        /// Get all Shop.
        /// </summary>
        /// <param name="logic">Shop logic.</param>
        internal static void GetAllShop(ShopManagementLogic logic)
        {
            Console.Clear();
            foreach (var item in logic.GetALL())
            {
                Console.WriteLine(item.ToString());
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Gets One Shop.
        /// </summary>
        /// <param name="logic">Shop logic.</param>
        internal static void GetOneShop(ShopManagementLogic logic)
        {
            NumberFormatInfo provider = new NumberFormatInfo();
            Console.Clear();
            Console.WriteLine("Write the Shop ID".ToString());
            try
            {
                int id = int.Parse(Console.ReadLine(), provider); // Rossz id esetén rossz!!!.
                Console.Clear();
                Console.WriteLine(logic.GetOne(id)?.ToString());
                Console.ReadKey();
            }
            catch (FormatException exception)
            {
                Console.WriteLine(exception.Message);
                Console.WriteLine("Press any key to contnue or Press Esc To exit.".ToString());
                if (Console.ReadKey().Key != ConsoleKey.Escape)
                {
                    GetOneShop(logic);
                }
            }
            catch (EntityNotFoundException exception)
            {
                Console.WriteLine(exception.Message);
                Console.WriteLine("Press any key to contnue or Press Esc To exit.".ToString());
                if (Console.ReadKey().Key != ConsoleKey.Escape)
                {
                    GetOneShop(logic);
                }
            }
        }

        /// <summary>
        /// Remove one Shop.
        /// </summary>
        /// <param name="logic">Shop logic.</param>
        internal static void RemoveOneShop(ShopManagementLogic logic)
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
                Console.ReadKey();
            }
            catch (FormatException exception)
            {
                Console.WriteLine(exception.Message);
                Console.WriteLine("Press any key to contnue or Press Esc To exit.".ToString());
                if (Console.ReadKey().Key != ConsoleKey.Escape)
                {
                    RemoveOneShop(logic);
                }
            }
            catch (EntityNotFoundException exception)
            {
                Console.WriteLine(exception.Message);
                Console.WriteLine("Press any key to contnue or Press Esc To exit.".ToString());
                if (Console.ReadKey().Key != ConsoleKey.Escape)
                {
                    RemoveOneShop(logic);
                }
            }
        }

        /// <summary>
        /// Change One Shop.
        /// </summary>
        /// <param name="logic">Shop Logic.</param>
        internal static void ChangeOneShop(ShopManagementLogic logic)
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
                Console.ReadKey();
            }
            catch (FormatException exception)
            {
                Console.WriteLine(exception.Message);
                Console.WriteLine("Press any key to contnue or Press Esc To exit.".ToString());
                if (Console.ReadKey().Key != ConsoleKey.Escape)
                {
                    ChangeOneShop(logic);
                }
            }
            catch (EntityNotFoundException exception)
            {
                Console.WriteLine(exception.Message);
                Console.WriteLine("Press any key to contnue or Press Esc To exit.".ToString());
                if (Console.ReadKey().Key != ConsoleKey.Escape)
                {
                    ChangeOneShop(logic);
                }
            }
        }

        /// <summary>
        /// Insert One Shop.
        /// </summary>
        /// <param name="logic">Shop Logic.</param>
        internal static void InsertOneShop(ShopManagementLogic logic)
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
                Console.ReadKey();
            }
            catch (FormatException exception)
            {
                Console.WriteLine(exception.Message);
                Console.WriteLine("Press any key to contnue or Press Esc To exit.".ToString());
                if (Console.ReadKey().Key != ConsoleKey.Escape)
                {
                    InsertOneShop(logic);
                }
            }
            catch (EntityNotFoundException exception)
            {
                Console.WriteLine(exception.Message);
                Console.WriteLine("Press any key to contnue or Press Esc To exit.".ToString());
                if (Console.ReadKey().Key != ConsoleKey.Escape)
                {
                    InsertOneShop(logic);
                }
            }
        }

        /// <summary>
        /// Shop number of products.
        /// </summary>
        /// /// <param name="logic">Shop logic.</param>
        internal static void GetNumberOfProducts(ShopManagementLogic logic)
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
        /// Shop number of products ASYNC.
        /// </summary>
        /// /// <param name="logic">Shop logic.</param>
        internal static void GetNumberOfProductsAsync(ShopManagementLogic logic)
        {
            Console.Clear();
            Task<IList<ShopNumberOfProduct>> task = logic.GetNumberOfProductsAsync();
            task.Start();
            var shops = task.Result;
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
            if (oldShop == null)
            {
                throw new EntityNotFoundException();
            }

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
