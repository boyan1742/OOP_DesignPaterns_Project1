using Project1.Figures;

namespace Project1.Factories;

public class StreamFigureFactory : IFigureFactory, IDisposable
{
    private readonly StreamReader _streamReader;
    private readonly StringToFigureFactory _stringToFigureFactory;
    
    public StreamFigureFactory(StreamReader streamReader)
    {
        _streamReader = streamReader;
        _stringToFigureFactory = new StringToFigureFactory();
    }
    
    public IFigure? Create()
    {
        if (_streamReader.EndOfStream)
            return null;
        
        string? line = _streamReader.ReadLine();
        if (line is null)
            return null;
        
        return _stringToFigureFactory.CreateFrom(line);
    }

    public void Dispose()
    {
        _streamReader.Dispose();
    }
}