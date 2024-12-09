using Project1.Factories;
using Project1.Figures;

Console.Write("Select an input method [Random/STDIN/File]: ");
string? input = null;

do
{
    if (input is not null)
        Console.Write("Invalid input! Try again [Random/STDIN/File]: ");

    input = Console.ReadLine();
} while (!IsInputValid(input));

bool filePathEntered = false;
string? filePath = null;
int n = 0;
if (input == "File")
{
    Console.Write("Enter the file that will be read: ");
    do
    {
        if (filePathEntered)
            Console.Write("Invalid file path! Try again: ");

        filePath = Console.ReadLine();
        filePathEntered = true;
    } while (string.IsNullOrEmpty(filePath));

    if (!File.Exists(filePath))
    {
        Console.WriteLine("The specified file doesn't exist!");
        Environment.Exit(0);
    }
}
else //here we should get the amount the user wants.
{
    Console.Write("Enter the amount of figures to generate/read: ");
    string? nStr = null;
    do
    {
        if (nStr is not null)
            Console.Write("Invalid number! Try again: ");

        nStr = Console.ReadLine();
    } while (string.IsNullOrEmpty(nStr) || !int.TryParse(nStr, out n) || n <= 0);
}

AbstractFigureFactory abstractFigureFactory = new();
IFigureFactory? factory = abstractFigureFactory.GetFactory(input!, filePath ?? "");

if (factory is null)
    throw new NotImplementedException(
        "The abstract figure factory returns an invalid factory. This can be because of a not implemented IFigureFactory and user input!");

List<IFigure> figures = [];

GenerateFigures(figures, factory, n);

do
{
    Console.Write("> ");
    input = Console.ReadLine();

    if (input?.ToLower() == "list")
    {
        ListFigures(figures);

        continue;
    }

    if (input?.ToLower() == "delete")
    {
        DeleteFigure(figures);

        continue;
    }

    if (input?.ToLower() == "duplicate")
    {
        DuplicateFigure(figures);

        continue;
    }

    if (input?.ToLower() == "save")
    {
        SaveFigures(figures);

        continue;
    }

    Console.WriteLine("\nInvalid Input!");
} while (!string.IsNullOrEmpty(input) && input.ToLower() != "exit");


static bool IsInputValid(string? input) => !string.IsNullOrEmpty(input) && input is "Random" or "STDIN" or "File";

static void GenerateFigures(List<IFigure> figures, IFigureFactory factory, int n)
{
    if (n == 0) //this is a file input.
    {
        while (true)
        {
            IFigure? f = factory.Create();;
            if(f is null)
                break;
            
            figures.Add(f);
        }
    }
    else //this is NOT a file input.
    {
        for (int i = 0; i < n; i++)
        {
            IFigure? f;
            do
            {
                f = factory.Create();
            } while (f is null);

            figures.Add(f);
        }
    }
}

static void ListFigures(List<IFigure> figures)
{
    int i = 0;
    foreach (var figure in figures)
        Console.WriteLine($"[{i++}]: {figure}");
}

static void DeleteFigure(List<IFigure> figures)
{
    int id = -1;

    do
    {
        if (id < 0)
            Console.Write("Enter an id to delete: ");

        if (int.TryParse(Console.ReadLine(), out id))
            break;
    } while (id < 0);

    if (id >= figures.Count)
        Console.WriteLine("Id was outside of the range of the figures!");

    figures.RemoveAt(id);
}

static void DuplicateFigure(List<IFigure> figures)
{
    int id = -1;

    do
    {
        if (id < 0)
            Console.Write("Enter an id to duplicate: ");

        if (int.TryParse(Console.ReadLine(), out id))
            break;
    } while (id < 0);

    if (id >= figures.Count)
        Console.WriteLine("Id was outside of the range of the figures!");

    figures.Add((figures[id].Clone() as IFigure)!);
}

void SaveFigures(List<IFigure> figures)
{
    string? filePath = null;

    Console.Write("Enter a path to save the figures to: ");

    do
    {
        if (filePath is not null)
            Console.Write("Invalid path! Try again: ");

        filePath = Console.ReadLine();
    } while (string.IsNullOrEmpty(filePath));

    string[] stringRep = new string[figures.Count];

    for (var i = 0; i < figures.Count; i++)
        stringRep[i] = figures[i].ToString() ?? "";

    File.WriteAllLines(filePath, stringRep);
}