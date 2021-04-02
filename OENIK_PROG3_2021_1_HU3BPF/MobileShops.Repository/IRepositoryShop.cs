// <copyright file="IRepositoryShop.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MobileWebshop.Repository
{
    using System;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using MobileWebshop.Data.Models;

    /// <summary>
    /// Manufacturer Repository.
    /// </summary>
    public interface IRepositoryShop : IRepository<Shop>
    {
        /// <summary>
        /// newShop uptare.
        /// </summary>
        /// <param name="newShop">New Shop.</param>
        void ShopUpdate(Shop newShop);
    }

    /// <summary>
    /// Manufacturer Repository.
    /// </summary>
    public class RepositoryManufacturer : AncestorRepository<Shop>, IRepositoryShop
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryManufacturer"/> class.
        /// </summary>
        /// <param name="ctx">Dbcontext.</param>
        public RepositoryManufacturer(DbContext ctx)
            : base(ctx)
        {
        }

        /// <summary>
        /// One Entity reader.
        /// </summary>
        /// <param name="id">Entity id.</param>
        /// <returns>Entity value.</returns>
        public override Shop GetOne(int id)
        {
            return this.GetALL().SingleOrDefault(x => x.ShopId == id);
        }

        /// <summary>
        /// Shop updatre.
        /// </summary>
        /// <param name="newShop">New Shop.</param>
        public void ShopUpdate(Shop newShop)
        {
            var oldShop = this.GetOne(newShop.ShopId);
            if (oldShop == null)
            {
                throw new InvalidOperationException("Not found");
            }

            oldShop.ShopAnnualProfit = newShop.ShopAnnualProfit;
            oldShop.ShopLeader = newShop.ShopLeader;
            oldShop.ShopLocation = newShop.ShopLocation;
            oldShop.ShopName = newShop.ShopName;
            oldShop.ShopNumberOfWorker = newShop.ShopNumberOfWorker;
            oldShop.ShopReliability = newShop.ShopReliability;
            oldShop.Brands = newShop.Brands;
            this.Ctx.SaveChanges();
        }
    }
}
