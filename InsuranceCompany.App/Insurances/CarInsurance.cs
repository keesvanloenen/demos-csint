namespace InsuranceCompany.App.Insurances;

public class CarInsurance : Insurance, IPremiumCalculator
{
    public decimal? Premium { get; set; }

    public static decimal CalculateAgePremium(int customerAge)
    {
        return 50m + (customerAge > 60 ? 0m : 25m);
    }

    public void CalculatePremium()
    {
        Console.WriteLine("⚙️ Calculate premium for CarInsurance");
        Premium = 100m;
    }

    public void PrintPolis()
    {
        // solution Eva
        base.PrintThePolis();
    }
}
