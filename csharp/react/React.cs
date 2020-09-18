using System;
using System.Collections.Generic;
using System.Linq;

public class Reactor
{
    public InputCell CreateInputCell(int value) => new InputCell(value);

    public ComputeCell CreateComputeCell(IEnumerable<Cell> producers, Func<int[], int> compute) => new ComputeCell(producers, compute);
}

public abstract class Cell
{
    private int _value;

    protected Cell(int value) => Value = value;

    public virtual int Value
    {
        get => _value;
        set
        {
            if (_value != value)
            {
                _value = value;
                Changed?.Invoke(this, value);
            }
        }
    }

    public event EventHandler<int> Changed;
}

public class InputCell : Cell
{
    public InputCell(int value) : base(value) { }
}

public class ComputeCell : Cell
{
    private readonly IEnumerable<Cell> producers;
    private readonly Func<int[], int> compute;
    private List<InputCell> subscribed = new List<InputCell>();

    public ComputeCell(IEnumerable<Cell> producers, Func<int[], int> compute) : base (0)
    {
        this.producers = producers ?? throw new ArgumentNullException(nameof(producers));
        this.compute = compute ?? throw new ArgumentNullException(nameof(compute));

        Subscribe(producers);

        base.Value = compute(producers.Select(cell => cell.Value).ToArray());
    }

    private void Subscribe(IEnumerable<Cell> producers)
    {
        foreach (var producer in from producer in producers select producer)
        {
            if (producer is InputCell inputCell && !subscribed.Contains(inputCell))
            {
                inputCell.Changed += Producer_Changed;
                subscribed.Add(inputCell);
            }
            else if (producer is ComputeCell computeCell)
            {
                Subscribe(computeCell.producers);
            }
        }
    }

    private void Producer_Changed(object sender, int e) =>
        base.Value = compute(producers.Select(cell => cell.Value).ToArray());

    public override int Value
    {
        get => base.Value;

        set { }
    }
}