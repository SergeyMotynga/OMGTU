using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Кубик_Рубика
{
    internal class Program
    {
        public class POS
        {
            int x = 0;
            int y = 0;
            int z = 0;
            public POS(int x, int y, int z)
            {
                this.x = x;
                this.y = y;
                this.z = z;
            }
            public int X
            { get { return x; } set { x = value; } }
            public int Y
            { get { return y; } set { y = value; } }
            public int Z
            { get { return z; } set { z = value; } }
            public POS Turned(int x, int y, int z, string p, int a, int b)
            {
                int q = 0;
                int w = 0;
                if (p == "Z") { q = x; w = y; }
                if (p == "X") { q = y; w = z; }
                if (p == "Y") { q = x; w = z; }
                (q, w) = (w, q);
                if (a == -1)
                {
                    if (w == 1 || w == b) q = b - w + 1; else if (q == b) q = 1; else if (q == 1) q = b;
                }
                if (a == 1)
                {
                    if (q == 1 || q == b) w = b - w + 1; else if (w == 1) w = b; else if (w == b) w = 1;
                }
                if (p == "Z") { x = q; y = w; }
                if (p == "X") { y = q; z = w; }
                if (p == "Y") { x = q; z = w; }
                POS pos = new POS(x, y, z);
                return pos;
            }
            public bool InBlock(POS tri, int b, string o)
            {
                int x = tri.x;
                int y = tri.y;
                int z = tri.z;
                if (o == "X" && x == b || o == "Y" && y == b || o == "Z" && z == b) { return true; }
                return false;
            }
        }
        static void Main()
        {
            Console.Write("Введите количество элементов кубика вдоль ребра и количество вращений через пробел: ");
            string input = Console.ReadLine();
            string[] str = input.Split(' ');
            int n = Convert.ToInt32(str[0]);
            int m = Convert.ToInt32(str[1]);
            Console.Write("Введите координаты элемента через пробел: ");
            string xyz = Console.ReadLine();
            string[] xyz1 = xyz.Split(' ');
            int x = Convert.ToInt32(xyz1[0]);
            int y = Convert.ToInt32(xyz1[1]);
            int z = Convert.ToInt32(xyz1[2]);
            POS pos = new POS(x, y, z);
            string[] vr = new string[m];
            Console.WriteLine("Введите вращения кубика в виде: ось номер_блока направление");
            for (int i = 0; i < m; i++)
            {
                vr[i] = Console.ReadLine();
            }
            for (int i = 0; i < m; i++)
            {
                string[] vrs = vr[i].Split(' ');
                string o = vrs[0];
                int b = Convert.ToInt32(vrs[1]);
                int s = Convert.ToInt32(vrs[2]);
                if (pos.InBlock(pos, b, o)) { pos = pos.Turned(pos.X, pos.Y, pos.Z, o, s, n); }
            }
            Console.WriteLine($"Конечное положение элемента: {pos.X}, {pos.Y}, {pos.Z}");
        }
    }
}
