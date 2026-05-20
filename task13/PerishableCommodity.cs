using System;

namespace CommodityLibrary
{
    public class PerishableCommodity : Commodity
    {
        public int MaxStorageDays { get; set; }

        public PerishableCommodity(string article, string name, UnitOfMeasure unit,
                                   decimal wholesalePrice, decimal retailPrice,
                                   string description, double stockQuantity,
                                   int maxStorageDays)
            : base(article, name, unit, wholesalePrice, retailPrice, description, stockQuantity)
        {
            MaxStorageDays = maxStorageDays;
        }

        public override string[] GetInfo()
        {
            var baseInfo = base.GetInfo();
            var newInfo = new string[baseInfo.Length + 1];
            Array.Copy(baseInfo, newInfo, baseInfo.Length);
            newInfo[newInfo.Length - 1] = $"Скоропортящийся товар, срок хранения: {MaxStorageDays} дн.";
            return newInfo;
        }
    }
}