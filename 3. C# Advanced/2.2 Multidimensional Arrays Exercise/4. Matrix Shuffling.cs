
int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();

int rows = dimensions[0];
int cols = dimensions[1];

string[,] matrix = new string[rows, cols];

for (int row = 0; row < rows; row++)
{
    string[] elements = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

    for (int col = 0; col < elements.Length; col++)
    {
        matrix[row, col] = elements[col];
    }
}

string command;
while ((command = Console.ReadLine()) != "END")
{
    string[] data = command.Split();

    //validate the swap command
    if (data[0] != "swap")
    {
        Console.WriteLine("Invalid input!");
        continue;
    }

    //more cordinates validation
    if (data.Length != 5)
    {
        Console.WriteLine("Invalid input!");
        continue;
    }

    //indeces
    int row1 = int.Parse(data[1]);
    int col1 = int.Parse(data[2]);
    int row2 = int.Parse(data[3]);
    int col2 = int.Parse(data[4]);

    //validate the indeces
    if (row1 < 0 || row1 >= rows
        || row2 < 0 || row2 >= rows
        || col1 < 0 || col1 >= cols
        || col2 < 0 || col2 >= cols)
    {
        Console.WriteLine("Invalid input!");
        continue;
    }

    //operation
    string swaper = matrix[row1, col1];
    matrix[row1, col1] = matrix[row2, col2];
    matrix[row2, col2] = swaper;

    Print(matrix, rows, cols);
}

static void Print(string[,] matrix, int rows, int cols)
{
    for (int row = 0; row < rows; row++)
    {
        for (int col = 0; col < cols; col++)
        {
            Console.Write(matrix[row, col] + " ");
        }
        Console.WriteLine();
    }
}
