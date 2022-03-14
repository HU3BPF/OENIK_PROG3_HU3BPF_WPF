using AMKWH0_HFT_2021221.Logic;
using AMKWH0_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMKWH0_HFT_2021221.Client
{
    class ProductFactory
    {
        internal static void ReadAllProduct(RestService rest)
        {
            var products = rest.Get<Product>("product");

            Console.Clear();
            foreach (var product in products)
            {
                Console.WriteLine(product.ToString());
            }
            Console.ReadKey();
        }

        internal static void ReadProduct(RestService rest)
        {
            Console.Clear();
            Console.WriteLine("Write here the product ID: ");
            try
            {
                int id = int.Parse(Console.ReadLine());
                Console.Clear();
                if (rest.GetSingle<Product>($"product/{id}") == null)
                {
                    Console.WriteLine("Product doesn't exist");
                }
                else
                {
                    Console.WriteLine(rest.GetSingle<Product>($"product/{id}")?.ToString());
                }

                Console.ReadKey();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                Console.WriteLine("Press any key to Continue or press ESC to Exit!");
                if (Console.ReadKey().Key != ConsoleKey.Escape)
                {
                    ReadProduct(rest);
                }
            }
        }
        internal static void CreateProduct(RestService rest)
        {
            Product newproduct = new Product();
            Console.Clear();
            try
            {
                newproduct = CreateNewProduct();
                rest.Post<Product>(newproduct, "product");
                Console.Clear();
                Console.WriteLine("You created new product!\n");
                Console.WriteLine(rest.Get<Product>("product").LastOrDefault().ToString());
                Console.ReadKey();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                Console.WriteLine("Press any key to Continue or press ESC to Exit!");
                if (Console.ReadKey().Key != ConsoleKey.Escape)
                {
                    CreateProduct(rest);
                }
            }
        }

        internal static void DeleteProduct(RestService rest)
        {
            Console.Clear();
            Console.WriteLine("Write here the product ID: ");
            try
            {
                int id = int.Parse(Console.ReadLine());
                Console.Clear();
                if (rest.GetSingle<Product>($"product/{id}") == null)
                {
                    Console.WriteLine("Product doesn't exist");
                }
                else
                {
                    Console.WriteLine(rest.GetSingle<Product>($"product/{id}")?.ToString());
                    rest.Delete(id, "product");
                    Console.WriteLine("You deleted the product!");
                }

                Console.ReadKey();
            }
            catch (NullReferenceException exception)
            {
                Console.WriteLine(exception.Message);
                Console.WriteLine("Press any key to Continue or press ESC to Exit!");
                if (Console.ReadKey().Key != ConsoleKey.Escape)
                {
                    DeleteProduct(rest);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                Console.WriteLine("Press any key to Continue or press ESC to Exit!");
                if (Console.ReadKey().Key != ConsoleKey.Escape)
                {
                    DeleteProduct(rest);
                }
            }
        }

        internal static void UpdateProduct(RestService rest)
        {
            Console.Clear();
            Console.WriteLine("Write here the product ID: ");
            try
            {
                int id = int.Parse(Console.ReadLine());
                Product newPorduct = ProductUpdate(id, rest);
                rest.Put(newPorduct, "product");
                Console.Clear();
                Console.WriteLine("You updated the product!\n");
                Console.WriteLine(rest.GetSingle<Product>($"product/{id}").ToString());
                Console.ReadKey();
            }
            catch (EntityNotFound exception)
            {
                Console.WriteLine(exception.Message);
                Console.WriteLine("Press any key to Continue or press ESC to Exit!");
                if (Console.ReadKey().Key != ConsoleKey.Escape)
                {
                    UpdateProduct(rest);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                Console.WriteLine("Press any key to Continue or press ESC to Exit!");
                if (Console.ReadKey().Key != ConsoleKey.Escape)
                {
                    UpdateProduct(rest);
                }
            }
        }

        private static Product ProductUpdate(int id, RestService rest)
        {
            Product updateProduct = new Product();
            Product oldProduct = rest.GetSingle<Product>($"product/{id}");
            if (oldProduct == null)
            {
                throw new EntityNotFound();
            }
            else
            {
                Console.WriteLine(oldProduct.ToString());
                Console.WriteLine("Product New Name");
                updateProduct.Product_Name = Console.ReadLine();
                Console.WriteLine("Product New Category");
                updateProduct.Product_Category = Console.ReadLine();
                Console.WriteLine("Product New Gender");
                updateProduct.Product_Gender = Console.ReadLine();
                Console.WriteLine("Product New Material");
                updateProduct.Product_Material = Console.ReadLine();
                Console.WriteLine("Product New Price");
                updateProduct.Product_Price = int.Parse(Console.ReadLine());
                updateProduct.Product_Id = id;
            }
            return updateProduct;
        }
        private static Product CreateNewProduct()
        {
            Product newproduct = new Product();
            Console.WriteLine("Product Name");
            newproduct.Product_Name = Console.ReadLine();
            Console.WriteLine("Product Category");
            newproduct.Product_Category = Console.ReadLine();
            Console.WriteLine("Product Gender");
            newproduct.Product_Gender = Console.ReadLine();
            Console.WriteLine("Product Material");
            newproduct.Product_Material = Console.ReadLine();
            Console.WriteLine("Product Price");
            newproduct.Product_Price = int.Parse(Console.ReadLine());
            return newproduct;
        }
    }
}
