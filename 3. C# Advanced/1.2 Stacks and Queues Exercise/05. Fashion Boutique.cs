

Stack<int> clothes = new Stack<int>(
    Console.ReadLine()
        .Split()
        .Select(int.Parse));

int capacityOfRack = int.Parse(Console.ReadLine());

int sum = 0;
int length = clothes.Count;

int rackCounter = 1;

for (int i = 0; i < length; i++)
{
    int current = clothes.Pop();

    if(sum + current > capacityOfRack)
    {
        sum = 0;
        rackCounter++;
    }

    sum += current;
}
Console.WriteLine(rackCounter);
