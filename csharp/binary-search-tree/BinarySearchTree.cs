using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class BinarySearchTree : IEnumerable<int>
{
    public BinarySearchTree(int value) => Value = value;

    public BinarySearchTree(IEnumerable<int> values)
    {
        Value = values.First();

        foreach (var item in values.Skip(1))
        {
            Add(item);
        }

    }

    public int Value { get; }

    public BinarySearchTree Left { get; private set; }

    public BinarySearchTree Right { get; private set; }

    public BinarySearchTree Add(int value)
    {
        if (value > Value)
        {
            if (Right is null)
            {
                Right = new BinarySearchTree(value);
                return Right;
            }

            return Right.Add(value);
        }

        if (value <= Value)
        {
            if (Left is null)
            {
                Left = new BinarySearchTree(value);
                return Left;
            }

            return Left.Add(value);
        }

        return null;
    }

    public IEnumerator<int> GetEnumerator()
    {
        if (Left is not null)
        {
            foreach (var item in Left)
            {
                yield return item;
            }
        }

        yield return Value;

        if (Right is not null)
        {
            foreach (var item in Right)
            {
                yield return item;
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public override string ToString() => $"{{Value: {Value} / Left: {Left?.ToString() ?? "null"} / Right:{Right?.ToString() ?? "null"} }}";
}