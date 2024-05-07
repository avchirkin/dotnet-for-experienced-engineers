namespace GenericsExamples.GenericType;

// Пример generic-класса с одним параметром типа
public sealed class FixedStack<T>
{
    private readonly T[] _items;
    private int _lastIndex = -1;

    public FixedStack(int storageSize)
    {
        _items = new T[storageSize];
    }
    
    public void Put(T item)
    {
        var nextIndex = _lastIndex + 1;
        if (nextIndex >= _items.Length)
        {
            throw new StackIsFullException();
        }

        _items[nextIndex] = item;
        _lastIndex = nextIndex;
    }

    public void Put(params T[] items)
    {
        foreach (var item in items)
        {
            Put(item);
        }
    }
    
    public T Get()
    {
        if (_lastIndex < 0)
        {
            throw new StackIsEmptyException();
        }
        
        return _items[_lastIndex--];
    }
}