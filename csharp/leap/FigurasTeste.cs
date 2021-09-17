using Xunit;

public class FigurasTeste
{
    [Fact]
    void Teste()
    {
        Area(new Triangulo(2, 3));

        IFiguraGeometrica figura = new Quadrilatero(2, 3);
        var resultado1 = figura.Area;
        var resultado2 = figura.Perimetro;
    }

    private double Area(IFiguraGeometrica figura) => figura.Area;
}
