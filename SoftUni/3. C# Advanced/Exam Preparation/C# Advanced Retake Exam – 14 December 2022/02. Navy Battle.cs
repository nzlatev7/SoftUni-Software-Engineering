using System;
using System.Collections.Generic;

namespace _2
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] battlefield = new char[size, size];

            int submarineRow = 0;
            int submarineCol = 0;

            for (int row = 0; row < size; row++)
            {
                string elements = Console.ReadLine();

                for (int col = 0; col < size; col++)
                {
                    battlefield[row, col] = elements[col];

                    if (battlefield[row, col] == 'S')
                    {
                        submarineRow = row;
                        submarineCol = col;
                    }
                }
            }

            int hits = 0;
            int cruiserDown = 0;

            string command;
            while ((command = Console.ReadLine()) != null)
            {
                switch (command)
                {
                    case "left":

                        if (IndexChecker(size, submarineRow, submarineCol - 1))
                        {
                            if (battlefield[submarineRow, submarineCol - 1] == '*')
                            {
                                hits++;
                            }

                            if (battlefield[submarineRow, submarineCol - 1] == 'C')
                            {
                                cruiserDown++;
                            }

                            battlefield[submarineRow, submarineCol] = '-';
                            battlefield[submarineRow, submarineCol - 1] = 'S';
                            submarineCol--;
                        }
                        break;
                    case "right":

                        if (IndexChecker(size, submarineRow, submarineCol + 1))
                        {
                            if (battlefield[submarineRow, submarineCol + 1] == '*')
                            {
                                hits++;
                            }

                            if (battlefield[submarineRow, submarineCol + 1] == 'C')
                            {
                                cruiserDown++;
                            }

                            battlefield[submarineRow, submarineCol] = '-';
                            battlefield[submarineRow, submarineCol + 1] = 'S';
                            submarineCol++;
                        }
                        break;
                    case "up":

                        if (IndexChecker(size, submarineRow - 1, submarineCol))
                        {
                            if (battlefield[submarineRow - 1, submarineCol] == '*')
                            {
                                hits++;
                            }

                            if (battlefield[submarineRow - 1, submarineCol] == 'C')
                            {
                                cruiserDown++;
                            }

                            battlefield[submarineRow, submarineCol] = '-';
                            battlefield[submarineRow - 1, submarineCol] = 'S';
                            submarineRow--;
                        }
                        break;
                    case "down":

                        if (IndexChecker(size, submarineRow + 1, submarineCol))
                        {
                            if (battlefield[submarineRow + 1, submarineCol] == '*')
                            {
                                hits++;
                            }

                            if (battlefield[submarineRow + 1, submarineCol] == 'C')
                            {
                                cruiserDown++;
                            }

                            battlefield[submarineRow, submarineCol] = '-';
                            battlefield[submarineRow + 1, submarineCol] = 'S';
                            submarineRow++;
                        }
                        break;
                }


                if (hits == 3)
                {
                    Console.WriteLine($"Mission failed, U-9 disappeared! Last known coordinates [{submarineRow}, {submarineCol}]!");
                    break;
                }

                if (cruiserDown == 3)
                {
                    Console.WriteLine("Mission accomplished, U-9 has destroyed all battle cruisers of the enemy!");
                    break;
                }
            }

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(battlefield[row, col]);
                }

                Console.WriteLine();
            }
            

            
        }
        static bool IndexChecker(int size, int row, int col)
        {
            if (row < 0 || row >= size
                || col < 0 || col >= size)
            {
                return false;
            }

            return true;
        }
    }
}
