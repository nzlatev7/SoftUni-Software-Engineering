
int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();

int rows = dimensions[0];
int cols = dimensions[1];

char[,] matrix = new char[rows, cols];

string word = Console.ReadLine();
int currentIndexOfWord = 0;
for (int row = 0; row < rows; row++)
{
    if (row % 2 == 0)
    {
        for (int col = 0; col < cols; col++)
        {
            if (currentIndexOfWord == word.Length)
            {
                currentIndexOfWord = 0;
            }

            matrix[row, col] = word[currentIndexOfWord];
            currentIndexOfWord++;
        }
    }
    else
    {
        for (int col = cols - 1; col >= 0; col--)
        {
            if (currentIndexOfWord == word.Length)
            {
                currentIndexOfWord = 0;
            }

            matrix[row, col] = word[currentIndexOfWord];
            currentIndexOfWord++;
        }
    } 
}

for (int row = 0; row < rows; row++)
{
    for (int col = 0; col < cols; col++)
    {
        Console.Write(matrix[row, col]);
    }
    Console.WriteLine();
}
