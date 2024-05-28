using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace RGR_ALGO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool Return;
            do
            {
                Return = true;
                Console.Write($"1.Задача про скобки\n2.Задача на польскую запись\n" +
                    $"3.Об авторе\n4.О программе\n5.Помощь\n6.Выход\nВыберете пункт: ");
                int choose = Convert.ToInt32(Console.ReadLine());
                if (choose != 1 && choose != 2 && choose != 3 && choose != 4 && choose != 5 && choose != 6)
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
                            Console.Write("Введите выражение: ");
                            string phrase = Console.ReadLine();
                            Stack<char> stack = new Stack<char>();
                            foreach (char c in phrase)
                            {
                                stack.Push(c);
                            }
                            bool result = true;
                            for (int i = 0; i < (stack.Count - 1); i++)
                            {
                                if (stack.Count % 2 != 0) { result = false; break; }
                                if (stack.ElementAt(i) == ')')
                                {
                                    if (stack.ElementAt(i + 1) != '(') { result = false; break; }
                                }
                                if (stack.ElementAt(i) == ']')
                                {
                                    if (stack.ElementAt(i + 1) != '[') { result = false; break; }
                                }
                                if (stack.ElementAt(i) == '}')
                                {
                                    if (stack.ElementAt(i + 1) != '{') { result = false; break; }
                                }
                            }
                            if (stack.Count == 0)
                            {
                                Console.Write("Вы не ввели выражение" +
                               "\nЧтобы вернуться введите 0, чтобы выйти из программы введите 1, " +
                               "чтобы заного ввести выражение введите 2\nВаш ответ: ");
                                choose = Convert.ToInt32(Console.ReadLine());
                                if (choose == 2) Return1 = true;
                                if (choose == 1) break;
                                if (choose == 0) { Console.Clear(); break; }
                            }
                            if (Return1 == true) Console.WriteLine();
                            if (result == false && Return1 == false)
                            {
                                Console.Write("Выражение некорректно" +
                                    "\nЧтобы вернуться введите 0, чтобы выйти из программы введите 1, " +
                                            "чтобы заного ввести выражение введите 2\nВаш ответ: ");
                                choose = Convert.ToInt32(Console.ReadLine());
                                if (choose == 2) Return1 = true;
                                if (choose == 1) break;
                            }
                            else if (Return1 == false)
                            {
                                Console.Write("Выражение корректно" +
                                    "\nЧтобы вернуться введите 0, чтобы выйти из программы введите 1, " +
                                            "чтобы заного ввести выражение введите 2\nВаш ответ: ");
                                choose = Convert.ToInt32(Console.ReadLine());
                                if (choose == 2) Return1 = true;
                                if (choose == 1) break;
                            }
                        }
                        while (Return1 == true);
                        if (choose == 1) Return = false;
                        Console.Clear();
                        break;
                    case 2:
                        bool Return2;
                        do
                        {
                            Console.Clear();
                            Return2 = false;
                            Console.Write("Введите выражение: ");
                            string phrase = Console.ReadLine();
                            Stack<string> stack = new Stack<string>();
                            double resultOfCalculated = 0, a, b;
                            if (phrase == "")
                            {
                                Console.Write("Вы не ввели выражение" +
                                "\nЧтобы вернуться введите 0, чтобы выйти из программы введите 1, " +
                                "чтобы заного ввести выражение введите 2\nВаш ответ: ");
                                choose = Convert.ToInt32(Console.ReadLine());
                                if (choose == 2) Return2 = true;
                                if (choose == 1) break;
                                if (choose == 0) { Console.Clear(); break; }
                            }
                            if (phrase.Length < 3)
                            {
                                Console.Write("Ошибка: в выражении отсутствуют элементы для вычисления" +
                                "\nЧтобы вернуться введите 0, чтобы выйти из программы введите 1, " +
                                "чтобы заного ввести выражение введите 2\nВаш ответ: ");
                                choose = Convert.ToInt32(Console.ReadLine());
                                if (choose == 2) { Return2 = true; }
                                if (choose == 1) break;
                                if (choose == 0) { Console.Clear(); break; }
                            }
                            foreach (char c in phrase)
                            {
                                if (c == '+' || c == '-' || c == '*' || c == '/')
                                {
                                    if (stack.Count < 2)
                                    {
                                        Console.Write("Ошибка: в выражении отсутствуют элементы для вычисления" +
                                             "\nЧтобы вернуться введите 0, чтобы выйти из программы введите 1, " +
                                             "чтобы заного ввести выражение введите 2\nВаш ответ: ");
                                        choose = Convert.ToInt32(Console.ReadLine());
                                        if (choose == 2) { Return2 = true; break; }
                                    }
                                    a = Convert.ToDouble(stack.Pop());
                                    b = Convert.ToDouble(stack.Pop());
                                    if (c == '/' && (a == 0 || b == 0))
                                    {
                                        Console.Write("Ошибка: деление на 0 невозможно" +
                                            "\nЧтобы вернуться введите 0, чтобы выйти из программы введите 1, " +
                                            "чтобы заного ввести выражение введите 2\nВаш ответ: ");
                                        choose = Convert.ToInt32(Console.ReadLine());
                                        if (choose == 2) { Return2 = true; break; }
                                    }
                                    if (c == '+') resultOfCalculated = b + a;
                                    if (c == '-') resultOfCalculated = b - a;
                                    if (c == '*') resultOfCalculated = b * a;
                                    if (c == '/') resultOfCalculated = b / a;
                                    stack.Push(Convert.ToString(resultOfCalculated));
                                }
                                else
                                {
                                    if (c != ' ') stack.Push(Convert.ToString(c));
                                }
                            }
                            if (Return2 == true) Console.Clear();
                            else
                            {
                                Console.Write($"Ответ: {resultOfCalculated}" +
                                $"\nЧтобы вернуться введите 0, чтобы выйти из программы введите 1, " +
                                            "чтобы заного ввести выражение введите 2\nВаш ответ: ");
                                choose = Convert.ToInt32(Console.ReadLine());
                                if (choose == 2) Return2 = true;
                            }
                        }
                        while (Return2 == true);
                        if (choose == 1) Return = false;
                        Console.Clear();
                        break;
                    case 3:
                        Console.Clear();
                        Console.Write("Автор данной програмы: Мотынга Сергей Андреевич, студент ОмГТУ, ФИТ-231" +
                            "\nЧтобы вернуться введите 0, чтобы выйти из программы введите 1\nВаш ответ: ");
                        choose = Convert.ToInt32(Console.ReadLine());
                        if (choose == 1) Return = false;
                        Console.Clear();
                        break;
                    case 4:
                        Console.Clear();
                        Console.Write("Данная программа выполняет 2 задачи:\n1-я проверка строки на првильность" +
                            " расстановки скобок, к примеру () - правильно, а )( - неправильно." +
                            "\n2-я решает математическое выражение, введённое при помощи польской записи." +
                            "\nЧтобы вернуться введите 0, чтобы выйти из программы введите 1\nВаш ответ: ");
                        choose = Convert.ToInt32(Console.ReadLine());
                        if (choose == 1) Return = false;
                        Console.Clear();
                        break;
                    case 5:
                        Console.Clear();
                        Console.Write("На данный момент здесь пусто" +
                            "\nЧтобы вернуться введите 0, чтобы выйти из программы введите 1\nВаш ответ: ");
                        choose = Convert.ToInt32(Console.ReadLine());
                        if (choose == 1) Return = false;
                        Console.Clear();
                        break;
                    case 6:
                        Console.Clear();
                        Return = false;
                        break;
                }
            }
            while (Return == true);
        }
    }
}
