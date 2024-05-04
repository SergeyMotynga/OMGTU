using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace krestyaninIChert
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите значение maxN: ");
            int maxN = Convert.ToInt32(Console.ReadLine());
            long result = maxN;
            for (int i = 3; i <= maxN; i = 2 * i + 1)
            {
                int rem = maxN / i;
                result += rem;
            }
            Console.WriteLine("Всего исходов: " + result);          
        }
    }
}
