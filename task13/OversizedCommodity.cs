using System;

namespace CommodityLibrary
{
    public class OversizedCommodity : Commodity
    {
        // Габариты: длина, ширина, высота
        public double Length { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }

        public OversizedCommodity(string article, string name, UnitOfMeasure unit,
                                  decimal wholesalePrice, decimal retailPrice,
                                  string description, double stockQuantity,
                                  double length, double width, double height)
            : base(article, name, unit, wholesalePrice, retailPrice, description, stockQuantity)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public override string[] GetInfo()
        {
            var baseInfo = base.GetInfo();
            var newInfo = new string[baseInfo.Length + 1];
            Array.Copy(baseInfo, newInfo, baseInfo.Length);
            newInfo[newInfo.Length - 1] = $"Габариты (ДхШхВ): {Length} x {Width} x {Height} м";
            return newInfo;
        }
    }
}