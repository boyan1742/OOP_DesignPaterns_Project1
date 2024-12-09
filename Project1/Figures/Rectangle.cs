using Project1.Helpers;

namespace Project1.Figures;

public class Rectangle : IFigure
{
    private readonly int _a, _b;
    private readonly double _perimeter;

    public Rectangle(int a, int b)
    {
        if (a <= 0 || b <= 0)
            throw new ArgumentException("The sides must be >= 0");

        if (FigureRules.DoesOverflow(a, b, a, b))
            throw new OverflowException("Rectangle's sides are too large.");

        _perimeter = 2 * (a + b);

        _a = a;
        _b = b;
    }

    public double Perimeter() => _perimeter;

    public override string ToString() => $"rectangle {_a} {_b}";

    public object Clone() => new Rectangle(_a, _b);
}