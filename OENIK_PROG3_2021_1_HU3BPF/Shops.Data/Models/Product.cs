// <copyright file="Product.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Shops.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Product class.
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
        /// Gets or Sets Product Stock Number.
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
        /// Product Entity Equals method.
        /// </summary>
        /// <param name="obj">Other Product object.</param>
        /// <returns>Equals or not other and this Entity.</returns>
        public override bool Equals(object obj)
        {
            if (obj is Product)
            {
                Product other = obj as Product;
                return this.ProductName == other.ProductName &&
                    this.ProductPrice == other.ProductPrice &&
                    this.ProductColour == other.ProductColour &&
                    this.StockNumber == other.StockNumber &&
                    this.UsresRating == other.UsresRating &&
                    this.BrandrId == other.BrandrId;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Product entity Get Hash Code Method.
        /// </summary>
        /// <returns>Product entity Hash code.</returns>
        public override int GetHashCode()
        {
            return this.ProductPrice.GetHashCode() + this.StockNumber.GetHashCode() + this.UsresRating.GetHashCode();
        }

        /// <summary>
        /// Gets Product string.
        /// </summary>
        /// <returns>Product all properties in a string.</returns>
        public override string ToString()
        {
            return $" Product ID: {this.ProductdId}\n Product Name: {this.ProductName}" +
                $"\n Product Price: {this.ProductPrice}\n Product Colour: {this.ProductColour}" +
                $"\n Product Stock Number: {this.StockNumber}\n Product User Rating: {this.UsresRating}\n";
        }
    }
}
