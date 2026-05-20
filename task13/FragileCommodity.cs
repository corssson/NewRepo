using System;

namespace CommodityLibrary
{
    public class FragileCommodity : Commodity
    {
        public int MaxStackSize { get; set; }

        public FragileCommodity(string article, string name, UnitOfMeasure unit,
                                decimal wholesalePrice, decimal retailPrice,
                                string description, double stockQuantity,
                                int maxStackSize)
            : base(article, name, unit, wholesalePrice, retailPrice, description, stockQuantity)
        {
            MaxStackSize = maxStackSize;
        }

        public override string[] GetInfo()
        {
            var baseInfo = base.GetInfo();
            var newInfo = new string[baseInfo.Length + 1];
            Array.Copy(baseInfo, newInfo, baseInfo.Length);
            newInfo[newInfo.Length - 1] = $"Хрупкий товар, макс. в стопке: {MaxStackSize} шт.";
            return newInfo;
        }
    }
}