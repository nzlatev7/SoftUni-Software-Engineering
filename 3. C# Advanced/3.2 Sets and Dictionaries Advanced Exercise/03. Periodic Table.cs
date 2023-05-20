
int n = int.Parse(Console.ReadLine());

HashSet<string> set = new HashSet<string>();

for (int i = 0; i < n; i++)
{
    string[] chemicals = Console.ReadLine().Split();

    for (int j = 0; j < chemicals.Length; j++)
    {
        set.Add(chemicals[j]);

        // UnionWith as alternative solution
    }
}

foreach (var chemical in set.OrderBy(x => x))
{
    Console.Write(chemical + " ");
}