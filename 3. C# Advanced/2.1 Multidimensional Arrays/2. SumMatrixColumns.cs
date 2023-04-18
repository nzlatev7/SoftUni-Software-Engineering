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

            List<int> allSums = new List<int>();

            for (int i = 0; i < rows; i++)
            {
                int[] array = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = array[j];

                }
            }

            int currentSum = 0;
            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    currentSum += matrix[j, i];
                }
                allSums.Add(currentSum);
                currentSum = 0;
            }

            Console.WriteLine(string.Join(Environment.NewLine, allSums));
        }
    }
}
