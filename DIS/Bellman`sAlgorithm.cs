using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bellman_sAlgorithm
{
    internal class Program
    {
        static bool checkingOfNegativeCycle(int[] ar1, int[] ar2)
        {
            bool result = true;
            for (int i = 0; i < ar1.Length; i++)
            {
                if (ar1[i] < ar2[i]) { result = false; break; }
            }
            return result;
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
                for (int i = 1; i < n + 1; i++)
                {
                    if (prevK == matrix[0, i])
                    {
                        for (int j = 1; j < n + 1; j++)
                        {
                            if (k == matrix[j, 0])
                            {
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
            Console.Write("Введите от какой вершины вы хотите найти расстояние до других вершин: ");
            int number = Convert.ToInt32(Console.ReadLine());
            int[] result = new int[n + 1];
            int inf = int.MaxValue;
            for (int i = 0; i <= n; i++) { result[i] = inf; }
            result[number] = 0;
            bool res = true;
            int[] S = new int[n + 1];
            for (int i = 1; i <= n; i++)
            {
                int[] check = new int[n + 1];
                for (int j = 1; j <= n; j++)
                {
                    if (result[j] == inf) continue;
                    else
                    {
                        for (int k = 1; k <= n; k++)
                        {
                            S[k] = matrix[j, k];
                        }
                        for (int k = 1; k <= n; k++)
                        {
                            if (S[k] == 0) continue;
                            result[k] = Math.Min(result[k], (result[j] + S[k]));
                        }
                    }
                    if (i == (n - 1))
                    {
                        for (int k = 1; k <= n; ++k)
                        {
                            check[k] = result[k];
                        }
                    }
                    if (i == n) res = checkingOfNegativeCycle(result, check);
                }
            }
            if (res == false)
            {
                Console.Write("Ответ: ");
                for (int i = 1; i <= n; i++)
                {
                    Console.Write(result[i] + ", ");
                }
            }
            else Console.WriteLine("В графе присутствует контур отрицательной длины!!! Выполнение алгоритма невозможно!!!");
        }
    }
}
