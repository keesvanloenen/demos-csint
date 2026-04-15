namespace InsuranceCompany.App.Insurances;

public class TravelInsurance : Insurance, IPremiumCalculator
{
    public decimal? Premium { get; set; }

    public static decimal CalculateAgePremium(int customerAge)
    {
        return 100m + (customerAge * 2m);
    }

    public void CalculatePremium()
    {
        Console.WriteLine("⚙️ Calculate premium for TravelInsurance");
        Premium = 150m;
    }
}
