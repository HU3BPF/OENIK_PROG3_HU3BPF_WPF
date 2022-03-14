using AMKWH0_HFT_2021221.Logic;
using AMKWH0_HFT_2021221.Logic.NonCrudClasses;
using AMKWH0_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMKWH0_HFT_2021221.Client
{
    class ManufacturerFactory
    {
        internal static void GetAverageQualityManufacturer(RestService rest)
        {
            Console.Clear();
            IEnumerable<AverageQualityManufacturer> averageQualityManufacturers = rest.Get<AverageQualityManufacturer>("stat/GetAverageQualityManufacturers");
            foreach (var item in averageQualityManufacturers)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("Press any key to Continue!");
            Console.ReadKey();
        }
        internal static void GetConfectioneryManufacturer(RestService rest)
        {
            Console.Clear();
            IEnumerable<ConfectioneryManufacturer> confectioneryManufacturers = rest.Get<ConfectioneryManufacturer>("stat/GetConfectioneryManufacturers");
            foreach (var item in confectioneryManufacturers)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("Press any key to Continue!");
            Console.ReadKey();
        }
        internal static void GetMostAccessoryManufacturer(RestService rest)
        {
            Console.Clear();
            Console.WriteLine(rest.GetSingle<MostAccessoryManufacturer>("stat/GetMostAccessoryManufacturer").ToString());
            Console.WriteLine("Press any key to Continue!");
            Console.ReadKey();
        }

        internal static void GetMostWomensClothingManufacturer(RestService rest)
        {
            Console.Clear();
            Console.WriteLine(rest.GetSingle<MostWomensClothingManufacturer>("stat/GetMostWomensClothingManufacturer").ToString());
            Console.WriteLine("Press any key to Continue!");
            Console.ReadKey();
        }
        internal static void ReadAllManufacturer(RestService rest)
        {
            var manufacturers = rest.Get<Manufacturer>("manufacturer");
            Console.Clear();
            foreach (var manufacturer in manufacturers)
            {
                Console.WriteLine(manufacturer.ToString());
            }
            Console.ReadKey();
        }

        internal static void ReadManufacturer(RestService rest)
        {
            Console.Clear();
            Console.WriteLine("Write here the manufacturer ID: ");
            try
            {
                int id = int.Parse(Console.ReadLine());
                Console.Clear();
                if (rest.GetSingle<Manufacturer>($"manufacturer/{id}") == null)
                {
                    Console.WriteLine("manufacturer doesn't exist");
                }
                else
                {
                    Console.WriteLine(rest.GetSingle<Manufacturer>($"manufacturer/{id}")?.ToString());
                }

                Console.ReadKey();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                Console.WriteLine("Press any key to Continue or press ESC to Exit!");
                if (Console.ReadKey().Key != ConsoleKey.Escape)
                {
                    ReadManufacturer(rest);
                }
            }
        }
        internal static void CreateManufacturer(RestService rest)
        {
            Manufacturer newmanufacturer = new Manufacturer();
            Console.Clear();
            try
            {
                newmanufacturer = CreateNewManufacturer();
                rest.Post(newmanufacturer, "manufacturer");
                Console.Clear();
                Console.WriteLine("You created new manufacturer!\n");
                Console.WriteLine(rest.Get<Manufacturer>("manufacturer").LastOrDefault().ToString());
                Console.ReadKey();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                Console.WriteLine("Press any key to Continue or press ESC to Exit!");
                if (Console.ReadKey().Key != ConsoleKey.Escape)
                {
                    CreateManufacturer(rest);
                }
            }
        }

        internal static void DeleteManufacturer(RestService rest)
        {
            Console.Clear();
            Console.WriteLine("Write here the manufacturer ID: ");
            try
            {
                int id = int.Parse(Console.ReadLine());
                Console.Clear();
                if (rest.GetSingle<Manufacturer>($"manufacturer/{id}") == null)
                {
                    Console.WriteLine("Manufacturer doesn't exist");
                }
                else
                {
                    Console.WriteLine(rest.GetSingle<Manufacturer>($"manufacturer/{id}")?.ToString());
                    rest.Delete(id, "manufacturer");
                    Console.WriteLine("You deleted the manufacturer!");
                }

                Console.ReadKey();
            }
            catch (NullReferenceException exception)
            {
                Console.WriteLine(exception.Message);
                Console.WriteLine("Press any key to Continue or press ESC to Exit!");
                if (Console.ReadKey().Key != ConsoleKey.Escape)
                {
                    DeleteManufacturer(rest);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                Console.WriteLine("Press any key to Continue or press ESC to Exit!");
                if (Console.ReadKey().Key != ConsoleKey.Escape)
                {
                    DeleteManufacturer(rest);
                }
            }
        }

        internal static void UpdateManufacturer(RestService rest)
        {
            Console.Clear();
            Console.WriteLine("Write here the manufacturer ID: ");
            try
            {
                int id = int.Parse(Console.ReadLine());
                Manufacturer newManufacturer = manufacturerUpdate(id, rest);
                rest.Put(newManufacturer, "manufacturer");
                Console.Clear();
                Console.WriteLine("You updated the manufacturer!\n");
                Console.WriteLine(rest.GetSingle<Manufacturer>($"manufacturer/{id}").ToString());
                Console.ReadKey();
            }
            catch (EntityNotFound exception)
            {
                Console.WriteLine(exception.Message);
                Console.WriteLine("Press any key to Continue or press ESC to Exit!");
                if (Console.ReadKey().Key != ConsoleKey.Escape)
                {
                    UpdateManufacturer(rest);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                Console.WriteLine("Press any key to Continue or press ESC to Exit!");
                if (Console.ReadKey().Key != ConsoleKey.Escape)
                {
                    UpdateManufacturer(rest);
                }
            }
        }

        private static Manufacturer manufacturerUpdate(int id, RestService rest)
        {
            Manufacturer updatemanufacturer = new Manufacturer();
            Manufacturer oldManufacturer = rest.GetSingle<Manufacturer>($"manufacturer/{id}");
            if (oldManufacturer == null)
            {
                throw new EntityNotFound();
            }
            else
            {
                Console.WriteLine(oldManufacturer.ToString());
                Console.WriteLine("manufacturer New Name");
                updatemanufacturer.Manufacturer_Name = Console.ReadLine();
                Console.WriteLine("manufacturer New CEO");
                updatemanufacturer.Manufacturer_CEO = Console.ReadLine();
                Console.WriteLine("manufacturer New Number Of Employees");
                updatemanufacturer.Manufacturer_NumberOfEmployees = int.Parse(Console.ReadLine());
                Console.WriteLine("manufacturer New Annual Income");
                updatemanufacturer.Manufacturer_AnnualIncome = int.Parse(Console.ReadLine());
                Console.WriteLine("manufacturer New Site");
                updatemanufacturer.Manufacturer_Site = Console.ReadLine();
                updatemanufacturer.Manufacturer_Id = id;
            }
            return updatemanufacturer;
        }
        private static Manufacturer CreateNewManufacturer()
        {
            Manufacturer newmanufacturer = new Manufacturer();
            Console.WriteLine("manufacturer New Name");
            newmanufacturer.Manufacturer_Name = Console.ReadLine();
            Console.WriteLine("manufacturer New CEO");
            newmanufacturer.Manufacturer_CEO = Console.ReadLine();
            Console.WriteLine("manufacturer New Number Of Employees");
            newmanufacturer.Manufacturer_NumberOfEmployees = int.Parse(Console.ReadLine());
            Console.WriteLine("manufacturer New Annual Income");
            newmanufacturer.Manufacturer_AnnualIncome = int.Parse(Console.ReadLine());
            Console.WriteLine("manufacturer New Site");
            newmanufacturer.Manufacturer_Site = Console.ReadLine();
            return newmanufacturer;
        }
    }
}
