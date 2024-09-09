using System;

class TrapezoidalRule
{
    public static double Solve(Func<double, double> f, double a, double b, double dx)
    {
        double epsilon = 10E-7;
        if (!double.IsNormal(a)) { throw new ArgumentException("Начало интервала не является число"); }
        if (!double.IsNormal(b)) { throw new ArgumentException("Конец интервала не является числом"); }
        if (dx < epsilon) { throw new ArgumentException("dx меньше epsilon"); }
        double result = 0;
        int intervals = Convert.ToInt32((b - a) / dx);
        for(int i = 0; i < intervals; i++){
            double x1 = a + i * dx;
            double x2 = a + (i + 1) * dx;
            double y1 = f(x1);
            double y2 = f(x2);
            result += (y1 + y2) * dx / 2;
        }
        return result;
    }
    static void Main(string[] args)
    {
        Func<double, double> f = (double x) => -x*x+9;
        double result = TrapezoidalRule.Solve(f, -3, 3, 0.1);
        Console.WriteLine(result);
    }
}
