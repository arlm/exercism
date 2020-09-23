using System;
using System.Collections.Generic;

public class StackDeque<T>
{
    private readonly Stack<T> stack = new Stack<T>();

    public void Push(T value)
    {
        stack.Push(value);
    }

    public T Pop()
    {
        return stack.Pop();
    }
}