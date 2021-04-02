// <copyright file="IRepositoryManufacturer.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MobileWebshop.Repository
{
    using System;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using MobileWebshop.Data.Models;

    /// <summary>
    /// Manufacturer Repository.
    /// </summary>
    public interface IRepositoryManufacturer : IRepository<Manufacturer>
    {
        /// <summary>
        /// Manufacturer uptare.
        /// </summary>
        /// <param name="newManufacturer">New manufacturer.</param>
        void ManufacturerUpdate(Manufacturer newManufacturer);
    }

    /// <summary>
    /// Manufacturer Repository.
    /// </summary>
    public class RepositoryManufacturer : AncestorRepository<Manufacturer>, IRepositoryManufacturer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryManufacturer"/> class.
        /// </summary>
        /// <param name="ctx">Dbcontext.</param>
        public RepositoryManufacturer(DbContext ctx)
            : base(ctx)
        {
        }

        /// <summary>
        /// One Entity reader.
        /// </summary>
        /// <param name="id">Entity id.</param>
        /// <returns>Entity value.</returns>
        public override Manufacturer GetOne(int id)
        {
            return this.GetALL().SingleOrDefault(x => x.ManufacturerId == id);
        }

        /// <summary>
        /// Manufacturer uptare.
        /// </summary>
        /// <param name="newManufacturer">New manufacturer.</param>
        public void ManufacturerUpdate(Manufacturer newManufacturer)
        {
            var oldManufacturer = this.GetOne(newManufacturer.ManufacturerId);
            if (oldManufacturer == null)
            {
                throw new InvalidOperationException("Not found");
            }

            oldManufacturer.ManufacturerCenter = newManufacturer.ManufacturerCenter;
            oldManufacturer.ManufacturerCEO = newManufacturer.ManufacturerCEO;
            oldManufacturer.ManufacturerName = newManufacturer.ManufacturerName;
            oldManufacturer.ManufacturerReliability = newManufacturer.ManufacturerReliability;
            oldManufacturer.ManufacturerWorkersCount = newManufacturer.ManufacturerWorkersCount;
            oldManufacturer.Brands = newManufacturer.Brands;
            this.Ctx.SaveChanges();
        }
    }
}
