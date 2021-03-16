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
        public void Insert(Manufacturer manufacturer)
        {
            this.iManufacturer.Insert(manufacturer);
        }

        /// <inheritdoc/>
        public void ManufacturerCEOChanger(int id, string ceo)
        {
            this.iManufacturer.ManufacturerCEOChanger(id, ceo);
        }

        /// <inheritdoc/>
        public void ManufacturerIdChanger(int id, int newId)
        {
            this.iManufacturer.ManufacturerIdChanger(id, newId);
        }

        /// <inheritdoc/>
        public void ManufacturerReliabilityChanger(int id, int reliability)
        {
            this.iManufacturer.ManufacturerReliabilityChanger(id, reliability);
        }

        /// <inheritdoc/>
        public void ManufacturerUpdate(int id, Manufacturer manufacturer)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc/>
        public void ManufacturerWorkersCountChanger(int id, int workers)
        {
            this.iManufacturer.ManufacturerWorkersCountChanger(id, workers);
        }

        /// <inheritdoc/>
        public void Remove(Manufacturer manufacturer)
        {
            this.iManufacturer.Remove(manufacturer);
        }
    }
}
