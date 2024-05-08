using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace stack1
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
                if (stack.Count == 0) { Console.WriteLine("Вы не ввели выражение, попробуйте заного."); Return = true; }
                if (Return == true) Console.WriteLine();  
                if (result == false && Return == false) { Console.WriteLine("Выражение некорректно"); }
                else if(Return == false) Console.WriteLine("Выражение корректно");
            }
            while (Return == true);
        }
    }
}
