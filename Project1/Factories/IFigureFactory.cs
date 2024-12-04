using Project1.Figures;

namespace Project1.Factories;

public interface IFigureFactory
{
    IFigure? Create();
}