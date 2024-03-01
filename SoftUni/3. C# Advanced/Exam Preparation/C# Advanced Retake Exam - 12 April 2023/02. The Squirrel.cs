using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            int fieldLength = int.Parse(Console.ReadLine());

            List<string> commands = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            char[,] field = new char[fieldLength, fieldLength];

            int squirrelRow = 0;
            int squirrelCol = 0;

            for (int row = 0; row < fieldLength; row++)
            {
                string current = Console.ReadLine();

                for (int col = 0; col < fieldLength; col++)
                {
                    field[row, col] = current[col];

                    if (current[col] == 's')
                    {
                        squirrelRow = row;
                        squirrelCol = col;
                    }
                }
            }

            int collectedHazelnuts = 0;
            bool isHavingMoreToCollect = false;

            foreach (var command in commands)
            {
                if (command == "left")
                {
                    squirrelCol--;
                }
                else if (command == "right")
                {
                    squirrelCol++;
                }
                else if (command == "up")
                {
                    squirrelRow--;
                }
                else if (command == "down")
                {
                    squirrelRow++;
                }

                if (squirrelRow < 0 || squirrelRow >= fieldLength
                    || squirrelCol < 0 || squirrelCol >= fieldLength)
                {
                    isHavingMoreToCollect = true;
                    Console.WriteLine("The squirrel is out of the field.");
                    break;
                }

                if (field[squirrelRow, squirrelCol] == 'h')
                {
                    field[squirrelRow, squirrelCol] = '*';
                    collectedHazelnuts++;
                }
                else if (field[squirrelRow, squirrelCol] == 't')
                {
                    isHavingMoreToCollect = true;
                    Console.WriteLine("Unfortunately, the squirrel stepped on a trap...");
                    break;
                }

                if (collectedHazelnuts == 3)
                {
                    isHavingMoreToCollect = true;
                    Console.WriteLine("Good job! You have collected all hazelnuts!");
                    break;
                }
                
            }

            if (!isHavingMoreToCollect)
            {
                Console.WriteLine("There are more hazelnuts to collect.");
            }

            Console.WriteLine($"Hazelnuts collected: {collectedHazelnuts}");
        }
    }
}
