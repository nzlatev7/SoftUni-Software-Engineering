
int n = int.Parse(Console.ReadLine());

int[,] matrix = new int[n, n];

for (int row = 0; row < n; row++)
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

string[] allIndexes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

foreach (var currentIndexes in allIndexes)
{
    int[] indexes = currentIndexes.Split(",", StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToArray();


    int currentRow = indexes[0];
    int currentCol = indexes[1];

    int value = matrix[currentRow, currentCol];

    if (value > 0)
    {
        matrix[currentRow, currentCol] = 0;

        if (currentRow > 0) //up
        {
            if (IsAlive(matrix[currentRow - 1, currentCol]))
            {
                matrix[currentRow - 1, currentCol] -= value;
            }
        }
        if (currentRow < n - 1) //down
        {
            if (IsAlive(matrix[currentRow + 1, currentCol]))
            {
                matrix[currentRow + 1, currentCol] -= value;
            }
        }
        if (currentCol > 0) //left
        {
            if (IsAlive(matrix[currentRow, currentCol - 1]))
            {
                matrix[currentRow, currentCol - 1] -= value;
            }
        }
        if (currentCol < n - 1) //right
        {
            if (IsAlive(matrix[currentRow, currentCol + 1]))
            {
                matrix[currentRow, currentCol + 1] -= value;
            }
        }

        //diagonals
        if (currentRow > 0 && currentCol > 0) //*
        {
            if (IsAlive(matrix[currentRow - 1, currentCol - 1]))
            {
                matrix[currentRow - 1, currentCol - 1] -= value;
            }

        }
        if (currentRow > 0 && currentCol < n - 1) // *
        {
            if (IsAlive(matrix[currentRow - 1, currentCol + 1]))
            {
                matrix[currentRow - 1, currentCol + 1] -= value;
            }
        }

        if (currentCol > 0 && currentRow < n - 1) //.
        {
            if (IsAlive(matrix[currentRow + 1, currentCol - 1]))
            {
                matrix[currentRow + 1, currentCol - 1] -= value;
            }
        }
        if (currentCol < n - 1 && currentRow < n - 1) // .
        {
            if (IsAlive(matrix[currentRow + 1, currentCol + 1]))
            {
                matrix[currentRow + 1, currentCol + 1] -= value;
            }
        }
    }
}

int aliveCells = 0;
int sumOfAlive = 0;
for (int row = 0; row < n; row++)
{
    for (int col = 0; col < n; col++)
    {
        if (matrix[row, col] > 0)
        {
            aliveCells++;
            sumOfAlive+= matrix[row, col];
        }
    }
}

Console.WriteLine($"Alive cells: {aliveCells}");
Console.WriteLine($"Sum: {sumOfAlive}");

for (int row = 0; row < n; row++)
{
    for (int col = 0; col < n; col++)
    {
            Console.Write(matrix[row, col] + " ");
    }

    Console.WriteLine();
}


static bool IsAlive(int num)
{
    return num > 0;
}