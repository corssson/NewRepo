using System;
using System.Collections.Generic;

namespace CommodityLibrary
{
    public class CommodityNamePriceComparer : IComparer<Commodity>
    {
        public int Compare(Commodity x, Commodity y)
        {
            if (x is null && y is null) return 0;
            if (x is null) return -1;
            if (y is null) return 1;

            // Сначала по названию
            int nameCompare = string.Compare(x.Name, y.Name, StringComparison.Ordinal);
            if (nameCompare != 0) return nameCompare;

            // Затем по розничной цене (по возрастанию)
            return decimal.Compare(x.RetailPrice, y.RetailPrice);
        }
    }
}