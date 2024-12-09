using Project1.Figures;

namespace Project1.Factories;

public class RandomFigureFactory : IFigureFactory
{
    private readonly Random _random;

    public RandomFigureFactory()
        : this(Random.Shared)
    {
    }

    public RandomFigureFactory(Random random)
    {
        _random = random;
    }

    public IFigure? Create()
    {
        var types = typeof(IFigure).Assembly.GetTypes();
        var figureTypes = types
            .Where(t => typeof(IFigure).IsAssignableFrom(t) && t is {IsClass: true, IsAbstract: false}).ToList();

        int selectedFigure = _random.Next(0, figureTypes.Count);

        var info = figureTypes[selectedFigure].GetConstructors()[0];

        while (true)
        {
            var paramsInfos = info.GetParameters();
            object?[] parameters = new object[paramsInfos.Length];
            for (var i = 0; i < paramsInfos.Length; i++)
            {
                parameters[i] = GenerateRandomValueForType(paramsInfos[i].ParameterType);
            }

            IFigure figure;

            try
            {
                figure = (IFigure) info.Invoke(parameters);
            }
            catch (Exception)
            {
                continue;
            }

            return figure;
        }
    }

    private object? GenerateRandomValueForType(Type parameterType)
    {
        if (parameterType == typeof(char))
        {
            byte[] sh = new byte[1];
            _random.NextBytes(sh);
            return (char) sh[0];
        }

        if (parameterType == typeof(short))
        {
            byte[] sh = new byte[2];
            _random.NextBytes(sh);
            return BitConverter.ToInt16(sh, 0) % 100;
        }
        
        if (parameterType == typeof(ushort))
        {
            byte[] sh = new byte[2];
            _random.NextBytes(sh);
            return BitConverter.ToUInt16(sh, 0) % 100;
        }
        
        if (parameterType == typeof(uint))
            return (uint)_random.Next() % 100;
        if (parameterType == typeof(ulong))
            return (ulong)_random.NextInt64() % 100;

        if (parameterType == typeof(int))
            return _random.Next() %  100;
        if (parameterType == typeof(long))
            return _random.NextInt64() % 100;
        if (parameterType == typeof(double))
            return _random.NextDouble();
        if (parameterType == typeof(float))
            return _random.NextSingle();
        
        return null;
    }
}