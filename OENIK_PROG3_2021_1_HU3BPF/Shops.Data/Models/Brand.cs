// <copyright file="Brand.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Shops.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Brand class.
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
        /// Gets products.
        /// </summary>
        [NotMapped]
#nullable enable
        public virtual ICollection<Product>? Products { get; }

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
        /// Gets or sets Brand Annual Profit.
        /// </summary>
#nullable disable
        public long BrandAnnualProfit { get; set; }

        /// <summary>
        /// Gets or sets Brand Number Of Products.
        /// </summary>
#nullable disable
        public int BrandNumberOfProducts { get; set; }

        /// <summary>
        /// Gets or sets Number Of Users.
        /// </summary>
#nullable disable
        public int NumberOfUsers { get; set; }

        /// <summary>
        /// Brand Entity Equals method.
        /// </summary>
        /// <param name="obj">Other Brand object.</param>
        /// <returns>Equals or not other and this Entity.</returns>
        public override bool Equals(object obj)
        {
            if (obj is Brand)
            {
                Brand other = obj as Brand;
                return this.BrandName == other.BrandName &&
                    this.BrandQuality == other.BrandQuality &&
                    this.BrandNumberOfProducts == other.BrandNumberOfProducts &&
                    this.NumberOfUsers == other.NumberOfUsers &&
                    this.BrandAnnualProfit == other.BrandAnnualProfit;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Brand entity Get Hash Code Method.
        /// </summary>
        /// <returns>Brands Hash code.</returns>
        public override int GetHashCode()
        {
            return this.NumberOfUsers.GetHashCode() + this.BrandQuality.GetHashCode() + this.BrandAnnualProfit.GetHashCode();
        }

        /// <summary>
        /// Gets Brand string.
        /// </summary>
        /// <returns>Brand all properties in a string.</returns>
        public override string ToString()
        {
            return $" Brand ID: {this.BrandId}\n Brand Name: {this.BrandName}\n" +
                $" Brand Quality: {this.BrandQuality}\n Brand Annual Profit: {this.BrandAnnualProfit}\n" +
                $" Brand Number of Users: {this.NumberOfUsers}\n Brand Number Of Products: {this.BrandNumberOfProducts}\n";
        }
    }
}
