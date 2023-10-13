
// Дан массив из N элементов, необходимо определить:
// 1. количество четных элементов расположенных между макс и мин элем массива (мин и макс только один) выдать сообщение если нету между ними вообще.
// 2.Определить все ли элементы стоящие на четных местах с точки зрения пользователя имеют в своей записи хотя бы одну 5
// 3.Заменить все нечетные элементы массива на сумму их цифр. 
// 4.Определить количество элементов, значения которых больше среднеарифметического нечетных элементов массива
// 5.Определить имеется ли в массиве хотя бы один отрицательный элемент, оканчивающийся на тройку

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labWork_11._10._23_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите количество элементов: ");
            int n = Convert.ToInt32(Console.ReadLine());
            //    First(n);
            //    Second(n);
            //    Third(n);
            //    Fourth(n);
            //    Fifth(n);
        }


        static void First(int n)
        {
            int[] array = new int[n];
            int min = 0;
            int max = 0;
            int counter = 0;

            for (int i = 0; i < n; i++)
            {
                int input = Convert.ToInt32(Console.ReadLine());
                array[i] = input;

                if (i == 0)
                {
                    min = input;
                }
                if (i == 1 && input > min)
                {
                    max = input;
                }
                if (i == 1 && input <= min)
                {
                    max = min;
                    min = input;
                }
                if (i > 1 && input >= max)
                {
                    max = input;
                }
                if (i > 1 && input <= min)
                {
                    min = input;
                }

            }
            for (int i = 0; i < n; i++)
            {
                if (array[i] % 2 == 0 && array[i] < max && array[i] > min)
                {
                    counter++;
                }
            }
            Console.WriteLine(counter);
        }



        static void Second(int n)
        {
            int[] array = new int[n];
            bool num = true;
            for (int i = 1; i <= n; i++)
            {
                int input = Convert.ToInt32(Console.ReadLine());
                array[i - 1] = input;
                int rem1 = input / 5;
                if (i % 2 == 0 && rem1 % 10 == 0)
                {
                    num = true;
                    continue;
                }
                if (i % 2 == 0 && rem1 % 2 == 0)
                {
                    num = false;
                }
            }
            if (num == false)
            {
                Console.WriteLine("Не все.");
            }
            else if (n == 1)
            {
                Console.WriteLine("не то");
            }
            else
            {
                Console.WriteLine("Все.");
            }
        }


        static void Third(int n)
        {
            int[] array = new int[n];

            for (int i = 1; i <= n; i++)
            {
                int input = Convert.ToInt32(Console.ReadLine());
                array[i - 1] = input;

                if (input % 2 != 0)
                {
                    int num = (input / 10);
                    int rem1 = input % 10;
                    int rem2 = num % 10;
                    int sum = rem1 + rem2;
                    array[i - 1] = sum;
                    if (array[i - 1] < 0)
                    {
                        array[i-1] *= -1;
                    }
                }
                Console.WriteLine(array[i - 1]);
            }
        }


        static void Fourth(int n)
        {
            int[] array = new int[n];
            int counterNum = 0;
            int counter = 0;
            int sum = 0;
            int arith = 0;

            for (int i = 0; i < n; i++)
            {
                int input = Convert.ToInt32(Console.ReadLine());
                array[i] = input;

                if (input % 2 != 0)
                {
                    sum += input;
                    counterNum++;
                }
            }

            arith = sum / counterNum;

            for (int i = 0; i < n; i++)
            {
                if (array[i] > arith)
                {
                    counter++;
                }
            }
            Console.WriteLine(counter);
        }


        static void Fifth(int n)
        {
            int[] array = new int[n];
            bool negative = false;

            for (int i = 0; i < n; i++)
            {
                int input = Convert.ToInt32(Console.ReadLine());
                array[i] = input;

                if (input < 0 && input % 10 == -3)
                {
                    negative = true;
                }
            }
            if (negative == true)
            {
                Console.WriteLine("Да, есть.");
            }
            else
            {
                Console.WriteLine("Нет, нет.");
            }
        }
    }
}
