using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace whiteGrayMice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите общее количество белых мышей: ");
            int whiteMiceInput = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите общее количество серых мышей: ");
            int grayMiceInput = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите оставшееся количество белых мышей: ");
            int whiteMiceOutput = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите оставшееся количество серых мышей: ");
            int grayMiceOutput = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите шаг: ");
            int k = Convert.ToInt32(Console.ReadLine());
            int position = 0;
            int[] countPosition = new int[0];
            bool res = true;
            int[] mice = new int[whiteMiceInput + grayMiceInput];
            int count = mice.Length;
            string[] countMice = new string[mice.Length];
            int defGrayMice = Math.Abs(grayMiceInput - grayMiceOutput);
            int defWhiteMice = Math.Abs(whiteMiceInput - whiteMiceOutput);

            for (int i = 0; i < int.MaxValue; i++)
            {
                if (grayMiceInput + whiteMiceInput < grayMiceOutput + whiteMiceOutput)
                {
                    res = false;
                    break;
                }

                if (mice[0] == 1 && grayMiceOutput == 1)
                {
                    res = false;
                    break;
                }

                if (count == grayMiceOutput + whiteMiceOutput)
                {
                    Console.WriteLine();
                    for (int j = 0; j < mice.Length; j++)
                    {
                        if (mice[j] == 0) countPosition[j] = 1;
                    }
                    for (int l = 0; l < countPosition.Length; l++)
                    {
                        
                        if (grayMiceOutput > 0 && countPosition[l] == 1)
                        {
                            countMice[l] = "grayMouse";
                            grayMiceOutput--;
                            continue;
                        }

                        
                        if (whiteMiceOutput > 0 && countPosition[l] == 1)
                        {
                            countMice[l] = "whiteMouse";
                            whiteMiceOutput--;
                            continue;
                        }

                        
                        if (defGrayMice > 0)
                        {
                            if (mice[l] == 1) countMice[l] = "grayMouse";
                            defGrayMice -= 1;
                            continue;
                        }

                        
                        if (defWhiteMice > 0)
                        {
                            if (mice[l] == 1) countMice[l] = "whiteMouse";
                            defWhiteMice -= 1;
                            continue;
                        }
                    }
                    break;
                }

                countPosition = new int[mice.Length];


                if (i == 0)
                {
                    position = mice[i] + k;
                    continue;
                }

                if (position > mice.Length)
                {
                    int def = position - mice.Length;
                    position = mice[0] + def;
                }

                if (position == mice.Length)
                {
                    position = 0;
                }

                while (mice[position] == 1)
                {
                    position++;
                    if (position == mice.Length)
                    {
                        position = 0;
                    }
                }
                mice[position] = 1;
                position = position + k;
                count -= 1;
            }
            if (res == false)
            {
                Console.WriteLine("Такое невозможно.");
            }
            else Console.WriteLine(String.Join(", ", countMice));
        }
    }
}
