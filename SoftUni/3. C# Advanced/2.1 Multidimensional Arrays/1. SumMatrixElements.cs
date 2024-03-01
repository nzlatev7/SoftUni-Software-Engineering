using System;
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

            int sum = 0;
            for (int i = 0; i < rows; i++)
            {
                int[] array = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                sum += array.Sum();
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = array[j];
                    
                }
            }

            Console.WriteLine(rows);
            Console.WriteLine(columns);
            Console.WriteLine(sum);   
        }
    }
}
