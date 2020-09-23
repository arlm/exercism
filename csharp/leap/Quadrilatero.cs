using System;
namespace Leap
{
    public class Quadrilatero : IFiguraGeometrica
    {
        public int Lado1 { get; }
        public int Lado2 { get; }

        public Quadrilatero(int lado1, int lado2)
        {
            Lado1 = lado1;
            Lado2 = lado2;
        }

        public Quadrilatero(int lado)
        {
            Lado1 = lado;
            Lado2 = lado;
        }

        public double Area => Lado1 * Lado2;

        public double Perimetro => 2 * Lado1 + 2 * Lado2;
    }
}
