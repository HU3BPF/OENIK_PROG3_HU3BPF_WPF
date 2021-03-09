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
        private ICollection<Product> mobiles;

        /// <summary>
        /// Initializes a new instance of the <see cref="Brand"/> class.
        /// Sets Mobiles attribute.
        /// </summary>
        public Brand() => this.SetMobiles(new HashSet<Product>());

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
        /// Gets Mobiles collection.
        /// </summary>
        /// <returns>Mobiles collection.</returns>
        public virtual ICollection<Product> GetMobiles()
        {
            return this.mobiles;
        }

        /// <summary>
        /// Sets Mobiles collection.
        /// </summary>
        /// <param name="value">Mobiles collections.</param>
        public void SetMobiles(ICollection<Product> value)
        {
            this.mobiles = value;
        }
    }
}
