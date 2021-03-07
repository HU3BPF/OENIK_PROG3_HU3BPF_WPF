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
                entity.HasOne(product => product.Brand).WithMany(brand => brand.Mobiles)
                .HasForeignKey(product => product.BrandrId).OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.HasOne(brand => brand.Manufacturer).WithMany(manufacturer => manufacturer.Brands).HasForeignKey(brand => brand.ManufacturerId);
            });
        }
    }
}
