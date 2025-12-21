using System;
using System.Collections.Generic;
using System.Text;

namespace task6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите текст на русском:");
            string input = Console.ReadLine();

            string output = Transliterate(input);
            Console.WriteLine("Транслитерация:");
            Console.WriteLine(output);
        }

        static string Transliterate(string text)
        {
            var map = new Dictionary<char, string>
            {
                ['А'] = "A",
                ['а'] = "a",
                ['Б'] = "B",
                ['б'] = "b",
                ['В'] = "V",
                ['в'] = "v",
                ['Г'] = "G",
                ['г'] = "g",
                ['Д'] = "D",
                ['д'] = "d",
                ['Е'] = "E",
                ['е'] = "e",
                ['Ё'] = "E",
                ['ё'] = "e",
                ['Ж'] = "ZH",
                ['ж'] = "zh",
                ['З'] = "Z",
                ['з'] = "z",
                ['И'] = "I",
                ['и'] = "i",
                ['Й'] = "Y",
                ['й'] = "y",
                ['К'] = "K",
                ['к'] = "k",
                ['Л'] = "L",
                ['л'] = "l",
                ['М'] = "M",
                ['м'] = "m",
                ['Н'] = "N",
                ['н'] = "n",
                ['О'] = "O",
                ['о'] = "o",
                ['П'] = "P",
                ['п'] = "p",
                ['Р'] = "R",
                ['р'] = "r",
                ['С'] = "S",
                ['с'] = "s",
                ['Т'] = "T",
                ['т'] = "t",
                ['У'] = "U",
                ['у'] = "u",
                ['Ф'] = "F",
                ['ф'] = "f",
                ['Х'] = "KH",
                ['х'] = "kh",
                ['Ц'] = "TS",
                ['ц'] = "ts",
                ['Ч'] = "CH",
                ['ч'] = "ch",
                ['Ш'] = "SH",
                ['ш'] = "sh",
                ['Щ'] = "SHCH",
                ['щ'] = "shch",
                ['Ы'] = "Y",
                ['ы'] = "y",
                ['Э'] = "E",
                ['э'] = "e",
                ['Ю'] = "IU",
                ['ю'] = "iu",
                ['Я'] = "IA",
                ['я'] = "ia",
                ['Ъ'] = "IE",
                ['ъ'] = "ie",
            };

            var sb = new StringBuilder();

            foreach (char ch in text)
            {
                if (ch == 'Ь' || ch == 'ь')
                    continue;                   
                if (map.TryGetValue(ch, out string val))
                    sb.Append(val);            
                else
                    sb.Append(ch);             
            }
            return sb.ToString();
        }
    }
}
