namespace event_exercise;

public class AgeChangedArgs : EventArgs
{
    public short OldAge { get; }        // 😉 most often read-only...
    public short NewAge { get; }

    public AgeChangedArgs(short oldAge, short newAge)
    {
        OldAge = oldAge;
        NewAge = newAge;
    }
}
