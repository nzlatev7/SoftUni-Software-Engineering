
int n = int.Parse(Console.ReadLine());

int[,] array = new int[n, n];

for (int row = 0; row < n; row++)
{
    int[] nums = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

    for (int col = 0; col < nums.Length; col++)
    {
        array[row, col] = nums[col];
    }
}

int primaryDiaSum = 0;
int secondaryDiaSum = 0;

for (int row = 0; row < n; row++)
{
    for (int col = 0; col < n; col++)
    {
        if (row == col)
        {
            primaryDiaSum += array[row, col];
        }

        if (col + row == n -1)
        {
            secondaryDiaSum += array[row, col];
        }
    }
}

if (primaryDiaSum >= secondaryDiaSum)
{
    Console.WriteLine(primaryDiaSum - secondaryDiaSum);
}
else
{
    Console.WriteLine(secondaryDiaSum - primaryDiaSum);
}