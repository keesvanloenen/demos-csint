namespace event_exercise;

public class Person
{
    public event EventHandler<AgeChangedArgs>? AgeChanged;

    public string Name { get; set; } = null!;

    public short Age {
        get;
        set
        {
            if (field == value) return;     // tip Nick
            OnAgeChanged(new AgeChangedArgs(field, value));
            field = value;
        }
    }

    public Person(string name, short age)
    {
        Name = name;
        Age = age;
    }

    public void AgeUp() => Age++;

    protected virtual void OnAgeChanged(AgeChangedArgs args) 
    {
        AgeChanged?.Invoke(this, args);
    }
    
    public override string ToString() => $"{Name} is {Age} year";
}

