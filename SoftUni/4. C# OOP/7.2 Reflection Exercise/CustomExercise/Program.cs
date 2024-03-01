
using CustomExer.Exceptions;
using CustomExer.Models;
using CustomExer.Utils;

Car car = new Car("12", 1999);

try
{
    bool isValid = Validator.IsValid(car);

    Console.WriteLine(isValid);
}
catch (ValidationExeption ex)
{
    Console.WriteLine($"Error code: {ex.ErrorCode}");
    Console.WriteLine($"Message: {ex.Message}");
}
