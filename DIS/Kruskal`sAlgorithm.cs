using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Kruskal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите количество вершин: ");
            int m = Convert.ToInt32(Console.ReadLine());
            int[] points = new int[m];
            for (int i = 0; i < m; i++)
            {
                points[i] = (i + 1);
            }
            Console.Write("Введите количество рёбер: ");
            int n = Convert.ToInt32(Console.ReadLine());
            int[,] ribsInput = new int[n, 2];
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Введите ребро №{i + 1}: ");
                string Input = Console.ReadLine();
                var digit = Input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                ribsInput[i, 0] = Convert.ToInt32(digit[0]);
                ribsInput[i, 1] = Convert.ToInt32(digit[1]);
            }
            int[] weightInput = new int[n];
            Console.Write("Введите вес рёбер в соответствии с воему ребру: ");
            var weightOfRib = Console.ReadLine();
            var Convert1 = weightOfRib.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < n; i++)
            {
                weightInput[i] = Convert.ToInt32(Convert1[i]);
            }
            int[,] ribs = new int[n, 2];
            int[] weight = new int[n];
            for (int i = 0; i < n; i++)
            {
                weight[i] = weightInput[i];
            }
            Array.Sort(weight);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (weight[i] == weightInput[j])
                    {
                        ribs[i, 0] = ribsInput[j, 0];
                        ribs[i, 1] = ribsInput[j, 1];
                        weightInput[j] = 0;
                        break;
                    }
                }
            }
            int[][] result = new int[n][];
            int resultWeight = 0;
            for (int i = 0; i < n; i++)
            {
                int countQ = 0;
                int count = 0;
                int p = 0;
                int q = 0;
                int[] w = new int[2 * n];
                int[] a = new int[2 * n];
                int[] b = new int[2];
                result[i] = new int[2 * n];
                var distinctArray = result[0].Distinct().ToArray();
                Array.Sort(distinctArray);
                distinctArray = distinctArray.Where(z => z != 0).ToArray();
                if (distinctArray.Equals(points)) break;
                if (i == 0)
                {
                    result[i][i] = ribs[i, 0];
                    result[i][i + 1] = ribs[i, 1];
                    resultWeight += weight[i];
                    continue;
                }
                for (int j = 0; j < i; j++)
                {
                    if (count != 0) break;
                    int prevK = 1;
                    foreach (int k in result[j])
                    {
                        if (prevK == 0 && k == 0) break;
                        if (ribs[i, 0] == k || ribs[i, 1] == k)
                        {
                            count++;
                            p = j;
                        }
                        prevK = k;
                    }
                }
                if (count == 2) continue;
                if (count == 1)
                {
                    if (p < (i - 1))
                    {
                        for (int o = p + 1; o < i; o++)
                        {
                            int prevK = 1;
                            foreach (int k in result[o])
                            {
                                if (countQ != 0) break;
                                if (prevK == 0 && k == 0) break;
                                if (ribs[i, 0] == k || ribs[i, 1] == k)
                                {
                                    countQ++;
                                    q = o;
                                }
                                prevK = k;
                            }
                        }
                    }
                    if (countQ == 1)
                    {
                        int j = 0;
                        foreach (int k in result[p])
                        {
                            if (k == 0) break;
                            a[j] = k;
                            j++;
                        }
                        j = 0;
                        foreach (int k in result[q])
                        {
                            if (k == 0) break;
                            w[j] = k;
                            j++;
                        }
                        b[0] = ribs[i, 0];
                        b[1] = ribs[i, 1];
                        int[] v = a.Union(b).ToArray();
                        int[] c = v.Union(w).ToArray();
                        c = c.Where(z => z != 0).ToArray();
                        j = 0;
                        int z = 0;
                        foreach (int k in c)
                        {
                            result[p][z] = k;
                            z++;
                        }
                        resultWeight += weight[i];
                    }
                    else
                    {
                        int j = 0;
                        foreach (int k in result[p])
                        {
                            if (k == 0) break;
                            a[j] = k;
                            j++;
                        }
                        b[0] = ribs[i, 0];
                        b[1] = ribs[i, 1];
                        int[] c = a.Union(b).ToArray();
                        c = c.Where(z => z != 0).ToArray();
                        j = 0;
                        int z = 0;
                        foreach (int k in c)
                        {
                            result[p][z] = k;
                            z++;
                        }
                        resultWeight += weight[i];
                    }
                }
                if (count == 0)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (result[j][0] == 0)
                        {
                            result[j][0] = ribs[i, 0];
                            result[j][1] = ribs[i, 1];
                            resultWeight += weight[i];
                            break;
                        }
                    }
                }
            }
            Console.WriteLine(resultWeight);
        }
    }
}

