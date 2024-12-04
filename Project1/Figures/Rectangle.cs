namespace Project1.Figures;

public class Rectangle : IFigure
{
    private readonly int _a, _b;
    private readonly double _perimeter;

    public Rectangle(int a, int b)
    {
        if (a <= 0 || b <= 0)
            throw new ArgumentException("The sides must be >= 0");

        checked
        {
            int perimeter = 2 * (a + b); //this will throw `OverflowException` if the sum overflows.
            _perimeter = perimeter;
        }

        _a = a;
        _b = b;
    }

    public double Perimeter() => _perimeter;

    public override string ToString() => $"rectangle {_a} {_b}";
    
    public object Clone() => new Rectangle(_a, _b);
}