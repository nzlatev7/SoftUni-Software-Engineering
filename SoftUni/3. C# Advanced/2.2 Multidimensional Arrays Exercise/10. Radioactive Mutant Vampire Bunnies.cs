

string[] dimensions = Console.ReadLine().Split();

int rows = int.Parse(dimensions[0]);
int cols = int.Parse(dimensions[1]);

char[,] lair = new char[rows, cols];

int playerRow = 0;
int playerCol = 0;

for (int row = 0; row < rows; row++)
{
    string elements = Console.ReadLine();

    for (int col = 0; col < cols; col++)
    {
        lair[row, col] = elements[col];

        if (elements[col] == 'P')
        {
            playerRow = row;
            playerCol = col;

            //set the player as a dot, to be easy later
            lair[playerRow, playerCol] = '.';
        }
    }
}

//get the directions
string directions = Console.ReadLine();

int lastPlayerRow = playerRow;
int lastPlayerCol = playerCol;

foreach (var direction in directions)
{
    lastPlayerRow = playerRow;
    lastPlayerCol = playerCol;

    switch (direction)
    {
        case 'L':
            playerCol--;
            break;
        case 'R':
            playerCol++;
            break;
        case 'U':
            playerRow--;
            break;
        case 'D':
            playerRow++;
            break;
    }

    lair = SpreadBunnies(lair, rows, cols);

    if (playerRow < 0
        || playerRow >= rows
        || playerCol < 0
        || playerCol >= cols)
    {
        break;
    }

    if (lair[playerRow, playerCol] == 'B')
    {
        Print(lair, rows, cols);
        Console.WriteLine($"dead: {playerRow} {playerCol}");
        return;
    }
}
Print(lair, rows, cols);
Console.WriteLine($"won: {lastPlayerRow} {lastPlayerCol}");

static char[,] SpreadBunnies(char[,] lair, int rows, int cols)
{
    char[,] newLair = new char[rows, cols];

    for (int row = 0; row < rows; row++)
    {
        for (int col = 0; col < cols; col++)
        {
            newLair[row, col] = lair[row, col];
        }
    }

    for (int row = 0; row < rows; row++)
    {
        for (int col = 0; col < cols; col++)
        {
            if (lair[row, col] == 'B')
            {
                if (row > 0) //up
                {
                    newLair[row - 1, col] = 'B';
                }

                if (row < rows - 1) //down
                {
                    newLair[row + 1, col] = 'B';
                }

                if (col > 0) //left
                {
                    newLair[row, col - 1] = 'B';
                }

                if (col < cols - 1) //right
                {
                    newLair[row, col + 1] = 'B';
                }
            }
        }
    }

    return newLair;
}

static void Print(char[,] lair, int rows, int cols)
{
    for (int row = 0; row < rows; row++)
    {
        for (int col = 0; col < cols; col++)
        {
            Console.Write(lair[row, col]);
        }

        Console.WriteLine();
    }
}
