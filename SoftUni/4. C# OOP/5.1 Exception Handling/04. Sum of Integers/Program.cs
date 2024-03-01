

string[] inputData = Console.ReadLine()
    .Split();

int totalSum = 0;

foreach (string element in inputData)
{
    try
    {
        int num = int.Parse(element);

        totalSum += num;
    }
    catch (FormatException)
    {
        Console.WriteLine($"The element '{element}' is in wrong format!");
    }
    catch (OverflowException)
    {
        Console.WriteLine($"The element '{element}' is out of range!");
    }
    finally
    {
        Console.WriteLine($"Element '{element}' processed - current sum: {totalSum}");
    }
}

Console.WriteLine($"The total sum of all integers is: {totalSum}");