using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace itensifikaciyaProizvodstva
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string dateStartInput = Console.ReadLine();
            string dateEndInput = Console.ReadLine();
            double rel = Convert.ToInt32(Console.ReadLine());

            DateTime dateStart = DateTime.Parse(dateStartInput);
            DateTime dateEnd = DateTime.Parse(dateEndInput);
            var def = dateEnd.Subtract(dateStart).Days + 1;

            double result = (2 * rel + def - 1) * def / 2;

            Console.WriteLine(result);
        }
    }
}
