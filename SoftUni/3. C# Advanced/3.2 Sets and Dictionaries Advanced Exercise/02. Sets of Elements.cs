
string[] dimensions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
int n = int.Parse(dimensions[0]);
int m = int.Parse(dimensions[1]);

HashSet<int> firstSet = new HashSet<int>();
HashSet<int> secondSet = new HashSet<int>();

for (int i = 0; i < n; i++)
{
    int currentNum = int.Parse(Console.ReadLine());
    firstSet.Add(currentNum);
}
for (int i = 0; i < m; i++)
{
    int currentNum = int.Parse(Console.ReadLine());
    secondSet.Add(currentNum);
}

foreach (var num1 in firstSet)
{
    foreach (var num2 in secondSet)
    {
        if (num1 == num2)
        {
            Console.Write(num1 + " ");
        }
    }
}

//or using IntersectWith
//firstSet.IntersectWith(secondSet);
//Console.WriteLine(String.Join(" ", firstSet));