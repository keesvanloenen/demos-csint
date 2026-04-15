namespace InsuranceCompany.App;

// cw
// prop
// ctor

public class Customer
{
    public int Id { get; set; }          // non-nullable value type
    public string Name { get; set; }     // non-nullable reference type

    public ContactPreference contactPreference { get; set; } = ContactPreference.Email;
    public Customer(string name) 
    {
        Name = name;
    }
}
