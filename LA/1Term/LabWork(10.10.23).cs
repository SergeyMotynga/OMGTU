/*
Для n-вводимых элементов определить:
1)Все ли элементы кратный номеру под которым они стоят.
2)Положение первого чётного элемента в массиве.
3)Положение последнего нулевого массива.
4)Кол-во элементов, которые кратны минимальному элементу (минимальным эелементо не может быть нуль).
5)Образуют ли элементы между минимальным и максимальным элементами убывающую последовательность (минимум и максимум только один, 
    предусмотреть что кол-во элементов расположеное между мин и макс не равно нулю).*/



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWork_10._10._23_
{
    internal class Program
    {
        static void Main()
        {
            Console.Write("Введите количество элементов: ");
            int n = Convert.ToInt32(Console.ReadLine());
            //First(n);
            //Second(n);
            //Third(n);
            //Fourth(n);
            Fifth(n);
        }


        static void First(int n)
        {
            int counter = 0;
            int[] array = new int[n];
            for (int i = 1; i <= n; i++)
            {
                int input = Convert.ToInt32(Console.ReadLine());
                array[i - 1] = input;

                if (input % i != 0)
                {
                    counter++;
                }
            }
            if (counter != 0)
            {
                Console.WriteLine("Не все эелементы кратны.");
            }
            else
            {
                Console.WriteLine("Все элементы кратны.");
            }
        }


        static void Second(int n)
        {
            int[] array = new int[n];
            int position = 0;
            for (int i = 0; i < n; i++)
            {
                int input = Convert.ToInt32(Console.ReadLine());
                array[i] = input;
                if (position == 0)
                {
                    if (input % 2 == 0)
                    {
                        position = i + 1;
                    }
                }
            }
            Console.WriteLine("Позиция первого четного: " + position);
        }



        static void Third(int n)
        {
            int[] array = new int[n];
            int position = 0;
            for (int i = 0; i < n; i++)
            {
                int input = Convert.ToInt32(Console.ReadLine());
                array[i] = input;

                if (input == 0)
                {
                    position = i + 1;
                }

            }
            if (position == 0)
            {
                Console.WriteLine("Нулевых элементов нет.");
            }
            else
            {

                Console.WriteLine("Позиция последнего нулевого элемента: " + position);
            }
        }


        static void Fourth(int n)
        {
            int[] array = new int[n];
            int minEl = 0;
            int counter = 0;
            for (int i = 0; i < n; i++)
            {
                int input = Convert.ToInt32(Console.ReadLine());
                array[i] = input;
                if (i == 0)
                {
                    minEl = input;
                }
                if (input <= minEl)
                {
                    minEl = input;
                }
                if (input % minEl == 0)
                {
                    counter++;
                }
            }
            Console.WriteLine(counter);
        }


        static void Fifth(int n)
        {
            int[] array = new int[n];
            int minEl = 0;
            int maxEl = 0;
            int prevEl = 0;
            int prePrevEl = 0;
            bool order = true;

            for (int i = 0; i < n; i++)
            {
                int input = Convert.ToInt32((Console.ReadLine()));
                array[i] = input;

                if (i == 0)
                {
                    minEl = input;
                }
                if (i == 1 && input <= minEl)
                {
                    maxEl = minEl;
                    minEl = input;
                }
                if (i == 1 && input > minEl)
                {
                    maxEl = input;
                }
                if (i > 1 && input >= maxEl)
                {
                    maxEl = input;
                }
                if (i > 1 && input <= minEl)
                {
                    minEl = input;
                }
            }
            for (int i = 0; i < n; i++)
            {
                if (prevEl == 0)
                {
                    prevEl = array[i];
                    continue;
                }
                if (prevEl != 0 && prePrevEl == 0)
                {
                    prePrevEl = prevEl;
                    prevEl = array[i];
                    continue;
                }
                if ((prevEl == minEl && prePrevEl == maxEl) || (prevEl == maxEl && prePrevEl == minEl))
                {
                    order = false;
                    break;
                }
                if (prevEl >= prePrevEl)
                {
                    continue;
                }

                if (array[i] > minEl && array[i] < maxEl)
                {                 
                    if(prevEl >= prePrevEl)
                    {
                        order = false;
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            if (order == false)
            {
                Console.WriteLine("Последовательности нет.");
            }
            else
            {
                Console.WriteLine("Последовательность есть.");
            }
        }

    }
}

