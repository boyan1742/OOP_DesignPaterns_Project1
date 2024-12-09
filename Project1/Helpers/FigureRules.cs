namespace Project1.Helpers;

public static class FigureRules
{
    public static bool IsTriangleRule(int a, int b, int c) => a + b > c && a + c > b && b + c > a;

    public static bool DoesOverflow(int a, int b, int c, int d)
    {
        try
        {
            checked
            {
                int _ = a + b + c + d;
            }
        }
        catch (OverflowException)
        {
            return true;
        }

        return false;
    }

    public static bool DoesOverflow(int a, int b, int c)
    {
        try
        {
            checked
            {
                int _ = a + b + c;
            }
        }
        catch (OverflowException)
        {
            return true;
        }

        return false;
    }

    public static bool DoesOverflow(double d) => double.IsPositiveInfinity(d) || double.IsNegativeInfinity(d);
}