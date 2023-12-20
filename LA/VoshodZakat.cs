﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoshodZakat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool result = true;

            Console.Write("Введите длину пути: ");
            int distance = Convert.ToInt32(Console.ReadLine());

            Console.Write("Количество пунктов отдыха: ");
            int numberOfRestPoints = Convert.ToInt32(Console.ReadLine());
            int[] restPoints = new int[numberOfRestPoints];

            for (int i = 0; i < numberOfRestPoints; i++)
            {
                Console.Write($"Введите расстояние от начала пути до пункта номер: {i + 1}:");
                restPoints[i] = Convert.ToInt32(Console.ReadLine());
            }

            Console.Write("Введите среднюю скорость в км/ч: ");
            double averageSpeed = Convert.ToDouble(Console.ReadLine()) / 60;

            Console.Write("Введите время восхода солнца: ");
            DateTime sunriseTime = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Введите время захода солнца: ");
            DateTime sunsetTime = Convert.ToDateTime(Console.ReadLine());

            double differenceTime = (sunsetTime - sunriseTime).TotalMinutes;

            double distancePerDay = averageSpeed * differenceTime;

            int count = 0;
            int[] restPointsOutput = new int[restPoints.Length];
            for (int i = 0, k = 0; i < restPoints.Length; i++)
            {
                if (restPoints[i] > distance) {
                    result = false;
                    break;
                }
                if (restPoints[0] > distancePerDay)
                {
                    result = false;
                    break;
                }
                if (restPoints[i] > distancePerDay)
                {
                    if (restPoints[i] - restPoints[i - 1] > distancePerDay)
                    {
                        result = false;
                        break;
                    }
                    restPointsOutput[k] = restPoints[i - 1];
                    k++;
                    count++;
                }
            }
            if (result == true)
            {
                restPointsOutput = restPointsOutput.Where(x => x != 0).ToArray();
                Console.WriteLine("Группа побывала в пунктах: " + String.Join(",", restPointsOutput));
                Console.WriteLine($"В путы пробыла: {count} дней");
            }
            else
                Console.WriteLine("Невозможная ситуация!");
        }
    }
}
