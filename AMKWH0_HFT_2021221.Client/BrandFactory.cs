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
    class BrandFactory
    {
        internal static void GetBrandAveragePrices(RestService rest)
        {
            Console.Clear();
            IEnumerable<BrandAveragePrice> brandAveragePrices = rest.Get<BrandAveragePrice>("stat/GetBrandAveragePrices");
            foreach (var item in brandAveragePrices)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("Press any key to Continue!");
            Console.ReadKey();
        }
        internal static void ReadAllBrand(RestService rest)
        {
            var brands = rest.Get<Brand>("brand");
            Console.Clear();
            foreach (var brand in brands)
            {
                Console.WriteLine(brand.ToString());
            }
            Console.ReadKey();
        }

        internal static void ReadBrand(RestService rest)
        {
            Console.Clear();
            Console.WriteLine("Write here the brand ID: ");
            try
            {
                int id = int.Parse(Console.ReadLine());
                Console.Clear();
                if (rest.GetSingle<Brand>($"brand/{id}") == null)
                {
                    Console.WriteLine("brand doesn't exist");
                }
                else
                {
                    Console.WriteLine(rest.GetSingle<Brand>($"brand/{id}")?.ToString());
                }

                Console.ReadKey();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                Console.WriteLine("Press any key to Continue or press ESC to Exit!");
                if (Console.ReadKey().Key != ConsoleKey.Escape)
                {
                    ReadBrand(rest);
                }
            }
        }
        internal static void CreateBrand(RestService rest)
        {
            Brand newbrand = new Brand();
            Console.Clear();
            try
            {
                newbrand = CreateNewBrand();
                rest.Post<Brand>(newbrand, "brand");
                Console.Clear();
                Console.WriteLine("You created new brand!\n");
                Console.WriteLine(rest.Get<Brand>("brand").LastOrDefault().ToString());
                Console.ReadKey();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                Console.WriteLine("Press any key to Continue or press ESC to Exit!");
                if (Console.ReadKey().Key != ConsoleKey.Escape)
                {
                    CreateBrand(rest);
                }
            }
        }

        internal static void DeleteBrand(RestService rest)
        {
            Console.Clear();
            Console.WriteLine("Write here the brand ID: ");
            try
            {
                int id = int.Parse(Console.ReadLine());
                Console.Clear();
                if (rest.GetSingle<Brand>($"brand/{id}") == null)
                {
                    Console.WriteLine("Brand doesn't exist");
                }
                else
                {
                    Console.WriteLine(rest.GetSingle<Brand>($"brand/{id}")?.ToString());
                    rest.Delete(id, "brand");
                    Console.WriteLine("You deleted the brand!");
                }

                Console.ReadKey();
            }
            catch (NullReferenceException exception)
            {
                Console.WriteLine(exception.Message);
                Console.WriteLine("Press any key to Continue or press ESC to Exit!");
                if (Console.ReadKey().Key != ConsoleKey.Escape)
                {
                    DeleteBrand(rest);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                Console.WriteLine("Press any key to Continue or press ESC to Exit!");
                if (Console.ReadKey().Key != ConsoleKey.Escape)
                {
                    DeleteBrand(rest);
                }
            }
        }

        internal static void UpdateBrand(RestService rest)
        {
            Console.Clear();
            Console.WriteLine("Write here the brand ID: ");
            try
            {
                int id = int.Parse(Console.ReadLine());
                Brand newBrand = brandUpdate(id, rest);
                rest.Put(newBrand, "brand");
                Console.Clear();
                Console.WriteLine("You updated the brand!\n");
                Console.WriteLine(rest.GetSingle<Brand>($"brand/{id}").ToString());
                Console.ReadKey();
            }
            catch (EntityNotFound exception)
            {
                Console.WriteLine(exception.Message);
                Console.WriteLine("Press any key to Continue or press ESC to Exit!");
                if (Console.ReadKey().Key != ConsoleKey.Escape)
                {
                    UpdateBrand(rest);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                Console.WriteLine("Press any key to Continue or press ESC to Exit!");
                if (Console.ReadKey().Key != ConsoleKey.Escape)
                {
                    UpdateBrand(rest);
                }
            }
        }

        private static Brand brandUpdate(int id, RestService rest)
        {
            Brand updatebrand = new Brand();
            Brand oldBrand = rest.GetSingle<Brand>($"brand/{id}");
            if (oldBrand == null)
            {
                throw new EntityNotFound();
            }
            else
            {
                Console.WriteLine(oldBrand.ToString());
                Console.WriteLine("brand New Name");
                updatebrand.Brand_Name = Console.ReadLine();
                Console.WriteLine("brand New Quality (1-10)");
                updatebrand.Brand_Quality = int.Parse(Console.ReadLine());
                Console.WriteLine("brand New Country");
                updatebrand.Brand_Country = Console.ReadLine();
                Console.WriteLine("brand New Founder");
                updatebrand.Brand_Founder = Console.ReadLine();
                Console.WriteLine("brand New Year Of Foundation");
                updatebrand.Brand_YearOfFoundation = int.Parse(Console.ReadLine());
                updatebrand.Brand_Id = id;
            }
            return updatebrand;
        }
        private static Brand CreateNewBrand()
        {
            Brand newbrand = new Brand();
            Console.WriteLine("brand New Name");
            newbrand.Brand_Name = Console.ReadLine();
            Console.WriteLine("brand New Quality (1-10)");
            newbrand.Brand_Quality = int.Parse(Console.ReadLine());
            Console.WriteLine("brand New Country");
            newbrand.Brand_Country = Console.ReadLine();
            Console.WriteLine("brand New Founder");
            newbrand.Brand_Founder = Console.ReadLine();
            Console.WriteLine("brand New Year Of Foundation");
            newbrand.Brand_YearOfFoundation = int.Parse(Console.ReadLine());
            return newbrand;
        }
    }
}
