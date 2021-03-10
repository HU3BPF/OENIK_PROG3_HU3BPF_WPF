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
        /// Brand Id Changer.
        /// </summary>
        void BrandIdChanger();
    }
}
