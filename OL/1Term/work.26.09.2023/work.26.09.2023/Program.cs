using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace work._26._09._2023
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int result = 0;
            int x = 3, y =4, L = 8, c1 = 10, c2 = 4, c3 =7, c4 = 6, c5 = 6, c6 = 20;
            int longestWall = Math.Max(x, y);
            int remainingLPart = L - longestWall;
            if (remainingLPart > 0)
            {
                result += c2 * remainingLPart; 
            }
            else
            {
                remainingLPart = 0;
            }


            int newWalls = 2 * x + 2 * y - L;
            int newWallsPrice = newWalls * (c4 + c5);

            int oldWallPriceRepair = (L - remainingLPart) * c1;
            int oldWallPriceRecompose = (L - remainingLPart) * (c2 + c3);
            int oldWallPriceReplace = (L - remainingLPart) * (c2 + c5 + c4 + c6);

            int oldWallLowestPrice = Math.Min(oldWallPriceRepair, oldWallPriceRecompose);

            result += newWallsPrice + oldWallLowestPrice;

            int smallPartRecomposePrice = remainingLPart * c3;
            int replaceWithNewPrice = remainingLPart * (c4 + c5 + c6);
            int lowestPriceCase = Math.Min(smallPartRecomposePrice, replaceWithNewPrice);
            result += lowestPriceCase;

            Console.WriteLine(result); 






        }
    }
}
