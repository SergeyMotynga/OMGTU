using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace RGR
{
    class Program
    {
        static int FordFulkerson(List<int> capacity, Stack<int> used, int stock, int source, int[,] _adj, int[,] _un, int[,] _fil)
        {
            int interimSource = source;
            int sum = 0;
            while (true)
            {
                List<int> S = new List<int>() { 0 };
                for (int i = 1; i < _un.GetLength(0); i++)
                {
                    if (used.Contains(i)) { S.Add(0); continue; }
                    S.Add(_un[interimSource, i]);
                }
                int max = S.Max();
                while (true)
                {
                    if (max == 0)
                    {
                        if (used.Count == 0) return sum;
                        S = new List<int>() { 0 };
                        for (int i = 1; i < _fil.GetLength(0); i++)
                        {
                            if (used.Contains(i)) { S.Add(0); continue; }
                            S.Add(_fil[i, interimSource]);
                        }
                        max = S.Max();
                        if (max == 0) return sum;
                        break;
                    }
                    else break;
                }
                capacity.Add(max);
                used.Push(interimSource);
                interimSource = S.IndexOf(max);
                if (interimSource == stock)
                {
                    used.Push(interimSource);
                    sum += capacity.Min();
                    while (used.Count != 1)
                    {
                        int a = used.Pop();
                        int b = used.Peek();
                        _fil[b, a] += capacity.Min();
                        _un[b, a] -= capacity.Min();
                    }
                    interimSource = source;
                    capacity = new List<int>();
                    used = new Stack<int>();
                }
            }
        }
        static void Main(string[] args)
        {
            Console.Write("Введите количество вершин: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите количество дуг: ");
            int m = Convert.ToInt32(Console.ReadLine());
            int[,] matrixOfThroughputPerUnit = new int[n + 1, n + 1];
            int[,] matrixOfFilling = new int[n + 1, n + 1];
            int[,] adjacencyMatrix = new int[n + 1, n + 1];
            Console.WriteLine("Введите информацию о дуге в формате: <вершина исхода> <вершина захода> " +
                "<пропускная способность дуги>");
            for (int i = 0; i < n + 2; i++)
            {
                matrixOfThroughputPerUnit[0, i] = i;
                matrixOfThroughputPerUnit[i, 0] = i;
                matrixOfFilling[0, i] = i;
                matrixOfFilling[i, 0] = i;
                adjacencyMatrix[0, i] = i;
                adjacencyMatrix[i, 0] = i;
            }
            for (int i = 0; i < m; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                if (input[0] == 'S')
                {
                    matrixOfThroughputPerUnit[0, int.Parse(input[1])] = int.Parse(input[2]);
                    continue;
                }
                if (input[1] == "T")
                {
                    matrixOfThroughputPerUnit[int.Parse(input[0]), n + 1] = int.Parse(input[2]);
                    continue;
                }
                matrixOfThroughputPerUnit[int.Parse(input[0]), int.Parse(input[1])] = int.Parse(input[2]);
                adjacencyMatrix[int.Parse(input[0]), int.Parse(input[1])] = 1;
            }
            int stock = n + 1;
            int source = 0;
            List<int> capacity = new List<int>();
            Stack<int> used = new Stack<int>();
            int sum = FordFulkerson(capacity, used, stock, source, adjacencyMatrix, matrixOfThroughputPerUnit, matrixOfFilling);
            Console.WriteLine($"Максимыльный поток равен: {sum}");
        }
    }
}


