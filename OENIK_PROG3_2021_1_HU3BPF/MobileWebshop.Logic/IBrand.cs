// <copyright file="IBrand.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace MobileWebshop.Logic
{
    using System.Collections.Generic;
    using MobileWebshop.Data.Models;

    /// <summary>
    /// Brand Logic.
    /// </summary>
    public interface IBrand
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

        /// <summary>
        /// Users number changer.
        /// </summary>
        /// <param name="id">Brand id.</param>
        /// <param name="numberOfUsers">Brand Users number.</param>
        void BrandNumberOfUsersChanger(int id, int numberOfUsers);

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
        void Insert(Brand brand);

        /// <summary>
        /// brand Remove.
        /// </summary>
        /// <param name="brand">brand.</param>
        void Remove(Brand brand);
    }
}
