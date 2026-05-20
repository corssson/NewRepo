using NUnit.Framework;
using CommodityLibrary;
using System.Linq;

namespace CommodityLibrary.UnitTests
{
    [TestFixture]
    public class WarehouseTests
    {
        private Warehouse GetTestWarehouse()
        {
            var goods = new[]
            {
                new Commodity("A001", "Товар 1", UnitOfMeasure.Pieces),
                new Commodity("B002", "Товар 2", UnitOfMeasure.Packages),
                new Commodity("A001", "Товар 1 дубль", UnitOfMeasure.Pieces) // дубликат
            };
            return new Warehouse("Центральный склад", goods);
        }

        [Test]
        public void Constructor_ShouldSetName()
        {
            var warehouse = GetTestWarehouse();
            Assert.That(warehouse.Name, Is.EqualTo("Центральный склад"));
        }

        [Test]
        public void Count_ShouldIgnoreDuplicates()
        {
            var warehouse = GetTestWarehouse();
            Assert.That(warehouse.Count, Is.EqualTo(2));
        }

        [Test]
        public void IEnumerable_ShouldReturnAllGoods()
        {
            var warehouse = GetTestWarehouse();
            var goodsList = warehouse.ToList();

            Assert.That(goodsList.Count, Is.EqualTo(2));
            Assert.That(goodsList[0].Article, Is.EqualTo("A001"));
            Assert.That(goodsList[1].Article, Is.EqualTo("B002"));
        }

        [Test]
        public void Foreach_LoopsOverGoods()
        {
            var warehouse = GetTestWarehouse();
            int count = 0;

            foreach (var item in warehouse)
            {
                count++;
            }

            Assert.That(count, Is.EqualTo(2));
        }
    }
}