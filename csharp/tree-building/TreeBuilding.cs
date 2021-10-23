using System;
using System.Collections.Generic;
using System.Linq;

public class TreeBuildingRecord : IEquatable<TreeBuildingRecord>
{
    private TreeBuildingRecord parent;

    public TreeBuildingRecord Parent
    {
        get => parent;

        internal set
        {
            parent = value;

            if (ParentId != value.RecordId)
            {
                ParentId = parent.RecordId;
            }
        }
    }

    public int ParentId { get; internal set; }
    public int RecordId { get; set; }

    public override bool Equals(object obj)
        => obj switch
        {
            null => false,
            _ => obj is TreeBuildingRecord record && Equals(record)
        };

    public bool Equals(TreeBuildingRecord other)
        => other switch
        {
            null => false,
            _ => ReferenceEquals(this, other) || RecordId == other.RecordId
        };

    public static bool operator ==(TreeBuildingRecord one, TreeBuildingRecord two)
        => one?.Equals(two) ?? two is null;

    public static bool operator !=(TreeBuildingRecord one, TreeBuildingRecord two)
        => !one?.Equals(two) ?? two is not null;

    public override int GetHashCode() => HashCode.Combine(RecordId);
    public override string ToString() => $"{{RecordId={RecordId}, ParentId={ParentId}}}";
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
            {
                throw new ArgumentException("ParentId should also be zero(0) for the root element", nameof(ParentId));
            }
        }
        else if (RecordId < ParentId)
        {
            throw new ArgumentException("RecordId should equal ou lesser than RecordId", nameof(RecordId));
        }
    }

    public List<Tree> Children { get; } = new List<Tree>();

    public List<Tree> Descendants => Children.SelectMany(record => record.Children).ToList();

    public int Id => RecordId;

    public bool IsLeaf => Children.Count == 0;
}

public static class TreeBuilder
{
    public static Tree BuildTree(IEnumerable<TreeBuildingRecord> records)
    {
        if (records == null)
        {
            throw new ArgumentException("records should not be null", nameof(records));
        }

        if (!records.Any())
        {
            throw new ArgumentException("Records cannot be empty", nameof(records));
        }

        var array = records.OrderBy(record => record.RecordId).ToArray();

        for (int index = 0; index < array.Length - 1; index++)
        {
            if ((array[index].RecordId + 1) != array[index+ 1].RecordId)
            {
                throw new ArgumentException("list have RecordIds in sequence", nameof(records));
            }
        }

        var root = records.FirstOrDefault(record => record.RecordId == record.ParentId);

        if (root == null)
        {
            throw new ArgumentException("list should have a root record with RecordId equals to ParentID", nameof(records));
        }

        if (records.Except(new[] { root }).Any(record => record.RecordId == record.ParentId))
        {
            throw new ArgumentException("list should have elements that cycle to self", nameof(records));
        }

        var item = new Tree(root);
        var remainingRecords = AssignChildren(records, item);

        return remainingRecords.Any()
            ? throw new ArgumentException("Shoudl not have items not attached to the root, directly or indirectly", nameof(records))
            : item;
    }

    private static IEnumerable<TreeBuildingRecord> AssignChildren(IEnumerable<TreeBuildingRecord> records, Tree item)
    {
        if (!records.Any())
        {
            return Enumerable.Empty<TreeBuildingRecord>();
        }

        var children = records
            .Where(record => record.ParentId == item.RecordId && record != item)
            .OrderBy(record => record.RecordId)
            .Select(record => new Tree(record));

        var remainingRecords = records;

        foreach (var child in children)
        {
            item.Children.Add(child);
            child.Parent = item;

            remainingRecords = AssignChildren(remainingRecords.Except(new[] { item }), child);

            if (!records.Any())
            {
                return Enumerable.Empty<TreeBuildingRecord>();
            }
        }

        return remainingRecords.Except(children.SelectMany(item => item.Descendants).Concat(new[] { item })); ;
    }
}