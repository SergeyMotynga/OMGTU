using System;
using System.Text.RegularExpressions;

namespace String3
{
    class Program
    {
        static void Main(string[] args)
        {
            var str = new string[]{"notestexample@as.r","-noest123@example.com.com","test--@example.com", "+79230123212",
            "nomail", "Test.123askk.as.12.a@example.com"};
            var pattern = new Regex(@"(?<=\s|^)[a-zA-Z0-9][a-zA-Z0-9._%+-]*@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}(?=\s|$)");
            MatchCollection matches = pattern.Matches(string.Join(" ", str.Select(x => x)));
            foreach (var match in matches)
            {
                Console.WriteLine(match);
            }
        }
    }
}
