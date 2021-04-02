// <copyright file="ManufacturerMethods.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MobileWebshop.Program
{
    using System;
    using System.Globalization;
    using MobileWebshop.Data.Models;
    using MobileWebshop.Logic;

    /// <summary>
    /// Manufacturer entity methods.
    /// </summary>
    internal static class ManufacturerMethods
    {
        /// <summary>
        /// Get all manufacturer.
        /// </summary>
        /// <param name="logic">Manufacturer logic.</param>
        internal static void GetAllManufacturer(ManufacturerLogic logic)
        {
            Console.Clear();
            foreach (var item in logic.GetALL())
            {
                Console.WriteLine(item.ToString());
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Get ONe manufacturer.
        /// </summary>
        /// <param name="logic">Manufacturer logic.</param>
        internal static void GetOneManufacturer(ManufacturerLogic logic)
        {
            NumberFormatInfo provider = new NumberFormatInfo();
            Console.Clear();
            Console.WriteLine("Write the Manufacturer ID".ToString());
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
                GetOneManufacturer(logic);
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Remove One manufacturer.
        /// </summary>
        /// <param name="logic">Manufacturer logic.</param>
        internal static void RemoveOneManufacturer(ManufacturerLogic logic)
        {
            NumberFormatInfo provider = new NumberFormatInfo();
            Manufacturer manufacturer = new Manufacturer();
            Console.Clear();
            Console.WriteLine("Write the Manufacturer ID".ToString());
            try
            {
                int id = int.Parse(Console.ReadLine(), provider); // Rossz id esetén rossz!!!.
                manufacturer = logic?.GetOne(id);
                Console.WriteLine(manufacturer?.ToString());
                logic?.ManufacturerRemove(manufacturer);
                Console.WriteLine("Manufacturer Deleted".ToString());
            }
            catch (FormatException exception)
            {
                Console.WriteLine(exception.Message);
                Console.WriteLine("Press any key to contnue.".ToString());
                Console.ReadKey();
                RemoveOneManufacturer(logic);
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Change One Manufacturer.
        /// </summary>
        /// <param name="logic">Manufacturer Logic.</param>
        internal static void ChangeOneManufacturer(ManufacturerLogic logic)
        {
            NumberFormatInfo provider = new NumberFormatInfo();
            Manufacturer manufacturer = new Manufacturer();
            Manufacturer newManufacturer = new Manufacturer();
            Console.Clear();
            Console.WriteLine("Write the Manufacturer ID".ToString());
            try
            {
                int id = int.Parse(Console.ReadLine(), provider); // Rossz id esetén rossz!!!.
                manufacturer = logic?.GetOne(id);
                Console.WriteLine($"Old Manufacturer: \n{manufacturer?.ToString()}");
                newManufacturer = NewManufacturer(manufacturer);
                Console.WriteLine($"New Manufacturer: \n{newManufacturer?.ToString()}");
                logic?.ManufacturerUpdate(newManufacturer);
                Console.WriteLine("Manufacturer Updated".ToString());
            }
            catch (FormatException exception)
            {
                Console.WriteLine(exception.Message);
                Console.WriteLine("Press any key to contnue.".ToString());
                Console.ReadKey();
                ChangeOneManufacturer(logic);
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Change One Manufacturer.
        /// </summary>
        /// <param name="logic">Manufacturer Logic.</param>
        internal static void InsertOneManufacturer(ManufacturerLogic logic)
        {
            NumberFormatInfo provider = new NumberFormatInfo();
            Manufacturer newManufacturer = new Manufacturer();
            Console.Clear();
            Console.WriteLine("Write the Manufacturer ID".ToString());
            try
            {
                newManufacturer = NewManufacturer();
                Console.WriteLine($"New Manufacturer: \n{newManufacturer?.ToString()}");
                logic?.ManufacturerInsert(newManufacturer);
                Console.WriteLine("Manufacturer Inserted".ToString());
            }
            catch (FormatException exception)
            {
                Console.WriteLine(exception.Message);
                Console.WriteLine("Press any key to contnue.".ToString());
                Console.ReadKey();
                InsertOneManufacturer(logic);
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Set new product.
        /// </summary>
        /// <param name="oldManufacturer">Old Manufacturer.</param>
        /// <returns>New product.</returns>
        private static Manufacturer NewManufacturer(Manufacturer oldManufacturer)
        {
            Manufacturer newManufacturer = new Manufacturer();
            NumberFormatInfo provider = new NumberFormatInfo();
            newManufacturer.ManufacturerId = oldManufacturer.ManufacturerId;
            Console.WriteLine("Manufacturer new Name".ToString());
            newManufacturer.ManufacturerName = Console.ReadLine();
            Console.WriteLine("Manufacturer new Reliability".ToString());
            newManufacturer.ManufacturerReliability = int.Parse(Console.ReadLine(), provider);
            Console.WriteLine("Manufacturer new Number of workers".ToString());
            newManufacturer.ManufacturerWorkersCount = int.Parse(Console.ReadLine(), provider);
            Console.WriteLine("Manufacturer new CEO.".ToString());
            newManufacturer.ManufacturerCEO = Console.ReadLine();
            Console.WriteLine("Manufacturer new Center".ToString());
            newManufacturer.ManufacturerCenter = Console.ReadLine();
            newManufacturer.Brands = oldManufacturer.Brands;
            return newManufacturer;
        }

        /// <summary>
        /// Set new product.
        /// </summary>
        /// <returns>New product.</returns>
        private static Manufacturer NewManufacturer()
        {
            Manufacturer newManufacturer = new Manufacturer();
            NumberFormatInfo provider = new NumberFormatInfo();
            Console.WriteLine("Manufacturer new Name".ToString());
            newManufacturer.ManufacturerName = Console.ReadLine();
            Console.WriteLine("Manufacturer new Reliability".ToString());
            newManufacturer.ManufacturerReliability = int.Parse(Console.ReadLine(), provider);
            Console.WriteLine("Manufacturer new Number of workers".ToString());
            newManufacturer.ManufacturerWorkersCount = int.Parse(Console.ReadLine(), provider);
            Console.WriteLine("Manufacturer new CEO.".ToString());
            newManufacturer.ManufacturerCEO = Console.ReadLine();
            Console.WriteLine("Manufacturer new Center".ToString());
            newManufacturer.ManufacturerCenter = Console.ReadLine();
            return newManufacturer;
        }
    }
}
