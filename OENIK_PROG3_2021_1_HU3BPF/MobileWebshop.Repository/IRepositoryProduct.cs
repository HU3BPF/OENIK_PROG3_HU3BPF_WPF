// <copyright file="IRepositoryProduct.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MobileWebshop.Repository
{
    using MobileWebshop.Data.Models;

    /// <summary>
    /// Product Repository.
    /// </summary>
    public interface IRepositoryProduct : IRepository<Product>
    {
        /// <summary>
        /// Product Id Changer.
        /// </summary>
        void ProductIdChanger();
    }
}
