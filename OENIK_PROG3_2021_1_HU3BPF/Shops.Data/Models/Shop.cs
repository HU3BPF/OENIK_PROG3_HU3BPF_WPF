// <copyright file="Shop.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Shops.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Shop class.
    /// </summary>
    [Table("Shop")]
    public class Shop
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Shop"/> class.
        /// </summary>
        public Shop() => this.Brands = new HashSet<Brand>();

        /// <summary>
        /// Gets or Sets Shop id.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
#nullable disable
        public int ShopId { get; set; }

        /// <summary>
        /// Gets or Sets Shop name.
        /// </summary>
        [MaxLength(100)]
#nullable disable
        public string ShopName { get; set; }

        /// <summary>
        /// Gets or Sets Shop Location.
        /// </summary>
#nullable disable
        public string ShopLocation { get; set; }

        /// <summary>
        /// Gets or Sets Shop Leader.
        /// </summary>
#nullable disable
        public string ShopLeader { get; set; }

        /// <summary>
        /// Gets or Sets Shop reliability.
        /// </summary>
        [Range(0, 10)]
#nullable disable
        public int ShopReliability { get; set; }

        /// <summary>
        /// Gets or Sets Shop workers members Number.
        /// </summary>
#nullable disable
        public int ShopNumberOfWorker { get; set; }

        /// <summary>
        /// Gets or Sets Shop Annual Profit.
        /// </summary>
#nullable disable
        public long ShopAnnualProfit { get; set; }

        /// <summary>
        /// Gets  Brands Collection.
        /// </summary>
        [NotMapped]
#nullable enable
        public virtual ICollection<Brand>? Brands { get; }

        /// <summary>
        /// Shop Entity Equals method.
        /// </summary>
        /// <param name="obj">Other Shop object.</param>
        /// <returns>Equals or not other and this Entity.</returns>
        public override bool Equals(object? obj)
        {
            if (obj is Shop)
            {
                Shop? other = obj as Shop;
                return this.ShopName == other?.ShopName &&
                    this.ShopLocation == other.ShopLocation &&
                    this.ShopLeader == other.ShopLeader &&
                    this.ShopReliability == other.ShopReliability &&
                    this.ShopNumberOfWorker == other.ShopNumberOfWorker &&
                    this.ShopAnnualProfit == other.ShopAnnualProfit;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Shop entity Get Hash Code Method.
        /// </summary>
        /// <returns>Shop entity Hash code.</returns>
        public override int GetHashCode()
        {
            return this.ShopNumberOfWorker.GetHashCode() + this.ShopAnnualProfit.GetHashCode();
        }

        /// <summary>
        /// Gets Manufacturer string.
        /// </summary>
        /// <returns>Manufacturer all entities in a string.</returns>
        public override string ToString()
        {
            return $" Shop ID: {this.ShopId}\n Shop Name: {this.ShopName}\n" +
                $" Shop reliability: {this.ShopReliability}\n Shop Number of worker: {this.ShopNumberOfWorker}\n" +
                $" Shop Leader: {this.ShopLeader}\n Shop Location: {this.ShopLocation}\n" +
                $" Shop Annual Profit: {this.ShopAnnualProfit}\n";
        }
    }
}
