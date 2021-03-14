// <copyright file="IRepositoryProduct.cs" company="PlaceholderCompany">
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
       /// Product ID changer.
       /// </summary>
       /// <param name="id">old id.</param>
       /// <param name="newID">new id.</param>
        void ProductIdChanger(int id, int newID);

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
        /// Product categori changer.
        /// </summary>
        /// <param name="id">Product id.</param>
        /// <param name="category">new category.</param>
        public void ProductCategoryChanger(int id, Category category)
        {
            var oldProduct = this.GetOne(id);
            if (oldProduct == null)
            {
                throw new InvalidOperationException("Not found");
            }

            oldProduct.ProductCategori = category;
            this.Ctx.SaveChanges();
        }

        /// <summary>
        /// Product colour changer.
        /// </summary>
        /// <param name="id">Product id.</param>
        /// <param name="colour">Product new Price.</param>
        public void ProductColorChanger(int id, string colour)
        {
            var oldProduct = this.GetOne(id);
            if (oldProduct == null)
            {
                throw new InvalidOperationException("Not found");
            }

            oldProduct.ProductColour = colour;
            this.Ctx.SaveChanges();
        }

        /// <summary>
        /// Product ID changer.
        /// </summary>
        /// <param name="id">old id.</param>
        /// <param name="newID">new id.</param>
        public void ProductIdChanger(int id, int newID)
        {
            var oldProduct = this.GetOne(id);
            if (oldProduct == null)
            {
                throw new InvalidOperationException("Not found");
            }

            oldProduct.ProductdId = newID;
            this.Ctx.SaveChanges();
        }

        /// <summary>
        /// Product price changer.
        /// </summary>
        /// <param name="id">Product id.</param>
        /// <param name="price">Product new Price.</param>
        public void ProductPriceChanger(int id, int price)
        {
            var oldProduct = this.GetOne(id);
            if (oldProduct == null)
            {
                throw new InvalidOperationException("Not found");
            }

            oldProduct.ProductPrice = price;
            this.Ctx.SaveChanges();
        }
    }
}
