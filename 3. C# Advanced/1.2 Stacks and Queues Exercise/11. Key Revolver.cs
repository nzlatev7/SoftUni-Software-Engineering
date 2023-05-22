
int priceOfBullet = int.Parse(Console.ReadLine());
int gunBarrel = int.Parse(Console.ReadLine());

List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();

Stack<int> bullets = new Stack<int>(nums);

Queue<int> locks = new(
    Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToArray());

int intelligence = int.Parse(Console.ReadLine());

int gunBarrelSupport = 0;
int shootsCount = 0;
int initialBulletsCount = bullets.Count;

for (int i = 0; i < initialBulletsCount; i++)
{
    if (bullets.Pop() <= locks.Peek())
    {
        Console.WriteLine("Bang!");
        locks.Dequeue();
    }
    else
    {
        Console.WriteLine("Ping!");
    }

    shootsCount++;
    gunBarrelSupport++;

    if (gunBarrelSupport == gunBarrel && bullets.Any())
    {
        Console.WriteLine("Reloading!");
        gunBarrelSupport = 0;
    }

    if (!bullets.Any() && locks.Any())
    {
        Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
        return;
    }

    if (!locks.Any())
    {
        break;
    }
}
Console.WriteLine($"{bullets.Count} bullets left. Earned ${intelligence - shootsCount * priceOfBullet}");