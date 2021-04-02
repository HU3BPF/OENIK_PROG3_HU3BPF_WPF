// <copyright file="ShopLogic.cs" company="PlaceholderCompany">
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
    public class ShopLogic : IShop
    {
        /// <summary>
        /// IRepositoryManufacturer.
        /// </summary>
        private readonly IRepositoryShop iManufacturer;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShopLogic"/> class.
        /// Sets I Repository iManufacturer.
        /// </summary>
        /// <param name="iManufacturer">IRepositoryManufacturer.</param>
        public ShopLogic(IRepositoryShop iManufacturer)
        {
            this.iManufacturer = iManufacturer;
        }

        /// <inheritdoc/>
        public IList<Shop> GetALL()
        {
            return this.iManufacturer.GetALL().ToList();
        }

        /// <inheritdoc/>
        public Shop GetOne(int id)
        {
            return this.iManufacturer.GetOne(id);
        }

        /// <inheritdoc/>
        public void ManufacturerInsert(Shop manufacturer)
        {
            this.iManufacturer.ProductInsert(manufacturer);
        }

        /// <inheritdoc/>
        public void ManufacturerUpdate(Shop manufacturer)
        {
            this.iManufacturer.ShopUpdate(manufacturer);
        }

        /// <inheritdoc/>
        public void ManufacturerRemove(Shop manufacturer)
        {
            this.iManufacturer.Remove(manufacturer);
        }
    }

    /// <summary>
    /// Manufacturer and Brand table logic.
    /// </summary>
    public interface IShop
    {
        /// <summary>
        /// One Entity reader.
        /// </summary>
        /// <param name="id">Entity id.</param>
        /// <returns>Entity value.</returns>
        Shop GetOne(int id);

        /// <summary>
        /// All Entities reader.
        /// </summary>
        /// <returns>All properties.</returns>
        IList<Shop> GetALL();

        /// <summary>
        /// One manufacturer inserter.
        /// </summary>
        /// <param name="manufacturer">manufacturer.</param>
        void ManufacturerInsert(Shop manufacturer);

        /// <summary>
        /// manufacturer Remove.
        /// </summary>
        /// <param name="manufacturer">manufacturer.</param>
        void ManufacturerRemove(Shop manufacturer);

        /// <summary>
        /// Manufacturer uptare.
        /// </summary>
        /// <param name="manufacturer">New manufacturer.</param>
        void ManufacturerUpdate(Shop manufacturer);
    }
}
