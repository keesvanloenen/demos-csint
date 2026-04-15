using System.Collections;

namespace InsuranceCompany.App;

public class DamageCollection : IEnumerable<Damage>
{
    private Damage[] _damages;      // field where the damages are really stored

    public int Count { get; set; }

    //private int _count;

    //public int Count
    //{
    //    get {  
    //        // ....
    //        return _count; }
    //    set { _count = value; }
    //}

    public Damage this[int index]       //  ☀️ indexer
    {
        get 
        {
            CheckBounds(index);
            return _damages[index]; 
        }
        set 
        {
            CheckBounds(index);
            _damages[index] = value; 
        }
    }

    public Damage? this[string description]
    {
        get => _damages.Take(Count).FirstOrDefault(d => d.Description == description);
    }

    private void CheckBounds(int index)
    {
        if (index < 0 || index > Count)
        {
            throw new IndexOutOfRangeException();
        }
    }

    public DamageCollection(int initialCapacity = 4)
	{
		_damages = new Damage[initialCapacity];
        Count = 0;
	}

    internal void Add(Damage damage)
    {
        if (Count >= _damages.Length)
        {
            Array.Resize(ref _damages, _damages.Length * 2);
        }

        _damages[Count++] = damage;
    }

    // Implementation 1 using yield return:
    //public IEnumerator<Damage> GetEnumerator()
    //{
    //    for (var i = 0; i < Count; i++)
    //    {
    //        yield return _damages[i];
    //    }
    //}

    // Implementation 2 using an explicit DamageEnumerator class:
    public IEnumerator<Damage> GetEnumerator()
    {
        return new DamageEnumerator(_damages, Count);
    }


    private class DamageEnumerator : IEnumerator<Damage>
    {
        private readonly Damage[] _damages;
        private readonly int _count;
        private int _index = -1;

        public DamageEnumerator(Damage[] damages, int count)
        {
            _damages = damages;
            _count = count;
        }

        public Damage Current => _damages[_index];

        // The old one which must be implemented. It's using EXPLICIT INTERFACE IMPLEMENTATION
        // as two methods with the same name are not allowed ...
        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            _index++;
            return _index < _count;
        }

        public void Reset()
        {
            _index = -1;
        }

        public void Dispose()
        {
            // Nothing to do here 😄
        }
    }


    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    // Old non-generic GetEnumerator()
    //public IEnumerator GetEnumerator()
    //{
    //    var dummy = new Damage { Amount = 1000000m, DamageDate = DateTime.Now };

    //    for (var i = 0; i < Count; i++)
    //    {
    //        yield return _damages[i];

    //        //yield return (i % 2 == 0) ?
    //        //             dummy :
    //        //             _damages[i];

    //    }
    //}
}
