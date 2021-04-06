// <copyright file="Product.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Shops.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Product or Mobile class.
    /// </summary>
    [Table("Product")]
    public class Product
    {
        /// <summary>
        /// Gets or Sets Product id.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
#nullable disable
        public int ProductdId { get; set; }

        /// <summary>
        /// Gets or sets Brand id.
        /// </summary>
        [ForeignKey(nameof(Brand))]
#nullable enable
        public int? BrandrId { get; set; }

        /// <summary>
        /// Gets or Sets not mapped Brand object.
        /// </summary>
        [NotMapped]
#nullable enable
        public virtual Brand? Brand { get; set; }

        /// <summary>
        /// Gets or Sets Product Name.
        /// </summary>
        [MaxLength(100)]
#nullable disable
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or Sets Product price.
        /// </summary>
#nullable disable
        public int ProductPrice { get; set; }

        /// <summary>
        /// Gets or Sets Product Colour.
        /// </summary>
#nullable disable
        public string ProductColour { get; set; }

        /// <summary>
        /// Gets or Sets Product Categories.
        /// </summary>
#nullable disable
        public int StockNumber { get; set; }

        /// <summary>
        /// Gets or Sets Users rating.
        /// </summary>
        [Range(0, 10)]
#nullable disable
        public int UsresRating { get; set; }

        /// <summary>
        /// Gets Product string.
        /// </summary>
        /// <returns>Product all entities in a string.</returns>
        public override string ToString()
        {
            return $" Product ID: {this.ProductdId}\n Product Name: {this.ProductName}" +
                $"\n Product Price: {this.ProductPrice}\n Product Colour: {this.ProductColour}" +
                $"\n Product Stock Number: {this.StockNumber}\n Product User Rating: {this.UsresRating}\n";
        }
    }
}
