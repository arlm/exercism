using System;
using System.Linq;

public class CircularBuffer<T>
{
    private readonly T[] buffer;

    private int readIndex;

    private int ReadIndex
    {
        get => readIndex % Capacity;
        set => readIndex = value % Capacity;
    }

    private int startIndex;

    private int StartIndex
    {
        get => startIndex % Capacity;
        set => startIndex = value % Capacity;
    }

    private int NextReadIndex
        => (readIndex + 1) % Capacity;

    private int writeIndex;

    private int WriteIndex
    {
        get => writeIndex % Capacity;
        set => writeIndex = value % Capacity;
    }

    private int NextWriteIndex
        => (writeIndex + 1) % Capacity;

    public int Capacity { get; }

    public int Size { get; private set; }

    public bool IsEmpty
        => startIndex == -1
            || Capacity == 0
            || Size == 0;

    public bool IsFull
        => Size == Capacity;

    private bool HasCycled
        => WriteIndex < StartIndex
            || WriteIndex < ReadIndex;

    private bool CanWrite
        => IsEmpty || !IsFull;

    private bool CanRead =>
        !IsEmpty
        && Size > 0
        && HasCycled
            ? ReadIndex <= WriteIndex || ReadIndex >= StartIndex
            : ReadIndex <= WriteIndex && ReadIndex >= StartIndex;
    public CircularBuffer(int capacity)
    {
        Capacity = capacity;
        buffer = new T[capacity];

        Clear(isNew: true);
    }

    public T Read()
    {
        if (IsEmpty)
        {
            throw new InvalidOperationException("Empty circular buffer.");
        }

        if (!CanRead)
        {
            throw new InvalidOperationException("Reached end of the circular buffer.");
        }

        var value = buffer[ReadIndex];
        Size--;
        readIndex++;
        StartIndex = ReadIndex;

        return value;
    }

    public void Write(T value)
    {
        if (!CanWrite)
        {
            throw new InvalidOperationException("Reached end of the circular buffer.");
        }

        if (IsEmpty)
        {
            startIndex = writeIndex;
        }

        buffer[WriteIndex] = value;
        Size++;
        writeIndex++;
    }

    public void Overwrite(T value)
    {
        if (IsFull)
        {
            writeIndex = StartIndex;
            Size--;
            StartIndex++;

            if (WriteIndex == ReadIndex)
            {
                ReadIndex++;
            }
        }
        Write(value);
    }

    public void Clear(bool isNew = false)
    {
        if (!isNew)
        {
            for (int index = 0; index < Capacity; index++)
            {
                buffer[index] = default;
            }
        }

        Size = 0;
        startIndex = -1;
        readIndex = 0;
        writeIndex = 0;
    }

    public override string ToString() => $"[{string.Join(", ", buffer.Select(item => item.ToString()))}]";
}