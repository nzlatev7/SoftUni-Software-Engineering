using System;
using System.Collections.Generic;

namespace _2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] field = new char[n, n];

            int moleRow = 0;
            int moleCol = 0;

            List<SpecialLocation> specials = new List<SpecialLocation>();

            for (int row = 0; row < n; row++)
            {
                string elements = Console.ReadLine();

                for (int col = 0; col < n; col++)
                {
                    field[row, col] = elements[col];

                    if (field[row, col] == 'M')
                    {
                        moleRow = row;
                        moleCol = col;
                    }

                    if (field[row,col] == 'S')
                    {
                        specials.Add(new SpecialLocation(row, col));
                    }
                }
            }

            int points = 0;

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                if (points >= 25)
                {
                    break;
                }

                if (command == "left")
                {
                    if (!CheckOutOfField(n, moleRow, moleCol - 1))
                    {
                        Console.WriteLine("Don't try to escape the playing field!");
                        continue;
                    }

                    field[moleRow, moleCol] = '-';
                    moleCol--;
                }
                else if (command == "right")
                {
                    if (!CheckOutOfField(n, moleRow, moleCol + 1))
                    {
                        Console.WriteLine("Don't try to escape the playing field!");
                        continue;
                    }

                    field[moleRow, moleCol] = '-';
                    moleCol++;
                }
                else if (command == "up")
                {
                    if (!CheckOutOfField(n, moleRow - 1, moleCol))
                    {
                        Console.WriteLine("Don't try to escape the playing field!");
                        continue;
                    }

                    field[moleRow, moleCol] = '-';
                    moleRow--;
                }
                else if (command == "down")
                {
                    if (!CheckOutOfField(n, moleRow + 1, moleCol))
                    {
                        Console.WriteLine("Don't try to escape the playing field!");
                        continue;
                    }

                    field[moleRow, moleCol] = '-';
                    moleRow++;
                }

                if (char.IsDigit(field[moleRow, moleCol]))
                {
                    points += int.Parse(field[moleRow, moleCol].ToString());
                }

                if (field[moleRow, moleCol] == 'S')
                {
                    SpecialLocation first = specials[0];
                    SpecialLocation second = specials[1];

                    if (moleRow == first.Row && moleCol == first.Col)
                    {
                        field[moleRow, moleCol] = '-';

                        moleRow = second.Row;
                        moleCol = second.Col;

                        points -= 3;
                    }
                    else
                    {
                        field[moleRow, moleCol] = '-';

                        moleRow = first.Row;
                        moleCol = first.Col;

                        points -= 3;
                    }
                }

                field[moleRow, moleCol] = 'M';
            }

            if (points >= 25)
            {
                Console.WriteLine("Yay! The Mole survived another game!");
                Console.WriteLine($"The Mole managed to survive with a total of {points} points.");
            }
            else
            {
                Console.WriteLine("Too bad! The Mole lost this battle!");
                Console.WriteLine($"The Mole lost the game with a total of {points} points.");
            }

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(field[row, col]);
                }

                Console.WriteLine();
            }
        }
        static bool CheckOutOfField(int n, int row, int col)
        {
            if (row < 0 || row >= n
                || col < 0 || col >= n)
            {
                return false;
            }

            return true;
        }
    }
    class SpecialLocation
    {
        public SpecialLocation(int row, int col)
        {
            Row = row;
            Col = col;
        }

        public int Row { get; set; }
        public int Col { get; set; }
    }
}
