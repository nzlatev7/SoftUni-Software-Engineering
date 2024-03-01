
using zad;

Store store = new Store(new ProductTextDatabase());

Product product = new Product(1, "boss", 120, 10);

store.Add(new Product(2, "gucci", 120, 5));
store.Add(product);

Console.WriteLine(store.Count);
Console.WriteLine(store.Contains(product));

foreach (var currProduct in store)
{
    Console.WriteLine(currProduct.Label);
}