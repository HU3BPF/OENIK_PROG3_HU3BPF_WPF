﻿// <copyright file="ProductFactory.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Shops.Program
{
    using System;
    using System.Globalization;
    using Shops.Data.Models;
    using Shops.Logic;

    /// <summary>
    /// Product entity methods.
    /// </summary>
    internal static class ProductFactory
    {
        /// <summary>
        /// Get All products.
        /// </summary>
        /// <param name="logic">product logic.</param>
        internal static void GetAllProduct(GoodsManagementLogic logic)
        {
            Console.Clear();
            foreach (var item in logic.ProductGetALL())
            {
                Console.WriteLine(item.ToString());
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Get All products.
        /// </summary>
        /// <param name="logic">product logic.</param>
        internal static void GetAllProductByBrand(GoodsManagementLogic logic)
        {
            NumberFormatInfo provider = new NumberFormatInfo();
            Console.Clear();
            Console.WriteLine("Write the Brand ID".ToString());
            try
            {
                int id = int.Parse(Console.ReadLine(), provider); // Rossz id esetén rossz!!!.
                Console.Clear();
                Console.WriteLine("Brand Name: " + logic.BrandGetOne(id).BrandName?.ToString() + "\n");
                Console.WriteLine("Products: ".ToString());
                foreach (var item in logic?.GetProductByBrand(id))
                {
                    Console.WriteLine(item.ToString());
                }
            }
            catch (FormatException exception)
            {
                Console.WriteLine(exception.Message);
                Console.WriteLine("Press any key to contnue.".ToString());
                Console.ReadKey();
                GetONeProduct(logic);
            }
            catch (ArgumentNullException exception)
            {
                Console.WriteLine(exception.Message);
                Console.WriteLine("Press any key to contnue.".ToString());
                Console.ReadKey();
                GetONeProduct(logic);
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Gets One product.
        /// </summary>
        /// <param name="logic">product logic.</param>
        internal static void GetONeProduct(GoodsManagementLogic logic)
        {
            NumberFormatInfo provider = new NumberFormatInfo();
            Console.Clear();
            Console.WriteLine("Write the Product ID".ToString());
            try
            {
                int id = int.Parse(Console.ReadLine(), provider); // Rossz id esetén rossz!!!.
                Console.Clear();
                Console.WriteLine(logic.ProductGetOne(id)?.ToString());
            }
            catch (FormatException exception)
            {
                Console.WriteLine(exception.Message);
                Console.WriteLine("Press any key to contnue.".ToString());
                Console.ReadKey();
                GetONeProduct(logic);
            }
            catch (ArgumentNullException exception)
            {
                Console.WriteLine(exception.Message);
                Console.WriteLine("Press any key to contnue.".ToString());
                Console.ReadKey();
                GetONeProduct(logic);
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Remove one Product.
        /// </summary>
        /// <param name="logic">product logic.</param>
        internal static void RemoveOneProduct(GoodsManagementLogic logic)
        {
            NumberFormatInfo provider = new NumberFormatInfo();
            Product product = new Product();
            Console.Clear();
            Console.WriteLine("Write the Product ID".ToString());
            try
            {
                int id = int.Parse(Console.ReadLine(), provider); // Rossz id esetén rossz!!!.
                product = logic?.ProductGetOne(id);
                Console.WriteLine(product?.ToString());
                logic?.ProductRemove(product);
                Console.WriteLine("Product Deleted".ToString());
            }
            catch (FormatException exception)
            {
                Console.WriteLine(exception.Message);
                Console.WriteLine("Press any key to contnue.".ToString());
                Console.ReadKey();
                GetONeProduct(logic);
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Change One Product.
        /// </summary>
        /// <param name="logic">product logic.</param>
        internal static void ChangeOneProduct(GoodsManagementLogic logic)
        {
            NumberFormatInfo provider = new NumberFormatInfo();
            Product product = new Product();
            Product newProduct = new Product();
            Console.Clear();
            Console.WriteLine("Write the Product ID".ToString());
            try
            {
                int id = int.Parse(Console.ReadLine(), provider); // Rossz id esetén rossz!!!.
                product = logic?.ProductGetOne(id);
                Console.WriteLine($"Old Product: \n{product?.ToString()}");
                newProduct = NewProduct(product);
                Console.WriteLine($"New Product: \n{newProduct?.ToString()}");
                logic?.ProductUpdate(newProduct);
                Console.WriteLine("Product Updated".ToString());
            }
            catch (FormatException exception)
            {
                Console.WriteLine(exception.Message);
                Console.WriteLine("Press any key to contnue.".ToString());
                Console.ReadKey();
                ChangeOneProduct(logic);
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Change One Product.
        /// </summary>
        /// <param name="logic">product logic.</param>
        internal static void InsertOneProduct(GoodsManagementLogic logic)
        {
            Product newProduct = new Product();
            Console.Clear();
            Console.WriteLine("Write the Product ID".ToString());
            try
            {
                newProduct = NewProduct();
                Console.WriteLine($"New Product: \n{newProduct?.ToString()}");
                logic?.ProductInsert(newProduct);
                Console.WriteLine("Product Inserted".ToString());
            }
            catch (FormatException exception)
            {
                Console.WriteLine(exception.Message);
                Console.WriteLine("Press any key to contnue.".ToString());
                Console.ReadKey();
                ChangeOneProduct(logic);
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Set new product.
        /// </summary>
        /// <param name="oldProduct">Old product.</param>
        /// <returns>New product.</returns>
        private static Product NewProduct(Product oldProduct)
        {
            Product newProduct = new Product();
            NumberFormatInfo provider = new NumberFormatInfo();
            newProduct.ProductdId = oldProduct.ProductdId;
            Console.WriteLine("Product new Name".ToString());
            newProduct.ProductName = Console.ReadLine();
            Console.WriteLine("Product new Price".ToString());
            newProduct.ProductPrice = int.Parse(Console.ReadLine(), provider);
            Console.WriteLine("Product new colour.".ToString());
            newProduct.ProductColour = Console.ReadLine();
            Console.WriteLine("Product new Stock Number.".ToString());
            newProduct.StockNumber = int.Parse(Console.ReadLine(), provider);
            Console.WriteLine("Product new Rating".ToString());
            newProduct.UsresRating = int.Parse(Console.ReadLine(), provider);
            newProduct.Brand = oldProduct.Brand;
            newProduct.BrandrId = oldProduct.BrandrId;
            return newProduct;
        }

        /// <summary>
        /// Set new product.
        /// </summary>
        /// <returns>New product.</returns>
        private static Product NewProduct()
        {
            Product newProduct = new Product();
            NumberFormatInfo provider = new NumberFormatInfo();
            Console.WriteLine("Product new Name".ToString());
            newProduct.ProductName = Console.ReadLine();
            Console.WriteLine("Product new Price".ToString());
            newProduct.ProductPrice = int.Parse(Console.ReadLine(), provider);
            Console.WriteLine("Product new colour.".ToString());
            newProduct.ProductColour = Console.ReadLine();
            Console.WriteLine("Product new Stock Number.".ToString());
            newProduct.StockNumber = int.Parse(Console.ReadLine(), provider);
            Console.WriteLine("Product new Rating".ToString());
            newProduct.UsresRating = int.Parse(Console.ReadLine(), provider);
            return newProduct;
        }
    }
}