// <copyright file="ShopManagementLogic.cs" company="PlaceholderCompany">
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
    /// Shop Logic.
    /// </summary>
    public class ShopManagementLogic : IShopManagementLogic
    {
        /// <summary>
        /// IRepositoryShop.
        /// </summary>
        private readonly IRepositoryShop iRepositoryShop;
        private readonly IRepositoryProduct iRepositoryProduct;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShopManagementLogic"/> class.
        /// </summary>
        /// <param name="iRepositoryShop">IRepository Shop value.</param>
        /// <param name="iRepositoryProduct">IRepository Product value.</param>
        public ShopManagementLogic(IRepositoryShop iRepositoryShop, IRepositoryProduct iRepositoryProduct)
        {
            this.iRepositoryProduct = iRepositoryProduct;
            this.iRepositoryShop = iRepositoryShop;
        }

        /// <inheritdoc/>
        public IList<Shop> GetALL()
        {
            return this.iRepositoryShop.GetALL().ToList();
        }

        /// <inheritdoc/>
        public Shop GetOne(int id)
        {
            return this.iRepositoryShop.GetOne(id);
        }

        /// <inheritdoc/>
        public void ShopInsert(Shop shop)
        {
            this.iRepositoryShop.Insert(shop);
        }

        /// <inheritdoc/>
        public void ShopUpdate(Shop shop)
        {
            this.iRepositoryShop.ShopUpdate(shop);
        }

        /// <inheritdoc/>
        public void ShopRemove(Shop shop)
        {
            this.iRepositoryShop.Remove(shop);
        }

        /// <inheritdoc/>
        public IList<ShopNumberOfProduct> GetNumberOfProducts()
        {
            var shopProducts = from shop in this.iRepositoryShop.GetALL()
                               join product in this.iRepositoryProduct.GetALL()
                               on shop.ShopId equals product.Brand.ShopID
                               let item = new { shop.ShopName, shop.ShopId, product.ProductName }
                               group item by item.ShopName into grp
                               orderby grp.Key descending
                               select new ShopNumberOfProduct
                               {
                                   ShopName = grp.Key,
                                   NumberOfProduct = grp.Select(x => x.ShopName).Count(),
                               };

            return shopProducts.ToList();
        }

        /// <inheritdoc/>
        public Task<IList<ShopNumberOfProduct>> GetNumberOfProductsAsync()
        {
            return new Task<IList<ShopNumberOfProduct>>(() => this.GetNumberOfProducts());
        }
    }

    /// <summary>
    /// Shop  Logic Interface.
    /// </summary>
    public interface IShopManagementLogic
    {
        /// <summary>
        /// One Entity reader.
        /// </summary>
        /// <param name="id">Entity id.</param>
        /// <returns>Entity value.</returns>
        Shop GetOne(int id);

        /// <summary>
        /// All Entity reader.
        /// </summary>
        /// <returns>All Entity.</returns>
        IList<Shop> GetALL();

        /// <summary>
        /// One shop inserter.
        /// </summary>
        /// <param name="shop">shop.</param>
        void ShopInsert(Shop shop);

        /// <summary>
        /// shop Remover.
        /// </summary>
        /// <param name="shop">shop.</param>
        void ShopRemove(Shop shop);

        /// <summary>
        /// shop updater.
        /// </summary>
        /// <param name="shop">New shop.</param>
        void ShopUpdate(Shop shop);

        /// <summary>
        /// Get Number Of Products.
        /// </summary>
        /// <returns>IList Shop Number Of Products.</returns>
        IList<ShopNumberOfProduct> GetNumberOfProducts();

        /// <summary>
        /// Get Number Of Products.
        /// </summary>
        /// <returns>IList Shop Number Of Products.</returns>
        Task<IList<ShopNumberOfProduct>> GetNumberOfProductsAsync();
    }
}
