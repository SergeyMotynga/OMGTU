using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Не_съем_так_надкушу
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamReader input = File.OpenText("input.txt");
            string[] values = input.ReadLine().Split(' ');
            int n = int.Parse(values[0]);
            int m = int.Parse(values[1]);
            int[,] matrix = new int[n + 1, n + 1];
            for (int i = 0; i < n + 1; i++)
            {
                for (int j = 0; j < n + 1; j++)
                {
                    matrix[i, j] = int.MaxValue;
                }
            }
            int first = 0;
            int second = 0;
            for (int k = 1; k <= n; k++)
            {
                values = input.ReadLine().Split(' ');
                first = int.Parse(values[0]);
                second = int.Parse(values[1]);
                for (int i = 0; i < n + 1; i++)
                {
                    for (int j = 0; j < n + 1; j++)
                    {
                        matrix[first, k] = matrix[k, first] = second;
                    }
                }
            }
            Dictionary<int, int> apples = new Dictionary<int, int>();
            for (int i = 0; i < m; i++)
            {
                values = input.ReadLine().Split(' ');
                apples.Add(int.Parse(values[0]), int.Parse(values[1]));
            }
            values = input.ReadLine().Split(' ');
            int wormPosition = int.Parse(values[0]);
            if (apples.ContainsKey(wormPosition))
                apples.Remove(wormPosition);
            int freshApple = int.Parse(values[1]);
            int way = 0;
            while (apples.Count != 0)
            {
                int min = 1000000;
                int[] weight = new int[n + 1];
                for (int i = 0; i < n + 1; i++)
                    weight[i] = 1000000;
                bool[] visited = new bool[n + 1];
                for (int i = 0; i < n + 1; i++)
                {
                    visited[i] = false;
                }
                visited[wormPosition] = true;
                int k = 0;
                int w = 0;
                for (int i = 0; i < n + 1; i++)
                {
                    if (apples.ContainsKey(i) && apples[i] < freshApple)
                    {
                        apples.Remove(i);
                        continue;
                    }
                    for (int j = 0; j < n + 1; j++)
                    {
                        if (visited[j] == false)
                        {
                            if (apples.ContainsKey(j) && apples[j] < freshApple)
                            {
                                apples.Remove(j);
                                continue;
                            }
                            else
                            {
                                if (matrix[wormPosition, j] + w < weight[j])
                                    weight[j] = matrix[wormPosition, j] + w;
                                if (weight[j] < min)
                                {
                                    min = weight[j];
                                    k = j;
                                }
                            }
                        }
                    }
                    wormPosition = k;
                    visited[wormPosition] = true;
                    w = min;
                    min = int.MaxValue;
                }
                for (int i = 0; i < n + 1; i++)
                {
                    if (apples.ContainsKey(i) && apples[i] >= freshApple && weight[i] < min)
                    {
                        min = weight[i];
                        wormPosition = i;
                    }
                }
                apples.Remove(wormPosition);
                way += min;
            }
            if (way == int.MaxValue) Console.WriteLine(0);
            else Console.WriteLine(way);
        }
    }
}
