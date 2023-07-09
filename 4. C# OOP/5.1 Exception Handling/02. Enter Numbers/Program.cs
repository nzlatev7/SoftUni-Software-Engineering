
List<int> nums = new List<int>();

while (nums.Count != 10)
{
    try
    {
        int n = int.Parse(Console.ReadLine());

        if (n <= 1 || n >= 100)
        {
            int lastnum = nums.LastOrDefault() == 0
                ? 1
                : nums.LastOrDefault();

            throw new ArgumentException($"Your number is not in range {lastnum} - 100!");
        }
        else if (n > nums.LastOrDefault())
        { 
            nums.Add(n);
        }
        else
        {
            throw new ArgumentException($"Your number is not in range {nums.LastOrDefault()} - 100!");
        }
    }
    catch (FormatException ex)
    {
        Console.WriteLine("Invalid Number!");
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine(ex.Message);
    }
}

Console.WriteLine(string.Join(", ", nums));
