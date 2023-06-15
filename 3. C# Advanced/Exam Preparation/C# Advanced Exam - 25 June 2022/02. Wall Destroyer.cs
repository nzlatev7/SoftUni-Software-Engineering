using System;

namespace _2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] wall = new char[n, n];

            int vankoRow = 0;
            int vankoCol = 0;

            for (int row = 0; row < n; row++)
            {
                string elements = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    wall[row, col] = elements[col];

                    if (wall[row, col] == 'V')
                    {
                        vankoRow = row;
                        vankoCol = col;
                    }
                }
            }

            int holeCount = 1;
            int rodCount = 0;

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                int newRow = vankoRow;
                int newCol = vankoCol;

                switch (command)
                {
                    case "left":
                        newCol--;
                        break;
                    case "right":
                        newCol++;
                        break;
                    case "up":
                        newRow--;
                        break;
                    case "down":
                        newRow++;
                        break;
                }

                char cell = wall[newRow, newCol];

                if (!ValidateIndex(newRow, newCol, n))
                {
                    continue;
                }

                if (cell == 'R')
                {
                    Console.WriteLine("Vanko hit a rod!");
                    rodCount++;
                    continue;
                }

                if (cell == 'C')
                {
                    wall[newRow, newCol] = 'E';

                    holeCount++;
                    wall[vankoRow, vankoCol] = '*';

                    Console.WriteLine($"Vanko got electrocuted, but he managed to make {holeCount} hole(s).");
                    PrintMatrix(wall, n);
                    return;
                }

                if (cell == '*')
                {
                    Console.WriteLine($"The wall is already destroyed at position [{newRow}, {newCol}]!");

                    wall[vankoRow, vankoCol] = '*';

                    wall[newRow, newCol] = 'V';

                    vankoRow = newRow;
                    vankoCol = newCol;
                    continue;
                }

                holeCount++;
                wall[vankoRow, vankoCol] = '*';

                wall[newRow, newCol] = 'V';

                vankoRow = newRow;
                vankoCol = newCol;
            }

            Console.WriteLine($"Vanko managed to make {holeCount} hole(s) and he hit only {rodCount} rod(s).");

            PrintMatrix(wall, n);
        }
        static void PrintMatrix(char[,] wall, int n)
        {
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(wall[row, col]);
                }

                Console.WriteLine();
            }
        }
        static bool ValidateIndex(int row, int col, int n)
        {
            if (row < 0 || row >= n
                || col < 0 || col >= n)
            {
                return false;
            }

            return true;
        }
    }
}
