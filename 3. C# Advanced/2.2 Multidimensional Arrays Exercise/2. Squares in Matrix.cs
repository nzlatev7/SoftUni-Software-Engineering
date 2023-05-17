
int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();

int rows = dimensions[0];
int cols = dimensions[1];

char[,] chars = new char[rows, cols];

for (int row = 0; row < rows; row++)
{
    char[] elements = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .Select(char.Parse)
        .ToArray();

    for (int col = 0; col < elements.Length; col++)
    {
        chars[row, col] = elements[col];
    }
}

int countMatrix = 0;

for (int row = 0; row < rows - 1; row++)
{

    for (int col = 0; col < cols - 1; col++)
    {
        if (chars[row,col] == chars[row,col + 1] 
            && chars[row, col] == chars[row + 1, col] 
            && chars[row, col] == chars[row + 1, col + 1])
        {
            countMatrix++;
        }
    }
}
Console.WriteLine(countMatrix);