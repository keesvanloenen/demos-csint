namespace InsuranceCompany.App;

public record struct Damage(string Description, decimal Amount, DateTime DamageDate) : IComparable<Damage>
{
    public int CompareTo(Damage other)
    {
        //if (other is null) return 0;
        if (Amount < other.Amount) return -1;
        if (Amount > other.Amount) return 1;
        return 0;
    }
}