namespace Project1.Figures;

public class Triangle : IFigure
{
    private readonly int _a, _b, _c;
    private readonly double _perimeter;

    public Triangle(int a, int b, int c)
    {
        if (a < 0 || b < 0 || c < 0)
            throw new ArgumentException("The sides must be >= 0");

        checked
        {
            int perimeter = a + b + c; //this will throw `OverflowException` if the sum overflows.
            _perimeter = perimeter;
        }
        
        if (a + b < c || a + c < b || b + c < a)
            throw new ArgumentException("These sides don't follow the rules of the triangle");

        _a = a;
        _b = b;
        _c = c;
    }

    public double Perimeter() => _perimeter;
    
    public override string ToString() => $"triangle {_a} {_b} {_c}";
    
    public object Clone() => new Triangle(_a, _b, _c);
}