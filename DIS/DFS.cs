using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Поиск_в_глубину
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите количество вершин: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите данные о графе следующим образом через enter: <Вершина> <Вершины смежные с первой>, например: A B C. Когда закончите напишите 'конец'.");
            List<string>[] graph = new List<string>[n];
            for (int i = 0; i < graph.Length; i++)
            {
                graph[i] = new List<string>();
                string input = Console.ReadLine();
                if (input == "конец") break;
                else
                {
                    graph[i].Add(input);
                }
            }
            bool res = false;
            bool containsOfPoints = false;
            List<string> visited = new List<string>();
            Console.Write("Введите вершину с которой будет поиск в глубину: ");
            string start = Console.ReadLine();
            string[] current = new string[graph.Length];
            Stack<string> proccesing = new Stack<string>();
            for (int i = 0; i < graph.Length; i++)
            {
                int index = 0;
                for (int j = 0; j < graph.Length; j++)
                {
                    if (res == true) break;
                    foreach (var item in graph[j])
                    {
                        if (item[0].Equals(start)) index = j; res = true; break;
                    }
                }
                for(int j = 0; j < graph.Length; j++)
                {
                    current[j] = graph[index][j];
                }
                
                foreach (var item in graph[index])
                {
                    proccesing.Push(item);
                }
                if (index == 0 && proccesing.Count > 0) proccesing.Pop();
                if (index == 0 && proccesing.Count == 0) throw new InvalidOperationException("Ошибка: данная вершина не является смeжной с какой либо другой.");
                start = proccesing.Peek();
            }
        }
    }
}
