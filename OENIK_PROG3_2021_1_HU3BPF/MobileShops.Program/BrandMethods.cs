// <copyright file="BrandMethods.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MobileWebshop.Program
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using MobileShops.Logic;
    using MobileShops.Logic.NonCrudLogic;
    using MobileWebshop.Data.Models;
    using MobileWebshop.Logic;

    /// <summary>
    /// Brand entity methods.
    /// </summary>
    internal static class BrandMethods
    {
        /// <summary>
        /// Get all Brand.
        /// </summary>
        /// <param name="logic">Brand logic.</param>
        internal static void GetAllBrand(BrandLogic logic)
        {
            Console.Clear();
            foreach (var item in logic.GetALL())
            {
                Console.WriteLine(item.ToString());
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Gets one Brand entity.
        /// </summary>
        /// <param name="logic">Brand Logic.</param>
        internal static void GetOneBrand(BrandLogic logic)
        {
            NumberFormatInfo provider = new NumberFormatInfo();
            Console.Clear();
            Console.WriteLine("Write the Brand ID".ToString());
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
                GetOneBrand(logic);
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Remove One Brand.
        /// </summary>
        /// <param name="logic">Brand Logic.</param>
        internal static void RemoveOneBrand(BrandLogic logic)
        {
            NumberFormatInfo provider = new NumberFormatInfo();
            Brand brand = new Brand();
            Console.Clear();
            Console.WriteLine("Write the Brand ID".ToString());
            try
            {
                int id = int.Parse(Console.ReadLine(), provider); // Rossz id esetén rossz!!!.
                brand = logic?.GetOne(id);
                Console.WriteLine(brand?.ToString());
                logic?.BrandRemove(brand);
                Console.WriteLine("Brand Deleted".ToString());
            }
            catch (FormatException exception)
            {
                Console.WriteLine(exception.Message);
                Console.WriteLine("Press any key to contnue.".ToString());
                Console.ReadKey();
                RemoveOneBrand(logic);
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Change One Brand.
        /// </summary>
        /// <param name="logic">Brand logic.</param>
        internal static void ChangeOneBrand(BrandLogic logic)
        {
            NumberFormatInfo provider = new NumberFormatInfo();
            Brand brand = new Brand();
            Brand newBrand = new Brand();
            Console.Clear();
            Console.WriteLine("Write the Brand ID".ToString());
            try
            {
                int id = int.Parse(Console.ReadLine(), provider); // Rossz id esetén rossz!!!.
                brand = logic?.GetOne(id);
                Console.WriteLine($"Old Brand: \n{brand?.ToString()}");
                newBrand = NewBrand(brand);
                Console.WriteLine($"New Brand: \n{newBrand?.ToString()}");
                logic?.BrandUpdate(newBrand);
                Console.WriteLine("Brand Updated".ToString());
            }
            catch (FormatException exception)
            {
                Console.WriteLine(exception.Message);
                Console.WriteLine("Press any key to contnue.".ToString());
                Console.ReadKey();
                ChangeOneBrand(logic);
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Change One Brand.
        /// </summary>
        /// <param name="logic">Brand logic.</param>
        internal static void InsertOneBrand(BrandLogic logic)
        {
            NumberFormatInfo provider = new NumberFormatInfo();
            Brand newBrand = new Brand();
            Console.Clear();
            try
            {
                newBrand = NewBrand();
                Console.WriteLine($"New Brand: \n{newBrand?.ToString()}");
                logic?.BrandInsert(newBrand);
                Console.WriteLine("Brand Inserted".ToString());
            }
            catch (FormatException exception)
            {
                Console.WriteLine(exception.Message);
                Console.WriteLine("Press any key to contnue.".ToString());
                Console.ReadKey();
                InsertOneBrand(logic);
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Brand Average profit.
        /// </summary>
        /// /// <param name="logic">Brand logic.</param>
        internal static void BrandAverageProfit(BrandLogic logic)
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
        /// Brand Average profit.
        /// </summary>
        /// /// <param name="logic">Brand logic.</param>
        internal static void BrandAverageRating(BrandLogic logic)
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
        /// Brand Average profit.
        /// </summary>
        /// /// <param name="logic">Brand logic.</param>
        internal static void BrandAverageProfitAsync(BrandLogic logic)
        {
            Console.Clear();
            IList<BrandAveragerProductPrice> brands = logic.GetBrandAveragesPriceAsync();
            foreach (BrandAveragerProductPrice item in brands)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine("Press any key to contnue.".ToString());
            Console.ReadKey();
        }

        /// <summary>
        /// Brand Average profit.
        /// </summary>
        /// /// <param name="logic">Brand logic.</param>
        internal static void BrandAverageRatingAsync(BrandLogic logic)
        {
            Console.Clear();
            IList<BrandAverageProductRating> brands = logic.GetBrandAveragesRatingAsync();
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
            newBrand.NumberOfUsers = int.Parse(Console.ReadLine(), provider);
            Console.WriteLine("Brand new Number Of Products".ToString());
            newBrand.BrandNumberOfProducts = int.Parse(Console.ReadLine(), provider);
            newBrand.Shop = oldBrand.Shop;
            newBrand.ShopID = oldBrand.ShopID;
            newBrand.Products = oldBrand.Products;
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
