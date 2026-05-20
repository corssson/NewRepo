using CommodityLibrary;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace CommodityLibrary.UnitTests
{
    [TestFixture]
    public class OversizedCommodityTests
    {
        private OversizedCommodity GetTestOversized()
        {
            return new OversizedCommodity(
                "ART0034", "Холодильник", UnitOfMeasure.Pieces,
                20000m, 35000m, "Двухкамерный", 5,
                1.8, 0.7, 0.85);
        }

        [Test]
        public void Constructor_ShouldSetDimensions()
        {
            var oversized = GetTestOversized();
            Assert.That(oversized.Length, Is.EqualTo(1.8));
            Assert.That(oversized.Width, Is.EqualTo(0.7));
            Assert.That(oversized.Height, Is.EqualTo(0.85));
        }

        [Test]
        public void GetInfo_ShouldIncludeDimensions()
        {
            var oversized = GetTestOversized();
            var info = oversized.GetInfo();

            Assert.That(info.Length, Is.EqualTo(3));

            // Проверяем наличие текста (без учёта формата чисел)
            Assert.That(info[2], Does.Contain("Габариты"));

            // Проверяем хотя бы одно число (не важно, с точкой или запятой)
            Assert.That(info[2], Does.Match("1[.,]8"));  // проверит и "1.8" и "1,8"
            Assert.That(info[2], Does.Match("0[.,]7"));
            Assert.That(info[2], Does.Match("0[.,]85"));
        }
    }
}