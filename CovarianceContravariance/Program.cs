namespace CovarianceContravariance;

public record Fruit(string Name, int Size);
public record Apple(string Name, int Size) : Fruit(Name, Size);
public record Banana(string Name, int Size) : Fruit(Name, Size);

public class FruitComparer : IComparer<Fruit>       //👈 IComparer is CONTRAVARIANT interface!
{
    public int Compare(Fruit? a, Fruit? b)
    {
        if (a is null & b is null) return 0;
        if (a is null) return -1;
        if (b is null) return 1;

        return a.Size.CompareTo(b.Size);
    }
}

// -----------------------------------------------

internal class Program
{
    // Reusable list of 3 apples
    private static readonly List<Apple> _apples =
    [
        new ("Braeburn", 1),
        new ("Fiji", 3),
        new ("Elstar", 2),
    ];

    static void Main(string[] args)
    {
        Show(_apples);      // Covariant demo
        
        Console.WriteLine();

        AppleSorter(new FruitComparer(), _apples);
        Show(_apples);
    }

    static void Show(IEnumerable<Fruit> fruits)
    {
        // IEnumerable is COVARIANT interface
        // Where a bag of fruit is expected a bag of apples can be passed

        foreach (var fruit in fruits)
        {
            Console.WriteLine(fruit);
        }

        // fruits[0] = new Banana { Name = "Chiquita" };   // Not allowed as IEnumberable is covariant = readonly = out-only
    }

    static void AppleSorter(IComparer<Apple> appleComparer, List<Apple> apples)   
    {
        // IComparer is a CONTRAVARIANT interface
        // Where an appleComparer is expected a fruitComparer can be passed
        _apples.Sort(appleComparer);
    }
}
