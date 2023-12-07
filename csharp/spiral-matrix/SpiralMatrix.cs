using System;

public class SpiralMatrix
{
    public static int[,] GetMatrix(int size)
    {
        var result = new int[size, size];

        if (size == 0)
        {
            return result;
        }

        var position = new Position(0, 0, size);
        var direction = Direction.Right;
        int finalNumber = size * size;

        for (int number = 1; number <= finalNumber; number++)
        {
            result.Set(position, number);

            var nextPosValue = result.GetNext(position, direction);

            if (nextPosValue > 0)
            {
                direction = Position.NextDirection(direction);
            }

            (position, direction) = position.Move(direction);
        }

        return result;
    }
}

public enum Direction
{
    Up,
    Down,
    Left,
    Right
}

internal static class Helpers
{
    public static int GetNext(this int[,] matrix, Position position, Direction direction)
    {
        (var nextPos, _) = position.Move(direction);
        return matrix[nextPos.Row, nextPos.Column];
    }

    public static void Set(this int[,] matrix, Position position, int value) => matrix[position.Row, position.Column] = value;
}

internal record struct Position(int Row, int Column, int Size)
{
    public int Size { get; set; } = Size < 0 ? throw new ArgumentException("Cannot be negative", nameof(Size)) : Size;
    public int Row { get; set; } = Row;
    public int Column { get; set; } = Column;

    public readonly bool IsAtLastRow => Row == Size - 1;

    public readonly bool IsAtLastColumn => Column == Size - 1;

    public readonly bool IsAtFirstRow => Row == 0;

    public readonly bool IsAtFirstColumn => Column == 0;

    public readonly int ActualRow => Row % Size;

    public readonly int ActualColumn => Column % Size;

    public static Position operator +(Position value, Position other)
    {
        if (value.Size != other.Size)
        {
            throw new ArgumentException("Both sizes must be equal", nameof(other));
        }

        var newRow = value.ActualRow + other.ActualRow;
        var newColumn = value.ActualColumn + other.ActualColumn;

        if (newRow < 0)
        {
            newRow += value.Size + 0;
        }

        if (newColumn < 0)
        {
            newColumn += value.Size + 0;
        }

        return new(newRow % value.Size, newColumn % value.Size, value.Size);
    }

    public readonly bool Equals(Position other)
    => this.Size == other.Size
        && this.ActualRow == other.ActualRow
        && this.ActualColumn == other.ActualColumn;

    public override readonly int GetHashCode() => HashCode.Combine(Size, Row, Column);

    public override readonly string ToString() => $"{{Row: {Row}, Column: {Column}, Size: {Size}}}";

    public readonly (Position Position, Direction Direction) Move(Direction direction)
    => this.Size <= 1
            ? (this, direction)
            : direction switch
            {
                Direction.Up => IsAtFirstRow
                    ? Move(NextDirection(direction))
                    : (this + new Position(Row: -1, Column: 0, Size: this.Size), direction),

                Direction.Down => IsAtLastRow
                    ? Move(NextDirection(direction))
                    : (this + new Position(Row: 1, Column: 0, Size: this.Size), direction),

                Direction.Left => IsAtFirstColumn
                    ? Move(NextDirection(direction))
                    : (this + new Position(Row: 0, Column: -1, Size: this.Size), direction),

                Direction.Right => IsAtLastColumn
                    ? Move(NextDirection(direction))
                    : (this + new Position(Row: 0, Column: 1, Size: this.Size), direction),

                _ => throw new ArgumentException("Unkwnown direction", nameof(direction)),
            };

    public static Direction NextDirection(Direction direction)
    => direction switch
    {
        Direction.Up => Direction.Right,
        Direction.Down => Direction.Left,
        Direction.Left => Direction.Up,
        Direction.Right => Direction.Down,
        _ => throw new ArgumentException("Unkwnown direction", nameof(direction)),
    };
}