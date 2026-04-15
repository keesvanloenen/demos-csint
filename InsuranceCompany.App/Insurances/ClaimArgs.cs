namespace InsuranceCompany.App.Insurances;

public class ClaimArgs : EventArgs
{
    public string? Description { get; set; }
    public decimal Amount { get; set; }
}
