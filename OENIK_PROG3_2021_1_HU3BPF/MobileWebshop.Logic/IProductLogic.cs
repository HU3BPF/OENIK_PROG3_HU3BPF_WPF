// <copyright file="IProductLogic.cs" company="PlaceholderCompany">
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
    /// Product logic interface.
    /// </summary>
    public interface IProductLogic
    {
        /// <summary>
        /// One product reader.
        /// </summary>
        /// <param name="id">Entity id.</param>
        /// <returns>Entity value.</returns>
        Product GetOne(int id);

        /// <summary>
        /// All product reader.
        /// </summary>
        /// <returns>All properties.</returns>
        IList<Product> GetALL();

        /// <summary>
        /// One product inserter.
        /// </summary>
        /// <param name="product">product.</param>
        void Insert(Product product);

        /// <summary>
        /// product Remove.
        /// </summary>
        /// <param name="product">product.</param>
        void Remove(Product product);

        /// <summary>
        /// Product ID changer.
        /// </summary>
        /// <param name="id">old id.</param>
        /// <param name="newID">new id.</param>
        void ProductIdChanger(int id, int newID);

        /// <summary>
        /// Product price changer.
        /// </summary>
        /// <param name="id">Product id.</param>
        /// <param name="product">Product new product.</param>
        void ProductUpdate(int id, Product product);

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
        /// <param name="colour">Product new colour.</param>
        void ProductColorChanger(int id, string colour);

        /// <summary>
        /// Product colour changer.
        /// </summary>
        /// <param name="id">Product id.</param>
        /// <param name="rating">Product new rating.</param>
        void ProductRatingChanger(int id, int rating);
    }
}
