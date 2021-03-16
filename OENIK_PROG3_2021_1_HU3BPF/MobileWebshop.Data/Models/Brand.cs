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
        public int BrandId { get; set; }

        /// <summary>
        /// Gets or sets Manufacturer Id.
        /// </summary>
        [ForeignKey(nameof(Manufacturer))]
        public int ManufacturerId { get; set; }

        /// <summary>
        /// Gets or Sets not mapped Manufacturer object.
        /// </summary>
        [NotMapped]
        public virtual Manufacturer Manufacturer { get; set; }

        /// <summary>
        /// Gets or sets products.
        /// </summary>
        public virtual ICollection<Product> Products { get; set; }

        /// <summary>
        /// Gets or sets Brand Name.
        /// </summary>
        [MaxLength(100)]
        public string BrandName { get; set; }

        /// <summary>
        /// Gets or sets Brand Quality.
        /// </summary>
        [Range(0, 10)]
        public int BrandQuality { get; set; }

        /// <summary>
        /// Gets or sets Brand Year.
        /// </summary>
        public int BrandYear { get; set; }

        /// <summary>
        /// Gets or sets System Type.
        /// </summary>
        public int SystemType { get; set; }

        /// <summary>
        /// Gets or sets Number Of Users.
        /// </summary>
        public int NumberOfUsers { get; set; }
    }
}
