using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Обобщение
{
    class Calculeted<T>
    {
        public T Plus(T a, T b)
        {
            dynamic p = a;
            dynamic o = b;
            return p + o;
        }
        public T Minus(T a, T b)
        {
            dynamic p = a;
            dynamic o = b;
            return p - o;
        }
        public T Multiplication(T a, T b)
        {
            dynamic p = a;
            dynamic o = b;
            return p * o;
        }
        public T Division(T a, T b)
        {
            dynamic p = a;
            dynamic o = b;
            return p / o;
        }
    }
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.Write("Выберите с какими числами работаем.\n1) Целые числа.\n2) Вещественные числа.\nВаш ответ: ");
            int input = Convert.ToInt32(Console.ReadLine());
            switch (input)
            {
                case 1:
                    Console.Write("Введите первое число: ");
                    int a = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Введите второе число: ");
                    int b = Convert.ToInt32(Console.ReadLine());
                    Calculeted<int> c = new Calculeted<int>();
                    Console.Write("Выберите операцию.\n1)Сложение.\n2)Вычитание\n3)Умножение\n4)Деление\nВаш ответ: ");
                    int n = Convert.ToInt32(Console.ReadLine());
                    switch (n)
                    {
                        case 1:
                            Console.WriteLine(c.Plus(a, b));
                            break;
                        case 2:
                            Console.WriteLine(c.Minus(a, b));
                            break;
                        case 3:
                            Console.WriteLine(c.Multiplication(a, b));
                            break;
                        case 4:
                            if (b == 0) { Console.WriteLine("Ошибка: деление на 0 невозможно!"); break; }
                            Console.WriteLine(c.Division(a, b));
                            break;
                    }
                    break;
                case 2:
                    Console.Write("Введите первое число: ");
                    double q = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Введите второе число: ");
                    double w = Convert.ToDouble(Console.ReadLine());
                    Calculeted<double> e = new Calculeted<double>();
                    Console.Write("Выберите операцию.\n1)Сложение.\n2)Вычитание\n3)Умножение\n4)Деление\nВаш ответ: ");
                    int m = Convert.ToInt32(Console.ReadLine());
                    switch (m)
                    {
                        case 1:
                            Console.WriteLine(e.Plus(q, w));
                            break;
                        case 2:
                            Console.WriteLine(e.Minus(q, w));
                            break;
                        case 3:
                            Console.WriteLine(e.Multiplication(q, w));
                            break;
                        case 4:
                            if (w == 0) { Console.WriteLine("Ошибка: деление на 0 невозможно!"); break; }
                            Console.WriteLine(e.Division(q, w));
                            break;
                    }
                    break;
            }
        }
    }
}

