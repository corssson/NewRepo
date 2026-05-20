using NUnit.Framework;
using CommodityLibrary;
using System.Collections.Generic;

namespace CommodityLibrary.UnitTests
{
    [TestFixture]
    public class CommodityComparableTests
    {
        [Test]
        public void CompareTo_SortsByArticleAlphabetically()
        {
            // Создаём два товара с разными артикулами
            // Артикул "B001" идёт позже, чем "A001" по алфавиту
            var commodityB = new Commodity("B001", "Товар Б", UnitOfMeasure.Pieces);
            var commodityA = new Commodity("A001", "Товар А", UnitOfMeasure.Pieces);

            // Помещаем их в список (сначала B, потом A)
            var list = new List<Commodity> { commodityB, commodityA };

            // Сортируем список
            // Автоматически вызывается наш метод CompareTo
            list.Sort();

            // Проверяем: после сортировки первым должен идти товар с артикулом "A001"
            Assert.That(list[0].Article, Is.EqualTo("A001"), "Первый товар должен быть с артикулом A001");
            Assert.That(list[1].Article, Is.EqualTo("B001"), "Второй товар должен быть с артикулом B001");
        }

        [Test]
        public void CompareTo_EqualArticles_ReturnsZero()
        {
            // Создаём два товара с одинаковым артикулом
            var commodity1 = new Commodity("X001", "Товар 1", UnitOfMeasure.Pieces);
            var commodity2 = new Commodity("X001", "Товар 2", UnitOfMeasure.Pieces);

            // Сравниваем их
            int result = commodity1.CompareTo(commodity2);

            // Результат должен быть 0 (товары равны по артикулу)
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void CompareTo_NullOther_ReturnsPositive()
        {
            // Создаём товар
            var commodity = new Commodity("A001", "Любой товар", UnitOfMeasure.Pieces);

            // Сравниваем с null
            int result = commodity.CompareTo(null);

            // Результат должен быть больше 0 (текущий товар больше null)
            Assert.That(result, Is.GreaterThan(0));
        }
    }
}