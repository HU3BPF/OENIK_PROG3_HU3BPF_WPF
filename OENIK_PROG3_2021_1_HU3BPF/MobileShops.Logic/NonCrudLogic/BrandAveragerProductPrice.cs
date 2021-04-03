﻿// <copyright file="BrandAveragerProductPrice.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MobileShops.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MobileWebshop.Data.Models;

    /// <summary>
    /// Brand Average Product Profit.
    /// </summary>
    public class BrandAveragerProductPrice
    {
        /// <summary>
        /// Gets or Sets Brand Name.
        /// </summary>
        public string BrandName { get; set; }

        /// <summary>
        /// Gets or Sets Average Profit.
        /// </summary>
        public double? AveragePrice { get; set; }

        /// <summary>
        /// Brand Average Price Equals.
        /// </summary>
        /// <param name="obj">Other Brand Average Price.</param>
        /// <returns>Brand Average Price equals other Brand Average Price.</returns>
        public override bool Equals(object obj)
        {
            if (obj is BrandAveragerProductPrice)
            {
                BrandAveragerProductPrice other = obj as BrandAveragerProductPrice;
                return this.BrandName == other.BrandName &&
                    this.AveragePrice == other.AveragePrice;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Brand Average Price hasher.
        /// </summary>
        /// <returns>Gets Brand Average Price hasCode.</returns>
        public override int GetHashCode()
        {
            return this.AveragePrice.GetHashCode() + this.AveragePrice.GetHashCode();
        }

        /// <summary>
        /// Brand Average Price ToString.
        /// </summary>
        /// <returns>Gets Brand Average Price string.</returns>
        public override string ToString()
        {
            return $"Brand Name: {this.BrandName},\n Average Price: {this.AveragePrice} ";
        }
    }
}
