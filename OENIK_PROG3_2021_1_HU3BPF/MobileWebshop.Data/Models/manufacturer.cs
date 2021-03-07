// <copyright file="Manufacturer.cs" company="PlaceholderCompany">
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
    [Table("manufacturer")]
    public class Manufacturer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Manufacturer"/> class.
        /// </summary>
        public Manufacturer()
        {
            this.Brands = new HashSet<Brand>();
        }

        /// <summary>
        /// Gets or sets manufacturer id.
        /// </summary>
        [Key]
        public int ManufacturerId { get; set; }

        /// <summary>
        /// gets or sets manufacturer name.
        /// </summary>
        [MaxLength(100)]
        public string ManufacturerName { get; set; }

        /// <summary>
        /// gets or sets manufacturer Ceo.
        /// </summary>
        public string ManufacturerCEO { get; set; }

        /// <summary>
        /// gets or sets manufacturer center place.
        /// </summary>
        public string ManufacturerCenter { get; set; }

        /// <summary>
        /// gets or sets manufacturer reliability.
        /// </summary>
        [Range(0, 10)]
        public int ManufacturerReliability { get; set; }

        /// <summary>
        /// gets or sets manufacturer workers members count.
        /// </summary>
        public int ManufacturerWorkersCount { get; set; }

        /// <summary>
        /// Gets or Sets Brand Collection.
        /// </summary>
        [NotMapped]
        public virtual ICollection<Brand> Brands { get; set; }
    }
}
