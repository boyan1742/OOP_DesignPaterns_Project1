using System.Collections;
using System.Reflection;
using Project1.Figures;

namespace Project1.Factories;

public class StringToFigureFactory
{
    public IFigure? CreateFrom(string representation)
    {
        string[] split = representation.Split(" ");
        string type = char.ToUpper(split[0][0]) + split[0][1..];
        
        var figureType = Assembly.GetAssembly(typeof(StringToFigureFactory))?.GetTypes()
            .SingleOrDefault(x => x.Name == type);
        if (figureType is null)
            return null;

        var ctors = figureType.GetConstructors(BindingFlags.Public);
        foreach (var info in ctors)
        {
            if (info.GetParameters().Length != split.Length - 1) 
                continue;
            
            var parameters = info.GetParameters();

            //I assume that all ctor parameters are ints, doubles, etc. not classes/structs. 
            if (parameters.Any(x => !x.ParameterType.IsValueType))
                continue;

            object?[] parameterValues = new object[parameters.Length];
            for (int i = 0; i < parameters.Length; i++)
            {
                try
                {
                    parameterValues[i] = Convert.ChangeType(split[i + 1], parameters[i].ParameterType);
                }
                catch (Exception)
                {
                    continue;
                }
            }

            return (IFigure) info.Invoke(parameterValues);
        }

        return null;
    }
}