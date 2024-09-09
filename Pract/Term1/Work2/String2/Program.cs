using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace String2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] str = { "21:35", "07:15", "19:10", "23:4", "нет", "no" };
            var pattern = new Regex(@"\b(?:[01][0-9]|2[0-3]):[0-5][0-9]\b");
            MatchCollection matches = pattern.Matches(string.Join(" ", str.Select(x => x)));
            foreach (var match in matches)
            {
                Console.WriteLine(match);
            }
        }
    }
}