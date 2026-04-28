using System;
class Program
{
    static void Main()
    {
        MyList list = new MyList();

        list.Add(10);
        list.Add(20);
        list.Add(30);

        list.Print();
        
        list.AddRange(new int[] { 40, 50 });

        list.Print();

        list.Remove(20);
        list.Print();

        int value;

        list.TryGet(1, out value);

        list.IndexOf(30);
        list.Contains(50);
        list.Clear();
    }
}
class MyList
{
    private int[] _items;
    private int _count;

    public MyList()
    {
        _items = new int[4];
        _count = 0;
    }
    public void Add(int item)
    {
        EnsureCapacity();

        _items[_count] = item;
        _count++;
    }
    public void AddRange(int[] items)
    {
        if (items == null)
            return;

        for (int i = 0; i < items.Length; i++)
        {
            Add(items[i]);
        }
    }
    public bool Remove(int item)
    {
        for (int i = 0; i < _count; i++)
        {
            if (_items[i] == item)
            {
                for (int j = i; j < _count - 1; j++)
                {
                    _items[j] = _items[j + 1];
                }

                _count--;
                return true;
            }
        }

        return false;
    }
    public bool TryGet(int index, out int value)
    {
        if (index < 0 || index >= _count)
        {
            value = 0;
            return false;
        }

        value = _items[index];
        return true;
    }
    public int IndexOf(int item)
    {
        for (int i = 0; i < _count; i++)
        {
            if (_items[i] == item)
                return i;
        }

        return -1;
    }
    public bool Contains(int item)
    {
        return IndexOf(item) != -1;
    }
    public void Clear()
    {
        _count = 0;
    }
    public int this[int index]
    {
        get
        {
            if (index < 0 || index >= _count)
                throw new IndexOutOfRangeException();

            return _items[index];
        }
        set
        {
            if (index < 0 || index >= _count)
                throw new IndexOutOfRangeException();

            _items[index] = value;
        }
    }
    public int Count
    {
        get { return _count; }
    }

    public void Print() 
    {
        for (int i = 0; i < _count; i++)
            Console.Write(_items[i] + " ");

        Console.WriteLine("");
    }

    private void EnsureCapacity()
    {
        if (_count < _items.Length)
            return;

        int newSize = _items.Length * 2;
        int[] newArray = new int[newSize];

        for (int i = 0; i < _items.Length; i++)
        {
            newArray[i] = _items[i];
        }

        _items = newArray;
    }
}
