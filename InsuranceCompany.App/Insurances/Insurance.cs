namespace InsuranceCompany.App.Insurances;

//public delegate void InsuranceHandler(object sender, ClaimArgs e);


public class Insurance
{
    public string? Code { get; set; }
    public Customer? Customer { get; set; }

    public decimal PaidClaims { get; private set; }

    //public event InsuranceHandler? ClaimSubmitted;
    public event EventHandler<ClaimArgs>? ClaimSubmitted;
    //      👆           👆              👆
    //     soon         type          event name

    public void ProcessClaim(decimal amount, string description)
    {
        PaidClaims += amount;

        if (amount > 1000)
        {
            var args = new ClaimArgs { Amount = amount, Description = description };
            ClaimSubmitted?.Invoke(this, args);

            //if (ClaimSubmitted is null)
            //{
            //    return;
            //}
            
            //ClaimSubmitted(this, "Warning: Amount above 1000€");
            
        }
    }

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
