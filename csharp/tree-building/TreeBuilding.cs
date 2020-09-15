using System;
using System.Collections.Generic;
using System.Linq;

public class TreeBuildingRecord
{
    public int ParentId { get; set; }
    public int RecordId { get; set; }
}

public class Tree : TreeBuildingRecord
{
    public Tree(TreeBuildingRecord record)
    {
        ParentId = record.ParentId;
        RecordId = record.RecordId;

        if (RecordId == 0)
        {
            if (ParentId != 0)
                throw new ArgumentException();
        }
        else if (ParentId >= RecordId)
        {
            throw new ArgumentException();
        }
    }

    public List<Tree> Children { get; } = new List<Tree>();

    public bool IsLeaf => Children.Count == 0;

}

public static class TreeBuilder
{
    public static Tree BuildTree(IEnumerable<TreeBuildingRecord> records)
    {
        _ = records ?? throw new ArgumentException();

        if (!records.Any())
        {
            throw new ArgumentException();
        }

        var orderedRecords = records.OrderBy(record => record.RecordId);

        var trees = orderedRecords
            .Select((record, index) => record.RecordId == index ? new Tree(record) : throw new ArgumentException())
            .ToList();

        foreach (var record in trees.Skip(1))
        {
            trees.First(parent => parent.RecordId == record.ParentId).Children.Add(record);
        }

        return trees.First(t => t.RecordId == 0);
    }
}