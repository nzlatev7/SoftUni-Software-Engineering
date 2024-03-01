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
                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int n = dimensions[0];
            int m = dimensions[1];

            char[,] field = new char[n, m];

            int mouseRow = 0;
            int mouseCol = 0;

            int cheeseCount = 0;
            for (int row = 0; row < n; row++)
            {
                string elements = Console.ReadLine();

                for (int col = 0; col < m; col++)
                {
                    field[row, col] = elements[col];

                    if (field[row, col] == 'M')
                    {
                        mouseRow = row;
                        mouseCol = col;
                    }

                    if (field[row, col] == 'C')
                    {
                        cheeseCount++;
                    }
                }
            }

            string command;
            while ((command = Console.ReadLine()) != "danger")
            {
                int newRow = mouseRow;
                int newCol = mouseCol;

                if (command == "left")
                {
                    newCol--;
                }
                else if (command == "right")
                {
                    newCol++;
                }
                else if (command == "up")
                {
                    newRow--;
                }
                else if (command == "down")
                {
                    newRow++;
                }

                if (IndexChecker(newRow, newCol, n, m))
                {
                    Console.WriteLine("No more cheese for tonight!");
                    PrintMatrix(field, n, m);
                    return;
                }

                if (field[newRow, newCol] == 'C')
                {
                    field[mouseRow, mouseCol] = '*';
                    field[newRow, newCol] = 'M';

                    cheeseCount--;

                    if (cheeseCount == 0)
                    {
                        Console.WriteLine("Happy mouse! All the cheese is eaten, good night!");
                        PrintMatrix(field, n, m);
                        return;
                    }
                }

                if (field[newRow, newCol] == 'T')
                {
                    Console.WriteLine("Mouse is trapped!");

                    field[mouseRow, mouseCol] = '*';
                    field[newRow, newCol] = 'M';

                    PrintMatrix(field, n, m);
                    return;
                }

                if (field[newRow, newCol] == '@')
                {
                    continue;
                }

                field[mouseRow, mouseCol] = '*';

                mouseRow = newRow;
                mouseCol = newCol;
                field[mouseRow, mouseCol] = 'M';
            }

            Console.WriteLine("Mouse will come back later!");
            PrintMatrix(field, n, m);
        }
        static bool IndexChecker(int row, int col, int n, int m)
        {
            return row < 0 || row >= n
                || col < 0 || col >= m;
        }
        static void PrintMatrix(char[,] matrix, int n, int m)
        {
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < m; col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
