using AMKWH0_HFT_2021221.Data.Models;
using AMKWH0_HFT_2021221.Logic;
using AMKWH0_HFT_2021221.Repository;
using ConsoleTools;
using System.Collections.Generic;
using System;
using AMKWH0_HFT_2021221.Models;

namespace AMKWH0_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            WebShopDbContext ctx = new WebShopDbContext();
            ManufacturerRepository manufacturerRepository = new ManufacturerRepository(ctx);
            BrandRepository brandRepository = new BrandRepository(ctx);
            ProductRepository productRepository = new ProductRepository(ctx);

            ManufacturerLogic manufacturerLogic = new ManufacturerLogic(manufacturerRepository, brandRepository, productRepository);
            BrandLogic brandLogic = new BrandLogic(brandRepository, productRepository);
            ProductLogic productLogic = new ProductLogic(productRepository);

            System.Threading.Thread.Sleep(8000);

            RestService rest = new RestService("http://localhost:51395");

            var menu = new ConsoleMenu()
                .Add("Read All Product", () => ProductFactory.ReadAllProduct(rest))
                .Add("Read Product", () => ProductFactory.ReadProduct(rest))
                .Add("Create Product", () => ProductFactory.CreateProduct(rest))
                .Add("Delete Product", () => ProductFactory.DeleteProduct(rest))
                .Add("Update Product", () => ProductFactory.UpdateProduct(rest))
                .Add("Read All Brand", () => BrandFactory.ReadAllBrand(rest))
                .Add("Read Brand", () => BrandFactory.ReadBrand(rest))
                .Add("Create Brand", () => BrandFactory.CreateBrand(rest))
                .Add("Delete Brand", () => BrandFactory.DeleteBrand(rest))
                .Add("Update Brand", () => BrandFactory.UpdateBrand(rest))
                .Add("Read All Manufacturer", () => ManufacturerFactory.ReadAllManufacturer(rest))
                .Add("Read Manufacturer", () => ManufacturerFactory.ReadManufacturer(rest))
                .Add("Create Manufacturer", () => ManufacturerFactory.CreateManufacturer(rest))
                .Add("Delete Manufacturer", () => ManufacturerFactory.DeleteManufacturer(rest))
                .Add("Update Manufacturer", () => ManufacturerFactory.UpdateManufacturer(rest))
                .Add("Brand Average Prices", () => BrandFactory.GetBrandAveragePrices(rest))
                .Add("Average Quality Manufacturers", () => ManufacturerFactory.GetAverageQualityManufacturer(rest))
                .Add("Confectionery Manufacturers", () => ManufacturerFactory.GetConfectioneryManufacturer(rest))
                .Add("The Most Accessory Manufacturer", () => ManufacturerFactory.GetMostAccessoryManufacturer(rest))
                .Add("The Most Women Clothing Manufacturer", () => ManufacturerFactory.GetMostWomensClothingManufacturer(rest))
                .Add("Exit Menu", ConsoleMenu.Close);
            menu.Show();

        }
    }
}
