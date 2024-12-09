using Project1.Figures;

namespace Project1.Factories;

public class StreamFigureFactory : IFigureFactory, IDisposable
{
    private readonly Stream _stream;
    private readonly StreamReader _reader;
    private readonly StringToFigureFactory _stringToFigureFactory;
    
    public StreamFigureFactory(Stream stream)
    {
        _stream = stream;
        _reader = new StreamReader(_stream);
        _stringToFigureFactory = new StringToFigureFactory();
    }
    
    public IFigure? Create()
    {
        if (_reader.EndOfStream)
            return null;

        string? line = _reader.ReadLine();
        
        return line is null ? null : _stringToFigureFactory.CreateFrom(line);
    }

    public void Dispose()
    {
        _reader.Dispose();
        _stream.Dispose();
    }
}