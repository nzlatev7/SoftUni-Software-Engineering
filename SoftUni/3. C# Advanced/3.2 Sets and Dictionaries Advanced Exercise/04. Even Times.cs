
int n = int.Parse(Console.ReadLine());

Dictionary<int, int> nums = new Dictionary<int, int>();

int evenTimeNum = 0;

for (int i = 0; i < n; i++)
{
    int currentNum = int.Parse(Console.ReadLine());

    if (nums.ContainsKey(currentNum))
    {
        nums[currentNum]++;
    }
    else
    {
        nums.Add(currentNum, 1);
    }
}

Console.WriteLine(nums.Where(x => x.Value % 2 == 0).First().Key);