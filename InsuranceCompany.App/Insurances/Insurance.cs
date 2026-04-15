namespace InsuranceCompany.App.Insurances;

public class Insurance
{
    public string? Code { get; set; }
    public Customer? Customer { get; set; }

    public void Deconstruct(out string? code, out Customer? customer)
    {
        code = Code;
        customer = Customer;
    }

    public void PrintThePolis()
    {
        // solution Kees
        ((IPremiumCalculator)this).PrintPolis();
    }
}
