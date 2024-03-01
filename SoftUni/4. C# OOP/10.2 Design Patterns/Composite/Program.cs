
using Composite;

var phone = new SingleGift("phone", 245);
phone.CalculateTotalPrice();
Console.WriteLine();

var rootBox = new CompositeGift("rootBox", 0);

var truck = new SingleGift("truck", 20);
var box = new CompositeGift("box", 0);
var soldierToy = new SingleGift("toy", 100);
box.Add(soldierToy);

rootBox.Add(truck);
rootBox.Add(box);

Console.WriteLine("Total price: {0}", rootBox.CalculateTotalPrice());