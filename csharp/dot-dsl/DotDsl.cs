using System.Collections;
using System.Collections.Generic;

public class Node : IEnumerable<Attr>
{
    public Node(string name)
    {
        Name = name;
    }

    public string Name { get; }

    public IEnumerator<Attr> GetEnumerator()
    {
        throw new System.NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new System.NotImplementedException();
    }
}

public class Edge
{
    public Edge(string v1, string v2)
    {
        V1 = v1;
        V2 = v2;
    }

    public string V1 { get; }
    public string V2 { get; }
}

public class Attr
{
    public Attr(string key, string value)
    {
        Key = key;
        Value = value;
    }

    public string Key { get; }
    public string Value { get; }
}

public class Graph
{
    public IEnumerable<Node> Nodes { get; internal set; }
    public IEnumerable<Edge> Edges { get; internal set; }
    public IEnumerable<Attr> Attrs { get; internal set; }
}