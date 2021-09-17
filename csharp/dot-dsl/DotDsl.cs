using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

internal static class SortedSetComparer
{
    public static int CompareTo<T>(this HashSet<T> one, HashSet<T> two)
    {
        if (ReferenceEquals(one, two))
        {
            return 0;
        }

        var lengthComparison = one.Count.CompareTo(two.Count);

        return lengthComparison != 0
            ? lengthComparison
            : one.IsProperSubsetOf(two) ? -1 : 1;
    }

    public static bool EqualsTo<T>(this HashSet<T> one, HashSet<T> two) =>
        ReferenceEquals(one, two)
        || one.Count == two.Count
        && one.IsSubsetOf(two)
        && two.IsSubsetOf(one);

    public static int CalculateHashCode<T>(this HashSet<T> one) {
        var hashCode = new HashCode();

        foreach (var item in one) {
            hashCode.Add(item);
        }

        return hashCode.ToHashCode();
    }
}

[DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
public class Node : IEnumerable<Attr>, IReadOnlyCollection<Attr>,
    IEquatable<Node>, IComparable<Node>
{
    private readonly HashSet<Attr> attrs = new HashSet<Attr>();
    public Attr[] Attrs => attrs.ToArray();

    public Node(string name) => Name = name;

    public string Name { get; }

    public int Count => attrs.Count;

    internal void Add(string key, string value) => attrs.Add(new Attr(key, value));
    internal void Add(Attr item) => attrs.Add(item);
    public bool Contains(Attr item) => attrs.Contains(item);

    public IEnumerator<Attr> GetEnumerator() => attrs.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => attrs.GetEnumerator();

    public override bool Equals(object obj) => Equals(obj as Node);
    public int CompareTo(Node other)
    {
        var nameComparison = Name.CompareTo(other.Name);

        return nameComparison != 0 ? nameComparison : attrs.CompareTo(other.attrs);
    }

    public bool Equals(Node other) =>
        ReferenceEquals(this, other)
        || !(other is null)
        && attrs.EqualsTo(other.attrs)
        && Name == other.Name;

    public override int GetHashCode() => HashCode.Combine(
        attrs.CalculateHashCode(),
        Name);

    public static bool operator ==(Node left, Node right) => left?.Equals(right) ?? false;
    public static bool operator !=(Node left, Node right) => !(left == right);

    private string GetDebuggerDisplay() => ToString();
    public override string ToString() => $"{Name}, Attributes: [ {string.Join(",", attrs)} ]";
}

[DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
public class Edge : IEnumerable<Attr>, IReadOnlyCollection<Attr>,
    IEquatable<Edge>, IComparable<Edge>
{
    private readonly HashSet<Attr> attrs = new HashSet<Attr>();
    public Attr[] Attrs => attrs.ToArray();

    public Edge(string v1, string v2)
    {
        V1 = v1;
        V2 = v2;
    }

    public string V1 { get; }
    public string V2 { get; }

    public void Deconstruct(out string v1, out string v2)
    {
        v1 = V1;
        v2 = V2;
    }

    public int Count => attrs.Count;

    internal void Add(string key, string value) => attrs.Add(new Attr(key, value));
    internal void Add(Attr item) => attrs.Add(item);
    public bool Contains(Attr item) => attrs.Contains(item);

    public IEnumerator<Attr> GetEnumerator() => attrs.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => attrs.GetEnumerator();

    public override bool Equals(object obj) => Equals(obj as Edge);
    public int CompareTo(Edge other)
    {
        var v1Comparison = V1.CompareTo(other.V1);

        if (v1Comparison != 0)
        {
            return v1Comparison;
        }
        else
        {
            var v2Comparison = V2.CompareTo(other.V1);

            if (v2Comparison != 0)
            {
                return attrs.CompareTo(other.attrs);
            }
            else
            {
                return V2.CompareTo(other.V2);
            }
        }
    }

    public bool Equals(Edge other) =>
        ReferenceEquals(this, other)
        || !(other is null)
        && attrs.EqualsTo(other.attrs)
        && V1 == other.V1
        && V2 == other.V2;

    public override int GetHashCode() => HashCode.Combine(
        attrs.CalculateHashCode(),
        V1,
        V2);

    public static bool operator ==(Edge left, Edge right) => left?.Equals(right) ?? false;
    public static bool operator !=(Edge left, Edge right) => !(left == right);

    private string GetDebuggerDisplay() => ToString();
    public override string ToString() => $"{{ {V1}, {V2} }}, Attributes: [ {string.Join(",", attrs)} ]";
}

[DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
public class Attr : IEquatable<Attr>, IComparable<Attr>
{
    public Attr(string key, string value)
    {
        Key = key;
        Value = value;
    }

    public string Key { get; }
    public string Value { get; }

    public void Deconstruct(out string key, out string value)
    {
        key = Key;
        value = Value;
    }

    public override bool Equals(object obj) => Equals(obj as Attr);
    public int CompareTo(Attr other) => Key.CompareTo(other.Key);

    public bool Equals(Attr other) =>
        ReferenceEquals(this, other) ||
        (!(other is null)
        && Key == other.Key
        && Value == other.Value);

    public override int GetHashCode() => HashCode.Combine(Key, Value);

    public static bool operator ==(Attr left, Attr right) => left?.Equals(right) ?? false;
    public static bool operator !=(Attr left, Attr right) => !(left == right);

    private string GetDebuggerDisplay() => ToString();
    public override string ToString() => $"{{ {Key}, {Value} }}";
}

[DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
public class Graph :
    IEnumerable<Node>, IEnumerable<Edge>, IEnumerable<Attr>,
    IReadOnlyCollection<Node>, IReadOnlyCollection<Edge>, IReadOnlyCollection<Attr>, IEquatable<Graph>
{
    private readonly HashSet<Node> nodes = new HashSet<Node>();
    private readonly HashSet<Edge> edges = new HashSet<Edge>();
    private readonly HashSet<Attr> attrs = new HashSet<Attr>();

    public Node[] Nodes => nodes.ToArray();
    public Edge[] Edges => edges.ToArray();
    public Attr[] Attrs => attrs.ToArray();

    IEnumerator IEnumerable.GetEnumerator() => throw new NotImplementedException();

    int IReadOnlyCollection<Node>.Count => nodes.Count;
    int IReadOnlyCollection<Edge>.Count => edges.Count;
    int IReadOnlyCollection<Attr>.Count => attrs.Count;

    internal void Add(string key, string value) => attrs.Add(new Attr(key, value));
    internal void Add(Node item) => nodes.Add(item);
    internal void Add(Edge item) => edges.Add(item);
    internal void Add(Attr item) => attrs.Add(item);

    public bool Contains(Node item) => nodes.Contains(item);
    public bool Contains(Edge item) => edges.Contains(item);
    public bool Contains(Attr item) => attrs.Contains(item);

    IEnumerator<Node> IEnumerable<Node>.GetEnumerator() => nodes.GetEnumerator();
    IEnumerator<Edge> IEnumerable<Edge>.GetEnumerator() => edges.GetEnumerator();
    IEnumerator<Attr> IEnumerable<Attr>.GetEnumerator() => attrs.GetEnumerator();

    public override bool Equals(object obj) => Equals(obj as Graph);

    public bool Equals(Graph other) =>
        ReferenceEquals(this, other)
        || !(other is null)
        && EqualityComparer<HashSet<Node>>.Default.Equals(nodes, other.nodes)
        && EqualityComparer<HashSet<Edge>>.Default.Equals(edges, other.edges)
        && EqualityComparer<HashSet<Attr>>.Default.Equals(attrs, other.attrs);

    public override int GetHashCode() => HashCode.Combine(
        nodes.CalculateHashCode(),
        edges.CalculateHashCode(),
        attrs.CalculateHashCode());

    public static bool operator ==(Graph left, Graph right) => left?.Equals(right) ?? false;
    public static bool operator !=(Graph left, Graph right) => !(left == right);

    private string GetDebuggerDisplay() => ToString();
    public override string ToString() => $"Nodes: [ {string.Join(",", nodes)} ], Edges: [ {string.Join(",", edges)} ], Attributes: [ {string.Join(",", attrs)} ]";
}