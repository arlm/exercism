using System;
using System.Collections.Generic;

public class QueueDeque<T>
{
    private readonly Queue<T> queue = new Queue<T>();

    public void Enqueue(T value)
    {
        queue.Enqueue(value);
    }

    public T Dequeue()
    {
        return queue.Dequeue();
    }
}