using System.Collections;

namespace InsuranceCompany.App;

public class MyList<T> : IEnumerable<T>
{
    private T[] _items;      // field where the damages are really stored

    public int Count { get; set; }

    public T this[int index]       //  ☀️ indexer
    {
        get 
        {
            CheckBounds(index);
            return _items[index]; 
        }
        set 
        {
            CheckBounds(index);
            _items[index] = value; 
        }
    }

    //public Damage? this[string description]
    //{
    //    get => _items.Take(Count).FirstOrDefault(d => d.Description == description);
    //}

    private void CheckBounds(int index)
    {
        if (index < 0 || index > Count)
        {
            throw new IndexOutOfRangeException();
        }
    }

    public MyList(int initialCapacity = 4)
	{
		_items = new T[initialCapacity];
        Count = 0;
	}

    internal void Add(T item)
    {
        if (Count >= _items.Length)
        {
            Array.Resize(ref _items, _items.Length * 2);
        }

        _items[Count++] = item;
    }

    // Implementation 1 using yield return:
    public IEnumerator<T> GetEnumerator()
    {
        for (var i = 0; i < Count; i++)
        {
            yield return _items[i];
        }
    }




    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

}
