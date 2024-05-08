
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace set2
{
    internal class Program
    {
        static void ShowSet(HashSet<string> set)
        {
            foreach (var item in set)
            {
                Console.Write($"{item} ");
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите множества в следующем виде: A B C D.");
            HashSet<string> first = new HashSet<string>();
            HashSet<string> second = new HashSet<string>();
            HashSet<string> third = new HashSet<string>();
            Console.Write("Введите первое множество: ");
            string input = Console.ReadLine();
            foreach (string item in input.Split(' ')) { first.Add(item); }
            Console.Write("Введите второе множество: ");
            input = Console.ReadLine();
            foreach (string item in input.Split(' ')) { second.Add(item); }
            Console.Write("Введите третье множество: ");
            input = Console.ReadLine();
            foreach (string item in input.Split(' ')) { third.Add(item); }
            HashSet<string> Union = new HashSet<string>();
            Union.UnionWith(first);
            Union.UnionWith(second);
            Union.UnionWith(third);
            Console.Write("Объединение: ");
            ShowSet(Union);
            HashSet<string> Intersection = new HashSet<string>();
            foreach(string item in first) { Intersection.Add(item); }
            Intersection.IntersectWith(second);
            Intersection.IntersectWith(third);
            Console.WriteLine();
            Console.Write("Пересечение: ");
            ShowSet(Intersection);
            Console.WriteLine();
            Console.WriteLine($"Дополнение первого множества: {String.Join(" ", Union.Except(first))}");
            Console.WriteLine($"Дополнение второго множества: {String.Join(" ", Union.Except(second))}");
            Console.WriteLine($"Дополнение третьего множества: {String.Join(" ", Union.Except(third))}");

        }
    }
}
