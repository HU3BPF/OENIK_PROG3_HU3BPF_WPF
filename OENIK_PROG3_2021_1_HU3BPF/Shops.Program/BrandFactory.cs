// <copyright file="BrandFactory.cs" company="PlaceholderCompany">
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
    /// Brand entity methods.
    /// </summary>
    internal static class BrandFactory
    {
        /// <summary>
        /// Get all Brand.
        /// </summary>
        /// <param name="logic">Brand logic.</param>
        internal static void GetAllBrand(GoodsManagementLogic logic)
        {
            Console.Clear();
            foreach (var item in logic.BrandGetALL())
            {
                Console.WriteLine(item.ToString());
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Gets one Brand entity.
        /// </summary>
        /// <param name="logic">Brand Logic.</param>
        internal static void GetOneBrand(GoodsManagementLogic logic)
        {
            NumberFormatInfo provider = new NumberFormatInfo();
            Console.Clear();
            Console.WriteLine("Write the Brand ID".ToString());
            try
            {
                int id = int.Parse(Console.ReadLine(), provider); // Rossz id esetén rossz!!!.
                Console.Clear();
                Console.WriteLine(logic?.BrandGetOne(id)?.ToString());
                Console.ReadKey();
            }
            catch (FormatException exception)
            {
                Console.WriteLine(exception.Message);
                Console.WriteLine("Press any key to contnue or Press Esc To exit.".ToString());
                if (Console.ReadKey().Key != ConsoleKey.Escape)
                {
                    GetOneBrand(logic);
                }
            }
            catch (EntityNotFoundException exception)
            {
                Console.WriteLine(exception.Message);
                Console.WriteLine("Press any key to contnue or Press Esc To exit.".ToString());
                if (Console.ReadKey().Key != ConsoleKey.Escape)
                {
                    GetOneBrand(logic);
                }
            }
        }

        /// <summary>
        /// Remove One Brand.
        /// </summary>
        /// <param name="logic">Brand Logic.</param>
        internal static void RemoveOneBrand(GoodsManagementLogic logic)
        {
            NumberFormatInfo provider = new NumberFormatInfo();
            Brand brand = new Brand();
            Console.Clear();
            Console.WriteLine("Write the Brand ID".ToString());
            try
            {
                int id = int.Parse(Console.ReadLine(), provider); // Rossz id esetén rossz!!!.
                brand = logic?.BrandGetOne(id);
                Console.WriteLine(brand?.ToString());
                logic?.BrandRemove(brand);
                Console.WriteLine("Brand Deleted".ToString());
                Console.ReadKey();
            }
            catch (FormatException exception)
            {
                Console.WriteLine(exception.Message);
                Console.WriteLine("Press any key to contnue or Press Esc To exit.".ToString());
                if (Console.ReadKey().Key != ConsoleKey.Escape)
                {
                    RemoveOneBrand(logic);
                }
            }
            catch (EntityNotFoundException exception)
            {
                Console.WriteLine(exception.Message);
                Console.WriteLine("Press any key to contnue or Press Esc To exit.".ToString());
                if (Console.ReadKey().Key != ConsoleKey.Escape)
                {
                    RemoveOneBrand(logic);
                }
            }
        }

        /// <summary>
        /// Change One Brand.
        /// </summary>
        /// <param name="logic">Brand logic.</param>
        internal static void ChangeOneBrand(GoodsManagementLogic logic)
        {
            NumberFormatInfo provider = new NumberFormatInfo();
            Brand brand = new Brand();
            Brand newBrand = new Brand();
            Console.Clear();
            Console.WriteLine("Write the Brand ID".ToString());
            try
            {
                int id = int.Parse(Console.ReadLine(), provider); // Rossz id esetén rossz!!!.
                brand = logic?.BrandGetOne(id);
                Console.WriteLine($"Old Brand: \n{brand?.ToString()}");
                newBrand = NewBrand(brand);
                Console.WriteLine($"New Brand: \n{newBrand?.ToString()}");
                logic?.BrandUpdate(newBrand);
                Console.WriteLine("Brand Updated".ToString());
                Console.ReadKey();
            }
            catch (FormatException exception)
            {
                Console.WriteLine(exception.Message);
                Console.WriteLine("Press any key to contnue or Press Esc To exit.".ToString());
                if (Console.ReadKey().Key != ConsoleKey.Escape)
                {
                    ChangeOneBrand(logic);
                }
            }
            catch (EntityNotFoundException exception)
            {
                Console.WriteLine(exception.Message);
                Console.WriteLine("Press any key to contnue or Press Esc To exit.".ToString());
                if (Console.ReadKey().Key != ConsoleKey.Escape)
                {
                    ChangeOneBrand(logic);
                }
            }
        }

        /// <summary>
        /// Change One Brand.
        /// </summary>
        /// <param name="logic">Brand logic.</param>
        internal static void InsertOneBrand(GoodsManagementLogic logic)
        {
            NumberFormatInfo provider = new NumberFormatInfo();
            Brand newBrand = new Brand();
            Console.Clear();
            try
            {
                newBrand = NewBrand();
                logic?.BrandInsert(newBrand);
                Console.WriteLine($"New Brand: \n{newBrand?.ToString()}");
                Console.WriteLine("Brand Inserted".ToString());
                Console.ReadKey();
            }
            catch (FormatException exception)
            {
                Console.WriteLine(exception.Message);
                Console.WriteLine("Press any key to contnue or Press Esc To exit.".ToString());
                if (Console.ReadKey().Key != ConsoleKey.Escape)
                {
                    InsertOneBrand(logic);
                }
            }
            catch (EntityNotFoundException exception)
            {
                Console.WriteLine(exception.Message);
                Console.WriteLine("Press any key to contnue or Press Esc To exit.".ToString());
                if (Console.ReadKey().Key != ConsoleKey.Escape)
                {
                    InsertOneBrand(logic);
                }
            }
        }

        /// <summary>
        /// Brand Average Product Price.
        /// </summary>
        /// /// <param name="logic">Brand logic.</param>
        internal static void BrandAveragePrice(GoodsManagementLogic logic)
        {
            Console.Clear();
            IList<BrandAveragerProductPrice> brands = logic.GetBrandAveragesPrice();
            foreach (BrandAveragerProductPrice item in brands)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine("Press any key to contnue.".ToString());
            Console.ReadKey();
        }

        /// <summary>
        /// Brand Average Product Rating.
        /// </summary>
        /// /// <param name="logic">Brand logic.</param>
        internal static void BrandAverageRating(GoodsManagementLogic logic)
        {
            Console.Clear();
            IList<BrandAverageProductRating> brands = logic.GetBrandAveragesRating();
            foreach (BrandAverageProductRating item in brands)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine("Press any key to contnue.".ToString());
            Console.ReadKey();
        }

        /// <summary>
        /// Brand Average Product Price ASYNC.
        /// </summary>
        /// /// <param name="logic">Brand logic.</param>
        internal static void BrandAveragePriceAsync(GoodsManagementLogic logic)
        {
            Console.Clear();
            Task<IList<BrandAveragerProductPrice>> task = logic.GetBrandAveragesPriceAsync();
            task.Start();
            var brands = task.Result;
            foreach (BrandAveragerProductPrice item in brands)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine("Press any key to contnue.".ToString());
            Console.ReadKey();
        }

        /// <summary>
        /// Brand Average Product RATING ASYNC.
        /// </summary>
        /// /// <param name="logic">Brand logic.</param>
        internal static void BrandAverageRatingAsync(GoodsManagementLogic logic)
        {
            Console.Clear();
            Task<IList<BrandAverageProductRating>> task = logic.GetBrandAveragesRatingAsync();
            task.Start();
            var brands = task.Result;
            foreach (BrandAverageProductRating item in brands)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine("Press any key to contnue.".ToString());
            Console.ReadKey();
        }

        /// <summary>
        /// Set new Brand.
        /// </summary>
        /// <param name="oldBrand">Old Brand.</param>
        /// <returns>New Brand.</returns>
        private static Brand NewBrand(Brand oldBrand)
        {
            if (oldBrand == null)
            {
                throw new EntityNotFoundException();
            }

            Brand newBrand = new Brand();
            NumberFormatInfo provider = new NumberFormatInfo();
            newBrand.BrandId = oldBrand.BrandId;
            Console.WriteLine("Brand new Name".ToString());
            newBrand.BrandName = Console.ReadLine();
            Console.WriteLine("Brand new Quality.".ToString());
            newBrand.BrandQuality = int.Parse(Console.ReadLine(), provider);
            Console.WriteLine("Brand new Yearly Income".ToString());
            newBrand.BrandAnnualProfit = int.Parse(Console.ReadLine(), provider);
            Console.WriteLine("Brand new Number Of Users".ToString());
            newBrand.NumberOfUsers = int.Parse(Console.ReadLine(), provider);
            Console.WriteLine("Brand new Number Of Products".ToString());
            newBrand.BrandNumberOfProducts = int.Parse(Console.ReadLine(), provider);
            newBrand.Shop = oldBrand.Shop;
            newBrand.ShopID = oldBrand.ShopID;
            return newBrand;
        }

        /// <summary>
        /// Set new Brand.
        /// </summary>
        /// <returns>New Brand.</returns>
        private static Brand NewBrand()
        {
            Brand newBrand = new Brand();
            NumberFormatInfo provider = new NumberFormatInfo();
            Console.WriteLine("Brand new Name".ToString());
            newBrand.BrandName = Console.ReadLine();
            Console.WriteLine("Brand new Quality.".ToString());
            newBrand.BrandQuality = int.Parse(Console.ReadLine(), provider);
            Console.WriteLine("Brand new Yearly Income".ToString());
            newBrand.BrandAnnualProfit = int.Parse(Console.ReadLine(), provider);
            Console.WriteLine("Brand new Number Of Users".ToString());
            newBrand.NumberOfUsers = int.Parse(Console.ReadLine(), provider);
            Console.WriteLine("Brand new Number Of Products".ToString());
            newBrand.BrandNumberOfProducts = int.Parse(Console.ReadLine(), provider);
            return newBrand;
        }
    }
}
