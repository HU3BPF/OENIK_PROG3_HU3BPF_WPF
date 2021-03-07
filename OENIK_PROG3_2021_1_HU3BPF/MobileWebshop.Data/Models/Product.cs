// <copyright file="Product.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MobileWebshop.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

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
        public int ProductdId { get; set; }

        /// <summary>
        /// Gets or sets Brand id.
        /// </summary>
        [ForeignKey(nameof(Brand))]
        public int BrandrId { get; set; }

        /// <summary>
        /// Gets or Sets not mapped Brand object.
        /// </summary>
        [NotMapped]
        public virtual Brand Brand { get; set; }

        /// <summary>
        /// Gets or Sets Product Name.
        /// </summary>
        [MaxLength(100)]
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or Sets Product price.
        /// </summary>
        public int ProductPrice { get; set; }

        /// <summary>
        /// Gets or Sets Product Colour.
        /// </summary>
        public string ProductColour { get; set; }

        /// <summary>
        /// Gets or Sets Product Categories.
        /// </summary>
        public Categori ProductCategori { get; set; }
    }
}
