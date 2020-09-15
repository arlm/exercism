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
        if (!(records?.Any() ?? false))
        {
            throw new ArgumentException();
        }

        var trees = new List<Tree>();
        var index = 0;

        foreach (var record in records.OrderBy(record => record.RecordId))
        {
            var item = new Tree(record);

            ValidateRecord(index, item);

            if (item.RecordId != 0)
                trees.First(leaf => leaf.RecordId == item.ParentId).Children.Add(item);

            trees.Add(item);

            index++;
        }



        return trees.First(t => t.RecordId == 0);
    }

    private static void ValidateRecord(int previousRecordId, Tree item)
    {
        if (item.RecordId == 0 && item.ParentId == 0)
        {
            // It is the root item
            return;
        }

        if (item.ParentId < item.RecordId && item.RecordId == previousRecordId)
        {
            // It is a valid regular item
            return;
        }

        throw new ArgumentException();
    }
}