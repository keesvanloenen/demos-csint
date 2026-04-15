namespace QuestionKelvin;

public class Person
{
    public string Name { get;  }
    public int Age { get; }
    public string City { get; }
    public string? ZipCode { get; }


    // Constructor 1 (most complete)
    public Person(string name, int age, string city)
    {
        this.Name = name;
        this.Age = age;
        this.City = city;
    }

    // Constructor 2 → calls constructor 1
    public Person(string name, int age)
        : this(name, age, "Unknown")
    {
    }

    // Constructor 3 → calls constructor 2
    public Person(string name)
        : this(name, 0)
    {
    }

    // Extra
    public Person(string name, int age, string city, string zipCode)
        : this(name, age, city)
    {
        this.ZipCode = zipCode;
    }

    // ToString override
    public override string ToString()
    {
        return $"Name: {Name}, Age: {Age}, City: {City}, ZipCode: {ZipCode}";
    }
}
