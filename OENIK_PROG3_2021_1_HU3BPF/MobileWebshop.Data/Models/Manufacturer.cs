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
    [Table("Manufacturer")]
    public class Manufacturer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Manufacturer"/> class.
        /// </summary>
        public Manufacturer() => this.Brands = new HashSet<Brand>();

        /// <summary>
        /// Gets or sets manufacturer id.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
#nullable disable
        public int ManufacturerId { get; set; }

        /// <summary>
        /// gets or sets manufacturer name.
        /// </summary>
        [MaxLength(100)]
#nullable disable
        public string ManufacturerName { get; set; }

        /// <summary>
        /// gets or sets manufacturer Ceo.
        /// </summary>
#nullable disable
        public string ManufacturerCEO { get; set; }

        /// <summary>
        /// gets or sets manufacturer center place.
        /// </summary>
#nullable disable
        public string ManufacturerCenter { get; set; }

        /// <summary>
        /// gets or sets manufacturer reliability.
        /// </summary>
        [Range(0, 10)]
#nullable disable
        public int ManufacturerReliability { get; set; }

        /// <summary>
        /// gets or sets manufacturer workers members count.
        /// </summary>
#nullable disable
        public int ManufacturerWorkersCount { get; set; }

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
            return $" Manufacturer ID: {this.ManufacturerId}\n Manufacturer Name: {this.ManufacturerName}\n" +
                $" Manufacturer reliability: {this.ManufacturerReliability}\n Manufacturer Number of worker: {this.ManufacturerWorkersCount}\n" +
                $" Manufacturer CEO: {this.ManufacturerCEO}\n Manufacturer Center: {this.ManufacturerCenter}\n";
        }
    }
}
