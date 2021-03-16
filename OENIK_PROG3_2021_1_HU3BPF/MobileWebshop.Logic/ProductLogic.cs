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
    public class ProductLogic : IProductLogics
    {
        /// <summary>
        /// Product Repository.
        /// </summary>
        private readonly IRepositoryProduct productRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductLogic"/> class.
        /// </summary>
        /// <param name="productRepository">IRepositoryProduct.</param>
        public ProductLogic(IRepositoryProduct productRepository)
        {
            this.productRepository = productRepository;
        }

        /// <summary>
        /// Gets one product.
        /// </summary>
        /// <param name="id">One product id.</param>
        /// <returns>Product where id = productId.</returns>
        public Product GetOneProduct(int id)
        {
            return this.productRepository.GetOne(id);
        }

        /// <summary>
        /// Price changer.
        /// </summary>
        /// <param name="productId">Product Id.</param>
        /// <param name="price">New Price.</param>
        public void ChangePrice(int productId, int price)
        {
            this.productRepository.ProductPriceChanger(productId, price);
        }

        /// <summary>
        /// Get all products.
        /// </summary>
        /// <returns>All products.</returns>
        public IList<Product> GetAllProducts()
        {
            return this.productRepository.GetALL().ToList();
        }

        /// <summary>
        /// IList <ProductAverag></ProductAverag>
        /// Gets list average product price.
        /// </summary>
        /// <returns>IList product average.</returns>
        public IList<ProductAverage> ProductAverages()
        {
            var q = from product in this.productRepository.GetALL()
                    group product by new { product.BrandrId, product.Brand.BrandName } into grp
                    select new ProductAverage()
                    {
                        ProductName = grp.Key.BrandName,
                        AveragePrice = grp.Average(x => x.ProductPrice),
                    };
            IList<ProductAverage> average = q.ToList();
            return average;
        }
    }
}
