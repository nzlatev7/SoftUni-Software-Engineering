

using Facade;

var car = new CarBuilderFacade()
    .Info
        .WithType("bmw")
        .WithColor("red")
        .WithNumberOfDoors(4)
    .Address
        .InCity("Pernik")
        .AtAddress("orlowska")
    .Build();

Console.WriteLine(car);