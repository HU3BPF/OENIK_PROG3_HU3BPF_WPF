﻿// <copyright file="ShopDbContext.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MobileWebshop.Data.Models
{
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Mobile databes creater.
    /// </summary>
    public class ShopDbContext : DbContext
    {
        /// <summary>
        /// Gets or Sets Manufactures.
        /// </summary>
        public virtual DbSet<Shop> Manufacturers { get; set; }

        /// <summary>
        /// Gets or Sets Brands.
        /// </summary>
        public virtual DbSet<Brand> Brands { get; set; }

        /// <summary>
        /// Gets or Sets Products.
        /// </summary>
        public virtual DbSet<Product> Products { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShopDbContext"/> class.
        /// This constructor ceart a Databes.
        /// </summary>
        public ShopDbContext()
        {
            this.Database.EnsureCreated();
        }

        /// <summary>
        /// Database pass added and lazy loading on.
        /// </summary>
        /// <param name="optionsBuilder">Database creator set.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies()
                .UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\ShopDbContext.mdf;Integrated Security=True;MultipleActiveResultSets=True");
            }
        }

        /// <summary>
        /// Entities created.
        /// </summary>
        /// <param name="modelBuilder">Database entities setted.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasOne(product => product.Brand).WithMany(brand => brand.Products);
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.HasOne(brand => brand.Shop).WithMany(shop => shop.Brands);
            });

            Shop mobileShop = new Shop() { ShopId = 1, ShopName = "Vodphone", ShopLeader = "Kim Ki Nam", ShopLocation = "Budapest", ShopReliability = 10, ShopAnnualProfit = 900000000, ShopNumberOfWorker = 15 };
            Shop clothesShop = new Shop() { ShopId = 2, ShopName = "Vodafon", ShopLeader = "	Tim Cook", ShopLocation = "Miskolc", ShopReliability = 9, ShopAnnualProfit = 988000000, ShopNumberOfWorker = 10 };
            Shop telefonSzerviz = new Shop() { ShopId = 3, ShopName = "Telefon-Szervíz", ShopLeader = "Zsen Cseng-fej", ShopLocation = "Bukarest", ShopReliability = 9, ShopAnnualProfit = 70550000, ShopNumberOfWorker = 8 };
            Shop arabTelefon = new Shop() { ShopId = 4, ShopName = "Arab-telefon", ShopLeader = "Lin Pin", ShopLocation = "Debrecen", ShopReliability = 7, ShopAnnualProfit = 85489525, ShopNumberOfWorker = 9 };

            Brand apple = new Brand() { BrandId = 1, BrandName = "Apple", BrandQuality = 9, BrandAnnualProfit = 9220000, ShopID = mobileShop.ShopId, NumberOfUsers = 100000, BrandNumberOfProducts = 3 };
            Brand samsung = new Brand() { BrandId = 2, BrandName = "Samsung", BrandQuality = 10, BrandAnnualProfit = 9802200, ShopID = mobileShop.ShopId, NumberOfUsers = 100000, BrandNumberOfProducts = 5 };
            Brand huawei = new Brand() { BrandId = 3, BrandName = "Huawei", BrandQuality = 8, BrandAnnualProfit = 7011000, ShopID = mobileShop.ShopId, NumberOfUsers = 100000, BrandNumberOfProducts = 4 };
            Brand xiaomi = new Brand() { BrandId = 4, BrandName = "Xiaomi", BrandQuality = 7, BrandAnnualProfit = 889525, ShopID = mobileShop.ShopId, NumberOfUsers = 100000, BrandNumberOfProducts = 4 };
            Brand honor = new Brand() { BrandId = 5, BrandName = "Honor", BrandQuality = 10, BrandAnnualProfit = 4519659, ShopID = mobileShop.ShopId, NumberOfUsers = 100000, BrandNumberOfProducts = 2 };

            Product iPhone12 = new Product() { ProductdId = 1, BrandrId = apple.BrandId, ProductSystem = SystemType.Iso, ProductColour = "Blue", ProductName = "IPhone12", ProductPrice = 2000, UsresRating = 9 };
            Product iPhone12Max = new Product() { ProductdId = 2, BrandrId = apple.BrandId, ProductSystem = SystemType.Iso, ProductColour = "Green", ProductName = "IPhone12Max", ProductPrice = 1800, UsresRating = 9 };
            Product iPhone11 = new Product() { ProductdId = 3, BrandrId = apple.BrandId, ProductSystem = SystemType.Iso, ProductColour = "White", ProductName = "IPhone11", ProductPrice = 1500, UsresRating = 9 };
            Product s10 = new Product() { ProductdId = 4, BrandrId = samsung.BrandId, ProductSystem = SystemType.Andorid, ProductColour = "Black", ProductName = "S10", ProductPrice = 1000, UsresRating = 9 };
            Product s11 = new Product() { ProductdId = 5, BrandrId = samsung.BrandId, ProductSystem = SystemType.Andorid, ProductColour = "Red", ProductName = "S11", ProductPrice = 1000, UsresRating = 9 };
            Product s10Lite = new Product() { ProductdId = 6, BrandrId = samsung.BrandId, ProductSystem = SystemType.Andorid, ProductColour = "Gray", ProductName = "S10Lite", ProductPrice = 500, UsresRating = 9 };
            Product honor20 = new Product() { ProductdId = 7, BrandrId = honor.BrandId, ProductSystem = SystemType.Andorid, ProductColour = "Pink", ProductName = "Honor20", ProductPrice = 600, UsresRating = 9 };
            Product honor30 = new Product() { ProductdId = 8, BrandrId = honor.BrandId, ProductSystem = SystemType.Andorid, ProductColour = "Yellow", ProductName = "Honor30", ProductPrice = 800, UsresRating = 9 };
            Product huaweiP10 = new Product() { ProductdId = 9, BrandrId = huawei.BrandId, ProductSystem = SystemType.Andorid, ProductColour = "Blue", ProductName = "HuaweiP10", ProductPrice = 400, UsresRating = 9 };
            Product huaweiP20 = new Product() { ProductdId = 10, BrandrId = huawei.BrandId, ProductSystem = SystemType.Andorid, ProductColour = "Red", ProductName = "HuaweiP20", ProductPrice = 500, UsresRating = 9 };
            Product huaweiP30 = new Product() { ProductdId = 11, BrandrId = huawei.BrandId, ProductSystem = SystemType.Andorid, ProductColour = "Purple", ProductName = "HuaweiP30", ProductPrice = 550, UsresRating = 9 };
            Product huaweiP40 = new Product() { ProductdId = 12, BrandrId = huawei.BrandId, ProductSystem = SystemType.Andorid, ProductColour = "Green", ProductName = "HuaweiP40", ProductPrice = 700, UsresRating = 9 };
            Product redmiS9 = new Product() { ProductdId = 13, BrandrId = xiaomi.BrandId, ProductSystem = SystemType.Andorid, ProductColour = "Red", ProductName = "RedmiS9", ProductPrice = 700, UsresRating = 9 };
            Product redmiS9Note = new Product() { ProductdId = 14, BrandrId = xiaomi.BrandId, ProductSystem = SystemType.Andorid, ProductColour = "Pink", ProductName = "RedmiS9Note", ProductPrice = 900, UsresRating = 9 };
            Product mi10 = new Product() { ProductdId = 15, BrandrId = xiaomi.BrandId, ProductSystem = SystemType.Andorid, ProductColour = "Blue", ProductName = "MI10", ProductPrice = 1000, UsresRating = 9 };
            Product mi10Pro = new Product() { ProductdId = 16, BrandrId = xiaomi.BrandId, ProductSystem = SystemType.Andorid, ProductColour = "Green", ProductName = "MI10Pro", ProductPrice = 1200, UsresRating = 9 };
            Product note10 = new Product() { ProductdId = 17, BrandrId = samsung.BrandId, ProductSystem = SystemType.Andorid, ProductColour = "Orange", ProductName = "Note10", ProductPrice = 1500, UsresRating = 9 };
            Product note20 = new Product() { ProductdId = 18, BrandrId = samsung.BrandId, ProductSystem = SystemType.Andorid, ProductColour = "Black", ProductName = "Note20", ProductPrice = 1600, UsresRating = 9 };

            Brand zara = new Brand() { BrandId = 6, BrandName = "Zara", BrandQuality = 10, BrandAnnualProfit = 820000, ShopID = clothesShop.ShopId, NumberOfUsers = 5220, BrandNumberOfProducts = 5 };
            Brand nike = new Brand() { BrandId = 7, BrandName = "Nike", BrandQuality = 9, BrandAnnualProfit = 92200, ShopID = clothesShop.ShopId, NumberOfUsers = 54200, BrandNumberOfProducts = 4 };
            Brand puma = new Brand() { BrandId = 8, BrandName = "Puma", BrandQuality = 8, BrandAnnualProfit = 811000, ShopID = clothesShop.ShopId, NumberOfUsers = 6584, BrandNumberOfProducts = 4 };
            Brand china = new Brand() { BrandId = 9, BrandName = "Kina", BrandQuality = 5, BrandAnnualProfit = 4011000, ShopID = clothesShop.ShopId, NumberOfUsers = 10000, BrandNumberOfProducts = 4 };

            Product zaraShoes = new Product() { ProductdId = 19, BrandrId = zara.BrandId, ProductSystem = SystemType.Iso, ProductColour = "Blue", ProductName = "zaraShoes", ProductPrice = 100, UsresRating = 1 };
            Product zaraTShirt = new Product() { ProductdId = 20, BrandrId = zara.BrandId, ProductSystem = SystemType.Iso, ProductColour = "Green", ProductName = "zaraTShirt", ProductPrice = 200, UsresRating = 7 };
            Product zaraJumper = new Product() { ProductdId = 21, BrandrId = zara.BrandId, ProductSystem = SystemType.Iso, ProductColour = "White", ProductName = "zaraJumper", ProductPrice = 300, UsresRating = 10 };
            Product zaraShirt = new Product() { ProductdId = 22, BrandrId = zara.BrandId, ProductSystem = SystemType.Andorid, ProductColour = "Black", ProductName = "zaraShirt", ProductPrice = 400, UsresRating = 10 };
            Product zaraSuit = new Product() { ProductdId = 23, BrandrId = zara.BrandId, ProductSystem = SystemType.Andorid, ProductColour = "Red", ProductName = "nikeShoes", ProductPrice = 100, UsresRating = 4 };
            Product nikeShoes = new Product() { ProductdId = 24, BrandrId = nike.BrandId, ProductSystem = SystemType.Andorid, ProductColour = "Gray", ProductName = "nikeShoes", ProductPrice = 50, UsresRating = 8 };
            Product nikeShirt = new Product() { ProductdId = 25, BrandrId = nike.BrandId, ProductSystem = SystemType.Andorid, ProductColour = "Pink", ProductName = "nikeShirt", ProductPrice = 70, UsresRating = 7 };
            Product nikeHat = new Product() { ProductdId = 26, BrandrId = honor.BrandId, ProductSystem = SystemType.Andorid, ProductColour = "Yellow", ProductName = "nikeHat", ProductPrice = 200, UsresRating = 4 };
            Product nikeBag = new Product() { ProductdId = 27, BrandrId = nike.BrandId, ProductSystem = SystemType.Andorid, ProductColour = "Blue", ProductName = "nikeBag", ProductPrice = 40, UsresRating = 8 };
            Product nikePants = new Product() { ProductdId = 28, BrandrId = nike.BrandId, ProductSystem = SystemType.Andorid, ProductColour = "Red", ProductName = "nikePants", ProductPrice = 200, UsresRating = 7 };
            Product pumaShoes = new Product() { ProductdId = 29, BrandrId = puma.BrandId, ProductSystem = SystemType.Andorid, ProductColour = "Purple", ProductName = "pumaShoes", ProductPrice = 150, UsresRating = 7 };
            Product pumaJacket = new Product() { ProductdId = 30, BrandrId = puma.BrandId, ProductSystem = SystemType.Andorid, ProductColour = "Green", ProductName = "pumaJacket", ProductPrice = 140, UsresRating = 8 };
            Product pumaCoat = new Product() { ProductdId = 31, BrandrId = puma.BrandId, ProductSystem = SystemType.Andorid, ProductColour = "Red", ProductName = "pumaCoat", ProductPrice = 130, UsresRating = 6 };
            Product pumaJumper = new Product() { ProductdId = 32, BrandrId = puma.BrandId, ProductSystem = SystemType.Andorid, ProductColour = "Pink", ProductName = "pumaJumper", ProductPrice = 144, UsresRating = 4 };
            Product chinaCoat = new Product() { ProductdId = 33, BrandrId = china.BrandId, ProductSystem = SystemType.Andorid, ProductColour = "Blue", ProductName = "chinaCoat", ProductPrice = 57, UsresRating = 7 };
            Product chinaShoes = new Product() { ProductdId = 34, BrandrId = china.BrandId, ProductSystem = SystemType.Andorid, ProductColour = "Green", ProductName = "chinaShoes", ProductPrice = 20, UsresRating = 4 };
            Product chinaSlippers = new Product() { ProductdId = 35, BrandrId = china.BrandId, ProductSystem = SystemType.Andorid, ProductColour = "Orange", ProductName = "chinaSlippers", ProductPrice = 25, UsresRating = 5 };
            Product chinaPants = new Product() { ProductdId = 36, BrandrId = china.BrandId, ProductSystem = SystemType.Andorid, ProductColour = "Black", ProductName = "chinaPants", ProductPrice = 13, UsresRating = 8 };

            modelBuilder.Entity<Product>().HasData(iPhone12, iPhone12Max, iPhone11, s10, s11, s10Lite, honor20, honor30, huaweiP10, huaweiP20, huaweiP30, huaweiP40, redmiS9, redmiS9Note, mi10, mi10Pro, note10, note20);
            modelBuilder.Entity<Product>().HasData(zaraShoes, zaraTShirt, zaraJumper, zaraShirt, zaraSuit, nikeShoes, nikeShirt, nikeHat, nikeBag, nikePants, pumaJacket, pumaCoat, pumaJumper, chinaCoat, chinaShoes, chinaSlippers, chinaPants, pumaShoes);
            modelBuilder.Entity<Brand>().HasData(apple, samsung, huawei, xiaomi, honor);
            modelBuilder.Entity<Brand>().HasData(zara, nike, puma, china);
            modelBuilder.Entity<Shop>().HasData(mobileShop, clothesShop);
        }
    }
}
