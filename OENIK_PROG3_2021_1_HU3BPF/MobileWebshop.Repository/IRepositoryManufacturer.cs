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
        /// Manufacturer Id changer.
        /// </summary>
        /// <param name="id">old Id.</param>
        /// <param name="newId">New Id.</param>
        void ManufacturerIdChanger(int id, int newId);

        /// <summary>
        /// Manufacturer CEO update.
        /// </summary>
        /// <param name="id">Manufacturer id.</param>
        /// <param name="ceo">New CEO.</param>
        void ManufacturerCEOChanger(int id, string ceo);

        /// <summary>
        /// Manufacturer uptare.
        /// </summary>
        /// <param name="id">Manufacturer id.</param>
        /// <param name="manufacturer">New manufacturer.</param>
        void ManufacturerUpdate(int id, Manufacturer manufacturer);

        /// <summary>
        /// Manufacturer reliability.
        /// </summary>
        /// <param name="id">Manufacturer id.</param>
        /// <param name="reliability">New manufacturer reliability.</param>
        void ManufacturerReliabilityChanger(int id, int reliability);

        /// <summary>
        /// Workers number changer.
        /// </summary>
        /// <param name="id">Manufacturer id.</param>
        /// <param name="workers">New workers number.</param>
        void ManufacturerWorkersCountChanger(int id, int workers);
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
        /// Manufacturer Id changer.
        /// </summary>
        /// <param name="id">old Id.</param>
        /// <param name="newId">New Id.</param>
        public void ManufacturerIdChanger(int id, int newId)
        {
            var oldId = this.GetOne(id);
            if (oldId == null)
            {
                throw new InvalidOperationException("Not found");
            }

            oldId.ManufacturerId = newId;
            this.Ctx.SaveChanges();
        }

        /// <summary>
        /// Manufacturer CEO update.
        /// </summary>
        /// <param name="id">Manufacturer id.</param>
        /// <param name="ceo">New CEO.</param>
        public void ManufacturerCEOChanger(int id, string ceo)
        {
            var oldCeo = this.GetOne(id);
            if (oldCeo == null)
            {
                throw new InvalidOperationException("Not found");
            }

            oldCeo.ManufacturerCEO = ceo;
            this.Ctx.SaveChanges();
        }

        /// <summary>
        /// Manufacturer uptare.
        /// </summary>
        /// <param name="id">Manufacturer id.</param>
        /// <param name="manufacturer">New manufacturer.</param>
        public void ManufacturerUpdate(int id, Manufacturer manufacturer)
        {
            var oldManufacturer = this.GetOne(id);
            if (oldManufacturer == null)
            {
                throw new InvalidOperationException("Not found");
            }

            oldManufacturer = manufacturer;

            this.Ctx.SaveChanges();
        }

        /// <summary>
        /// Manufacturer reliability.
        /// </summary>
        /// <param name="id">Manufacturer id.</param>
        /// <param name="reliability">New manufacturer reliability.</param>
        public void ManufacturerReliabilityChanger(int id, int reliability)
        {
            var oldReliability = this.GetOne(id);
            if (oldReliability == null)
            {
                throw new InvalidOperationException("Not found");
            }

            oldReliability.ManufacturerReliability = reliability;

            this.Ctx.SaveChanges();
        }

        /// <summary>
        /// Workers number changer.
        /// </summary>
        /// <param name="id">Manufacturer id.</param>
        /// <param name="workers">New workers number.</param>
        public void ManufacturerWorkersCountChanger(int id, int workers)
        {
            var oldWorkers = this.GetOne(id);
            if (oldWorkers == null)
            {
                throw new InvalidOperationException("Not found");
            }

            oldWorkers.ManufacturerWorkersCount = workers;

            this.Ctx.SaveChanges();
        }
    }
}
