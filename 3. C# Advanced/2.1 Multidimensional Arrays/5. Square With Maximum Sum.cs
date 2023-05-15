using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._SumMatrixElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            int rows = sizes[0];
            int columns = sizes[1];

            int[,] matrix = new int[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                int[] array = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = array[j];

                }
            }

            int highSum = 0;
            List<int> highNums = new List<int>();

            int currentSum = 0;
            for (int i = 0; i < rows - 1; i++)
            {
                for (int j = 0; j < columns - 1; j++)
                {
                    currentSum = matrix[i, j] + matrix[i, j + 1] + matrix[i + 1, j] + matrix[i + 1, j + 1];

                    if (highSum < currentSum)
                    {
                        highNums.Clear();

                        highSum = currentSum;

                        highNums.Add(matrix[i, j]);
                        highNums.Add(matrix[i, j + 1]);
                        highNums.Add(matrix[i + 1, j]);
                        highNums.Add(matrix[i + 1, j + 1]);
                    }
                }
            }

            int skipper = 0;
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    int currentNumForPrint = highNums[skipper];
                    Console.Write(currentNumForPrint + " ");
                    skipper++;
                }

                Console.WriteLine();
            }
            Console.WriteLine(highSum);
        }
    }
}
