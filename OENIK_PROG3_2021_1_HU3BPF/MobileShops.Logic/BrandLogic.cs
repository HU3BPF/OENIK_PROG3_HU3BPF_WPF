// <copyright file="BrandLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MobileWebshop.Logic
{
    using System.Collections.Generic;
    using System.Linq;
    using MobileShops.Logic;
    using MobileShops.Logic.NonCrudLogic;
    using MobileWebshop.Data.Models;
    using MobileWebshop.Repository;

    /// <summary>
    /// Brand logic class.
    /// </summary>
    public class BrandLogic : IBrand
    {
        /// <summary>
        /// Irepository Brand.
        /// </summary>
        private readonly IRepositoryBrand iRepositoryBrand;

        /// <summary>
        /// Irepository Product.
        /// </summary>
        private readonly IRepositoryProduct iRepositoryProduct;

        /// <summary>
        /// Initializes a new instance of the <see cref="BrandLogic"/> class.
        /// Sets IRepository Brand and IRepository Product.
        /// </summary>
        /// <param name="iRepositoryBrand">iRepository Brand value.</param>
        /// /// <param name="iRepositoryProduct">iRepository Product value.</param>
        public BrandLogic(IRepositoryBrand iRepositoryBrand, IRepositoryProduct iRepositoryProduct)
        {
            this.iRepositoryBrand = iRepositoryBrand;
            this.iRepositoryProduct = iRepositoryProduct;
        }

        /// <inheritdoc/>
        public void BrandUpdate(Brand brand)
        {
            this.iRepositoryBrand.BrandUpdate(brand);
        }

        /// <inheritdoc/>
        public IList<Brand> GetALL()
        {
            return this.iRepositoryBrand.GetALL().ToList();
        }

        /// <inheritdoc/>
        public Brand GetOne(int id)
        {
            return this.iRepositoryBrand.GetOne(id);
        }

        /// <inheritdoc/>
        public void BrandInsert(Brand brand)
        {
            this.iRepositoryBrand.ProductInsert(brand);
        }

        /// <inheritdoc/>
        public void BrandRemove(Brand brand)
        {
            this.iRepositoryBrand.Remove(brand);
        }

        /// <summary>
        /// Get Brand Avrerages product price.
        /// </summary>
        /// <returns>IList Brand Average price.</returns>
        public IList<BrandAveragerProductPrice> GetBrandAveragesPrice()
        {
            var brandProductPrice = from brand in this.iRepositoryBrand.GetALL()
                                    join product in this.iRepositoryProduct.GetALL()
                                    on brand.BrandId equals product.BrandrId
                                    group brand by new { brand.BrandName, brand.BrandId, product.ProductPrice } into grp
                                    orderby grp.Key.BrandName descending
                                    select new BrandAveragerProductPrice
                                    {
                                        BrandName = grp.Key.BrandName,
                                        AveragePrice = grp.Key.ProductPrice,
                                    };

            var brandAveragePrice = from brand in brandProductPrice
                                    group brand by brand.BrandName into grp
                                    select new BrandAveragerProductPrice
                                    {
                                       BrandName = grp.Key,
                                       AveragePrice = (long)grp.Average(x => x.AveragePrice),
                                    };

            return brandAveragePrice.ToList();
        }

        /// <summary>
        /// Get Brand Avrerages product Rating.
        /// </summary>
        /// <returns>IList Brand Average Rating.</returns>
        public IList<BrandAverageProductRating> GetBrandAveragesRating()
        {
            var brandProductPrice = from brand in this.iRepositoryBrand.GetALL()
                                    join product in this.iRepositoryProduct.GetALL()
                                    on brand.BrandId equals product.BrandrId
                                    group brand by new { brand.BrandName, brand.BrandId, product.UsresRating } into grp
                                    orderby grp.Key.BrandName descending
                                    select new BrandAverageProductRating
                                    {
                                        BrandName = grp.Key.BrandName,
                                        AverageRating = grp.Key.UsresRating,
                                    };

            var brandAveragePrice = from brand in brandProductPrice
                                    group brand by brand.BrandName into grp
                                    select new BrandAverageProductRating
                                    {
                                        BrandName = grp.Key,
                                        AverageRating = (long)grp.Average(x => x.AverageRating),
                                    };

            return brandAveragePrice.ToList();
        }

        /// <summary>
        /// Get Brand Avrerages product price.
        /// </summary>
        /// <returns>IList Brand Average price.</returns>
        public IList<BrandAveragerProductPrice> GetBrandAveragesPriceAsync()
        {
            var brandProductPrice = from brand in this.iRepositoryBrand.GetALL()
                                    join product in this.iRepositoryProduct.GetALL()
                                    on brand.BrandId equals product.BrandrId
                                    group brand by new { brand.BrandName, brand.BrandId, product.ProductPrice } into grp
                                    orderby grp.Key.BrandName descending
                                    select new BrandAveragerProductPrice
                                    {
                                        BrandName = grp.Key.BrandName,
                                        AveragePrice = grp.Key.ProductPrice,
                                    };

            var brandAveragePrice = from brand in brandProductPrice
                                    group brand by brand.BrandName into grp
                                    select new BrandAveragerProductPrice
                                    {
                                        BrandName = grp.Key,
                                        AveragePrice = (long)grp.Average(x => x.AveragePrice),
                                    };

            return brandAveragePrice.ToList();
        }

        /// <summary>
        /// Get Brand Avrerages product Rating.
        /// </summary>
        /// <returns>IList Brand Average Rating.</returns>
        public IList<BrandAverageProductRating> GetBrandAveragesRatingAsync()
        {
            var brandProductPrice = from brand in this.iRepositoryBrand.GetALL()
                                    join product in this.iRepositoryProduct.GetALL()
                                    on brand.BrandId equals product.BrandrId
                                    group brand by new { brand.BrandName, brand.BrandId, product.UsresRating } into grp
                                    orderby grp.Key.BrandName descending
                                    select new BrandAverageProductRating
                                    {
                                        BrandName = grp.Key.BrandName,
                                        AverageRating = grp.Key.UsresRating,
                                    };

            var brandAveragePrice = from brand in brandProductPrice
                                    group brand by brand.BrandName into grp
                                    select new BrandAverageProductRating
                                    {
                                        BrandName = grp.Key,
                                        AverageRating = (long)grp.Average(x => x.AverageRating),
                                    };

            return brandAveragePrice.ToList();
        }
    }

    /// <summary>
    /// Brand Logic.
    /// </summary>
    public interface IBrand
    {
        /// <summary>
        /// Brand Update.
        /// </summary>
        /// <param name="brand">New brand.</param>
        void BrandUpdate(Brand brand);

        /// <summary>
        /// One brand reader.
        /// </summary>
        /// <param name="id">brand id.</param>
        /// <returns>brand value.</returns>
        Brand GetOne(int id);

        /// <summary>
        /// All Entities reader.
        /// </summary>
        /// <returns>All Entities.</returns>
        IList<Brand> GetALL();

        /// <summary>
        /// One brand inserter.
        /// </summary>
        /// <param name="brand">new brand.</param>
        void BrandInsert(Brand brand);

        /// <summary>
        /// brand Remove.
        /// </summary>
        /// <param name="brand">brand.</param>
        void BrandRemove(Brand brand);

        /// <summary>
        /// Get Brand Avrerages price.
        /// </summary>
        /// <returns>IList Brand Average price.</returns>
        IList<BrandAveragerProductPrice> GetBrandAveragesPrice();

        /// <summary>
        /// Get Brand Avrerages product Rating.
        /// </summary>
        /// <returns>IList Brand Average Rating.</returns>
        public IList<BrandAverageProductRating> GetBrandAveragesRatingAsync();
    }
}
