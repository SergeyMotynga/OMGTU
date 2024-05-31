using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace AlgorithmFordFulkerson
{
    internal class Program
    {
        static int FordFulkerson(List<int> capacity, Stack<int> used, int stock, int source, int[,] _adj, int[,] _un, int[,] _fil)
        {
            int interimSource = source;
            int sum = 0;
            Stack<int> usedN = new Stack<int>();
            while (true)
            {
                bool next = false;
                List<int> S = new List<int>() { 0 };
                for (int i = 1; i < _un.GetLength(0); i++)
                {
                    if (used.Contains(i) || usedN.Contains(i)) { S.Add(0); continue; }
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
                            if (used.Contains(i) || usedN.Contains(i)) { S.Add(0); continue; }
                            S.Add(_fil[i, interimSource]);
                        }
                        max = S.Max();
                        if (max == 0)
                        {
                            int a = used.Pop();
                            usedN.Push(interimSource);
                            interimSource = a;
                            capacity.RemoveAt(capacity.Count - 1);
                            next = true;
                        }
                        break;
                    }
                    else break;
                }
                if (next == true) continue;
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
            bool Return;
            do
            {
                Return = true;
                Console.Write($"1.Решение задачи\n2.Об авторе\n" +
                    $"3.Помощь\n4.О программе\n5.Выход\nВыберете пункт: ");
                int choose = Convert.ToInt32(Console.ReadLine());
                if (choose != 1 && choose != 2 && choose != 3 && choose != 4 && choose != 5)
                {
                    Console.Write("Ошибка: такой пункт отсутствует" +
                        "\nЧтобы попробовать заного 0, чтобы выйти из программы введите 1\nВаш ответ: ");
                    choose = Convert.ToInt32(Console.ReadLine());
                    if (choose == 1) { Return = false; }
                    Console.Clear();
                }
                switch (choose)
                {
                    case 1:
                        bool Return1;
                        do
                        {
                            Console.Clear();
                            Return1 = false;
                            string input = @"C:\Users\motyn\OneDrive\Рабочий стол\project\123\123\bin\Debug\input.txt";
                            string[] lines = File.ReadAllLines(input);
                            int m = 0;
                            int n = Convert.ToInt32(lines[0]);
                            if (n < 1 || n > 100) throw new ArgumentException("Ошибка: количество промежуточных пунктов должно находится в диапазоне от 1 до 100 включительно.");
                            int[,] matrixOfThroughputPerUnit = new int[n + 3, n + 3];
                            int[,] matrixOfFilling = new int[n + 3, n + 3];
                            int[,] adjacencyMatrix = new int[n + 3, n + 3];
                            for (int i = 0; i < n + 2; i++)
                            {
                                matrixOfThroughputPerUnit[0, i + 1] = i + 1;
                                matrixOfThroughputPerUnit[i + 1, 0] = i + 1;
                                matrixOfFilling[0, i + 1] = i + 1;
                                matrixOfFilling[i + 1, 0] = i + 1;
                                adjacencyMatrix[0, i + 1] = i + 1;
                                adjacencyMatrix[i + 1, 0] = i + 1;
                            }
                            int k = 0;
                            foreach (string line in lines)
                            {
                                string[] lineInput = line.Split(' ');
                                if (k == 0) { k++; continue; }
                                if (lineInput[0].Equals("A"))
                                {
                                    matrixOfThroughputPerUnit[1, Convert.ToInt32(lineInput[1]) + 1] = Convert.ToInt32(lineInput[2]);
                                    continue;
                                }
                                if (lineInput[1].Equals("B"))
                                {
                                    matrixOfThroughputPerUnit[Convert.ToInt32(lineInput[0]) + 1, n + 2] = Convert.ToInt32(lineInput[2]);
                                    continue;
                                }
                                if (lineInput[0].Equals("A") && lineInput[1].Equals("B"))
                                {
                                    matrixOfThroughputPerUnit[1, n + 2] = Convert.ToInt32(lineInput[2]);
                                    continue;
                                }
                                matrixOfThroughputPerUnit[Convert.ToInt32(lineInput[0]) + 1, Convert.ToInt32(lineInput[1]) + 1] = Convert.ToInt32(lineInput[2]);
                                adjacencyMatrix[Convert.ToInt32(lineInput[0]) + 1, Convert.ToInt32(lineInput[1]) + 1] = 1;
                            }
                            int stock = n + 2;
                            int source = 1;
                            List<int> capacity = new List<int>();
                            Stack<int> used = new Stack<int>();
                            int sum = FordFulkerson(capacity, used, stock, source, adjacencyMatrix, matrixOfThroughputPerUnit, matrixOfFilling);
                            Console.Write($"Суммарная величина объёма прокаченной нефти: {sum}" +
                                $"\nЧтобы вернуться введите 0, чтобы выйти из программы введите 1\nВаш ответ: ");
                            choose = Convert.ToInt32(Console.ReadLine());
                            if (choose == 0) break;
                        }
                        while (Return1 == true);
                        if (choose == 1) Return = false;
                        Console.Clear();
                        break;
                    case 2:
                        Console.Clear();
                        Console.Write("Автор данной програмы: Мотынга Сергей Андреевич, студент ОмГТУ, ФИТ-231" +
                            "\nЧтобы вернуться введите 0, чтобы выйти из программы введите 1\nВаш ответ: ");
                        choose = Convert.ToInt32(Console.ReadLine());
                        if (choose == 1) Return = false;
                        Console.Clear();
                        break;
                    case 3:
                        Console.Clear();
                        Console.Write("На данный момент здесь пусто" +
                            "\nЧтобы вернуться введите 0, чтобы выйти из программы введите 1\nВаш ответ: ");
                        choose = Convert.ToInt32(Console.ReadLine());
                        if (choose == 1) Return = false;
                        Console.Clear();
                        break;
                    case 4:
                        Console.Clear();
                        Console.Write("Данная программа находит суммарный объём прокаченной нефти при помощи алгоритма Форда-Фалкерсона" +
                            "\nЧтобы вернуться введите 0, чтобы выйти из программы введите 1\nВаш ответ: ");
                        choose = Convert.ToInt32(Console.ReadLine());
                        if (choose == 1) Return = false;
                        Console.Clear();
                        break;
                    case 5:
                        Return = false;
                        break;
                }
            }
            while (Return == true);
        }
    }
}


