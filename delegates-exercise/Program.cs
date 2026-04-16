using System.Text;

namespace delegates_exercise;

//public delegate string MyFormatter(int number);

class Printer
{
    public void Print(int number, Func<int, string> formatter)
    {
        Console.WriteLine(formatter(number));
    }
}

static class Layout
{
    public static string SuperDuperFormat(int number)
    {
        return $"The number is [{number}]";
    }

    public static string ChristmasFormat(int number)
    {
        return $"Number {number} ❄️🎄";
    }
}

internal class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        var printer = new Printer();
        printer.Print(42, Layout.SuperDuperFormat);
        printer.Print(12, Layout.ChristmasFormat);
    }
}
