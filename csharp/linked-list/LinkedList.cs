using System;
using System.Collections.Generic;

public class Deque<T>
{
    private readonly LinkedList<T> list = new LinkedList<T>();

    public void Push(T value)
    {
        list.AddLast(value);
    }

    public T Pop()
    {
        var item = list.Last;
        list.RemoveLast();
        return item.Value;
    }

    public void Unshift(T value)
    {
        list.AddFirst(value);
    }

    public T Shift()
    {
        var item = list.First;
        list.RemoveFirst();
        return item.Value;
    }
}