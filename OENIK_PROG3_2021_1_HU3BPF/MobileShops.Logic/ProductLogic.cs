// <copyright file="ProductLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MobileWebshop.Logic
{
    using System.Collections.Generic;
    using System.Linq;
    using MobileShops.Logic;
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
        /// <param name="iProductRepository">IRepository Product.</param>
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
        public void ProductInsert(Product product)
        {
            this.iProductRepository.ProductInsert(product);
        }

        /// <inheritdoc/>
        public void ProductUpdate(Product newProduct)
        {
            this.iProductRepository.ProductUpdate(newProduct);
        }

        /// <inheritdoc/>
        public void ProductRemove(Product product)
        {
            this.iProductRepository.Remove(product);
        }
    }

    /// <summary>
    /// Product logic interface.
    /// </summary>
    public interface IProductLogic
    {
        /// <summary>
        /// One product reader.
        /// </summary>
        /// <param name="id">Entity id.</param>
        /// <returns>Entity value.</returns>
        Product GetOne(int id);

        /// <summary>
        /// All product reader.
        /// </summary>
        /// <returns>All Entity.</returns>
        IList<Product> GetALL();

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
    }
}
