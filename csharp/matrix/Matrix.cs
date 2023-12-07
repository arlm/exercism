using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Matrix
{
    readonly int[][] matrix;

    public Matrix(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            throw new ArgumentException($"'{nameof(input)}' cannot be null or whitespace.", nameof(input));
        }

        List<int[]> lines = new();

        using (var reader = new StringReader(input))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                var columns = line
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                    .Select(item => int.Parse(item))
                    .ToArray();

                lines.Add(columns);
            }
        }

        if (!lines.All(line => line.Length == lines[0].Length))
        {
            throw new ArgumentNullException(nameof(input), "All lines in the matrix should have the same length");
        }

        matrix = lines.ToArray();
    }

    public int[] Row(int row) => matrix[row - 1];

    public int[] Column(int col) => matrix.Select(line => line[col - 1]).ToArray();
}