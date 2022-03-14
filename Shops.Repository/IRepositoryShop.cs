// <copyright file="IRepositoryShop.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Shops.Repository
{
    using System;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using Shops.Data.Models;

    /// <summary>
    /// Shop Repository.
    /// </summary>
    public interface IRepositoryShop : IRepository<Shop>
    {
        /// <summary>
        /// New Shop updater.
        /// </summary>
        /// <param name="newShop">New Shop.</param>
        void ShopUpdate(Shop newShop);
    }

    /// <summary>
    /// Shop Repository.
    /// </summary>
    public class RepositoryShop : AncestorRepository<Shop>, IRepositoryShop
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryShop"/> class.
        /// </summary>
        /// <param name="ctx">Dbcontext.</param>
        public RepositoryShop(DbContext ctx)
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
        /// Shop updater.
        /// </summary>
        /// <param name="newShop">New Shop.</param>
        public void ShopUpdate(Shop newShop)
        {
            if (newShop == null)
            {
                throw new EntityNotFoundException();
            }

            var oldShop = this.GetOne(newShop.ShopId);
            oldShop.ShopAnnualProfit = newShop.ShopAnnualProfit;
            oldShop.ShopLeader = newShop.ShopLeader;
            oldShop.ShopLocation = newShop.ShopLocation;
            oldShop.ShopName = newShop.ShopName;
            oldShop.ShopNumberOfWorker = newShop.ShopNumberOfWorker;
            oldShop.ShopReliability = newShop.ShopReliability;
            this.Ctx.SaveChanges();
        }
    }
}
