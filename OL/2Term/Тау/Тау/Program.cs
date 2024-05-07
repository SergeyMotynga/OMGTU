using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Тау
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите фразу на языке Тау, длина фразы должна лежать в диапозоне от 1 до 255 символов: ");
            string[] inputPhrase = Console.ReadLine().Split(' ');
            string word = "";
            string[] middleResult = new string[inputPhrase.Length];
            string[] result = new string[inputPhrase.Length];
            middleResult[0] = inputPhrase[inputPhrase.Length / 2];
            for (int i = inputPhrase.Length / 2 - 1, j = inputPhrase.Length / 2 + 1, k = 1; i > -1; i--, j++)
            {
                middleResult[k] = inputPhrase[i];
                k++;
                if (j == inputPhrase.Length) break;
                middleResult[k] = inputPhrase[j];
                k++;
            }
            for (int i = 0; i < result.Length; i++)
            {
                word = middleResult[i];
                string[] resultWord = new string[word.Length];
                resultWord[0] = Convert.ToString(word[word.Length / 2]);
                for (int j = word.Length / 2 - 1, k = word.Length / 2 + 1, q = 1; j > -1; j--, k++)
                {
                    resultWord[q] = Convert.ToString(word[j]);
                    q++;
                    if(k == word.Length) break;
                    resultWord[q] = Convert.ToString(word[k]);
                    q++;
                }
                result[i] = string.Join(string.Empty, resultWord);
            }
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
