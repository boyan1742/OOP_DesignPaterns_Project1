using Project1.Factories;
using Project1.Figures;

namespace Tests;

public class RandomFigureFactoryTests
{
    private const int NUMBER_OF_FIGURES_TO_TEST = 300;
    private const int TOLERANCE = 50;
    
    [Fact]
    public void Create_Distribution()
    {
        List<IFigure?> figures = [];
        RandomFigureFactory factory = new();
        
        for(int i = 0; i < NUMBER_OF_FIGURES_TO_TEST; i++)
            figures.Add(factory.Create());

        Dictionary<Type, int> typeCounts = figures.GroupBy(f => f?.GetType() ?? typeof(object))
            .ToDictionary(g => g.Key, g => g.Count());
        
        int min = typeCounts.Values.Min();
        int max = typeCounts.Values.Max();
        Assert.True((max - min) <= TOLERANCE);
    }
}