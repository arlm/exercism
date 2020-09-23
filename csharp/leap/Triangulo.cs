using System;
namespace Leap
{
    public class Triangulo : IFiguraGeometrica
    {
        public Triangulo(int @base, int altura)
        {
            Base = @base;
            Altura = altura;
        }


        public double Area => (Base * Altura) / 2;

        public int Base { get; }
        public int Altura { get; }

        public double Perimetro => throw new NotImplementedException();
    }
}
