using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Work_25._10
{
    internal class Program
    {
        static void Main()
        {
            Console.Write("Введите количество строк: ");
            int n = Convert.ToInt32(Console.ReadLine());
            int maxLength = 0;
            int[][] array = new int[n][];
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Введите количество элементов в {i + 1} строке: ");
                int length = Convert.ToInt32(Console.ReadLine());
                maxLength += length;
                Console.Write($"Введите элементы {i + 1} строки через пробел: ");
                var inputElements = Console.ReadLine();
                var outputElements = inputElements.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                array[i] = new int[length];
                for (int j = 0; j < length; j++)
                {
                    array[i][j] = Convert.ToInt32(outputElements[j]);
                }
            }


            //Пересечение
            int intersectionSize = array[0].Length;
            foreach (int i in array[0])
            {
                foreach (int[] j in array)
                {
                    if (!j.Contains(i))
                    {
                        intersectionSize--;
                        break;
                    }
                }
            }
            int[] intersection = new int[intersectionSize];
            int intersectionCount = 0;
            foreach (int i in array[0])
            {
                bool res = true;
                foreach (int[] j in array)
                {
                    if (!j.Contains(i))
                    {
                        res = false;
                        break;
                    }
                }
                if (res)
                {
                    intersection[intersectionCount] = i;
                    intersectionCount++;
                }
            }
            Console.WriteLine("Пересечение: [{0}]", string.Join(", ", (intersection)));

            //Объединение
            int[] union = new int[maxLength];
            int count = 0;
            foreach (int[] i in array)
            {
                foreach (int j in i)
                {
                    union[count] = j;
                    count++;
                }
            }
            int[] unionOutput = union.Distinct().ToArray();
            Console.WriteLine("Объединение: [{0}]", string.Join(", ", (unionOutput)));

            //Максимальные элементы
            int maxElement = 0;
            int[] maxElements = new int[n];
            int countEl = 0;
            foreach (int[] i in array)
            {
                foreach(int j in i)
                {
                    maxElement = Math.Max(maxElement, j);
                }
                maxElements[countEl] = maxElement;
                countEl++;
            }
            Console.WriteLine("Максимальыне эелементы: [{0}]", string.Join(", ", (maxElements)));
        }
    }
}
