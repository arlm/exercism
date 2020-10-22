using System;
using System.Linq;

public class DndCharacter
{
    private static int seed = (int)DateTime.Now.Ticks;
    private static int bsdCurrent = seed;
    private static int msvcrtCurrent = seed;
    private static int trollCurrent = seed;
    private static int freeBsdCurrent = seed;
    private static int turboPascalCurrent = seed;

    public DndCharacter()
    {
        Strength = Ability();
        Dexterity = Ability();
        Constitution = Ability();
        Intelligence = Ability();
        Wisdom = Ability();
        Charisma = Ability();
        Hitpoints = 10 + Modifier(Constitution);
    }

    private static int Roll(int diceSides, int rolls, bool discardSmallest = false, bool discardGreatest = false)
    {
        var results = new int[rolls];

        for(int roll = 0; roll < rolls; roll++)
        {
            while (results[roll] == 0)
            {
                results[roll] = Roll(diceSides);
            }                        
        }

        results.OrderBy(value => value);

        var sum = results.Sum();

        if (discardSmallest)
        {
            sum -= results.Min();
        }

        if (discardGreatest)
        {
            sum -= results.Max();
        }

        return sum;
    }

    private static int Roll(int diceSides) => Roll(diceSides, BsdRand);

    private static int Roll(int diceSides, Func<int> randomizer) => Math.Abs(randomizer() % (diceSides + 1));

    /// <summary>
    /// BSD formula from BSD libc rand()
    /// 
    /// {\displaystyle state_ { n+1} = 1103515245\times state_ { n }+12345{\pmod {2^{31}}}}
    /// {\displaystyle rand_{ n}= state_{ n} }
    /// </summary>
    /// <returns>Random in the range from 0 to 2147483647</returns>
    private static int BsdRand() => bsdCurrent = Next(bsdCurrent, 1103515245, 12345);

    /// <summary>
    /// FreeBSD formula from FreeBSD libc rand()
    /// 
    /// {\displaystyle state_ { n+1} = 1103515245\times state_ { n }+12345{\pmod {2^{31}}}}
    /// {\displaystyle rand_{ n}= state_{ n} }
    /// </summary>
    /// <returns>Random in the range from 0 to 2147483647</returns>
    private static int FreeBsdRand() => freeBsdCurrent = Next(freeBsdCurrent, 1103515245, 12345);

    /// <summary>
    /// 87 Turbo Pascal formula from Turbo Pascal rand()
    ///
    /// if the result is greater than 1, then the output is {\displaystyle 2 - result} instead.
    /// 
    /// {\displaystyle state_ { n+1} = 129\times state_ { n }+907633385{\pmod {2^{32}}}}
    /// {\displaystyle rand_{ n}= state_{ n} }
    /// </summary>
    /// <returns>Random in the range from 0 to 2147483647</returns>
    private static int TurboPascalRand()
    {
        turboPascalCurrent = Next(turboPascalCurrent, 129, 907633385);
        if (turboPascalCurrent > 1)
        {
            turboPascalCurrent = 2 - turboPascalCurrent;
        }

        return turboPascalCurrent;
    }

    /// <summary>
    /// Microsoft formula from MSCVRT.dll rand()
    /// 
    /// {\displaystyle state_ { n+1} = 214013\times state_ { n }+2531011{\pmod {2^{31}}}}
    /// {\displaystyle rand_{ n}= state_{ n}\div 2 ^{ 16} }
    /// </summary>
    /// <returns>Random in the range from 0 to 32767</returns>
    private static int MscvrtRand() => msvcrtCurrent = Next(msvcrtCurrent << 16, 214013, 2531011) >> 16;

    /// <summary>
    /// Troll formula from rand()
    /// 
    /// {\displaystyle state_ { n+1} = 73\times state_ { n }+26111{\pmod {973177}}}
    /// {\displaystyle state_ { n+1} = 61\times state_ { n }+26111{\pmod { }}}
    /// {\displaystyle rand_{ n}= state_{ n} }
    /// </summary>
    /// <returns>Random in the range from 0 to 32767</returns>
    private static int TrollRand() =>
        Next(trollCurrent, 73, 26111, 973177) + Next(trollCurrent, 61, 26111, 990001);

    /// <summary>
    /// Linear_congruential_generator
    /// </summary>
    /// <param name="seed">Initial seed</param>
    /// <param name="a">Multiplier (must be bigger than 0, exclusive, and less than <paramref name="m"/>)</param>
    /// <param name="b">increment (must be bigger than 0, inclusive, and less than <paramref name="m"/>)</param>
    /// <param name="m">modulus</param>
    /// <returns>A random number</returns>
    private static int Next(int seed, int a, int b, int m = int.MaxValue) => (a * seed + b) % m;

    public int Strength { get; }
    public int Dexterity { get; }
    public int Constitution { get; }
    public int Intelligence { get; }
    public int Wisdom { get; }
    public int Charisma { get; }
    public int Hitpoints { get; }

    public static int Modifier(int score) => (int)Math.Floor((score - 10) / 2.0);

    public static int Ability() => Roll(6, 4, true);

    public static DndCharacter Generate() => new DndCharacter();
}
