
int n = int.Parse(Console.ReadLine());

int[][] jaggedArray = new int[n][];

for (int row = 0; row < n; row++)
{
    int[] nums = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToArray();

    jaggedArray[row] = nums;

    if (row > 0)
    {
        if (jaggedArray[row - 1].Length == jaggedArray[row].Length)
        {
            Multiply(jaggedArray[row - 1]);
            Multiply(jaggedArray[row]);
        }
        else
        {
            Divede(jaggedArray[row - 1]);
            Divede(jaggedArray[row]);
        }
    }
}

string command;
while ((command = Console.ReadLine()) != "End")
{
    string[] data = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

    string firstCommand = data[0];

    int currentRow = int.Parse(data[1]);
    int currentCol = int.Parse(data[2]);
    int value = int.Parse(data[3]);


    if (currentRow < 0 || currentRow >= jaggedArray.Length
        || currentCol < 0 || currentCol >= jaggedArray[currentRow].Length)
    {
        continue;
    }

    if (firstCommand == "Add")
    {
        jaggedArray[currentRow][currentCol] += value;
    }
    else if (firstCommand == "Subtract")
    {
        jaggedArray[currentRow][currentCol] -= value;
    }
}

Print(jaggedArray);


//Methods
static void Print(int[][] jaggedArray)
{
    for (int row = 0; row < jaggedArray.Length; row++)
    {
        for (int col = 0; col < jaggedArray[row].Length; col++)
        {
            Console.Write(jaggedArray[row][col] + " ");
        }

        Console.WriteLine();
    }
}
static void Multiply(int[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        array[i] += array[i];
    }
}
static void Divede(int[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        array[i] /= 2;
    }
}
