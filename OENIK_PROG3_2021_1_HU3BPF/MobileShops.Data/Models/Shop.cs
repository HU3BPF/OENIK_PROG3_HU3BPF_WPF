// <copyright file="Shop.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MobileWebshop.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Manufacturer table.
    /// </summary>
    [Table("Shops")]
    public class Shop
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Shop"/> class.
        /// </summary>
        public Shop() => this.Brands = new HashSet<Brand>();

        /// <summary>
        /// Gets or sets manufacturer id.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
#nullable disable
        public int ShopId { get; set; }

        /// <summary>
        /// gets or sets manufacturer name.
        /// </summary>
        [MaxLength(100)]
#nullable disable
        public string ShopName { get; set; }

        /// <summary>
        /// gets or sets Shop Location.
        /// </summary>
#nullable disable
        public string ShopLocation { get; set; }

        /// <summary>
        /// gets or sets Shop Leader.
        /// </summary>
#nullable disable
        public string ShopLeader { get; set; }

        /// <summary>
        /// gets or sets manufacturer reliability.
        /// </summary>
        [Range(0, 10)]
#nullable disable
        public int ShopReliability { get; set; }

        /// <summary>
        /// gets or sets Shop workers members Number.
        /// </summary>
#nullable disable
        public int ShopNumberOfWorker { get; set; }

        /// <summary>
        /// gets or sets Shop Annual Profit.
        /// </summary>
#nullable disable
        public long ShopAnnualProfit { get; set; }

        /// <summary>
        /// Gets or Sets Brands Collection.
        /// </summary>
#nullable enable
        public virtual ICollection<Brand>? Brands { get; set; }

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
