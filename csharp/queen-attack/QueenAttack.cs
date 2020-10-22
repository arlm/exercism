using System;

public class Queen
{
    private const int BOARD_LIMIT = 8;

    public Queen(int row, int column)
    {
        if (row < 0 || row >= BOARD_LIMIT)
        {
            throw new ArgumentOutOfRangeException(nameof(row), row, "The value should be between 0 (inclusive) and 8 (exclusive)");
        }

        if (column < 0 || column >= BOARD_LIMIT)
        {
            throw new ArgumentOutOfRangeException(nameof(column), column, "The value should be between 0 (inclusive) and 8 (exclusive)");
        }

        Row = row;
        Column = column;
    }

    public int Row { get; }
    public int Column { get; }
}

public static class QueenAttack
{
    public static bool CanAttack(Queen white, Queen black)
    {
        var sameRow = white.Row == black.Row;
        var sameColumn = white.Column == black.Column;

        return sameRow || sameColumn || SameDiagonal(white, black);
    }

    private static bool SameDiagonal(Queen white, Queen black)
    {
        var adjustedRow = Math.Abs(white.Row - black.Row);
        var adjustedColumn = Math.Abs(white.Column - black.Column);

        return adjustedRow == adjustedColumn;
    }

    public static Queen Create(int row, int column) => new Queen(row, column);
}