using System;
using System.Linq;

class TrapezoidalRule_LINQ
{
    public static double Solve(Func<double, double> f, double a, double b, double dx)
    {
        double epsilon = 10E-7;
        if (!double.IsNormal(a)) { throw new ArgumentException("Начало интервала не является число"); }
        if (!double.IsNormal(b)) { throw new ArgumentException("Конец интервала не является числом"); }
        if (dx < epsilon) { throw new ArgumentException("dx меньше epsilon"); }

        int intervals = Convert.ToInt32(Math.Ceiling((b - a) / dx));
        double result = Enumerable.Range(0, intervals).Select(i=>{
            double x1 = a + i * dx;
            double x2 = a + (i + 1) * dx;
            double func = Math.Abs((f(x1) + f(x2))/2 *dx);
            return func;
        }).Sum();

        return result;
    }
    static void Main(string[] args)
    {
        Func<double, double> f = (double x) => -x * x + 9;
        double result = TrapezoidalRule_LINQ.Solve(f, -3, 3, 0.1);
        Console.WriteLine(result);
    }
}
