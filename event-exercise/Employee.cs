namespace event_exercise;

public class Employee : Person
{
    public decimal Salary { get; private set; }

	public Employee(string name, short age, decimal salary) : base(name, age)
	{
		Salary = salary;
	}

    protected override void OnAgeChanged(AgeChangedArgs args)
    {
        Salary += 10m;
        base.OnAgeChanged(args);
    }

	public override string ToString() => $"{base.ToString()}, salary: {Salary}";
    
}
