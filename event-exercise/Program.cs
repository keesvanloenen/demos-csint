namespace event_exercise;

internal class Program
{
    static void Main(string[] args)
    {
        //var p = new Person("Ellen", 27);

        //p.AgeChanged += OnAgeChanged!;

        //p.AgeUp();
        //Console.WriteLine(p);

        var e = new Employee("Ellen", 27, 1000m);

        e.AgeChanged += OnAgeChanged!;

        e.AgeUp();
        Console.WriteLine(e);


    }

    static void OnAgeChanged(object sender, AgeChangedArgs args)
    {
        var congratulations = $"Congrats {((Person)sender).Name}, you're already {args.NewAge}, I remember the time you were {args.OldAge}";
        Console.WriteLine(congratulations);
    }
}
