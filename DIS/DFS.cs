using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dfs
{
    internal class Program
    {
        static List<int> dfs(int[,] mat, int start)
        {
            List<int> visited = new List<int>();
            Stack<int> stack = new Stack<int>();
            visited.Add(start);
            stack.Push(start);
            while (visited.Count != mat.GetLength(0) - 1)
            {
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
                        stack.Push(i);
                        start = i;
                        break;
                    }
                    else if (i == S.Count - 1)
                    {
                        stack.Pop();
                        start = stack.Peek();
                    }
                }
            }
            return visited;
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
                if (matrix[i, 0] == Convert.ToInt32(input[0]))
                {
                    for (int j = 1; j < input.Length; j++)
                    {
                        matrix[i, Convert.ToInt32(input[j])] = 1;
                    }
                }
            }
            Console.Write("Введите из какой вершины будет поиск в глубину: ");
            int start = Convert.ToInt32(Console.ReadLine());
            List<int> result = dfs(matrix, start);
            for (int i = 0; i < result.Count; i++) { Console.Write($"{result[i]}, "); }
        }
    }
}
