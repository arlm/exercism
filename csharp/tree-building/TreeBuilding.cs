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

        var hasInvalidItems = orderedRecords.Where((r, index) =>
             r.RecordId != index ||
            (r.RecordId == 0 && r.ParentId != 0) ||
            (r.RecordId != 0 && r.ParentId >= r.RecordId)).Any();

        if (hasInvalidItems)
        {
            throw new ArgumentException();
        }

        var trees = new List<Tree>();

        foreach (var record in orderedRecords)
        {
            var item = new Tree(record);

            if (item.RecordId != 0)
                trees.First(leaf => leaf.RecordId == item.ParentId).Children.Add(item);

            trees.Add(item);
        }

        return trees.First(t => t.RecordId == 0);
    }
}