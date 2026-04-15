namespace InsuranceCompany.App.Insurances;

public interface IPremiumCalculator
{
    public decimal? Premium { get; }

    public void CalculatePremium();

    public void PrintPolis()
    {
        Console.WriteLine("Polis with Premium info is printed 🖨️");
    }

    static abstract decimal CalculateAgePremium(int customerAge);
}
