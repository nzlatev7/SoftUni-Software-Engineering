
int n = int.Parse(Console.ReadLine());

if (n < 3)
{
    Console.WriteLine(0);
    return;
}

char[,] board = new char[n, n];

for (int row = 0; row < n; row++)
{
    string elements = Console.ReadLine();

    for (int col = 0; col < n; col++)
    {
        board[row, col] = elements[col];
    }
}



int knightRemoved = 0;

while (true)
{
    int fights = 0;

    int rowIndexMax = 0;
    int colIndexMax = 0;
        
    for (int row = 0; row < n; row++)
    {
        for (int col = 0; col < n; col++)
        {
            if (board[row, col] == 'K')
            {
                int currentFights = CountAttackedKnights(board, row, col, n);

                if (fights < currentFights)
                {
                    fights = currentFights;
                    rowIndexMax = row;
                    colIndexMax = col;
                }
            }

        }
    }

    if (fights == 0)
    {
        break;
    }

    board[rowIndexMax, colIndexMax] = '0';
    knightRemoved++;
}

Console.WriteLine(knightRemoved);

static int CountAttackedKnights(char[,] board, int row, int col, int n)
{
    int counter = 0;

    //horizontal left-up
    if (IsValidCell(row - 1, col - 2, n))
    {
        if (board[row - 1, col - 2] == 'K')
        {
            counter++;
        }
    }

    //horizontal left-down
    if (IsValidCell(row + 1, col - 2, n))
    {
        if (board[row + 1, col - 2] == 'K')
        {
            counter++;
        }
    }

    //horizontal up-left
    if (IsValidCell(row - 2, col - 1, n))
    {
        if (board[row - 2, col - 1] == 'K')
        {
            counter++;
        }
    }

    //horizontal up-right
    if (IsValidCell(row - 2, col + 1, n))
    {
        if (board[row - 2, col + 1] == 'K')
        {
            counter++;
        }
    }

    //horizontal right-up
    if (IsValidCell(row - 1, col + 2, n))
    {
        if (board[row - 1, col + 2] == 'K')
        {
            counter++;
        }
    }

    //horizontal right-down
    if (IsValidCell(row + 1, col + 2, n))
    {
        if (board[row + 1, col + 2] == 'K')
        {
            counter++;
        }
    }

    //horizontal down-left
    if (IsValidCell(row + 2, col -1, n))
    {
        if (board[row + 2, col - 1] == 'K')
        {
            counter++;
        }
    }

    //horizontal down-right
    if (IsValidCell(row + 2, col + 1, n))
    {
        if (board[row + 2, col + 1] == 'K')
        {
            counter++;
        }
    }

    return counter;
}

static bool IsValidCell(int row, int col, int n)
{
    return row >= 0 
        && col >= 0 
        && row < n 
        && col < n;
}