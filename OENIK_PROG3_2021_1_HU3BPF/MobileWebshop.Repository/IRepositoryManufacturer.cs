// <copyright file="IRepositoryManufacturer.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MobileWebshop.Repository
{
    using Microsoft.EntityFrameworkCore;
    using MobileWebshop.Data.Models;

    /// <summary>
    /// Manufacturer Repository.
    /// </summary>
    public interface IRepositoryManufacturer : IRepository<Manufacturer>
    {
        /// <summary>
        /// Manufacturer Id Changer.
        /// </summary>
        void ManufacturerIdChanger();

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
    public class RepositoryManufacturer : Repository<Manufacturer>, IRepositoryManufacturer
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
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Manufacturer Id Changer.
        /// </summary>
        public void ManufacturerIdChanger()
        {
        }

        /// <summary>
        /// Manufacturer CEO update.
        /// </summary>
        /// <param name="id">Manufacturer id.</param>
        /// <param name="ceo">New CEO.</param>
        public void ManufacturerCEOChanger(int id, string ceo)
        {
        }

        /// <summary>
        /// Manufacturer uptare.
        /// </summary>
        /// <param name="id">Manufacturer id.</param>
        /// <param name="manufacturer">New manufacturer.</param>
        public void ManufacturerUpdate(int id, Manufacturer manufacturer)
        {
        }

        /// <summary>
        /// Manufacturer reliability.
        /// </summary>
        /// <param name="id">Manufacturer id.</param>
        /// <param name="reliability">New manufacturer reliability.</param>
        public void ManufacturerReliabilityChanger(int id, int reliability)
        {
        }

        /// <summary>
        /// Workers number changer.
        /// </summary>
        /// <param name="id">Manufacturer id.</param>
        /// <param name="workers">New workers number.</param>
        public void ManufacturerWorkersCountChanger(int id, int workers)
        {
        }
    }
}
