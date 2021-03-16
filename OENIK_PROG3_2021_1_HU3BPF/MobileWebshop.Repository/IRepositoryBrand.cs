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
        /// Brand Quality changer.
        /// </summary>
        /// <param name="id">Brand Id.</param>
        /// <param name="newQuality">New brand quality.</param>
        void BrandQualityChanger(int id, int newQuality);

        /// <summary>
        /// Brand Update.
        /// </summary>
        /// <param name="id">Old Brand id.</param>
        /// <param name="brand">New brand.</param>
        void BrandUpdate(int id, Brand brand);

        /// <summary>
        /// Brand year fixer.
        /// </summary>
        /// <param name="id">Brand id.</param>
        /// <param name="year">FIxed year.</param>
        void BrandYearFixer(int id, int year);

        /// <summary>
        /// Users number changer.
        /// </summary>
        /// <param name="id">Brand id.</param>
        /// <param name="numberOfUsers">Brand Users number.</param>
        void BrandNumberOfUsersChanger(int id, int numberOfUsers);
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
        /// Brand Quality changer.
        /// </summary>
        /// <param name="id">Brand Id.</param>
        /// <param name="newQuality">New brand quality.</param>
        public void BrandQualityChanger(int id, int newQuality)
        {
            var oldBrand = this.GetOne(id);
            if (oldBrand == null)
            {
                throw new InvalidOperationException("NOt found");
            }

            oldBrand.BrandQuality = newQuality;
            this.Ctx.SaveChanges();
        }

        /// <summary>
        /// Brand Update.
        /// </summary>
        /// <param name="id">Old Brand id.</param>
        /// <param name="brand">New brand.</param>
        public void BrandUpdate(int id, Brand brand)
        {
            var oldBrand = this.GetOne(id);
            if (oldBrand == null)
            {
                throw new InvalidOperationException("NOt found");
            }

            oldBrand = brand;
            this.Ctx.SaveChanges();
        }

        /// <summary>
        /// Brand year fixer.
        /// </summary>
        /// <param name="id">Brand id.</param>
        /// <param name="year">FIxed year.</param>
        public void BrandYearFixer(int id, int year)
        {
            var oldYear = this.GetOne(id);
            if (oldYear == null)
            {
                throw new InvalidOperationException("NOt found");
            }

            oldYear.BrandYear = year;
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

        /// <summary>
        /// Users number changer.
        /// </summary>
        /// <param name="id">Brand id.</param>
        /// <param name="numberOfUsers">Brand Users number.</param>
        public void BrandNumberOfUsersChanger(int id, int numberOfUsers)
        {
            var oldUsersNumber = this.GetOne(id);
            if (oldUsersNumber == null)
            {
                throw new InvalidOperationException("NOt found");
            }

            oldUsersNumber.BrandYear = numberOfUsers;
            this.Ctx.SaveChanges();
        }
    }
}
