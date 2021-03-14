﻿// <copyright file="ProductAverage.cs" company="PlaceholderCompany">
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
    /// Product logic.
    /// </summary>
    internal class ProductAverage
    {
        /// <summary>
        /// Gets or sets Produt name.
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or sets and Sets Product average price.
        /// </summary>
        public double AveragePrice { get; set; }

        /// <summary>
        /// Comparer to 2 Product object.
        /// </summary>
        /// <param name="obj">another Product object.</param>
        /// <returns>Bigger Product price.</returns>
        public override bool Equals(object obj)
        {
            if (obj is ProductAverage)
            {
                ProductAverage other = obj as ProductAverage;
                return this.ProductName == other.ProductName && this.AveragePrice == other.AveragePrice;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Generate a Product hash Code.
        /// </summary>
        /// <returns>Product hash Code.</returns>
        public override int GetHashCode()
        {
            return (int)this.AveragePrice;
        }

        /// <summary>
        /// Ganerate Pruduct object string.
        /// </summary>
        /// <returns>String.</returns>
        public override string ToString()
        {
            return $"Product = {this.ProductName}, Product Average Price = {this.AveragePrice}";
        }
    }

    /// <summary>
    /// Product logic interface.
    /// </summary>
    public interface IProductLogics
    {
        /// <summary>
        /// Gets one product.
        /// </summary>
        /// <param name="id">One product id.</param>
        /// <returns>Product where id = productId.</returns>
        Product GetOneProduct(int id);

        /// <summary>
        /// Price changer.
        /// </summary>
        /// <param name="productId">Product Id.</param>
        /// <param name="price">New Price.</param>
        void ChangePrice(int productId, int price);

        /// <summary>
        /// Get all products.
        /// </summary>
        /// <returns>All products.</returns>
        IList<Product> GetAllProducts();
    }
}
