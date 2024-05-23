using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Floyd_sAlgorithm
{
    internal class Program
    {
        private static int[,] Numbering(int[,] array)
        {
            for (int i = 1; i < array.GetLength(0); i++)
            {
                array[0, i] = i;
                array[i, 0] = i;
            }
            return array;
        }
        private static int[,] Inf(int[,] array)
        {
            for (int i = 1; i < array.GetLength(0); i++)
            {
                for (int j = 1; j < array.GetLength(0); j++)
                {
                    if (j == i) continue;
                    array[i, j] = int.MaxValue;
                }
            }
            return array;
        }
        static void Main(string[] args)
        {
            Console.Write("Введите количество вершин: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите количество рёбер: ");
            int m = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите информацию о ребре (вершина (пробел) вершина (пробел) вес ребра): ");
            int[] ribs = new int[2 * m];
            int[] weight = new int[m];
            int p = 1;
            for (int i = 1; i < 2 * m; i += 2)
            {
                Console.Write($"Ребро №{p}: ");
                var digitsRow = Console.ReadLine();
                var digits = digitsRow.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                ribs[i - 1] = Convert.ToInt32(digits[0]);
                ribs[i] = Convert.ToInt32(digits[1]);
                weight[p - 1] = Convert.ToInt32(digits[2]);
                p++;
            }
            int[,] dist = new int[n + 1, n + 1];
            dist = Numbering(dist);
            dist = Inf(dist);
            int prevK = 0;
            int a = 0;
            int num = 0;
            foreach (int k in ribs)
            {
                if (num % 2 == 0) { prevK = k; num++; continue; }
                for (int i = 1; i < n + 1; i++)
                {
                    if (prevK == dist[0, i])
                    {
                        for (int j = 1; j < n + 1; j++)
                        {
                            if (k == dist[j, 0])
                            {
                                dist[i, j] = weight[a];
                                a++;
                                num++;
                                break;
                            }
                        }
                        break;
                    }
                }
            }
            for (int k = 1; k < n + 1; k++)
            {
                for (int i = 1; i < n + 1; i++)
                {
                    for (int j = 1; j < n + 1; j++)
                    {
                        if (j == i) dist[i,j] = 0;
                        if (dist[i, k] == int.MaxValue || dist[k, j] == int.MaxValue) continue;
                        dist[i, j] = Math.Min(dist[i, j], dist[i, k] + dist[k, j]);
                    }
                }
            }
            Console.WriteLine("Ответ: ");
            for (int i = 0; i < dist.GetLength(0); i++)
            {
                for (int j = 0; j < dist.GetLength(1); j++)
                {
                    if (dist[i,j] == int.MaxValue) {Console.Write("inf" + "\t"); continue;}
                    Console.Write(dist[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}
