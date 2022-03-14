// <copyright file="IRepositoryProduct.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Shops.Repository
{
    using System;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using Shops.Data.Models;

    /// <summary>
    /// Product Repository.
    /// </summary>
    public interface IRepositoryProduct : IRepository<Product>
    {
        /// <summary>
        /// Product Updater.
        /// </summary>
        /// <param name="newProduct">new product.</param>
        void ProductUpdate(Product newProduct);
    }

    /// <summary>
    /// Repository class of Product.
    /// </summary>
    public class RepositoryProduct : AncestorRepository<Product>, IRepositoryProduct
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryProduct"/> class.
        /// </summary>
        /// <param name="ctx">DBcontext.</param>
        public RepositoryProduct(DbContext ctx)
            : base(ctx)
        {
        }

        /// <summary>
        /// One Entity reader.
        /// </summary>
        /// <param name="id">Entity id.</param>
        /// <returns>Entity value.</returns>
        public override Product GetOne(int id)
        {
            return this.GetALL().SingleOrDefault(x => x.ProductdId == id);
        }

        /// <summary>
        /// Product Updater.
        /// </summary>
        /// <param name="newProduct">New product.</param>
        public void ProductUpdate(Product newProduct)
        {
            if (newProduct == null)
            {
                throw new EntityNotFoundException();
            }

            var oldProduct = this.GetOne(newProduct.ProductdId);
            oldProduct.ProductPrice = newProduct.ProductPrice;
            oldProduct.ProductName = newProduct.ProductName;
            oldProduct.ProductColour = newProduct.ProductColour;
            oldProduct.UsresRating = newProduct.UsresRating;
            oldProduct.StockNumber = newProduct.StockNumber;
            this.Ctx.SaveChanges();
        }
    }
}
