// <copyright file="IManufacturer.cs" company="PlaceholderCompany">
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
        void Insert(Manufacturer manufacturer);

        /// <summary>
        /// manufacturer Remove.
        /// </summary>
        /// <param name="manufacturer">manufacturer.</param>
        void Remove(Manufacturer manufacturer);

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
}
