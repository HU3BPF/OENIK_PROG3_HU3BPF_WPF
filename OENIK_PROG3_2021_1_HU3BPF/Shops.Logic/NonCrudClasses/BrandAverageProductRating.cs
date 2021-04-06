// <copyright file="BrandAverageProductRating.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Shops.Logic.NonCrudClasses
{
    /// <summary>
    /// Brands Average Product Rating.
    /// </summary>
    public class BrandAverageProductRating
    {
        /// <summary>
        /// Gets or Sets Brand Name.
        /// </summary>
        public string BrandName { get; set; }

        /// <summary>
        /// Gets or Sets Average Rating.
        /// </summary>
        public double? AverageRating { get; set; }

        /// <summary>
        /// Brand Average Rating Equals.
        /// </summary>
        /// <param name="obj">Other Brand Average Price.</param>
        /// <returns>Brand Average Rating equals other Brand Average Price.</returns>
        public override bool Equals(object obj)
        {
            if (obj is BrandAverageProductRating)
            {
                BrandAverageProductRating other = obj as BrandAverageProductRating;
                return this.BrandName == other.BrandName &&
                    this.AverageRating == other.AverageRating;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Brand Average Price hasher.
        /// </summary>
        /// <returns>Gets Brand Average Rating hasCode.</returns>
        public override int GetHashCode()
        {
            return this.AverageRating.GetHashCode();
        }

        /// <summary>
        /// Brand Average Price ToString.
        /// </summary>
        /// <returns>Gets Brand Average Rating string.</returns>
        public override string ToString()
        {
            return $"Brand Name: {this.BrandName},\n Average Rating: {this.AverageRating} ";
        }
    }
}
