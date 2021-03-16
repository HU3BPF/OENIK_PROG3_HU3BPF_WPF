// <copyright file="IManufacturerAndBrandLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MobileWebshop.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MobileWebshop.Data.Models;

    /// <summary>
    /// Manufacturer and Brand table logic.
    /// </summary>
    public interface IManufacturerAndBrandLogic
    {
        /// <summary>
        /// Get all Manufacturer.
        /// </summary>
        /// <returns>All Manufacturer.</returns>
        IList<Manufacturer> GetAllManufacturers();

        /// <summary>
        /// Get manufacturer Brand.
        /// </summary>
        /// <param name="manufacturer">Manufacture.</param>
        /// <returns>The manufactur brand.</returns>
        IList<Brand> GetManufacturerBrand(Manufacturer manufacturer);

        /// <summary>
        /// Remuve Manufacturer().
        /// </summary>
        void RemoveManufacturer();

        /// <summary>
        /// Add new Manufacturer.
        /// </summary>
        void AddManufacturer();

        /// <summary>
        /// Manufacturer Update.
        /// </summary>
        /// <param name="id">Manufacturer id.</param>
        /// <param name="manufacturer">New Manufacturer.</param>
        void ManufacturerUpdate(int id, Manufacturer manufacturer);

        /// <summary>
        /// Gets Manufacturer's total value.
        /// </summary>
        /// <returns>Manufacturer's total value.</returns>
        int MnaufacturerValue();
    }
}
