// <copyright file="GoodsManagementLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Shops.Logic
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Shops.Data.Models;
    using Shops.Logic.NonCrudClasses;
    using Shops.Repository;

    /// <summary>
    /// Product and Brand Logic.
    /// </summary>
    public class GoodsManagementLogic : IGoodsManagementLogic
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
        /// Initializes a new instance of the <see cref="GoodsManagementLogic"/> class.
        /// Sets IRepository Brand and IRepository Product.
        /// </summary>
        /// <param name="iRepositoryBrand">iRepository Brand value.</param>
        /// /// <param name="iRepositoryProduct">iRepository Product value.</param>
        public GoodsManagementLogic(IRepositoryBrand iRepositoryBrand, IRepositoryProduct iRepositoryProduct)
        {
            this.iRepositoryBrand = iRepositoryBrand;
            this.iRepositoryProduct = iRepositoryProduct;
        }

        /// <inheritdoc/>
        public IList<Product> ProductGetALL()
        {
            return this.iRepositoryProduct.GetALL().ToList();
        }

        /// <inheritdoc/>
        public Product ProductGetOne(int id)
        {
            return this.iRepositoryProduct.GetOne(id);
        }

        /// <inheritdoc/>
        public void ProductInsert(Product product)
        {
            this.iRepositoryProduct.Insert(product);
        }

        /// <inheritdoc/>
        public void ProductUpdate(Product newProduct)
        {
            this.iRepositoryProduct.ProductUpdate(newProduct);
        }

        /// <inheritdoc/>
        public void ProductRemove(Product product)
        {
            this.iRepositoryProduct.Remove(product);
        }

        /// <inheritdoc/>
        public void BrandUpdate(Brand brand)
        {
            this.iRepositoryBrand.BrandUpdate(brand);
        }

        /// <inheritdoc/>
        public IList<Brand> BrandGetALL()
        {
            return this.iRepositoryBrand.GetALL().ToList();
        }

        /// <inheritdoc/>
        public IList<Product> GetProductByBrand(int brand)
        {
            return this.iRepositoryProduct.GetALL().Where(x => x.BrandrId == brand).ToList();
        }

        /// <inheritdoc/>
        public Brand BrandGetOne(int id)
        {
            return this.iRepositoryBrand.GetOne(id);
        }

        /// <inheritdoc/>
        public void BrandInsert(Brand brand)
        {
            this.iRepositoryBrand.Insert(brand);
        }

        /// <inheritdoc/>
        public void BrandRemove(Brand brand)
        {
            this.iRepositoryBrand.Remove(brand);
        }

        /// <inheritdoc/>
        public IList<BrandAveragerProductPrice> GetBrandAveragesPrice()
        {
            var brandProductPrice = from brand in this.iRepositoryBrand.GetALL()
                                    join product in this.iRepositoryProduct.GetALL()
                                    on brand.BrandId equals product.BrandrId
                                    let item = new { BrandName = brand.BrandName, BrandId = brand.BrandId, Price = product.ProductPrice }
                                    group item by item.BrandName into grp
                                    orderby grp.Key descending
                                    select new BrandAveragerProductPrice
                                    {
                                        BrandName = grp.Key,
                                        AveragePrice = (double)grp.Average(x => x.Price),
                                    };

            return brandProductPrice.ToList();
        }

        /// <inheritdoc/>
        public IList<BrandAverageProductRating> GetBrandAveragesRating()
        {
            var brandProductPrice = from brand in this.iRepositoryBrand.GetALL()
                                    join product in this.iRepositoryProduct.GetALL()
                                    on brand.BrandId equals product.BrandrId
                                    let item = new { BrandName = brand.BrandName, BrandId = brand.BrandId, Rating = product.UsresRating }
                                    group item by item.BrandName into grp
                                    orderby grp.Key descending
                                    select new BrandAverageProductRating
                                    {
                                        BrandName = grp.Key,
                                        AverageRating = (double)grp.Average(x => x.Rating),
                                    };

            return brandProductPrice.ToList();
        }

        /// <inheritdoc/>
        public Task<IList<BrandAveragerProductPrice>> GetBrandAveragesPriceAsync()
        {
            return new Task<IList<BrandAveragerProductPrice>>(() => this.GetBrandAveragesPrice());
        }

        /// <inheritdoc/>
        public Task<IList<BrandAverageProductRating>> GetBrandAveragesRatingAsync()
        {
            return new Task<IList<BrandAverageProductRating>>(() => this.GetBrandAveragesRating());
        }
    }

    /// <summary>
    /// Product and Brand logic interface.
    /// </summary>
    public interface IGoodsManagementLogic
    {
        /// <summary>
        /// One product reader.
        /// </summary>
        /// <param name="id">Entity id.</param>
        /// <returns>Entity value.</returns>
        Product ProductGetOne(int id);

        /// <summary>
        /// All product reader.
        /// </summary>
        /// <returns>All Entity.</returns>
        IList<Product> ProductGetALL();

        /// <summary>
        /// One product inserter.
        /// </summary>
        /// <param name="product">product.</param>
        void ProductInsert(Product product);

        /// <summary>
        /// product Remove.
        /// </summary>
        /// <param name="product">product.</param>
        void ProductRemove(Product product);

        /// <summary>
        /// Product changer.
        /// </summary>
        /// <param name="newProduct">New product.</param>
        void ProductUpdate(Product newProduct);

        /// <summary>
        /// Brand Updater.
        /// </summary>
        /// <param name="brand">New brand.</param>
        void BrandUpdate(Brand brand);

        /// <summary>
        /// One brand reader.
        /// </summary>
        /// <param name="id">brand id.</param>
        /// <returns>brand value.</returns>
        Brand BrandGetOne(int id);

        /// <summary>
        /// All Entity reader.
        /// </summary>
        /// <returns>All Entity.</returns>
        IList<Brand> BrandGetALL();

        /// <summary>
        /// One Brand Products reader.
        /// </summary>
        /// /// <param name="brand">brand id.</param>
        /// <returns>One Brand Products.</returns>
        IList<Product> GetProductByBrand(int brand);

        /// <summary>
        /// One brand inserter.
        /// </summary>
        /// <param name="brand">new brand.</param>
        void BrandInsert(Brand brand);

        /// <summary>
        /// brand Remover.
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
        IList<BrandAverageProductRating> GetBrandAveragesRating();

        /// <summary>
        /// Get Brand Avrerages product price.
        /// </summary>
        /// <returns>IList Brand Average price Task.</returns>
        Task<IList<BrandAveragerProductPrice>> GetBrandAveragesPriceAsync();

        /// <summary>
        /// Get Brand Avrerages product Rating.
        /// </summary>
        /// <returns>IList Brand Average Rating Task.</returns>
        Task<IList<BrandAverageProductRating>> GetBrandAveragesRatingAsync();
    }
}
