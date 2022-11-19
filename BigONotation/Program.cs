// See https://aka.ms/new-console-template for more information

var parameter = string.Empty;

Console.WriteLine("Constant");
parameter = Console.ReadLine();
ConstantTest(Convert.ToInt32(parameter));
Console.WriteLine("-------------------");

Console.WriteLine("Linear");
parameter = Console.ReadLine();
LinearTest(Convert.ToInt32(parameter));
Console.WriteLine("-------------------");

Console.WriteLine("Quadratic");
parameter = Console.ReadLine();
QuadraticTest(Convert.ToInt32(parameter));
Console.WriteLine("-------------------");

Console.WriteLine("Exponential");
parameter = Console.ReadLine();
ExponentialTest(Convert.ToInt32(parameter));
Console.WriteLine("-------------------");

Console.WriteLine("Logarithmic");
Console.WriteLine("Type the length");
parameter = Console.ReadLine();
Console.WriteLine("Type the number to find");
var parameter2 = Console.ReadLine();
LogarithmicTest(Convert.ToInt32(parameter), Convert.ToInt32(parameter2));
Console.WriteLine("-------------------");

Console.ReadLine();

/*
 * Big O Notation - Complexity of algorithm
 * Way to measure the complexity of the code independent of the power computing
 * */

// O(1) Constants
void ConstantTest(int i)
{
    var interaction = 1;
    var sum = 1 + 2;
    Console.WriteLine($"interaction: {interaction}");
}

// O(n) Linear
void LinearTest(int length)
{
    var interaction = 0;
    for (int i = 0; i < length; i++)
    {
        var sum = i + 2;
        interaction++;
    }

    Console.WriteLine($"interaction: {interaction}");
}

// O(n²) Quadratic
void QuadraticTest(int length)
{
    var interaction = 0;
    for (int i = 0; i < length; i++)
    {
        for (int j = 0; j < length; j++)
        {
            var sum = i + j + 2;
            interaction++;
        }
    }

    Console.WriteLine($"interaction: {interaction}");
}

// O(2n) Exponential
void ExponentialTest(float value, int interaction = 0)
{
    interaction++;

    if (value < 0)
    {
        Console.WriteLine($"interaction: {interaction}");
        return;
    }

    var sub = value >= 5 ? 0.15F : 0.53F;
    ExponentialTest(value - sub, interaction);
}

// O(log n) Logarithmic
void LogarithmicTest(int length, int numberToFind)
{
    var cts = new CancellationTokenSource();
    cts.CancelAfter(TimeSpan.FromSeconds(3));

    var interaction = 1;
    var findTheNumber = false;
    var indexToValidate = length / 2;
    var lastIndexUsed = 0;

    var range = new int[length];
    for (int i = 0; i < length; i++)
        range[i] = i;

    while (!findTheNumber)
    {
        try
        {
            cts.Token.ThrowIfCancellationRequested();

            var valueFromRange = range[indexToValidate];

            if (numberToFind > valueFromRange)
            {
                lastIndexUsed = indexToValidate;
                var division = (length - indexToValidate);
                indexToValidate = (division / 2) + indexToValidate;
            }
            else if (numberToFind < valueFromRange)
            {
                var division = indexToValidate - lastIndexUsed;
                indexToValidate = ((division / 2) - indexToValidate)*-1;
            }
            else
            {
                findTheNumber = true;
                Console.WriteLine($"interaction: {interaction}");
            }

            interaction++;
        }
        catch
        {
            Console.WriteLine("Error");
            findTheNumber = true;
        }
    }
}