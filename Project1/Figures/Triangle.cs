using Project1.Helpers;

namespace Project1.Figures;

public class Triangle : IFigure
{
    private readonly int _a, _b, _c;
    private readonly double _perimeter;

    public Triangle(int a, int b, int c)
    {
        if (a < 0 || b < 0 || c < 0)
            throw new ArgumentException("The sides must be >= 0");

        if (FigureRules.DoesOverflow(a, b, c))
            throw new OverflowException("Triangle's sides are too large.");

        _perimeter = a + b + c;

        if (!FigureRules.IsTriangleRule(a, b, c))
            throw new ArgumentException("These sides don't follow the rules of the triangle");

        _a = a;
        _b = b;
        _c = c;
    }

    public double Perimeter() => _perimeter;

    public override string ToString() => $"triangle {_a} {_b} {_c}";

    public object Clone() => new Triangle(_a, _b, _c);
}