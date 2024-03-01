using System;
using System.Linq;

namespace _6._Jagged_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //6.	Jagged-Array Modification

            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                int[] sequence = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = sequence[j];
                }
            }

            //add
            //subtract

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] data = command.Split(" ");

                string currentOperation = data[0];
                int row = int.Parse(data[1]);
                int col = int.Parse(data[2]);
                int value = int.Parse(data[3]);

                //validate the indexes
                if (row < 0 || col < 0 || row >= n || col >= n)
                {
                    Console.WriteLine("Invalid coordinates");
                    continue;
                }

                if (currentOperation == "Add")
                {
                    matrix[row, col] += value;
                }
                else if (currentOperation == "Subtract")
                {
                    matrix[row, col] -= value;
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}