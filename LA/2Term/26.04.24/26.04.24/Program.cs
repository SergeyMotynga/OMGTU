using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _26._04._24
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>() { "дом", "солнце", "мир", "книга", "стол", "река", "машина", "цветок", "дерево", "песок", "звезда", "луна", "озеро", "планета", "космос", "радуга" };
            var even = from e in list where e.Length % 2 == 0 select e;
            foreach (var e in even)
            {
                Console.Write($"{e}, ");
            }
            Console.WriteLine();
            Console.Write("Введите количество строк, которые необходимо добавить: ");
            int m = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < m; i++)
            {
                list.Add(Console.ReadLine());
            }
            for (int i = 0; i < list.Count; i += 2)
            {
                list[i] = "";
            }
            even = from e in list where e.Length % 2 == 0 && e != "" select e;
            foreach (var e in even)
            {
                Console.Write($"{e}, ");
            }
            Console.WriteLine();
        }
    }
}
