// <copyright file="Brand.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MobileWebshop.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Brand database class.
    /// </summary>
    [Table("Brand")]
    public class Brand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Brand"/> class.
        /// Sets Mobiles attribute.
        /// </summary>
        public Brand() => this.Products = new HashSet<Product>();

        /// <summary>
        /// Gets or sets Brand Id.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
#nullable disable
        public int BrandId { get; set; }

        /// <summary>
        /// Gets or sets Manufacturer Id.
        /// </summary>
        [ForeignKey(nameof(Shop))]
#nullable enable
        public int? ShopID { get; set; }

        /// <summary>
        /// Gets or Sets not mapped Manufacturer object.
        /// </summary>
        [NotMapped]
#nullable enable
        public virtual Shop? Shop { get; set; }

        /// <summary>
        /// Gets or sets products.
        /// </summary>
#nullable enable
        public virtual ICollection<Product>? Products { get; set; }

        /// <summary>
        /// Gets or sets Brand Name.
        /// </summary>
        [MaxLength(100)]
#nullable disable
        public string BrandName { get; set; }

        /// <summary>
        /// Gets or sets Brand Quality.
        /// </summary>
        [Range(0, 10)]
#nullable disable
        public int BrandQuality { get; set; }

        /// <summary>
        /// Gets or sets Brand Year.
        /// </summary>
#nullable disable
        public long BrandAnnualProfit { get; set; }

        /// <summary>
        /// Gets or sets System Type.
        /// </summary>
#nullable disable
        public int BrandNumberOfProducts { get; set; }

        /// <summary>
        /// Gets or sets Number Of Users.
        /// </summary>
#nullable disable
        public int NumberOfUsers { get; set; }

        /// <summary>
        /// Gets Brand string.
        /// </summary>
        /// <returns>Brand all entities in a string.</returns>
        public override string ToString()
        {
            return $" Brand ID: {this.BrandId}\n Brand Name: {this.BrandName}\n" +
                $" Brand Quality: {this.BrandQuality}\n Brand Annual Profit: {this.BrandAnnualProfit}\n" +
                $" Brand Number of Users: {this.NumberOfUsers}\n Brand Number Of Products: {this.BrandNumberOfProducts}\n";
        }
    }
}
