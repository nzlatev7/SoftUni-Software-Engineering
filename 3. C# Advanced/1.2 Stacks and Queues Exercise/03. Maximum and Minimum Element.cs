
Stack<int> nums = new Stack<int>();

int n = int.Parse(Console.ReadLine());

for (int i = 0; i < n; i++)
{
    int[] commandAndNum = Console.ReadLine().Split().Select(int.Parse).ToArray();

    int commandNum = commandAndNum[0];

    if (commandNum == 1)
    {
        int num = commandAndNum[1];
        nums.Push(num);
    }
    else if (commandNum == 2)
    {
        nums.Pop();
    }
    else if (commandNum == 3)
    {
        if (nums.Any())
        {
            Console.WriteLine(nums.Max());
        }
    }
    else if (commandNum == 4)
    {
        if (nums.Any())
        {
            Console.WriteLine(nums.Min());
        }
    }
}
Console.WriteLine(String.Join(", ", nums));
