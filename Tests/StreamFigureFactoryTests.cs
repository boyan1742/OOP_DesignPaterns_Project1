using Moq;

using Project1.Factories;

namespace Tests;

public class StreamFigureFactoryTests
{
    [Fact]
    public void Create_StreamWithValidShapes()
    {
        MemoryStream stream = new("""
                                  triangle 3 4 5
                                  rectangle 3 4
                                  circle 5.71
                                  """u8.ToArray());
        StreamFigureFactory f = new(stream);

        Assert.NotNull(f.Create());
        Assert.NotNull(f.Create());
        Assert.NotNull(f.Create());
    }

    [Fact]
    public void Create_StreamWithInvalidShapes()
    {
        MemoryStream stream = new("""
                                  triangle1 1 2 3
                                  triangle 3 4 5
                                  rectangle 3 4
                                  circle 5.71
                                  """u8.ToArray());
        StreamFigureFactory f = new(stream);

        Assert.Null(f.Create());
        Assert.NotNull(f.Create());
        Assert.NotNull(f.Create());
        Assert.NotNull(f.Create());
    }

    [Fact]
    public void Create_EmptyStream()
    {
        MemoryStream stream = new(""u8.ToArray());
        StreamFigureFactory f = new(stream);

        Assert.Null(f.Create());
    }

    [Fact]
    public void Create_WritableOnlyStream()
    {
        Mock<Stream> stream = new();
        stream.Setup(s => s.CanWrite).Returns(true);
        stream.Setup(s => s.CanRead).Returns(false);

        Assert.Throws<ArgumentException>(() => new StreamFigureFactory(stream.Object));
    }
}