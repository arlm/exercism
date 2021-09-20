using System;

public class Player
{
    private Random random = new Random();

    public int RollDie() => random.Next(1, 18);

    public double GenerateSpellStrength() => random.NextDouble() * 100.0;
}
