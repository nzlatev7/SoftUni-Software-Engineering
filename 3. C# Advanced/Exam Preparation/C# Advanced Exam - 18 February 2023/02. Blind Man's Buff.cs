using System;
using System.Collections.Generic;
using System.Linq;

namespace _2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int n = dimensions[0];
            int m = dimensions[1];

            char[,] playground = new char[n, m];

            int blinderRow = 0;
            int blinderCol = 0;

            for (int row = 0; row < n; row++)
            {
                char[] current = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < m; col++)
                {
                    playground[row, col] = current[col];

                    if (playground[row, col] == 'B')
                    {
                        blinderRow = row;
                        blinderCol = col;
                    }
                }
            }

            List<string> commands = new List<string>();

            string command;
            while ((command = Console.ReadLine()) != "Finish")
            {
                commands.Add(command);
            }

            int touchOpponentCount = 0;
            int moves = 0;

            foreach (var currCommand in commands)
            {
                if (currCommand == "up")
                {
                    if (blinderRow - 1 < 0 || blinderRow - 1 >= n
                        || blinderCol < 0 || blinderCol >= m
                        || playground[blinderRow - 1, blinderCol] == 'O')
                    {
                        continue;
                    }

                    if (playground[blinderRow - 1, blinderCol] == 'P')
                    {
                        touchOpponentCount++;
                    }

                    moves++;

                    playground[blinderRow, blinderCol] = '-';

                    blinderRow--;
                    playground[blinderRow, blinderCol] = 'B';
                }
                else if (currCommand == "down")
                {

                    if (blinderRow + 1 < 0 || blinderRow + 1 >= n
                        || blinderCol < 0 || blinderCol >= m
                        || playground[blinderRow + 1, blinderCol] == 'O')
                    {
                        continue;
                    }

                    if (playground[blinderRow + 1, blinderCol] == 'P')
                    {
                        touchOpponentCount++;
                    }

                    moves++;

                    playground[blinderRow, blinderCol] = '-';

                    blinderRow++;
                    playground[blinderRow, blinderCol] = 'B';
                }
                else if (currCommand == "left")
                {
                    if (blinderRow < 0 || blinderRow >= n
                        || blinderCol - 1 < 0 || blinderCol - 1 >= m
                        || playground[blinderRow, blinderCol- 1] == 'O')
                    {
                        continue;
                    }

                    if (playground[blinderRow, blinderCol - 1] == 'P')
                    {
                        touchOpponentCount++;
                    }

                    moves++;

                    playground[blinderRow, blinderCol] = '-';

                    blinderCol--;
                    playground[blinderRow, blinderCol] = 'B';
                }
                else if (currCommand == "right")
                {
                    if (blinderRow < 0 || blinderRow >= n
                        || blinderCol + 1 < 0 || blinderCol + 1 >= m
                        || playground[blinderRow, blinderCol + 1] == 'O')
                    {
                        continue;
                    }

                    if (playground[blinderRow, blinderCol + 1] == 'P')
                    {
                        touchOpponentCount++;
                    }

                    moves++;

                    playground[blinderRow, blinderCol] = '-';

                    blinderCol++;
                    playground[blinderRow, blinderCol] = 'B';
                }

                if (touchOpponentCount == 3)
                {
                    break;
                }
            }

            Console.WriteLine("Game over!");
            Console.WriteLine($"Touched opponents: {touchOpponentCount} Moves made: {moves}");
        }
    }
}
