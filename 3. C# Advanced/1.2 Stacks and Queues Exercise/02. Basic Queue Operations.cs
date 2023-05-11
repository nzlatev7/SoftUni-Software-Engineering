
List<int> numsForOurTask = Console.ReadLine().Split().Select(int.Parse).ToList();

int n = numsForOurTask[0]; // nums to read
int s = numsForOurTask[1]; // nums to pop
int x = numsForOurTask[2]; // num that i need to found

List<int> nums = Console.ReadLine().Split().Select(int.Parse).Take(n).ToList();

Queue<int> lastNums = new Queue<int>(nums);

for (int i = 0; i < s; i++)
{
    lastNums.Dequeue();
}

if (lastNums.Count == 0)
{
    Console.WriteLine(0);
    return;
}

Console.WriteLine(lastNums.Contains(x) ? "true" : lastNums.Min());

