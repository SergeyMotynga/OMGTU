using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryWork1_12._09._23_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int S = 0, n = 5, m = 10, l = 7;
            for (int i = 0; i <= 20; i++) 
            {
                S = i * (2 * (m + n + l) + m * (i - 1));
                Console.WriteLine(S);
            }
        }    
    }
}
