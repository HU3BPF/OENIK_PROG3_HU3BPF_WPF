// <copyright file="IRepositoryManufacturer.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MobileWebshop.Repository
{
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
}
