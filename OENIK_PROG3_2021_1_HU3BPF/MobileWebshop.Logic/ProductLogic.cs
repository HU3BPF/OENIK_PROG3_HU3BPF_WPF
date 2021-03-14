// <copyright file="ProductLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace MobileWebshop.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Product logic.
    /// </summary>
    internal class ProductLogic
    {
        /// <summary>
        /// Comparer to 2 Product object.
        /// </summary>
        /// <param name="obj">another Product object.</param>
        /// <returns>Bigger Product price.</returns>
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        /// <summary>
        /// Generate a Product hash Code.
        /// </summary>
        /// <returns>Product hash Code.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Ganerate Pruduct object string.
        /// </summary>
        /// <returns>String.</returns>
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
