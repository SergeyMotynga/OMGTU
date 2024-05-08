using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _19._04._24_2_
{
    internal class Program
    {
        static void Main()
        {
            string inputFile = "input.txt";
            string shortestASequence = null;

            using (StreamReader reader = new StreamReader(inputFile))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    int currentLength = GetShortestASequenceLength(line);
                    if (currentLength > 0 && (shortestASequence == null || currentLength < GetShortestASequenceLength(shortestASequence)))
                    {
                        shortestASequence = line;
                    }
                }
            }
            Console.WriteLine(shortestASequence ?? "No 'A' sequences found");
        }
        static int GetShortestASequenceLength(string s)
        {
            int shortestLength = int.MaxValue;
            int currentLength = 0;
            bool inSequence = false;
            foreach (char c in s)
            {
                if (c == 'A')
                {
                    inSequence = true;
                    currentLength++;
                }
                else if (inSequence)
                {
                    if (currentLength < shortestLength)
                    {
                        shortestLength = currentLength;
                    }
                    inSequence = false;
                    currentLength = 0;
                }
            }
            if (inSequence && currentLength < shortestLength)
            {
                shortestLength = currentLength;
            }
            return shortestLength == int.MaxValue ? 0 : shortestLength;
        }
    }
}
