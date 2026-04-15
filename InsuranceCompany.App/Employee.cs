using InsuranceCompany.App.Insurances;

namespace InsuranceCompany.App;

public class Employee
{
    public required string Name { get; init; }

    public void OnClaimSubmitted(object sender, ClaimArgs e)
    {
        Console.WriteLine($"🚨 Insurance {((Insurance)sender).Code}: {e.Amount:C} - {e.Description}");
    }
}

