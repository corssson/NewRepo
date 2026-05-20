using NUnit.Framework;
using CommodityLibrary;

namespace CommodityLibrary.UnitTests
{
    [TestFixture]
    public class PerishableCommodityTests
    {
        private PerishableCommodity GetTestPerishable()
        {
            return new PerishableCommodity(
                "ART002", "Молоко", UnitOfMeasure.Pieces,
                40m, 65m, "Пастеризованное", 200, 7);
        }

        [Test]
        public void Constructor_ShouldSetMaxStorageDays()
        {
            var perish = GetTestPerishable();
            Assert.That(perish.MaxStorageDays, Is.EqualTo(7));
        }

        [Test]
        public void GetInfo_ShouldIncludeStorageDays()
        {
            var perish = GetTestPerishable();
            var info = perish.GetInfo();

            Assert.That(info.Length, Is.EqualTo(3));
            Assert.That(info[2], Does.Contain("Скоропортящийся товар"));
            Assert.That(info[2], Does.Contain("срок хранения: 7 дн."));
        }
    }
}