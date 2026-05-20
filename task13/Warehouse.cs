using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CommodityLibrary
{
    public class Warehouse : IEnumerable<Commodity>
    {
        public string Name { get; set; }
        public int Count => goods.Count;

        private List<Commodity> goods;

        // Конструктор
        public Warehouse(string name, IEnumerable<Commodity> commodities)
        {
            Name = name;
            goods = new List<Commodity>();

            foreach (var item in commodities)
            {
                // Исключаем дубликаты (по артикулу)
                if (!goods.Any(g => g.Article == item.Article))
                {
                    goods.Add(item);
                }
            }
        }

        // Реализация IEnumerable<Commodity>
        public IEnumerator<Commodity> GetEnumerator()
        {
            return goods.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}