using System;
using System.Text;
using System.Diagnostics;

namespace String1
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            string str1 = "0123456789";
            Random random = new Random();
            for (int i = 0; i < 1000000; i++)
            {
                int index = i % 10;
                str1 = str1.Remove(index, 1).Insert(index, Convert.ToString(random.Next(0, 9)));
            }
            timer.Stop();
            Console.WriteLine($"Время string: {timer.ElapsedMilliseconds} мс");
            timer.Restart();
            StringBuilder str2 = new StringBuilder("0123456789");
            for (int i = 0; i < 1000000; i++)
            {
                str2[i % 10] = Convert.ToString(random.Next(0, 9))[0];
            }
            timer.Stop();
            Console.WriteLine($"Время StringBuilder: {timer.ElapsedMilliseconds} мс");
        }
    }
}