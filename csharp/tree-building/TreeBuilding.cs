﻿using System;
using System.Collections.Generic;
using System.Linq;

public class TreeBuildingRecord
{
    public int ParentId { get; set; }
    public int RecordId { get; set; }
}

public class Tree
{
    public int Id { get; set; }
    public int ParentId { get; set; }

    public List<Tree> Children { get; set; }

    public bool IsLeaf => Children.Count == 0;
}

public static class TreeBuilder
{
    public static Tree BuildTree(IEnumerable<TreeBuildingRecord> records)
    {
        var ordered = new SortedList<int, TreeBuildingRecord>(
            records.ToDictionary(record => record.RecordId));

        records = ordered.Values;

        var trees = new List<Tree>();
        var previousRecordId = -1;

        foreach (var record in records)
        {
            var t = new Tree { Children = new List<Tree>(), Id = record.RecordId, ParentId = record.ParentId };
            trees.Add(t);

            ValidateRecord(previousRecordId, t);

            previousRecordId++;
        }

        if (trees.Count == 0)
        {
            throw new ArgumentException();
        }

        for (int i = 1; i < trees.Count; i++)
        {
            var t = trees.First(x => x.Id == i);
            var parent = trees.First(x => x.Id == t.ParentId);
            parent.Children.Add(t);
        }

        return trees.First(t => t.Id == 0);
    }

    private static void ValidateRecord(int previousRecordId, Tree t)
    {
        if (t.Id == 0 && (t.ParentId != 0))
        {
            throw new ArgumentException();
        }

        if (t.Id != 0 && (t.ParentId >= t.Id || t.Id != previousRecordId + 1))
        {
            throw new ArgumentException();
        }
    }
}