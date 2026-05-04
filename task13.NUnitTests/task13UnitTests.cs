using NUnit.Framework;
using CommodityLibrary;

namespace CommodityLibrary.NUnitTests
{
    [TestFixture]
    public class CommodityUnitTests
    {
        private Commodity CreateTestCommodity()
        {
            return new Commodity(
                article: "A-001234",
                name: "Сахар-песок белый",
                unit: UnitOfMeasure.Kilograms,
                wholesalePrice: 45.50m,
                retailPrice: 59.99m,
                description: "Фасованный по 1 кг",
                stockQuantity: 1500.5
            );
        }

        [Test]
        public void ConstructorTest()
        {
            var sugar = CreateTestCommodity();

            Assert.That(sugar.Article, Is.EqualTo("A-001234"));
            Assert.That(sugar.Name, Is.EqualTo("Сахар-песок белый"));
            Assert.That(sugar.Unit, Is.EqualTo(UnitOfMeasure.Kilograms));
            Assert.That(sugar.WholesalePrice, Is.EqualTo(45.50m));
            Assert.That(sugar.RetailPrice, Is.EqualTo(59.99m));
            Assert.That(sugar.Description, Is.EqualTo("Фасованный по 1 кг"));
            Assert.That(sugar.StockQuantity, Is.EqualTo(1500.5d).Within(0.001));
        }

        [Test]
        public void GetInfoTest()
        {
            var sugar = CreateTestCommodity();

            var info = sugar.GetInfo();

            Assert.That(info.Length, Is.EqualTo(2));
            Assert.That(info[0], Is.EqualTo("[A-001234] Сахар-песок белый"));

            Assert.That(info[1], Does.Contain("Опт: 45.50"));
            Assert.That(info[1], Does.Contain("Розница: 59.99"));
            Assert.That(info[1], Does.Contain("руб./кг"));
            Assert.That(info[1], Does.Contain("Остаток: 1500.5 кг"));
        }
    }
}