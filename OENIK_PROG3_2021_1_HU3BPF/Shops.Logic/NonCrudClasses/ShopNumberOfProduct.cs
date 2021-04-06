// <copyright file="ShopNumberOfProduct.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Shops.Logic.NonCrudClasses
{
    /// <summary>
    /// Shop Number Of Product.
    /// </summary>
    public class ShopNumberOfProduct
    {
        /// <summary>
        /// Gets or Sets Shop Name.
        /// </summary>
        public string ShopName { get; set; }

        /// <summary>
        /// Gets or Sets Shop Number Of Products.
        /// </summary>
        public double? NumberOfProduct { get; set; }

        /// <summary>
        /// Shop Number Of Products Equals.
        /// </summary>
        /// <param name="obj">Other Shop Number Of Products.</param>
        /// <returns>Shop Number Of Products equals other Shop Number Of Products.</returns>
        public override bool Equals(object obj)
        {
            if (obj is ShopNumberOfProduct)
            {
                ShopNumberOfProduct other = obj as ShopNumberOfProduct;
                return this.ShopName == other.ShopName &&
                    this.NumberOfProduct == other.NumberOfProduct;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Shop Number Of Products hasher.
        /// </summary>
        /// <returns>Gets Shop Number Of Products hasCode.</returns>
        public override int GetHashCode()
        {
            return this.NumberOfProduct.GetHashCode();
        }

        /// <summary>
        /// Shop Number Of Products ToString.
        /// </summary>
        /// <returns>Gets Shop Number Of Products string.</returns>
        public override string ToString()
        {
            return $"Shop Name: {this.ShopName},\n Number Of Product: {this.NumberOfProduct} ";
        }
    }
}
