using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace set1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество разговоров через enter следующим образом, <номер> <длительность разговора в минутах, если хотите прекратить вводить, то напишите " + "'конец'.");
            HashSet<string> numbers = new HashSet<string>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "конец") break;
                string[] strings = input.Split(' ');
                numbers.Add(strings[0]);
            }
            Console.WriteLine($"Количество уникальных номеров: {numbers.Count}");
        }
    }
}

