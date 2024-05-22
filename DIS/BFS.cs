using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bfs
{
    internal class Program
    {
        static List<int> bfs(int[,] mat, int start, List<int> result)
        {
            List<int> visited = new List<int>() { start };
            Stack<int> startPoints = new Stack<int>();
            Stack<int> proccesing = new Stack<int>();
            startPoints.Push(start);
            while (true)
            {
                while (true)
                {
                    if (startPoints.Count == 0 && proccesing.Count == 0) { return visited; }
                    start = startPoints.Pop();
                    List<int> S = new List<int>() { 0 };
                    for (int i = 1; i < mat.GetLength(0); i++)
                    {
                        S.Add(mat[start, i]);
                    }
                    for (int i = 1; i < S.Count; i++)
                    {
                        if (S[i] == 1 && !visited.Contains(i))
                        {
                            visited.Add(i);
                            proccesing.Push(i);
                        }
                    }
                    if (startPoints.Count == 0)
                    {
                        if (proccesing.Count == 0) break;
                        while (proccesing.Count != 0)
                        {
                            int n = proccesing.Pop();
                            startPoints.Push(n);
                        }
                        break;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            Console.Write("Введите количество вершин: ");
            int n = Convert.ToInt32(Console.ReadLine());
            int[,] matrix = new int[n + 1, n + 1];
            for (int i = 1; i < n + 1; i++)
            {
                matrix[0, i] = i;
                matrix[i, 0] = i;
            }
            Console.WriteLine("Введите список смежностых вершин в формате: <вершина> <смежные к ней вершины (через пробел)>" +
                "\nПример:\n1 2 3\n2 1");
            Console.WriteLine("Ваш ответ:");
            for (int i = 1; i < n + 1; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                for (int j = 1; j < input.Length; j++)
                {
                    matrix[Convert.ToInt32(input[0]), Convert.ToInt32(input[j])] = 1;
                }
            }
            Console.Write("Введите из какой вершины будет поиск в ширину: ");
            int start = Convert.ToInt32(Console.ReadLine());
            List<int> result = new List<int>();
            result = bfs(matrix, start, result);
            for (int i = 0; i < result.Count(); i++) { Console.Write($"{result[i]}, "); }
        }
    }
}
