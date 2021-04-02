// <copyright file="BrandLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MobileWebshop.Logic
{
    using System.Collections.Generic;
    using System.Linq;
    using MobileWebshop.Data.Models;
    using MobileWebshop.Repository;

    /// <summary>
    /// Brand logic class.
    /// </summary>
    public class BrandLogic : IBrand
    {
        /// <summary>
        /// Irepository Brand.
        /// </summary>
        private readonly IRepositoryBrand iRepositoryBrand;

        /// <summary>
        /// Initializes a new instance of the <see cref="BrandLogic"/> class.
        /// Sets I repository Brand.
        /// </summary>
        /// <param name="iRepositoryBrand">iRepositoryBrand value.</param>
        public BrandLogic(IRepositoryBrand iRepositoryBrand)
        {
            this.iRepositoryBrand = iRepositoryBrand;
        }

        /// <inheritdoc/>
        public void BrandUpdate(Brand brand)
        {
            this.iRepositoryBrand.BrandUpdate(brand);
        }

        /// <inheritdoc/>
        public IList<Brand> GetALL()
        {
            return this.iRepositoryBrand.GetALL().ToList();
        }

        /// <inheritdoc/>
        public Brand GetOne(int id)
        {
            return this.iRepositoryBrand.GetOne(id);
        }

        /// <inheritdoc/>
        public void BrandInsert(Brand brand)
        {
            this.iRepositoryBrand.ProductInsert(brand);
        }

        /// <inheritdoc/>
        public void BrandRemove(Brand brand)
        {
            this.iRepositoryBrand.Remove(brand);
        }
    }

    /// <summary>
    /// Brand Logic.
    /// </summary>
    public interface IBrand
    {
        /// <summary>
        /// Brand Update.
        /// </summary>
        /// <param name="brand">New brand.</param>
        void BrandUpdate(Brand brand);

        /// <summary>
        /// One brand reader.
        /// </summary>
        /// <param name="id">brand id.</param>
        /// <returns>brand value.</returns>
        Brand GetOne(int id);

        /// <summary>
        /// All Entities reader.
        /// </summary>
        /// <returns>All properties.</returns>
        IList<Brand> GetALL();

        /// <summary>
        /// One brand inserter.
        /// </summary>
        /// <param name="brand">new brand.</param>
        void BrandInsert(Brand brand);

        /// <summary>
        /// brand Remove.
        /// </summary>
        /// <param name="brand">brand.</param>
        void BrandRemove(Brand brand);
    }
}
