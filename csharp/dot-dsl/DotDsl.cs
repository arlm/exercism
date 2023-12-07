using System.Collections;
using System.Collections.Generic;

public interface IAttributable
{
    IEnumerable<Attr> Attrs { get; }

    void Add(Attr attr);
    void Add(string name, string value);
}

public abstract class BaseClass : IEnumerable, IAttributable
{
    public abstract IEnumerator GetEnumerator();

    private readonly List<Attr> attrs = new();

    public IEnumerable<Attr> Attrs => attrs;

    public void Add(Attr attr) => attrs.Add(attr);
    public void Add(string name, string value) => Add(new Attr(name, value));
}

public class Node : BaseClass
{
    public string Name { get; }

    public Node(string name) => Name = name;

    public override IEnumerator GetEnumerator() => throw new System.NotImplementedException();
}

public class Edge : BaseClass
{
    private string edge1;
    private string edge2;

    public Edge(string edge1, string edge2)
    {
        this.edge1 = edge1;
        this.edge2 = edge2;
    }

    public override IEnumerator GetEnumerator() => throw new System.NotImplementedException();
}

public class Attr
{
    public string Name { get; }
    public string Value { get; }

    public Attr(string name, string value)
    {
        Name = name;
        Value = value;
    }
}

public class Graph : BaseClass
{
    private readonly List<Edge> edges = new();
    private readonly List<Node> nodes = new();

    public IEnumerable<Edge> Edges => edges;
    public IEnumerable<Node> Nodes => nodes;

    public override IEnumerator GetEnumerator() => throw new System.NotImplementedException();

    public void Add(Edge edge) => edges.Add(edge);
    public void Add(Node node) => nodes.Add(node);
}