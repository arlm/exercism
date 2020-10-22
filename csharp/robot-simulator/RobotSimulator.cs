using System;

public enum Direction
{
    North,
    East,
    South,
    West
}

public class RobotSimulator
{
    public RobotSimulator(Direction direction, int x, int y)
    {
        if (!Enum.IsDefined(typeof(Direction), direction))
        {
            throw new ArgumentOutOfRangeException(nameof(direction), direction, "Invalid initial direction.");
        }

        Direction = direction;
        X = x;
        Y = y;
    }

    public Direction Direction { get; private set; }

    public int X { get; private set; }

    public int Y { get; private set; }

    public void Move(string instructions)
    {
        if (instructions == null)
        {
            throw new ArgumentNullException(nameof(instructions));
        }

        foreach(var instruction in instructions.ToUpper())
        {
            ExecuteInstruction(instruction);
        }
    }

    private void ExecuteInstruction(char instruction)
    {
        switch (instruction)
        {
            case 'A':
                Advance();
                break;

            case 'R':
                TurnRight();
                break;

            case 'L':
                TurnLeft();
                break;

            default:
                throw new ArgumentOutOfRangeException(nameof(instruction), instruction, $"Invalid instruction: {instruction}");
        }
    }

    private void TurnLeft() => Direction = Direction switch
    {
        Direction.North => Direction.West,
        Direction.East => Direction.North,
        Direction.South => Direction.East,
        Direction.West => Direction.South,
        _ => throw new InvalidOperationException($"Invalid direction: {Direction}")
    };

    private void TurnRight() => Direction = Direction switch
    {
        Direction.North => Direction.East,
        Direction.East => Direction.South,
        Direction.South => Direction.West,
        Direction.West => Direction.North,
        _ => throw new InvalidOperationException($"Invalid direction: {Direction}")
    };

    private void Advance()
    {
        switch (Direction)
        {
            case Direction.North:
                Y++;
                break;
            case Direction.East:
                X++;
                break;
            case Direction.South:
                Y--;
                break;
            case Direction.West:
                X--;
                break;
            default:
                throw new InvalidOperationException($"Invalid direction: {Direction}");
        }
    }
}