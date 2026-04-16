namespace Delegates.App;

//public delegate double MathsFunction(double arg);
//              ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ how should method(s) look like

internal class Program
{
    static void Plot(Func<double, double> f, double xStart, double xEnd, double step)
    {
        for (double x = xStart; x < xEnd; x += step)
        {
            double y = f(x);
            Console.WriteLine($"{x:N2}, {y:N2}");
        }
    }

    static void Main(string[] args)
    {
        //Plot(Math.Sin, 0.0, Math.PI / 2, 0.01);
        //Plot(Math.Cos, 0.0, Math.PI / 2, 0.01);
        //Plot(Math.Sqrt, 0.0, Math.PI / 2, 0.01);
        //Plot(Math.Tan, 0.0, Math.PI / 2, 0.01);
        //Plot(Triple, 0.0, Math.PI / 2, 0.01);
        //Plot(delegate(double x) { return x * 2; }, 0.0, Math.PI / 2, 0.01);
        Plot(x => x * 3, 0.0, Math.PI / 2, 0.01);
    }

    static double Double(double x)
    {
        return x * 2;
    }

    static double Triple(double x)
    {
        return x * 3;
    }
}
