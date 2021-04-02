// <copyright file="IRepositoryBrand.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MobileWebshop.Repository
{
    using System;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using MobileWebshop.Data.Models;

    /// <summary>
    /// Brand Repository.
    /// </summary>
    public interface IRepositoryBrand : IRepository<Brand>
    {
        /// <summary>
        /// Brand Update.
        /// </summary>
        /// <param name="newBrand">New Brand entity.</param>
        void BrandUpdate(Brand newBrand);
    }

    /// <summary>
    /// Brand Repository class.
    /// </summary>
    public class BrandRepository : AncestorRepository<Brand>, IRepositoryBrand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BrandRepository"/> class.
        /// </summary>
        /// <param name="ctx">Dbcontext.</param>
        public BrandRepository(DbContext ctx)
            : base(ctx)
        {
        }

        /// <summary>
        /// Brand Update.
        /// </summary>
        /// <param name="newBrand">New Brand entity.</param>
        public void BrandUpdate(Brand newBrand)
        {
            var oldBrand = this.GetOne(newBrand.BrandId);
            if (oldBrand == null)
            {
                throw new InvalidOperationException("NOt found");
            }

            oldBrand.BrandId = newBrand.BrandId;
            oldBrand.BrandName = newBrand.BrandName;
            oldBrand.BrandQuality = newBrand.BrandQuality;
            oldBrand.BrandYear = newBrand.BrandYear;
            oldBrand.Manufacturer = newBrand.Manufacturer;
            oldBrand.ManufacturerId = newBrand.ManufacturerId;
            oldBrand.NumberOfUsers = newBrand.NumberOfUsers;
            oldBrand.SystemType = newBrand.SystemType;
            oldBrand.Products = newBrand.Products;
            this.Ctx.SaveChanges();
        }

        /// <summary>
        /// GetONe entity.
        /// </summary>
        /// <param name="id">Entity Id.</param>
        /// <returns>1 Entity when Id =ID.</returns>
        public override Brand GetOne(int id)
        {
            return this.GetALL().SingleOrDefault(x => x.BrandId == id);
        }
    }
}
