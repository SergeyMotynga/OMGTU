﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milk
{
    internal class Program
    {
        static void Main()
        {
            int N = Convert.ToInt32(Console.ReadLine());
            int l = 0;
            float min = 1000f;
            for (int i = 0; i < N; i++)
            {
                int x1 = Convert.ToInt32(Console.ReadLine());   
                int y1 = Convert.ToInt32(Console.ReadLine());
                int z1 = Convert.ToInt32(Console.ReadLine());
                int x2 = Convert.ToInt32(Console.ReadLine());
                int y2 = Convert.ToInt32(Console.ReadLine());
                int z2 = Convert.ToInt32(Console.ReadLine());
                float c1 = Convert.ToSingle(Console.ReadLine()); 
                float c2 = Convert.ToSingle(Console.ReadLine());

                int s1 = 2 * x1 * y1 + 2 * x1 * z1 + 2 * y1 * z1;   
                int s2 = 2 * x2 * y2 + 2 * x2 * z2 + 2 * y2 * z2;

                float v1 = (x1 * y1 * z1) / 1000f;        
                float v2 = ((float)x2 * y2 * z2) / 1000;

                float price = (c2 * s1 - s2 * c1) / (v2 * s1 - s2 * v1); 

                if (price < min)
                {
                    l = i + 1;
                    min = price;
                }
            }
            Console.WriteLine("{0} {1:F}", l, min);
        }

    }
}
