// <copyright file="MobileDbContext.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MobileWebshop.Data.Models
{
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Mobile databes creater.
    /// </summary>
    public class MobileDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MobileDbContext"/> class.
        /// This constructor ceart a Databes.
        /// </summary>
        public MobileDbContext()
        {
            this.Database.EnsureCreated();
        }

        /// <summary>
        /// Gets or Sets Manufactures.
        /// </summary>
        public virtual DbSet<Manufacturer> Manufacturers { get; set; }

        /// <summary>
        /// Gets or Sets Brands.
        /// </summary>
        public virtual DbSet<Brand> Brands { get; set; }

        /// <summary>
        /// Gets or Sets Products.
        /// </summary>
        public virtual DbSet<Product> Products { get; set; }

        /// <summary>
        /// Database pass added and lazy loading on.
        /// </summary>
        /// <param name="optionsBuilder">Database creator set.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies()
                .UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CarDb.mdf;Integrated Security=True;MultipleActiveResultSets=True");
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
                entity.HasOne(product => product.Brand).WithMany(brand => brand.GetMobiles())
                .HasForeignKey(product => product.BrandrId).OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.HasOne(brand => brand.Manufacturer).WithMany(manufacturer => manufacturer.GetBrands())
                .HasForeignKey(brand => brand.ManufacturerId).OnDelete(DeleteBehavior.ClientSetNull);
            });

            Manufacturer samsungElectronics = new Manufacturer() { ManufacturerId = 1, ManufacturerCenter = "Dél-Korea", ManufacturerCEO = "Kim Ki Nam", ManufacturerName = "Samsung Electronics", ManufacturerReliability = 10 };
            Manufacturer appleInc = new Manufacturer() { ManufacturerId = 2, ManufacturerCenter = "Cupertino", ManufacturerCEO = "	Tim Cook", ManufacturerName = "Apple Inc.", ManufacturerReliability = 9 };
            Manufacturer huaweiTechnologies = new Manufacturer() { ManufacturerId = 3, ManufacturerCenter = "Sencsen", ManufacturerCEO = "Zsen Cseng-fej", ManufacturerName = "Huawei Technologies", ManufacturerReliability = 9 };
            Manufacturer xiaomiInc = new Manufacturer() { ManufacturerId = 4, ManufacturerCenter = "Peking", ManufacturerCEO = "Lin Pin", ManufacturerName = "Xiaomi Inc.", ManufacturerReliability = 7 };

            Brand apple = new Brand() { BrandId = 1, BrandName = "Apple", BrandQuality = 9, BrandYear = 1979, ManufacturerId = appleInc.ManufacturerId };
            Brand samsung = new Brand() { BrandId = 2, BrandName = "Samsung", BrandQuality = 10, BrandYear = 1969, ManufacturerId = samsungElectronics.ManufacturerId };
            Brand huawei = new Brand() { BrandId = 3, BrandName = "Huawei", BrandQuality = 8, BrandYear = 1987, ManufacturerId = huaweiTechnologies.ManufacturerId };
            Brand xiaomi = new Brand() { BrandId = 4, BrandName = "Xiaomi", BrandQuality = 7, BrandYear = 2010, ManufacturerId = xiaomiInc.ManufacturerId };
            Brand honor = new Brand() { BrandId = 5, BrandName = "Honor", BrandQuality = 10, BrandYear = 2013, ManufacturerId = huaweiTechnologies.ManufacturerId };

            Product iPhone12 = new Product() { ProductdId = 1, BrandrId = apple.BrandId, ProductCategori = Category.Expensive, ProductColour = "Blue", ProductName = "IPhone12", ProductPrice = 2000 };
            Product iPhone12Max = new Product() { ProductdId = 2, BrandrId = apple.BrandId, ProductCategori = Category.Expensive, ProductColour = "Green", ProductName = "IPhone12Max", ProductPrice = 1800 };
            Product iPhone11 = new Product() { ProductdId = 3, BrandrId = apple.BrandId, ProductCategori = Category.Expensive, ProductColour = "White", ProductName = "IPhone11", ProductPrice = 1500 };
            Product s10 = new Product() { ProductdId = 4, BrandrId = samsung.BrandId, ProductCategori = Category.ModeratelyExpensive, ProductColour = "Black", ProductName = "S10", ProductPrice = 1000 };
            Product s11 = new Product() { ProductdId = 5, BrandrId = samsung.BrandId, ProductCategori = Category.ModeratelyExpensive, ProductColour = "Red", ProductName = "S11", ProductPrice = 1000 };
            Product s10Lite = new Product() { ProductdId = 6, BrandrId = samsung.BrandId, ProductCategori = Category.Cheap, ProductColour = "Gray", ProductName = "S10Lite", ProductPrice = 500 };
            Product honor20 = new Product() { ProductdId = 7, BrandrId = honor.BrandId, ProductCategori = Category.Cheap, ProductColour = "Pink", ProductName = "Honor20", ProductPrice = 600 };
            Product honor30 = new Product() { ProductdId = 8, BrandrId = honor.BrandId, ProductCategori = Category.ModeratelyExpensive, ProductColour = "Yellow", ProductName = "Honor30", ProductPrice = 800 };
            Product huaweiP10 = new Product() { ProductdId = 9, BrandrId = huawei.BrandId, ProductCategori = Category.Cheap, ProductColour = "Blue", ProductName = "HuaweiP10", ProductPrice = 400 };
            Product huaweiP20 = new Product() { ProductdId = 10, BrandrId = huawei.BrandId, ProductCategori = Category.Cheap, ProductColour = "Red", ProductName = "HuaweiP20", ProductPrice = 500 };
            Product huaweiP30 = new Product() { ProductdId = 11, BrandrId = huawei.BrandId, ProductCategori = Category.Cheap, ProductColour = "Purple", ProductName = "HuaweiP30", ProductPrice = 550 };
            Product huaweiP40 = new Product() { ProductdId = 12, BrandrId = huawei.BrandId, ProductCategori = Category.Cheap, ProductColour = "Green", ProductName = "HuaweiP40", ProductPrice = 700 };
            Product redmiS9 = new Product() { ProductdId = 12, BrandrId = xiaomi.BrandId, ProductCategori = Category.Cheap, ProductColour = "Red", ProductName = "RedmiS9", ProductPrice = 700 };
            Product redmiS9Note = new Product() { ProductdId = 13, BrandrId = xiaomi.BrandId, ProductCategori = Category.ModeratelyExpensive, ProductColour = "Pink", ProductName = "RedmiS9Note", ProductPrice = 900 };
            Product mi10 = new Product() { ProductdId = 14, BrandrId = xiaomi.BrandId, ProductCategori = Category.ModeratelyExpensive, ProductColour = "Blue", ProductName = "MI10", ProductPrice = 1000 };
            Product mi10Pro = new Product() { ProductdId = 15, BrandrId = xiaomi.BrandId, ProductCategori = Category.ModeratelyExpensive, ProductColour = "Green", ProductName = "MI10Pro", ProductPrice = 1200 };
            Product note10 = new Product() { ProductdId = 16, BrandrId = samsung.BrandId, ProductCategori = Category.Expensive, ProductColour = "Orange", ProductName = "Note10", ProductPrice = 1500 };
            Product note20 = new Product() { ProductdId = 17, BrandrId = samsung.BrandId, ProductCategori = Category.Expensive, ProductColour = "Black", ProductName = "Note20", ProductPrice = 1600 };

            modelBuilder.Entity<Product>().HasData(iPhone12, iPhone12Max, iPhone11, s10, s11, s10Lite, honor20, honor30, huaweiP10, huaweiP20, huaweiP30, huaweiP40, redmiS9, redmiS9Note, mi10, mi10Pro, note10, note20);
            modelBuilder.Entity<Brand>().HasData(apple, samsung, huawei, xiaomi, honor);
            modelBuilder.Entity<Manufacturer>().HasData(samsungElectronics, appleInc, huaweiTechnologies, xiaomiInc);
        }
    }
}
