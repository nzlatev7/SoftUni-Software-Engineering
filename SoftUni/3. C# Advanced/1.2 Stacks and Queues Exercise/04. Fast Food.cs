
int quantity = int.Parse(Console.ReadLine());

List<int> sequence = Console.ReadLine().Split().Select(int.Parse).ToList();

Queue<int> orders = new Queue<int>(sequence); // here we enqueue the all orders

Console.WriteLine(orders.Max());

int lenght = orders.Count;
for (int i = 0; i < lenght; i++)
{
    int currentOrder = orders.Dequeue();
    if (quantity - currentOrder >= 0)
    {
        quantity -= currentOrder;
    }
    else
    {
        orders.Enqueue(currentOrder);
        LastBecomeFirst(orders);

        Console.WriteLine($"Orders left: {string.Join(" ", orders)}");
        return;
    }
}

Console.WriteLine("Orders complete");

static void LastBecomeFirst(Queue<int> orders)
{
    for (int i = 0; i < orders.Count - 1; i++)
    {
        orders.Enqueue(orders.Dequeue());
    }
}
