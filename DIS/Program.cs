using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Dijkstra_sAlgorithm
{
    internal class Program
    {
        static int[] FindArray(int[] array)
        {
            int[] arr = new int[array.Length];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > 0) arr[i] = i;
            }
            return arr;
        }
        static int FindMinWeight(int[] array, List<int> arr)
        {
            int j = -1;
            int m = array.Max();
            bool res = true;
            for (int i = 1; i < array.Length; i++)
            {
                foreach (int k in arr)
                {
                    if (i == k) { res = false; break; }
                    else res = true;
                }
                if (res == true)
                {
                    if (array[i] < m) { m = array[i]; j = i; }
                }
            }
            return j;
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
            int[,] matrix = new int[n + 1, n + 1];
            for (int i = 1; i < n + 1; i++)
            {
                matrix[0, i] = i;
                matrix[i, 0] = i;
            }
            int prevK = 0;
            int a = 0;
            int num = 0;
            foreach (int k in ribs)
            {
                if (num % 2 == 0) { prevK = k; num++; continue; }
                for (int i = 1; i < m + 1; i++)
                {
                    if (prevK == matrix[0, i])
                    {
                        for (int j = 1; j < m + 1; j++)
                        {
                            if (k == matrix[j, 0])
                            {
                                matrix[j, i] = weight[a];
                                matrix[i, j] = weight[a];
                                a++;
                                num++;
                                break;
                            }
                        }
                        break;
                    }
                }
            }
            int[] array = new int[0];
            Console.Write("Введите вершину, от хотите узнать расстояние до остальных: ");
            int number = Convert.ToInt32(Console.ReadLine());
            int[] T = new int[n + 1];
            int inf = int.MaxValue;
            for (int i = 1; i <= n; i++) { T[i] = inf; }
            int minWeight = 0;
            List<int> points = new List<int>();
            points.Add(number);
            T[number] = minWeight;
            int[] S = new int[n + 1];
            bool res = true;
            while (number != -1)
            {
                for (int i = 1; i <= n; ++i)
                {
                    S[i] = matrix[number, i];
                }
                array = FindArray(S);
                for (int i = 1; i <= n; ++i)
                {
                    foreach (int k in points)
                    {
                        if ((i) == k) { res = false; break; }
                        else res = true;
                    }
                    if (res == true)
                    {
                        int w = 0;
                        if (S[i] != 0)
                        {
                            w = T[number] + S[i];
                            if (w < T[i] && w != 0) T[i] = w;
                        }
                    }
                }
                number = FindMinWeight(T, points);
                if (number > 0) points.Add(number);
            }
            Console.Write("Ответ: ");
            for (int i = 1; i <= n; i++)
            {
                Console.Write(T[i] + ", ");
            }
        }
    }
}
