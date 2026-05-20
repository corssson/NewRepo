using NUnit.Framework;
using CommodityLibrary;
using System.Collections.Generic;

namespace CommodityLibrary.UnitTests
{
    [TestFixture]
    public class CommodityNamePriceComparerTests
    {
        [Test]
        public void Comparer_SortsByNameThenPrice()
        {
            var goods = new List<Commodity>
            {
                new Commodity("001", "Яблоки", UnitOfMeasure.Kilograms) { RetailPrice = 100m },
                new Commodity("002", "Бананы", UnitOfMeasure.Kilograms) { RetailPrice = 80m },
                new Commodity("003", "Яблоки", UnitOfMeasure.Kilograms) { RetailPrice = 90m },
                new Commodity("004", "Апельсины", UnitOfMeasure.Kilograms) { RetailPrice = 120m }
            };

            goods.Sort(new CommodityNamePriceComparer());

            Assert.That(goods[0].Name, Is.EqualTo("Апельсины")); // А
            Assert.That(goods[1].Name, Is.EqualTo("Бананы"));    // Б
            Assert.That(goods[2].Name, Is.EqualTo("Яблоки"));    // Я (первый 90)
            Assert.That(goods[3].Name, Is.EqualTo("Яблоки"));    // Я (второй 100)

            Assert.That(goods[2].RetailPrice, Is.EqualTo(90m));
            Assert.That(goods[3].RetailPrice, Is.EqualTo(100m));
        }
    }
}