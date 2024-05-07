using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Отгадай_число
{
    internal class Program
    {
        static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            if (N < 0 || N > 100) throw new InvalidOperationException("Ошибка: невозможное количество действий, оно может быть в диапазоне от 0 до 100.");
            string[] operations = new string[N];
            for (int i = 0; i < N; i++)
            {
                operations[i] = Console.ReadLine();
            }
            int R = int.Parse(Console.ReadLine());
            if (R > 2000000000 || R < -2000000000) throw new InvalidOperationException("Ошибка: число не должно превышать 2000000000 по модулю.");
            int coefficientX = 1;
            int freeTerm = 0;
            for (int i = 0; i < N; i++)
            {
                string operation = Convert.ToString(operations[i][0]);
                string action = Convert.ToString(operations[i]);
                string[] part = action.Split(' ');
                bool result = action.Contains("x");
                int value;
                if (result == true)
                {
                    if (part[1].Length > 1) value = Convert.ToInt32(part[1].Remove(part[1].Length - 1));
                    else value = 1;
                    if(value < -100 || value > 100)  throw new InvalidOperationException("Ошибка: число не должно превышать 100 по модулю.");
                    switch (operation)
                    {
                        case "+":
                            coefficientX += value;
                            break;
                        case "-":
                            coefficientX -= value;
                            break;
                        case "*":
                            throw new InvalidOperationException("Ошибка: по условию задачи умножение на коеффициент при x невозможно.");
                            break;
                        case "/":
                            throw new InvalidOperationException("Ошибка: по условию задачи деление на коеффициент при x невозможно.");
                            break;
                    }
                }
                else
                {
                    value = Convert.ToInt32(part[1]);
                    if (value < -100 || value > 100) throw new InvalidOperationException("Ошибка: число не должно превышать 100 по модулю.");
                    switch (operation)
                    {
                        case "+":
                            freeTerm += value;
                            break;
                        case "-":
                            freeTerm -= value;
                            break;
                        case "*":
                            freeTerm *= value;
                            coefficientX *= value;
                            break;
                        case "/":
                            if (freeTerm == 0) throw new InvalidOperationException("Ошибка: деление на 0 запрещено.");
                            freeTerm /= value;
                            break;
                    }
                }
            }
            if (coefficientX == 0) throw new InvalidOperationException("Ошибка: деление на 0 невозможно.");
            Console.WriteLine($"x = {(R-freeTerm)/coefficientX}");
        }
    }
}
