using System;

public class Circulo : IFiguraGeometrica
{
    public Circulo(int raio)
    {
        Raio = raio;
    }

    public int Raio { get; }

    public double Area => 2.0 * Math.PI * Raio;

    public double Perimetro => Math.Pow(Raio, 2);
}
