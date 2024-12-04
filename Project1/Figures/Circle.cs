namespace Project1.Figures;

public class Circle : IFigure
{
    private readonly double _radius;
    private readonly double _perimeter;

    public Circle(double radius)
    {
        if (radius < 0 || Math.Abs(radius) < double.Epsilon)
            throw new ArgumentException("The radius must be >= 0");
        
        _perimeter = 2.0 * Math.PI * radius;
        
        if(double.IsPositiveInfinity(_perimeter) || double.IsNegativeInfinity(_perimeter))
            throw new OverflowException();
        
        _radius = radius;
    }

    public double Perimeter() => _perimeter;
    
    public override string ToString() => $"circle {_radius}";
    
    public object Clone() => new Circle(_radius);
}