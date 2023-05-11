


List<int> numsForOurTask = Console.ReadLine().Split().Select(int.Parse).ToList();

int n = numsForOurTask[0]; // nums to read
int s = numsForOurTask[1]; // nums to pop
int x = numsForOurTask[2]; // num that i need to found

List<int> nums = Console.ReadLine().Split().Select(int.Parse).Take(n).ToList();

Stack<int> stackNums = new Stack<int>(nums);

for (int i = 0; i < s; i++)
{
    stackNums.Pop();
}

if (stackNums.Count == 0)
{
    Console.WriteLine(0);
    return;
}

if (stackNums.Contains(x))
{
    Console.WriteLine("true");
}
else
{
    Console.WriteLine(stackNums.Min());
}
