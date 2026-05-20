using System;
using System.Globalization;

namespace CommodityLibrary
{
    public class Commodity : IComparable<Commodity>
    {
        public readonly string Article;

        // Наименование товара
        public string Name { get; set; }

        // Оптовая цена за единицу
        public decimal WholesalePrice { get; set; }

        // Розничная цена за единицу
        public decimal RetailPrice { get; set; }

        // Единица измерения
        public readonly UnitOfMeasure Unit;

        // Описание товара
        public string Description { get; set; }

        // Наличие на складе
        public double StockQuantity { get; set; }

        public Commodity(string article, string name, UnitOfMeasure unit)
        {
            Article = article;
            Name = name;
            Unit = unit;

            Description = string.Empty;
            WholesalePrice = 0;
            RetailPrice = 0;
            StockQuantity = 0;
        }

        public Commodity(string article, string name, UnitOfMeasure unit,
                         decimal wholesalePrice, decimal retailPrice,
                         string description, double stockQuantity)
            : this(article, name, unit)
        {
            WholesalePrice = wholesalePrice;
            RetailPrice = retailPrice;
            Description = description;
            StockQuantity = stockQuantity;
        }

        public virtual string[] GetInfo()
        {
            var info = new string[2];

            info[0] = $"[{Article}] {Name}";

            string unitName;
            switch (Unit)
            {
                case UnitOfMeasure.Pieces: unitName = "шт."; break;
                case UnitOfMeasure.Packages: unitName = "уп."; break;
                case UnitOfMeasure.Kilograms: unitName = "кг."; break;
                case UnitOfMeasure.Tons: unitName = "т."; break;
                default: unitName = "неизв."; break;
            }

            info[1] = $"Опт: {WholesalePrice.ToString("F2", CultureInfo.InvariantCulture)}, " +
                      $"Розница: {RetailPrice.ToString("F2", CultureInfo.InvariantCulture)} руб./{unitName}. " +
                      $"Остаток: {StockQuantity.ToString(CultureInfo.InvariantCulture)} {unitName}.";

            return info;

        }
        public int CompareTo(Commodity other)
        {
            if (other is null) return 1;

            return string.Compare(this.Article, other.Article, StringComparison.Ordinal);
        }
    }
}