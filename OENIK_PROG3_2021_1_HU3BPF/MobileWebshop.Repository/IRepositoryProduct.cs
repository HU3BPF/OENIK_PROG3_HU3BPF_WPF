﻿// <copyright file="IRepositoryProduct.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MobileWebshop.Repository
{
    using System;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using MobileWebshop.Data.Models;

    /// <summary>
    /// Product Repository.
    /// </summary>
    public interface IRepositoryProduct : IRepository<Product>
    {
        /// <summary>
        /// Product price changer.
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
        /// Product price changer.
        /// </summary>
        /// <param name="newProduct">New product.</param>
        public void ProductUpdate(Product newProduct)
        {
            var oldProduct = this.GetOne(newProduct.ProductdId);
            if (oldProduct == null)
            {
                throw new InvalidOperationException("Not found");
            }

            oldProduct.ProductPrice = newProduct.ProductPrice;
            oldProduct.ProductName = newProduct.ProductName;
            oldProduct.ProductColour = newProduct.ProductColour;
            oldProduct.UsresRating = newProduct.UsresRating;
            oldProduct.ProductCategory = newProduct.ProductCategory;
            this.Ctx.SaveChanges();
        }
    }
}
