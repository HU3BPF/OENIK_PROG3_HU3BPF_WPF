using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shops.Models.NonCrudClasses
{
    public class ShopAveragePrice
    {
        public string ShopName { get; set; }

        public double? AveragePrice { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is ShopAveragePrice)
            {
                ShopAveragePrice other = obj as ShopAveragePrice;
                return this.ShopName == other.ShopName &&
                    this.AveragePrice == other.AveragePrice;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return this.AveragePrice.GetHashCode();
        }

        public override string ToString()
        {
            return $"Shop Name: {this.ShopName},\n Average Price: {this.AveragePrice} ";
        }
    }
}
