using InsuranceCompany.App.Insurances;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Text;

namespace InsuranceCompany.App;

internal class Program
{
    static void Main(string[] args)
    {
         Console.OutputEncoding = Encoding.UTF8;

        //DemoNullableValueType();
        //DemoInsuranceAndCustomer();
        //DemoStruct();
        //DemoEnum();
        //DemoTuple();
        //DemoCalculatePayout();
        //DemoDeconstruct();
        //DemoRecord();
        //DemoCollection();
        //DemoEvaChecked();
        //DemoCollectionInitializer();
        //DemoInterface();
        //DemoStaticInInterface(); 
        //DemoVariadic();
        //DemoPatternMatching();
        //DemoTypeConversions();
        //DemoRealConversions();
        //DemoUserDefinedConversions();
        //DemoUserDefinedOperators();

        DemoEvents();

    }

    private static void DemoEvents()
    {
        var insurance = new CarInsurance
        {
            Code = "AUTO-001",
            Customer = new Customer("Namdar Abdulrahman"),
        };

        Console.WriteLine($"Insurance: {insurance.Code}");
        Console.WriteLine($"Customer: {insurance.Customer.Name}");

        // SUBSCRIBE !!!
        insurance.ClaimSubmitted += MethodOfAnInterestedSubscriber;

        // Process claims
        insurance.ProcessClaim(3000m, "Car repair after heavy collision");
        Console.WriteLine($"Total paid out: {insurance.PaidClaims:C}");

        insurance.ProcessClaim(2500m, "Replacing parts");
        Console.WriteLine($"Total paid out: {insurance.PaidClaims:C}");
    }

    private static void MethodOfAnInterestedSubscriber(object sender, ClaimArgs e)
    {
        Console.WriteLine($"🚨 Insurance {((Insurance)sender).Code}: {e.Amount:C} - {e.Description}");
    }
    private static void DemoUserDefinedOperators()
    {
        var amount1 = new Amount(150.34m);
        var amount2 = new Amount(200m);

        Console.WriteLine(amount1 + amount2);
    }

    private static void DemoUserDefinedConversions()
    {
        // Implicit conversion
        Amount amount = 6.14m;                   // -> 6.14 -> 6.14 EUR

        // Explicit conversion
        decimal decimalNumber = (decimal)amount; // 6.14 EUR -> 6.14

    }

    private static void DemoRealConversions()
    {

        int number = 42;
        double doubleValue = number;        // implicit (no data loss)

        Console.WriteLine(number);

        double pi = 3.14;
        int rounded = (int)pi;             // explicit (data loss)
        Console.WriteLine(rounded);         

    }

    private static void DemoTypeConversions()
    {
        int number = 42;

        object obj = number;       // Upcasting (and boxing: value type => reference type)
        Console.WriteLine(obj);
        int backToInt = (int)obj;   // Downcasting (and unboxing)

        Console.WriteLine(backToInt);
    }

    private static void DemoPatternMatching()
    {
        //if (obj.GetType() == typeof(string))      // old 1
        //var value = obj as string;                // old 2

        // Type Pattern (is operator)
        object obj = "Hello";

        if (obj is string)                          // new 3
        {
            Console.WriteLine(((string)obj).Length);
        }

        // Declaration
        if (obj is string s)
        {
            Console.WriteLine(s.Length);
        }

        // Constant Pattern
        List<Customer> customers = [new Customer("Ab"), new Customer("Heinrich")];
        
        if (customers is List<Customer>)
        {
            Console.WriteLine("Is List<Customer>");
        }

        // Null Pattern
        string? text = null;

        if (text is null)           // is not overwritable, (== is overwritable)
        {
            Console.WriteLine("Is null");
        }

        // Relational Pattern
        int age = 20;

        // if (age >= 18 && age <= 21)
        if (age is >= 18 and <= 21)
        {
            Console.WriteLine("Young adult");
        }

        // Property Pattern
        if (customers[0] is { Name: "Ab", Name.Length: 2 })
        {
            Console.WriteLine("First customer is Ab");
        }

        // Switch statement old-fashioned

        string ageCategory;

        switch (age)
        {
            case 0:
                ageCategory = "Infant";
                break;
            case < 18:      // Relational Pattern 😉
                ageCategory = "Child";
                break;
            case < 21:
                ageCategory = "Young Adult";
                break;
            case < 75:
                ageCategory = "Adult";
                break;
            default:
                ageCategory = "Elderly";
                break;
        }

        Console.WriteLine(ageCategory);

        string ageCategory2 = age switch
        {
            0 => "Infant",
            < 18 => "Child",
            < 21 => "Young Adult",
            < 75 => "Adult",
            _ => "Elderly"
        };

        Console.WriteLine(ageCategory2);
    }

    private static void DemoVariadic()
    {
        PrintCharacters('a', 'b', 'c', 'd');
        PrintCharacters([ 'd', 'e', 'f' ]);
    }

    private static void PrintCharacters(params IEnumerable<char> characters)
    {
        foreach(char c in characters)
        {
            Console.Write(c);
        }
    }

    private static void DemoStaticInInterface()
    {
        // static abstract members: implementations must provide these
        // static virtual members: implementations can override these (with their own behaviour)

        decimal carPremium = CarInsurance.CalculateAgePremium(53);
        decimal carPremium2 = CarInsurance.CalculateAgePremium(61);

        Console.WriteLine($"{carPremium}, {carPremium2}");
    }

    private static void DemoInterface()
    {
        Insurance travelInsurance = new TravelInsurance { Code = "ABC123", Premium = 100m, Customer = new Customer("A. Janssen") };
        Console.WriteLine(travelInsurance.Code);

        ((IPremiumCalculator)travelInsurance).CalculatePremium();

        // Default implementation of normal method in interface:
        ((IPremiumCalculator)travelInsurance).PrintPolis();

        travelInsurance.PrintThePolis();
    }

    private static void DemoCollectionInitializer()
    {
        // List<char> characters = new List<char>() { 'b', 'c', 'd' };
        //                                            ^^^^^^^^^^^^^    coll initializer
        // List<char> characters = new() { 'b', 'c', 'd' };
        List<char> characters = ['b', 'c', 'd'];    // coll expression

        characters.AddRange(['e', 'f']);
        characters = ['a', .. characters, 'g', 'h'];

        foreach (var character in characters)
        {
            Console.WriteLine(character);
        }
    }

    private static void DemoEvaChecked()
    {
        int max = int.MaxValue;  // handy property on struct int: 2.147.483.647

        Console.WriteLine("--- Without checked ---");
        
        int overflow = max + 1;  // This gives: -2147483648 (it becomes negative)
        Console.WriteLine(overflow);

        // Why 🤯 ???

        // 01111111 11111111 11111111 11111111 (max)
        // +                                    1
        // ------------------------------------
        // 10000000 00000000 00000000 00000000


        Console.WriteLine("\n--- With checked ---");
        try
        {
            // This block checks on overflow
            checked
            {
                int correct = max + 1;  // Exception thanks to checked!
                Console.WriteLine(correct);
            }
        }
        catch (OverflowException e)
        {
            Console.WriteLine("Overflow exception: " + e.Message);
        }
    }



    private static void DemoCollection()
    {
        //var damageCollection = new DamageCollection();

        //var damage1 = new Damage("A", 1m, DateTime.Now);
        //var damage2 = new Damage("B", 2m, DateTime.Now);
        //var damage3 = new Damage("C", 3m, DateTime.Now);
        //var damage4 = new Damage("D", 4m, DateTime.Now);

        //damageCollection.Add(damage1);
        //damageCollection.Add(damage2);
        //damageCollection.Add(damage3);
        //damageCollection.Add(damage4);

        // thanks to the face my collection has got a. an Add() method and b. implements IEnumerable<Damage>:
        // Collection Initializer
        //var damageCollection = new DamageCollection()
        //{
        //    new ("A", 1m, DateTime.Now),
        //    new ("B", 1m, DateTime.Now),
        //    new ("C", 1m, DateTime.Now),
        //    new ("D", 1m, DateTime.Now),
        //};


        // Collection Expression
        DamageCollection damageCollection = 
        [
            new ("A", 1m, DateTime.Now),
            new ("B", 1m, DateTime.Now),
            new ("C", 1m, DateTime.Now),
            new ("D", 1m, DateTime.Now),
        ];


        Console.WriteLine(damageCollection[3].Description);
        Console.WriteLine(damageCollection.Count);

        for (var i = 0; i < damageCollection.Count;i++)
        {
            Console.WriteLine(damageCollection[i]);
        }

        Damage? damageB = damageCollection["B"];

        var amountForDamageB = damageB?.Amount.ToString() ?? "n/a";
        Console.WriteLine(amountForDamageB);

        foreach (var damage in damageCollection) 
        {
            Console.WriteLine(damage);
        }
    }

    private static void DemoRecord()
    {
        var now = DateTime.Now.AddDays(-1);
        var damage1 = new Damage("Car Accident", 1500m, now);

        // free ToString()
        Console.WriteLine(damage1);

        var damage2 = new Damage("Car Accident", 1500m, now);

        // free value-based (!) equality
        Console.WriteLine($"Damages are equal by == ? {damage1 == damage2}");
        Console.WriteLine($"Damages are equal by .Equals() ? {damage1.Equals(damage2)}");
        Console.WriteLine($"Damages are equal by .HashCode() ? {damage1.GetHashCode() == damage2.GetHashCode()}, show me: {damage2.GetHashCode()}");

        // free deconstruct
        var (_, Amount, DamageDate) = damage1;
        Console.WriteLine($"{Amount:C}");

        // free with support
        var damage3 = damage2 with { DamageDate = DateTime.Now.AddDays(-7) };
        Console.WriteLine(damage3);


    }

    private static void DemoDeconstruct()
    {
        Insurance insurance = new Insurance { Code = "BOAT-2026-001", Customer = new Customer("User 1") };
        var (code, _) = insurance;

        Console.WriteLine($"{code}");
    }

    private static void DemoCalculatePayout()
    {
        //var result = DamageCalculation.CalculatePayout(1500m, 600m);

        //Console.WriteLine($"Payout: {result.payout}");
        //Console.WriteLine($"Applied Deductible: {result.appliedDeductible}");

        //(decimal payout, decimal appliedDeductibleXXX) = DamageCalculation.CalculatePayout(1500m, 600m);

        //Console.WriteLine($"Payout: {payout}");
        //Console.WriteLine($"Applied Deductible: {appliedDeductibleXXX}");

        //(var payout, var appliedDeductibleXXX) = DamageCalculation.CalculatePayout(1500m, 600m);

        //Console.WriteLine($"Payout: {payout}");
        //Console.WriteLine($"Applied Deductible: {appliedDeductibleXXX}");

        var (payout, _) = DamageCalculation.CalculatePayout(1500m, 600m);

        Console.WriteLine($"Payout: {payout}");
        //Console.WriteLine($"Applied Deductible: {appliedDeductibleXXX}");
    }

    private static void DemoTuple()
    {
        //(string, decimal) premiumInfo = ("Boat Insurance", 110m);
        //Console.WriteLine($"Product: {premiumInfo.Item1}");
        //Console.WriteLine($"Premium: {premiumInfo.Item2}");

        (string Product, decimal Premium) premiumInfo = ("Boat Insurance", 110m);
        Console.WriteLine($"Product: {premiumInfo.Product}");
        Console.WriteLine($"Premium: {premiumInfo.Premium}");

        (string Name, decimal Premie) premiumInfo2 = ("Boat Insurance", 110m);
        Console.WriteLine($"Are equal: {premiumInfo == premiumInfo2}");
    }

    private static void DemoEnum()
    {
        Customer c1 = new Customer("Sonja Barend");
        c1.contactPreference = ContactPreference.Sms | ContactPreference.Phone | ContactPreference.Email;

        Console.WriteLine($"{c1.contactPreference} - {(ushort)c1.contactPreference}");

        if ((c1.contactPreference & (ContactPreference.Sms | ContactPreference.Email)) != 0)
        {
            Console.WriteLine("Customer prefers contact via SMS or email");
        }

        if ((c1.contactPreference.HasFlag(ContactPreference.Sms) || c1.contactPreference.HasFlag(ContactPreference.Email)))
        {
            Console.WriteLine("Customer prefers contact via SMS or email");
        }
    }

    private static void DemoStruct()
    {
        var amount1 = new Amount(120.50m);
        var amount2 = new Amount(130.50m);
        var total = amount1.Add(amount2);

        Console.WriteLine(total);
    }

    private static void DemoInsuranceAndCustomer()
    {
        Insurance insurance = new Insurance();
        Console.WriteLine($"Insurance code: {insurance.Code ?? "Not yet assigned"}");

        // Null-coalescing  assignment (??=)
        insurance.Code ??= "12345";
        
        Console.WriteLine($"Insurance code after assignment: {insurance.Code ?? "Not yet assigned"}");

        insurance.Customer = new Customer("Brad Pitt");
        Console.WriteLine($"Customer name: {insurance?.Customer?.Name}");
        Console.WriteLine($"Length name: {insurance!.Customer?.Name?.Length}");

    }

    private static void DemoNullableValueType()
    {
        //Nullable<decimal> premium = 32.50m;
        decimal? premium = null;

        // Console.WriteLine($"Premium: {(premium.HasValue ? premium.Value : "n/a")}");
        Console.WriteLine($"Premium: {(premium.ToString() ?? "n/a")} ");
    }
}
