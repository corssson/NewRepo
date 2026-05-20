using NUnit.Framework;
using CommodityLibrary;

namespace CommodityLibrary.UnitTests
{
    [TestFixture]
    public class FragileCommodityTests
    {
        private FragileCommodity GetTestFragile()
        {
            return new FragileCommodity(
                "ART001", "Стеклянная ваза", UnitOfMeasure.Pieces,
                500m, 1200m, "Хрупкая ваза", 15, 5);
        }

        [Test]
        public void Constructor_ShouldSetMaxStackSize()
        {
            var fragile = GetTestFragile();
            Assert.That(fragile.MaxStackSize, Is.EqualTo(5));
        }

        [Test]
        public void GetInfo_ShouldIncludeFragileInfo()
        {
            var fragile = GetTestFragile();
            var info = fragile.GetInfo();

            // Проверяем количество строк (должно быть 3: 2 от базового + 1 от производного)
            Assert.That(info.Length, Is.EqualTo(3));

            // Проверяем, что последняя строка содержит нужный текст (без жёсткого совпадения)
            Assert.That(info[2], Does.Contain("Хрупкий товар"));
            Assert.That(info[2], Does.Contain("макс. в стопке: 5"));
        }
    }
}