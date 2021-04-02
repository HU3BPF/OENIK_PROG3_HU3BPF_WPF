// <copyright file="ManufacturerLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MobileWebshop.Logic
{
    using System.Collections.Generic;
    using System.Linq;
    using MobileWebshop.Data.Models;
    using MobileWebshop.Repository;

    /// <summary>
    /// Manufacturer and Brand Logic.
    /// </summary>
    public class ManufacturerLogic : IManufacturer
    {
        /// <summary>
        /// IRepositoryManufacturer.
        /// </summary>
        private readonly IRepositoryManufacturer iManufacturer;

        /// <summary>
        /// Initializes a new instance of the <see cref="ManufacturerLogic"/> class.
        /// Sets I Repository iManufacturer.
        /// </summary>
        /// <param name="iManufacturer">IRepositoryManufacturer.</param>
        public ManufacturerLogic(IRepositoryManufacturer iManufacturer)
        {
            this.iManufacturer = iManufacturer;
        }

        /// <inheritdoc/>
        public IList<Manufacturer> GetALL()
        {
            return this.iManufacturer.GetALL().ToList();
        }

        /// <inheritdoc/>
        public Manufacturer GetOne(int id)
        {
            return this.iManufacturer.GetOne(id);
        }

        /// <inheritdoc/>
        public void ManufacturerInsert(Manufacturer manufacturer)
        {
            this.iManufacturer.ProductInsert(manufacturer);
        }

        /// <inheritdoc/>
        public void ManufacturerUpdate(Manufacturer manufacturer)
        {
            this.iManufacturer.ManufacturerUpdate(manufacturer);
        }

        /// <inheritdoc/>
        public void ManufacturerRemove(Manufacturer manufacturer)
        {
            this.iManufacturer.Remove(manufacturer);
        }
    }

    /// <summary>
    /// Manufacturer and Brand table logic.
    /// </summary>
    public interface IManufacturer
    {
        /// <summary>
        /// One Entity reader.
        /// </summary>
        /// <param name="id">Entity id.</param>
        /// <returns>Entity value.</returns>
        Manufacturer GetOne(int id);

        /// <summary>
        /// All Entities reader.
        /// </summary>
        /// <returns>All properties.</returns>
        IList<Manufacturer> GetALL();

        /// <summary>
        /// One manufacturer inserter.
        /// </summary>
        /// <param name="manufacturer">manufacturer.</param>
        void ManufacturerInsert(Manufacturer manufacturer);

        /// <summary>
        /// manufacturer Remove.
        /// </summary>
        /// <param name="manufacturer">manufacturer.</param>
        void ManufacturerRemove(Manufacturer manufacturer);

        /// <summary>
        /// Manufacturer uptare.
        /// </summary>
        /// <param name="manufacturer">New manufacturer.</param>
        void ManufacturerUpdate(Manufacturer manufacturer);
    }
}
