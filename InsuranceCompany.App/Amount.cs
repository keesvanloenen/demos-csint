namespace InsuranceCompany.App;

// readonly = tip! because immutable
// properties cannot be modified after initialization
// thread-safe
// the compiler can apply optimizations

public readonly struct Amount
{
    public decimal Value { get; }
    public string Currency { get; }

    public Amount(decimal value, string currency = "EUR") 
    {
        if (value < 0)
        {
            throw new ArgumentException("Amount cannot be negative");
        }

        Value = value;
        Currency = currency;

    }

    public static implicit operator Amount(decimal value) => new Amount(value);
    public static implicit operator Amount(int value) => new Amount((decimal)value);

    public static explicit operator decimal(Amount amount) => amount.Value;

    public static Amount operator +(Amount a, Amount b) => a.Add(b);

    public Amount Add(Amount other)
    {
        if (Currency != other.Currency) 
        {
            throw new InvalidOperationException("Currencies must match");
        }
        return new Amount(Value + other.Value, Currency);

    }

    public override string ToString()
    {
        return $"{Currency} {Value}";
    }
}
