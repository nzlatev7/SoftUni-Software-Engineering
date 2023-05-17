
int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();

int rows = dimensions[0];
int cols = dimensions[1];

int[,] matrix = new int[rows, cols];

for (int row = 0; row < rows; row++)
{
    int[] elements = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToArray();

    for (int col = 0; col < elements.Length; col++)
    {
        matrix[row, col] = elements[col];
    }
}

int biggestSum = 0;
int[,] biggestArray = new int[3,3];

for (int row = 0; row < rows; row++)
{
    if (row + 2 == rows)
    {
        break;
    }

    for (int col = 0; col < cols; col++)
    {
        if (col + 2 == cols)
        {
            break;
        }

        int currentSum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2]
            + matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2]
            + matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];

        if (biggestSum < currentSum)
        {
            biggestSum = currentSum;
            biggestArray[0, 0] = matrix[row, col];
            biggestArray[0, 1] = matrix[row, col + 1];
            biggestArray[0, 2] = matrix[row, col + 2];

            biggestArray[1, 0] = matrix[row + 1, col];
            biggestArray[1, 1] = matrix[row + 1, col + 1];
            biggestArray[1, 2] = matrix[row + 1, col + 2];

            biggestArray[2, 0] = matrix[row + 2, col];
            biggestArray[2, 1] = matrix[row + 2, col + 1];
            biggestArray[2, 2] = matrix[row + 2, col + 2];
        }
    }
}
Console.WriteLine("Sum = " + biggestSum);
for (int row = 0; row < 3; row++)
{
    for (int col = 0; col < 3; col++)
    {
        Console.Write(biggestArray[row, col] + " ");
    }
    Console.WriteLine();
}
