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
    }
}
