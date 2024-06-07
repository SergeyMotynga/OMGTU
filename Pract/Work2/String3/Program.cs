using System;
using System.Text.RegularExpressions;

namespace String3
{
    class Program
    {
        static void Main(string[] args)
        {
            var str = new string[]{"testexample@as.r.r","-notest123@example.com","test--@example.com", "+79230123212",
            "nomail", "Test.123askk.as.12.a@example.com"};
            var pattern = new Regex(@"(?<=\s|^)[A-z0-9][A-z0-9-_.]*@[A-z0-9-]{2,}(\.([A-z0-9-])*)+(?=\s|$)");
            MatchCollection matches = pattern.Matches(string.Join(" ", str.Select(x => x)));
            foreach (var match in matches)
            {
                Console.WriteLine(match);
            }
        }
    }
}
