
Queue<int> cups = new Queue<int>(
    Console.ReadLine()
    .Split()
    .Select(int.Parse));

Stack<int> bottles = new Stack<int>(
    Console.ReadLine()
    .Split()
    .Select(int.Parse));

int wastedWater = 0;

int currentBottle = 0;
int currentCup = 0;

int remaining = 0;
int lastCup = 0;

while (bottles.Any())
{
    //exit
    if (cups.Count == 0 || bottles.Count == 0)
    {
        break;
    }

    currentBottle = bottles.Peek();
    currentCup = cups.Peek();

    
    if (currentCup - currentBottle <= 0)
    {
        bottles.Pop();
        cups.Dequeue();

        remaining = currentBottle - currentCup;
        wastedWater += remaining;
    }
    else
    {
        
        while (currentCup > 0)
        {
            lastCup = currentCup;
            currentBottle = bottles.Pop();
            currentCup -= currentBottle;
        }
        remaining = currentBottle - lastCup;

        wastedWater += remaining;

        cups.Dequeue();
    }
}
if (cups.Count == 0)
{
    Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
}
else
{
    Console.WriteLine($"Cups: {string.Join(" ", cups)}");
}
Console.WriteLine($"Wasted litters of water: { wastedWater }");
