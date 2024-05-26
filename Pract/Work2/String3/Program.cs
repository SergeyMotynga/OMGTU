using System;
using System.Text.RegularExpressions;

namespace String3{
    class Program{
        static void Main(string[] args){
            var str = new string[] {"notestexample.ru","test123_-@example.com","test--@example.com", "+79230123212", "nomail"};
            var pattern = new Regex(@"([A-z0-9-_.]){2,63}@([A-z0-9-]{1,})(\.([A-z0-9-]){1,}){1,}");
            MatchCollection matches = pattern.Matches(string.Join(" ", str.Select(x => x.ToLower())));
            foreach (var match in matches)
            {
                Console.WriteLine(match);
            }
        }
    }
}