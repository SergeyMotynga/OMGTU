
//1)На вход подаётся строка, нужно определить сумму всех чётных элементов.
//2)на вход подается строка, необходимо определить является ли строка палиндромом
//(причем строка, к примеру, "А роза упала на лапу Азора" будет палиндромом несмотря на большие буквы и пробелы)

using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Work_07._11._23_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //isFirst();
            //isSecond();
        }

        static void isFirst()
        {
            int sum = 0;
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    sum += numbers[i];
                }
            }
            Console.WriteLine(sum);
        }

        static void isSecond()
        {
            string inputText = Console.ReadLine();
            int start = 0;
            int end = inputText.Length - 1;
            bool result = true;

            while (start < end)
            {
                char startChar = inputText[start];
                char endChar = inputText[end];
                
                if (char.ToUpper(startChar) == char.ToLower(startChar))
                {
                    start += 1;
                    continue;
                } 
                
                if (char.ToUpper(endChar) == char.ToLower(endChar))
                {
                    end -= 1;
                    continue;
                } 
                
                if (char.ToUpper(startChar) == char.ToLower(endChar))
                {
                    result = false;
                }

                start += 1;
                end -= 1;
            }
            if (result == true)
            {
                Console.WriteLine("Это паллиндром");
            }
            else
            {
                Console.WriteLine("Это не паллиндром");
            }
        }
    }
}
