using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shops.Models.NonCrudClasses
{
    public class ShopAverageRating
    {
        public string ShopName { get; set; }

        public double? AverageRating { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is ShopAverageRating)
            {
                ShopAverageRating other = obj as ShopAverageRating;
                return this.ShopName == other.ShopName &&
                    this.AverageRating == other.AverageRating;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return this.AverageRating.GetHashCode();
        }

        public override string ToString()
        {
            return $"Shop Name: {this.ShopName},\n Average Rating: {this.AverageRating} ";
        }
    }
}
