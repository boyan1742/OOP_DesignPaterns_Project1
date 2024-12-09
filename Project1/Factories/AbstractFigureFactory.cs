namespace Project1.Factories;

public class AbstractFigureFactory
{
    public IFigureFactory? GetFactory(string type) => GetFactory(type, "");
    
    public IFigureFactory? GetFactory(string type, string filePath = "") =>
        type switch
        {
            "Random" => new RandomFigureFactory(),
            "STDIN" => new StreamFigureFactory(Console.OpenStandardInput()),
            "File" => new StreamFigureFactory(new FileStream(filePath, FileMode.Open)),
            _ => null
        };
}