
using Command;
using Command.Enums;

var modifyPrice = new ModifyPrice();

var product = new Product("bira", 12.40m);

Execute(product, modifyPrice, new ProductCommand(product, PriceAction.Increase, 12));

Console.WriteLine(product.Price);

static void Execute(Product product, ModifyPrice modifyPrice, ICommand command)
{ 
    modifyPrice.SetCommand(command);
    modifyPrice.Invoke();
}