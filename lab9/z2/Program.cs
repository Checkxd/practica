using System;

public class MyCircularBuffer<T>
{
    private T[] buffer;
    private int head;
    private int tail;
    private int size;
    private int capacity;

    public MyCircularBuffer(int capacity)
    {
        this.capacity = capacity;
        buffer = new T[capacity];
        head = 0;
        tail = 0;
        size = 0;
    }

    public void Add(T item)
    {
        buffer[tail] = item;
        tail = (tail + 1) % capacity;
        if (size < capacity)
        {
            size++;
        }
        else
        {
            head = (head + 1) % capacity;
        }
    }

    public T Remove()
    {
        if (size == 0) throw new InvalidOperationException("Buffer is empty");
        T item = buffer[head];
        buffer[head] = default(T);
        head = (head + 1) % capacity;
        size--;
        return item;
    }

    public T Peek()
    {
        if (size == 0) throw new InvalidOperationException("Buffer is empty");
        return buffer[head];
    }

    public int Count => size;
}

public class BufferController<T>
{
    private MyCircularBuffer<T> buffer;

    public BufferController(int capacity)
    {
        buffer = new MyCircularBuffer<T>(capacity);
    }

    public void AddItem(T item)
    {
        buffer.Add(item);
    }

    public T RemoveItem()
    {
        return buffer.Remove();
    }

    public T PeekItem()
    {
        return buffer.Peek();
    }

    public int GetCount()
    {
        return buffer.Count;
    }
}

class Program
{
    static void Main()
    {
        BufferController<int> controller = new BufferController<int>(3);
        controller.AddItem(1);
        controller.AddItem(2);
        controller.AddItem(3);
        controller.AddItem(4);
        Console.WriteLine(controller.PeekItem());
        Console.WriteLine(controller.RemoveItem());
        Console.WriteLine(controller.GetCount());
    }
}