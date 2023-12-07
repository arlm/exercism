using System;
using Xunit;

public class PositionTests
{
    [Fact]
    public void Invalid_position_negative_size()
    {
        Assert.Throws<ArgumentException>(() => new Position(0, 0, Size: -1));
    }

    [Fact]
    public void Invalid_addition()
    {
        Assert.Throws<ArgumentException>(() => new Position(0, 0, Size: 1) + new Position(0, 0, Size: 2));
    }

    [Fact]
    public void Compare_different_sizes()
    {
        Assert.NotEqual(new Position(1, 1, Size: 3), new Position(1, 1, Size: 4));
    }

    [Fact]
    public void Compare_equality()
    {
        Assert.Equal(new Position(1, 1, Size: 3), new Position(1, 1, Size: 3));
        Assert.Equal(new Position(1, 1, Size: 3), new Position(1, 4, Size: 3));
        Assert.Equal(new Position(1, 1, Size: 3), new Position(4, 1, Size: 3));
        Assert.Equal(new Position(1, 1, Size: 3), new Position(4, 4, Size: 3));
        Assert.Equal(new Position(1, 1, Size: 3), new Position(7, 4, Size: 3));
        Assert.Equal(new Position(1, 1, Size: 3), new Position(4, 7, Size: 3));
        Assert.Equal(new Position(1, 1, Size: 3), new Position(7, 7, Size: 3));
    }

    [Fact]
    public void Compare_not_equality()
    {
        Assert.NotEqual(new Position(1, 1, Size: 3), new Position(2, 1, Size: 3));
        Assert.NotEqual(new Position(1, 1, Size: 3), new Position(1, 2, Size: 3));
        Assert.NotEqual(new Position(1, 1, Size: 3), new Position(2, 2, Size: 3));
        Assert.NotEqual(new Position(1, 1, Size: 3), new Position(5, 1, Size: 3));
        Assert.NotEqual(new Position(1, 1, Size: 3), new Position(1, 5, Size: 3));
        Assert.NotEqual(new Position(1, 1, Size: 3), new Position(5, 5, Size: 3));
        Assert.NotEqual(new Position(1, 1, Size: 3), new Position(4, 5, Size: 3));
        Assert.NotEqual(new Position(1, 1, Size: 3), new Position(5, 4, Size: 3));
        Assert.NotEqual(new Position(1, 1, Size: 3), new Position(5, 5, Size: 3));
    }

    [Fact]
    public void Add_zero()
    {
        Assert.Equal(new Position(1, 1, Size: 3), new Position(1, 1, Size: 3) + new Position(0, 0, Size: 3));
    }

    [Fact]
    public void Add_one_on_row()
    {
        Assert.Equal(new Position(2, 1, Size: 3), new Position(1, 1, Size: 3) + new Position(1, 0, Size: 3));
        Assert.Equal(new Position(2, 1, Size: 3), new Position(1, 1, Size: 3) + new Position(4, 0, Size: 3));
        Assert.Equal(new Position(2, 1, Size: 3), new Position(1, 1, Size: 3) + new Position(7, 0, Size: 3));
    }

    [Fact]
    public void Add_minus_one_on_row()
    {
        Assert.Equal(new Position(0, 1, Size: 3), new Position(1, 1, Size: 3) + new Position(-1, 0, Size: 3));
        Assert.Equal(new Position(0, 1, Size: 3), new Position(1, 1, Size: 3) + new Position(-4, 0, Size: 3));
        Assert.Equal(new Position(0, 1, Size: 3), new Position(1, 1, Size: 3) + new Position(-7, 0, Size: 3));
    }

    [Fact]
    public void Add_one_on_column()
    {
        Assert.Equal(new Position(1, 2, Size: 3), new Position(1, 1, Size: 3) + new Position(0, 1, Size: 3));
        Assert.Equal(new Position(1, 2, Size: 3), new Position(1, 1, Size: 3) + new Position(0, 4, Size: 3));
        Assert.Equal(new Position(1, 2, Size: 3), new Position(1, 1, Size: 3) + new Position(0, 7, Size: 3));
    }

    [Fact]
    public void Add_minus_one_on_column()
    {
        Assert.Equal(new Position(1, 0, Size: 3), new Position(1, 1, Size: 3) + new Position(0, -1, Size: 3));
        Assert.Equal(new Position(1, 0, Size: 3), new Position(1, 1, Size: 3) + new Position(0, -4, Size: 3));
        Assert.Equal(new Position(1, 0, Size: 3), new Position(1, 1, Size: 3) + new Position(0, -7, Size: 3));
    }

    [Fact]
    public void Add_one_on_both()
    {
        Assert.Equal(new Position(2, 2, Size: 3), new Position(1, 1, Size: 3) + new Position(1, 1, Size: 3));
        Assert.Equal(new Position(2, 2, Size: 3), new Position(1, 1, Size: 3) + new Position(4, 4, Size: 3));
        Assert.Equal(new Position(2, 2, Size: 3), new Position(1, 1, Size: 3) + new Position(7, 7, Size: 3));
    }

    [Fact]
    public void Add_minus_one_on_both()
    {
        Assert.Equal(new Position(0, 0, Size: 3), new Position(1, 1, Size: 3) + new Position(-1, -1, Size: 3));
        Assert.Equal(new Position(0, 0, Size: 3), new Position(1, 1, Size: 3) + new Position(-4, -4, Size: 3));
        Assert.Equal(new Position(0, 0, Size: 3), new Position(1, 1, Size: 3) + new Position(-7, -7, Size: 3));
    }

    [Fact]
    public void Check_next_direction()
    {
        Assert.Equal(Direction.Down, Position.NextDirection(Direction.Right));
        Assert.Equal(Direction.Left, Position.NextDirection(Direction.Down));
        Assert.Equal(Direction.Up, Position.NextDirection(Direction.Left));
        Assert.Equal(Direction.Right, Position.NextDirection(Direction.Up));
    }

    [Fact]
    public void Move_up()
    {
        Assert.Equal((new Position(0, 1, Size: 3), Direction.Right), new Position(0, 0, Size: 3).Move(Direction.Up));
        Assert.Equal((new Position(0, 2, Size: 3), Direction.Right), new Position(0, 1, Size: 3).Move(Direction.Up));
        Assert.Equal((new Position(1, 2, Size: 3), Direction.Down), new Position(0, 2, Size: 3).Move(Direction.Up));
        Assert.Equal((new Position(0, 1, Size: 3), Direction.Up), new Position(1, 1, Size: 3).Move(Direction.Up));
        Assert.Equal((new Position(1, 2, Size: 3), Direction.Up), new Position(2, 2, Size: 3).Move(Direction.Up));
    }

    [Fact]
    public void Move_down()
    {
        Assert.Equal((new Position(1, 0, Size: 3), Direction.Up), new Position(2, 0, Size: 3).Move(Direction.Down));
        Assert.Equal((new Position(2, 0, Size: 3), Direction.Left), new Position(2, 1, Size: 3).Move(Direction.Down));
        Assert.Equal((new Position(2, 1, Size: 3), Direction.Left), new Position(2, 2, Size: 3).Move(Direction.Down));
        Assert.Equal((new Position(1, 0, Size: 3), Direction.Down), new Position(0, 0, Size: 3).Move(Direction.Down));
        Assert.Equal((new Position(2, 1, Size: 3), Direction.Down), new Position(1, 1, Size: 3).Move(Direction.Down));
    }

    [Fact]
    public void Move_left()
    {
        Assert.Equal((new Position(0, 1, Size: 3), Direction.Right), new Position(0, 0, Size: 3).Move(Direction.Left));
        Assert.Equal((new Position(0, 0, Size: 3), Direction.Up), new Position(1, 0, Size: 3).Move(Direction.Left));
        Assert.Equal((new Position(1, 0, Size: 3), Direction.Up), new Position(2, 0, Size: 3).Move(Direction.Left));
        Assert.Equal((new Position(1, 0, Size: 3), Direction.Left), new Position(1, 1, Size: 3).Move(Direction.Left));
        Assert.Equal((new Position(2, 1, Size: 3), Direction.Left), new Position(2, 2, Size: 3).Move(Direction.Left));
    }

    [Fact]
    public void Move_right()
    {
        Assert.Equal((new Position(1, 2, Size: 3), Direction.Down), new Position(0, 2, Size: 3).Move(Direction.Right));
        Assert.Equal((new Position(2, 2, Size: 3), Direction.Down), new Position(1, 2, Size: 3).Move(Direction.Right));
        Assert.Equal((new Position(2, 1, Size: 3), Direction.Left), new Position(2, 2, Size: 3).Move(Direction.Right));
        Assert.Equal((new Position(0, 1, Size: 3), Direction.Right), new Position(0, 0, Size: 3).Move(Direction.Right));
        Assert.Equal((new Position(1, 2, Size: 3), Direction.Right), new Position(1, 1, Size: 3).Move(Direction.Right));
    }
}