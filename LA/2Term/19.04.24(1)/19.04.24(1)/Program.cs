using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19._04._24_1_
{
    internal class Program
    {
        static void Main()
        {
            string inputFile1 = "input1.txt";
            string inputFile2 = "input2.txt";
            string outputFile = "output.txt";
            using (StreamReader reader1 = new StreamReader(inputFile1))
            using (StreamReader reader2 = new StreamReader(inputFile2))
            using (StreamWriter writer = new StreamWriter(outputFile))
            {
                string line1 = reader1.ReadLine();
                string line2 = reader2.ReadLine();
                string[] numbers1 = line1.Split(' ');
                string[] numbers2 = line2.Split(' ');
                int index1 = 0, index2 = 0;
                while (index1 < numbers1.Length && index2 < numbers2.Length)
                {
                    if (int.Parse(numbers1[index1]) > int.Parse(numbers2[index2]))
                    {
                        writer.Write(numbers1[index1++] + " ");
                    }
                    else
                    {
                        writer.Write(numbers2[index2++] + " ");
                    }
                }
                while (index1 < numbers1.Length)
                {
                    writer.Write(numbers1[index1++] + " ");
                }
                while (index2 < numbers2.Length)
                {
                    writer.Write(numbers2[index2++] + " ");
                }
            }
        }
    }
}
