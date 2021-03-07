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
    }
}
