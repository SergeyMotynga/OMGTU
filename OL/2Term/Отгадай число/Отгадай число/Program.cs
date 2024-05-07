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
            string[] operations = new string[N];
            for (int i = 0; i < N; i++)
            {
                operations[i] = Console.ReadLine();
            }
            int R = int.Parse(Console.ReadLine());
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
                    switch (operation)
                    {
                        case "+":
                            coefficientX += value;
                            break;
                        case "-":
                            coefficientX -= value;
                            break;
                        case "*":
                            coefficientX *= value;
                            break;
                        case "/":
                            if (coefficientX == 0) throw new InvalidOperationException("Ошибка: деление на 0 запрещено.");
                            coefficientX /= value;
                            break;
                    }
                }
                else
                {
                    value = Convert.ToInt32(part[1]);
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
            Console.WriteLine($"x = {(R-freeTerm)/coefficientX}");
        }
    }
}
