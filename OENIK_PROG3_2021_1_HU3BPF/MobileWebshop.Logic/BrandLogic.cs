// <copyright file="BrandLogic.cs" company="PlaceholderCompany">
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
        public void BrandNumberOfUsersChanger(int id, int numberOfUsers)
        {
            this.iRepositoryBrand.BrandNumberOfUsersChanger(id, numberOfUsers);
        }

        /// <inheritdoc/>
        public void BrandQualityChanger(int id, int newQuality)
        {
            this.iRepositoryBrand.BrandQualityChanger(id, newQuality);
        }

        /// <inheritdoc/>
        public void BrandUpdate(int id, Brand brand)
        {
            this.iRepositoryBrand.BrandUpdate(id, brand);
        }

        /// <inheritdoc/>
        public void BrandYearFixer(int id, int year)
        {
            this.iRepositoryBrand.BrandYearFixer(id, year);
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
        public void Insert(Brand brand)
        {
            this.iRepositoryBrand.Insert(brand);
        }

        /// <inheritdoc/>
        public void Remove(Brand brand)
        {
            this.iRepositoryBrand.Remove(brand);
        }
    }
}
