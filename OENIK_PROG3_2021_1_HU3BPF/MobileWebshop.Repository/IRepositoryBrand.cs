// <copyright file="IRepositoryBrand.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MobileWebshop.Repository
{
    using MobileWebshop.Data.Models;

    /// <summary>
    /// Brand Repository.
    /// </summary>
    public interface IRepositoryBrand : IRepository<Brand>
    {
        /// <summary>
        /// Brand Quality changer.
        /// </summary>
        /// <param name="id">Brand Id.</param>
        /// <param name="newQuality">New brand quality.</param>
        void BrandQualityChanger(int id, int newQuality);

        /// <summary>
        /// Brand Update.
        /// </summary>
        /// <param name="id">Old Brand id.</param>
        /// <param name="brand">New brand.</param>
        void BrandUpdate(int id, Brand brand);

        /// <summary>
        /// Brand year fixer.
        /// </summary>
        /// <param name="id">Brand id.</param>
        /// <param name="year">FIxed year.</param>
        void BrandYearFixer(int id, int year);
    }
}
