
int durGreenLigth = int.Parse(Console.ReadLine()); //durationOfGreenLigth

int durFreeWindow = int.Parse(Console.ReadLine()); //durationOfFreeWindow


Queue<string> cars = new Queue<string>();

int carCount = 0;

string command;
while ((command = Console.ReadLine()) != "END")
{
    if (command != "green")
    {
        cars.Enqueue(command);
        continue;
    }

    int currentGreen = durGreenLigth;

    while (currentGreen > 0 && cars.Count > 0)
    {
        string currentCar = cars.Dequeue();

        if (currentGreen - currentCar.Length >= 0)
        {
            currentGreen -= currentCar.Length;
            carCount++;
            continue;
        }

        if (currentGreen + durFreeWindow - currentCar.Length >=  0)
        {
            carCount++;
            continue;
        }


        int hittedChar = currentGreen + durFreeWindow;

        Console.WriteLine("A crash happened!");
        Console.WriteLine($"{currentCar} was hit at {currentCar[hittedChar]}.");

        return;
    }
}
Console.WriteLine("Everyone is safe.");
Console.WriteLine($"{carCount} total cars passed the crossroads.");