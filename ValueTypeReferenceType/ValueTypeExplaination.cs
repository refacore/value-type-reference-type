namespace ValueTypeReferenceType;

public class ValueTypeExplaination
{
    public void Explain()
    {
        Console.WriteLine("Giai thich ve value type");

        int origin = 2;

        int square = Square(origin);

        Console.WriteLine("Bình phương biến origin");

        Console.WriteLine($"origin: {origin}");

        Console.WriteLine($"square: {square}");

        Console.WriteLine("Bình phương của bình phương square");

        int squareOfSquare = Square(square);

        Console.WriteLine($"origin: {origin}");

        Console.WriteLine($"square: {square}");

        Console.WriteLine($"squareOfSquare: {squareOfSquare}");

        Console.WriteLine("================");
    }

    public void ExplainRef()
    {
        Console.WriteLine("Giai thich ve value type voi tu khoa ref");

        int origin = 2;

        int square = SquareRef(ref origin);

        Console.WriteLine("Bình phương biến origin");

        Console.WriteLine($"origin: {origin}");

        Console.WriteLine($"square: {square}");

        Console.WriteLine("Bình phương của bình phương square");

        int squareOfSquare = SquareRef(ref square);

        Console.WriteLine($"origin: {origin}");

        Console.WriteLine($"square: {square}");

        Console.WriteLine($"squareOfSquare: {squareOfSquare}");

        Console.WriteLine("================");
    }

    public void ExplainOut()
    {
        Console.WriteLine("Giai thich ve value type voi tu khoa out");

        int origin = 2;

        int outValue;

        int square = SquareOut(origin, out outValue);

        Console.WriteLine("Bình phương biến origin");

        Console.WriteLine($"origin: {origin}");

        Console.WriteLine($"square: {square}");

        Console.WriteLine($"outValue: {outValue}");

        Console.WriteLine("Bình phương của bình phương square");

        int outValue2;

        int squareOfSquare = SquareOut(square, out outValue2);

        Console.WriteLine($"origin: {origin}");

        Console.WriteLine($"square: {square}");

        Console.WriteLine($"outValue: {outValue}");

        Console.WriteLine($"outValue2: {outValue2}");

        Console.WriteLine($"squareOfSquare: {squareOfSquare}");

        Console.WriteLine("================");
    }

    private int SquareOut(int x, out int result)
    {
        result = x * 2;

        return result;
    }

    private int SquareRef(ref int x)
    {
        x = x * 2;

        return x;
    }

    private int Square(int x)
    {
        x = x * 2;

        return x;
    }
}
