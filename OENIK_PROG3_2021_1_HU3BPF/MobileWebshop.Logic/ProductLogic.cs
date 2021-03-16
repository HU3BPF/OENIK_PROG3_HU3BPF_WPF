// <copyright file="ProductLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace MobileWebshop.Logic
{
    using System.Collections.Generic;
    using System.Linq;
    using MobileWebshop.Data.Models;
    using MobileWebshop.Repository;

    /// <summary>
    /// Product Logic.
    /// </summary>
    public class ProductLogic : IProductLogic
    {
        /// <summary>
        /// Product Repository.
        /// </summary>
        private readonly IRepositoryProduct iProductRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductLogic"/> class.
        /// </summary>
        /// <param name="iProductRepository">IRepositoryProduct.</param>
        public ProductLogic(IRepositoryProduct iProductRepository)
        {
            this.iProductRepository = iProductRepository;
        }

        /// <inheritdoc/>
        public IList<Product> GetALL()
        {
            return this.iProductRepository.GetALL().ToList();
        }

        /// <inheritdoc/>
        public Product GetOne(int id)
        {
            return this.iProductRepository.GetOne(id);
        }

        /// <inheritdoc/>
        public void Insert(Product product)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// IList <ProductAverag></ProductAverag>
        /// Gets list average product price.
        /// </summary>
        /// <returns>IList product average.</returns>
        public IList<ProductAverage> ProductAverages()
        {
            var q = from product in this.iProductRepository.GetALL()
                    group product by new { product.BrandrId, product.Brand.BrandName } into grp
                    select new ProductAverage()
                    {
                        ProductName = grp.Key.BrandName,
                        AveragePrice = grp.Average(x => x.ProductPrice),
                    };
            IList<ProductAverage> average = q.ToList();
            return average;
        }

        /// <inheritdoc/>
        public void ProductCategoryChanger(int id, Category category)
        {
            this.iProductRepository.ProductCategoryChanger(id, category);
        }

        /// <inheritdoc/>
        public void ProductColorChanger(int id, string colour)
        {
            this.iProductRepository.ProductColorChanger(id, colour);
        }

        /// <inheritdoc/>
        public void ProductIdChanger(int id, int newID)
        {
            this.iProductRepository.ProductIdChanger(id, newID);
        }

        /// <inheritdoc/>
        public void ProductPriceChanger(int id, int price)
        {
            this.iProductRepository.ProductPriceChanger(id, price);
        }

        /// <inheritdoc/>
        public void ProductRatingChanger(int id, int rating)
        {
            this.iProductRepository.ProductRatingChanger(id, rating);
        }

        /// <inheritdoc/>
        public void ProductUpdate(int id, Product product)
        {
            this.iProductRepository.ProductUpdate(id, product);
        }

        /// <inheritdoc/>
        public void Remove(Product product)
        {
            this.iProductRepository.Remove(product);
        }
    }
}
