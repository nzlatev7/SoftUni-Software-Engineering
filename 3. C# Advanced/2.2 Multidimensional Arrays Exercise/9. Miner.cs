
int size = int.Parse(Console.ReadLine());

char[,] field = new char[size, size];

string[] directions = Console.ReadLine().Split();

int coals = 0;

int minerRowIndex = 0;
int minerColIndex = 0;

for (int row = 0; row < size; row++)
{
    char[] elements = Console.ReadLine()
        .Split()
        .Select(char.Parse)
        .ToArray();

    for (int col = 0; col < size; col++)
    {
        field[row, col] = elements[col];

        if (elements[col] == 'c')
        {
            coals++;
        }
        if (elements[col] == 's')
        {
            minerRowIndex = row;
            minerColIndex = col;
        }
    }
}

int collectedCoal = 0;

foreach (var direction in directions)
{
    switch (direction)
    {
        case "up":
            if (minerRowIndex > 0) //up
            {
                minerRowIndex--;
            }
            break;
        case "down":
            if (minerRowIndex < size - 1) //down
            {
                minerRowIndex++;
            }
            break;
        case "left":
            if (minerColIndex > 0) //left
            {
                minerColIndex--;
            }
            break;
        case "right":
            if (minerColIndex < size - 1) //right
            {
                minerColIndex++;
            }
            break;
    }
    

    if (field[minerRowIndex, minerColIndex] == 'c')
    {
        collectedCoal++;
        field[minerRowIndex, minerColIndex] = '*';
    }

    //if collecting all coals
    if (coals == collectedCoal)
    {
        Console.WriteLine($"You collected all coals! ({ minerRowIndex }, { minerColIndex })");
        return;
    }

    // if current = 'e' - end game
    if (field[minerRowIndex, minerColIndex] == 'e')
    {
        Console.WriteLine($"Game over!({ minerRowIndex}, { minerColIndex })");
        return;
    }
}
Console.WriteLine($"{coals - collectedCoal} coals left. ({minerRowIndex}, {minerColIndex})");
