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

        /// <summary>
        /// Product price changer.
        /// </summary>
        /// <param name="id">Product id.</param>
        /// <param name="price">Product new Price.</param>
        void ProductPriceChanger(int id, int price);

        /// <summary>
        /// Product categori changer.
        /// </summary>
        /// <param name="id">Product id.</param>
        /// <param name="category">new category.</param>
        void ProductCategoryChanger(int id, Category category);

        /// <summary>
        /// Product colour changer.
        /// </summary>
        /// <param name="id">Product id.</param>
        /// <param name="colour">Product new Price.</param>
        void ProductColorChanger(int id, string colour);
    }
}
