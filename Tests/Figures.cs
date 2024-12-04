using Project1.Figures;

namespace Tests;

public class Figures
{
    [Fact]
    public void Triangle_ValidParameters()
    {
        var t = new Triangle(1, 2, 3);

        Assert.Equal(6, t.Perimeter());
    }

    [Fact]
    public void Triangle_NegativeParameters()
    {
        Assert.Throws<ArgumentException>(() => new Triangle(-1, 2, 3));
        Assert.Throws<ArgumentException>(() => new Triangle(1, -2, 3));
        Assert.Throws<ArgumentException>(() => new Triangle(1, 2, -3));
        
        Assert.Throws<ArgumentException>(() => new Triangle(0, 2, 3));
        Assert.Throws<ArgumentException>(() => new Triangle(1, 0, 3));
        Assert.Throws<ArgumentException>(() => new Triangle(1, 2, 0));
    }
    
    [Fact]
    public void Triangle_NonTriangleParameters()
    {
        Assert.Throws<ArgumentException>(() => new Triangle(99, 2, 3));
        Assert.Throws<ArgumentException>(() => new Triangle(1, 99, 3));
        Assert.Throws<ArgumentException>(() => new Triangle(1, 2, 99));
    }

    [Fact]
    public void Triangle_TooBigParameters()
    {
        Assert.Throws<OverflowException>(() => new Triangle(int.MaxValue, 2, 3));
        Assert.Throws<OverflowException>(() => new Triangle(1, int.MaxValue, 3));
        Assert.Throws<OverflowException>(() => new Triangle(1, 2, int.MaxValue));

        Assert.Throws<OverflowException>(() =>
            new Triangle(int.MaxValue / 3 + 1, int.MaxValue / 3 + 1, int.MaxValue / 3 + 1));
    }
    
    [Fact]
    public void Rectangle_ValidParameters()
    {
        var t = new Rectangle(1, 2);

        Assert.Equal(6, t.Perimeter());
    }

    [Fact]
    public void Rectangle_NegativeParameters()
    {
        Assert.Throws<ArgumentException>(() => new Rectangle(-1, 2));
        Assert.Throws<ArgumentException>(() => new Rectangle(1, -2));
        
        Assert.Throws<ArgumentException>(() => new Rectangle(0, 2));
        Assert.Throws<ArgumentException>(() => new Rectangle(1, 0));
    }

    [Fact]
    public void Rectangle_TooBigParameters()
    {
        Assert.Throws<OverflowException>(() => new Rectangle(int.MaxValue, 2));
        Assert.Throws<OverflowException>(() => new Rectangle(1, int.MaxValue));

        Assert.Throws<OverflowException>(() => new Rectangle(int.MaxValue / 2 + 1, int.MaxValue / 2 + 1));
    }
    
    [Fact]
    public void Circle_ValidParameters()
    {
        var t = new Circle(1);

        Assert.Equal(6.2831853071795862d, t.Perimeter());
    }

    [Fact]
    public void Circle_NegativeParameters()
    {
        Assert.Throws<ArgumentException>(() => new Circle(-1));
        Assert.Throws<ArgumentException>(() => new Circle(0.0));
    }

    [Fact]
    public void Circle_TooBigParameters()
    {
        Assert.Throws<OverflowException>(() => new Circle(double.MaxValue));
    }

    [Fact]
    public void Circle_Cloneable()
    {
        var c = new Circle(1);
        
        var t = c.Clone() as Circle;

        Assert.NotNull(t);
        Assert.Equal(c.Perimeter(), t.Perimeter());
    }
    
    [Fact]
    public void Triangle_Cloneable()
    {
        var c = new Triangle(1, 2, 3);
        
        var t = c.Clone() as Triangle;

        Assert.NotNull(t);
        Assert.Equal(c.Perimeter(), t.Perimeter());
    }
    
    [Fact]
    public void Rectangle_Cloneable()
    {
        var c = new Rectangle(1, 2);
        
        var t = c.Clone() as Rectangle;

        Assert.NotNull(t);
        Assert.Equal(c.Perimeter(), t.Perimeter());
    }
    
    [Fact]
    public void Rectangle_ToString()
    {
        var c = new Rectangle(1, 2);
        
        Assert.Equal("rectangle 1 2", c.ToString());
    }
    
    [Fact]
    public void Circle_ToString()
    {
        var c = new Circle(1);
        var c1 = new Circle(1.2);
        
        Assert.Equal("circle 1", c.ToString());
        Assert.Equal("circle 1.2", c1.ToString());
    }
    
    [Fact]
    public void Triangle_ToString()
    {
        var c = new Triangle(1, 2, 3);
        
        Assert.Equal("triangle 1 2 3", c.ToString());
    }
}