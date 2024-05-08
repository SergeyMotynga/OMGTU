using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stack2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool Return = false;
            do
            {
                Return = false;
                Console.Write("Введите выражение: ");
                string phrase = Console.ReadLine();
                Stack<string> stack = new Stack<string>();
                double resultOfCalculated = 0, a, b;
                bool result = true;
                if (phrase == "") { Console.WriteLine("Вы не ввели выражение, попробуйте заного"); Return = true; }
                int check = 0;
                foreach (char c in phrase)
                {
                    if (c == '+' || c == '-' || c == '*' || c == '/')
                    {
                        if (stack.Count < 2) { Console.WriteLine("Ошибка: в выражении отсутствуют элементы для вычисления, попробуйте заного"); Return = true; break; }
                        if (check > 2) { Console.WriteLine("Ошибка: в выражении присутствует неоднозначность, вычисление невозможно, попробуйте заного"); Return = true; break; }
                        a = Convert.ToDouble(stack.Pop());
                        b = Convert.ToDouble(stack.Pop());
                        if (c == '/' && a == 0) { Console.WriteLine("Деление на 0 невозможно, попробуйте заного"); Return = true; break; }
                        if (c == '+') { resultOfCalculated = b + a; check = 0; }
                        if (c == '-') { resultOfCalculated = b - a; check = 0; }
                        if (c == '*') { resultOfCalculated = b * a; check = 0; }
                        if (c == '/') { resultOfCalculated = b / a; check = 0; }
                        stack.Push(Convert.ToString(resultOfCalculated));
                    }
                    else
                    {
                        if (c != ' ' || c != ')' || c != '(') stack.Push(Convert.ToString(c));
                        check++;
                    }
                }
                if (Return == true) Console.WriteLine();
                else Console.WriteLine($"Ответ: {resultOfCalculated}");
            }
            while (Return != false);
        }
    }
}
