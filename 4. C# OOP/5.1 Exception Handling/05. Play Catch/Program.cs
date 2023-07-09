
int[] nums = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int exceptionCount = 0;



while (true)
{
    if (exceptionCount == 3)
    {
        break;
    }

    string[] commandData = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

    string command = commandData[0];

    try
    {
        if (command == "Replace")
        {
            int index = int.Parse(commandData[1]);

            if (ValidateIndex(nums, index))
            {
                throw new IndexOutOfRangeException("The index does not exist!");
            }

            int element = int.Parse(commandData[2]);

            nums[index] = element;
        }
        else if (command == "Print")
        {
            int startIndex = int.Parse(commandData[1]);
            int endIndex = int.Parse(commandData[2]);

            if (ValidateIndex(nums, startIndex))
            {
                throw new IndexOutOfRangeException("The index does not exist!");
            }

            if (ValidateIndex(nums, endIndex))
            {
                throw new IndexOutOfRangeException("The index does not exist!");
            }

            int[] newArray = new int[endIndex - startIndex + 1];

            Array.Copy(nums, startIndex, newArray, 0, endIndex - startIndex + 1);

            Console.WriteLine(String.Join(", ", newArray));
        }
        else if (command == "Show")
        {
            int index = int.Parse(commandData[1]);

            if (ValidateIndex(nums, index))
            {
                throw new IndexOutOfRangeException("The index does not exist!");
            }

            Console.WriteLine(nums[index]);
        }
    }
    catch (FormatException)
    {
        exceptionCount++;
        Console.WriteLine("The variable is not in the correct format!");
    }
    catch (IndexOutOfRangeException ex)
    {
        exceptionCount++;
        Console.WriteLine(ex.Message);
    }
}

Console.WriteLine(String.Join(", ", nums));

static bool ValidateIndex(int[] nums, int index)
{ 
    return index < 0 || index >= nums.Length;
}

