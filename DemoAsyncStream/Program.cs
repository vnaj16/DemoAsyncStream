//https://www.c-sharpcorner.com/learn/c-sharp-asynchronous-programming/working-with-async-stream-and-static-local-function-in-c-sharp-

await ExecuteAsyncStream();
ExecuteStream();
Console.ReadKey();

static async Task ExecuteAsyncStream()
{
    await foreach (var number in GenerateSequenceAsync())
    {
        Console.WriteLine();
        Console.WriteLine("Start show square of number "+DateTime.Now.ToString("hh:mm:ss.fff"));
        Console.WriteLine($"The square of number {number.Number} is: {number.Square}");
    }
}

static void ExecuteStream()
{
    foreach (var number in GenerateSequence())
    {
        Console.WriteLine();
        Console.WriteLine("Start show square of number " + DateTime.Now.ToString("hh:mm:ss.fff"));
        Console.WriteLine($"The square of number {number.Number} is: {number.Square}");
    }
}

static async IAsyncEnumerable<SquareNumber> GenerateSequenceAsync()
{
    for (int i = 1; i <= 10; i++)
    {
        Console.WriteLine($"Before yield value {i} " + DateTime.Now.ToString("hh:mm:ss.fff"));
        await Task.Delay(200);
        yield return new SquareNumber //El Yield retorna el elemento a donde se está usando, luego regresa aca y continua
        {
            Number = i,
            Square = i * i
        };
        Console.WriteLine($"After yield value {i} "+ DateTime.Now.ToString("hh:mm:ss.fff"));
        Console.WriteLine();
    }
}

static IEnumerable<SquareNumber> GenerateSequence()
{
    List<SquareNumber> numbers = new List<SquareNumber>();
    for (int i = 1; i <= 10; i++)
    {
        Console.WriteLine($"Before add value {i} " + DateTime.Now.ToString("hh:mm:ss.fff"));
        Task.Delay(200);
        numbers.Add(new SquareNumber
        {
            Number = i,
            Square = i * i
        });
        Console.WriteLine($"After add value {i} " + DateTime.Now.ToString("hh:mm:ss.fff"));
    }
    return numbers;
}
public class SquareNumber
{
    public int Number
    {
        get;
        set;
    }
    public int Square
    {
        get;
        set;
    }
}

