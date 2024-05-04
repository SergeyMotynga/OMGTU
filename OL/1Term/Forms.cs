using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите количество деталей: ");
            int countOfDetails = Convert.ToInt32(Console.ReadLine());
            int n = 20;
            int[][] details = new int[countOfDetails][];
            for (int i = 0; i < countOfDetails; i++)
            {
                int j = 0;
                details[i] = new int[n];
                Console.Write($"Введите детали для массива {i + 1}: ");
                var arrayInput = Console.ReadLine();
                var arrayOutput = arrayInput.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var k in arrayOutput)
                {
                    details[i][j] = Convert.ToInt32(k);
                    j++;
                }
            }
            int[][] forms = new int[countOfDetails * 2][];
            for (int i = 0; i < countOfDetails * 2; i++)
            {
                int j = 0;
                forms[i] = new int[n - 5];
                Console.Write($"Введите формы для массива {i + 1}: ");
                var arrayInput = Console.ReadLine();
                var arrayOutput = arrayInput.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var k in arrayOutput)
                {
                    forms[i][j] = Convert.ToInt32(k);
                    j++;
                }

            }

            for (int i = 0; i < forms.Length - 1; i++)
            {
                for (int j = i + 1; j < forms.Length; j++)
                {
                    if (isFirstEqualFirst(forms[i], forms[j]) && isLastEqualLast(forms[i], forms[j]))
                    {
                        Console.WriteLine($"{i + 1} и {j + 1} пара");
                    }
                    else if (isFirstEqualLast(forms[i], forms[j]) && isLastEqualFirst(forms[i], forms[j]))
                    {
                        Console.WriteLine($"{i + 1} и {j + 1} пара");
                    }
                }
            }

        }

        static bool isEqualSide(int[] first, int[] second)
        {
            bool ok = true;
            for (int i = 0; i < first.Length; i++)
            {
                if (first[i] != second[i])
                {
                    ok = false;
                    break;
                }
            }

            return ok;
        }

        static bool isEqualMirrorSide(int[] first, int[] second)
        {
            bool ok = true;
            for (int i = 0; i < first.Length; i++)
            {
                if (first[i] != second[4 - i])
                {
                    ok = false;
                    break;
                }
            }

            return ok;
        }

        static bool isSideMatched(int[] side1, int[] side2)
        {
            return isEqualSide(side1, side2) || isEqualMirrorSide(side1, side2);
        }

        static int[] getSide(Sides side, int[] half)
        {
            int[] res = new int[5];
            int index = 0;
            for (int i = 5 * ((int)side - 1); i < (int)side * 5; i++)
            {
                res[index] = half[i];
                index++;
            }

            return res;
        }

        static bool isFirstEqualFirst(int[] half1, int[] half2)
        {
            int[] half1SideUp = getSide(Sides.UP, half1);
            int[] half2SideUp = getSide(Sides.UP, half2);

            return isSideMatched(half1SideUp, half2SideUp);
        }

        static bool isLastEqualLast(int[] half1, int[] half2)
        {
            int[] half1SideDown = getSide(Sides.DOWN, half1);
            int[] half2SideDown = getSide(Sides.DOWN, half2);

            return isSideMatched(half1SideDown, half2SideDown);
        }

        static bool isFirstEqualLast(int[] half1, int[] half2)
        {
            int[] half1SideUp = getSide(Sides.UP, half1);
            int[] half2SideDown = getSide(Sides.DOWN, half2);

            return isEqualMirrorSide(half1SideUp, half2SideDown);
        }

        static bool isLastEqualFirst(int[] half1, int[] half2)
        {
            int[] half1SideDown = getSide(Sides.DOWN, half1);
            int[] half2SideUp = getSide(Sides.UP, half2);

            return isEqualMirrorSide(half1SideDown, half2SideUp);
        }

        static int[] getMirrorArray(int[] array)
        {
            int[] res = new int[array.Length];
            for (int i = array.Length - 1, index = 0; i >= 0; i--, index++)
            {
                res[i] = array[index];
            }

            return res;
        }

    }

    enum Sides
    {
        UP = 1, NEAR = 2, DOWN = 3, DISTANT = 4
    }
}

