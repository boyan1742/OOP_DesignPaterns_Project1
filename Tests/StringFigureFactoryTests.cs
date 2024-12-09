using Project1.Factories;

namespace Tests;

public class StringFigureFactoryTests
{
    [Fact]
    public void CreateFrom_EmptyString()
    {
        StringToFigureFactory factory = new();
        Assert.Null(factory.CreateFrom(""));
    }
    
    [Fact]
    public void CreateFrom_ValidShape()
    {
        StringToFigureFactory factory = new();
        Assert.NotNull(factory.CreateFrom("triangle 3 4 5"));
        Assert.NotNull(factory.CreateFrom("rectangle 2 4"));
        Assert.NotNull(factory.CreateFrom("circle 1"));
        Assert.NotNull(factory.CreateFrom("circle 1.6"));
    }
    
    [Fact]
    public void CreateFrom_NonExistentShape()
    {
        StringToFigureFactory factory = new();
        Assert.Null(factory.CreateFrom("square 1"));
    }
    
    [Fact]
    public void CreateFrom_NonExistentShapeCtor()
    {
        StringToFigureFactory factory = new();
        Assert.Null(factory.CreateFrom("triangle 1 2"));
    }
}