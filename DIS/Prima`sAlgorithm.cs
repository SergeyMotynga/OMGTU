using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Prima_sAlgorithm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите количество вершин: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите количество рёбер: ");
            int m = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите информацию о ребре (вершина (пробел) вершина (пробел) вес ребра): ");
            int[,] matrix = new int[n + 1, n + 1];
            for (int i = 1; i < n + 1; i++)
            {
                matrix[0, i] = i;
                matrix[i, 0] = i;
            }
            for (int i = 0; i < m; i++)
            {
                Console.Write($"Ребро №{i + 1}: ");
                string[] input = Console.ReadLine().Split(' ');
                matrix[int.Parse(input[0]), int.Parse(input[1])] = int.Parse(input[2]);
                matrix[int.Parse(input[1]), int.Parse(input[0])] = int.Parse(input[2]);
            }
            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                for (int j = 1; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 0) matrix[i, j] = int.MaxValue;
                }
            }
            List<int> used = new List<int>();
            int current = 0;
            Random rand = new Random();
            int start = rand.Next(1,n);
            List<List<int>> S = new List<List<int>>();
            int min = 0;
            int result = 0;
            int prevMin = int.MaxValue;
            S.Add(new List<int>() { 0 });
            used.Add(start);
            for (int i = 1; i < n + 1; i++)
            {
                if (used.Count == n) break;
                S.Add(new List<int>());
                S[i] = new List<int>() { int.MaxValue};
                for (int j = 1; j < n + 1; j++)
                {
                    S[i].Add(matrix[start, j]);
                }
                for (int j = 1; j < i + 1; j++)
                {
                    min = S[j].Min();
                    if (used.Contains(S[j].IndexOf(min)))
                    {
                        S[j][S[j].IndexOf(min)] = int.MaxValue;
                        j--;
                        continue;
                    }
                    if (min < prevMin)
                    {
                        current = j;
                        prevMin = min;
                    }
                }
                int index = S[current].IndexOf(prevMin);
                S[current][index] = int.MaxValue;
                if (!used.Contains(index)) { used.Add(index); start = index; }
                result += prevMin;
                min = 0;
                prevMin = int.MaxValue;
            }
            Console.WriteLine($"Ответ: {result}");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == int.MaxValue) { Console.Write("\u221E\t"); continue; }
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}
