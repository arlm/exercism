using System;
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

    public List<Tree> Children { get; } = new List<Tree>();

    public bool IsLeaf => Children.Count == 0;

    public static explicit operator Tree(TreeBuildingRecord obj) =>
        new Tree
        {
            Id = obj.RecordId,
            ParentId = obj.ParentId
        };
}

public static class TreeBuilder
{
    public static Tree BuildTree(IEnumerable<TreeBuildingRecord> records)
    {
        if (!(records?.Any() ?? false))
        {
            throw new ArgumentException();
        }

        var trees = new List<Tree>();
        var previousRecordId = 0;

        foreach (var record in records.OrderBy(record => record.RecordId))
        {
            var item = (Tree)record;

            ValidateRecord(previousRecordId, item);

            trees.Add(item);

            previousRecordId++;
        }

        foreach(var item in trees.Skip(1))
        {
            trees.First(x => x.Id == item.ParentId).Children.Add(item);
        }

        return trees.First(t => t.Id == 0);
    }

    private static void ValidateRecord(int previousRecordId, Tree item)
    {
        if (item.Id == 0 && item.ParentId == 0)
        {
            // It is the root item
            return;
        }

        if (item.ParentId < item.Id && item.Id == previousRecordId)
        {
            // It is a valid regular item
            return;
        }

        throw new ArgumentException();
    }
}