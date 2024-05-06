using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Золотая_рыбка
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = Convert.ToInt32(Console.ReadLine());
            if (N > 30000 || N <= 0) Console.WriteLine("Ошибка: такого количества слов быть не может!");
            string[] words = new string[N];
            for (int i = 0; i < N; i++)
            {
                words[i] = Console.ReadLine();
            }
            int F = Convert.ToInt32(Console.ReadLine());
            if (F > 26 || F <= 0) Console.WriteLine("Ошибка: такого количества букв быть не может!");
            int[] startOfInt = new int[F];
            string[] start = new string[F];
            int[] resultOfStart = new int[F];
            for (int i = 0; i < F; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                start[i] = input[0];
                startOfInt[i] = Convert.ToInt32(input[1]);
            }
            int L = Convert.ToInt32(Console.ReadLine());
            int[] finishOfInt = new int[L];
            string[] finish = new string[L];
            int[] resultOfFinish = new int[L];
            if (L > 26 || L <= 0) Console.WriteLine("Ошибка: такого количества букв быть не может!");
            for (int i = 0; i < L; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                finish[i] = input[0];
                finishOfInt[i] = Convert.ToInt32(input[1]);
            }
            int count1 = 0, count2 = 0;
            string word;
            List<string> result = new List<string>();
            for (int i = 0, j = 0; i < start.Length; j++)
            {
                if (count1 == startOfInt[i]) { i++; count1 = 0; j = 0; continue; }
                if (j == words.Length) { i++; count1 = 0; j = 0; continue; }
                for (int k = 0, l = 0; k < finish.Length; l++)
                {
                    if (count2 == finishOfInt[k]) { k++; count2 = 0; l = -1; continue; }
                    if (count1 == startOfInt[i]) { i++; count1 = 0; j = 0; break; }
                    if (l == words.Length) { k++; count2 = 0; l = -1; continue; }
                    word = words[l];
                    string m1 = start[i];
                    string n1 = Convert.ToString(word[0]);
                    string m2 = finish[k];
                    string n2 = Convert.ToString(word[(word.Length) - 1]);
                    if (m1.Equals(n1) && m2.Equals(n2))
                    {
                        result.Add(word);
                        count1++;
                        count2++;
                        resultOfStart[i]++;
                        resultOfFinish[k]++;
                        continue;
                    }
                }
            }
            List<string> noDupes = result.Distinct().ToList();
            Console.WriteLine(noDupes.Count());
        }
    }
}
