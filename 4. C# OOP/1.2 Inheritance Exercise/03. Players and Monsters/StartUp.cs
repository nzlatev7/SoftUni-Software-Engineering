using System;

namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Knight knight = new Knight("fef", 3);
            Console.WriteLine(knight.Level);

            Console.WriteLine(knight);
        }
    }
}