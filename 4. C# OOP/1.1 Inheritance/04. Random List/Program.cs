﻿using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList list = new RandomList();

            list.Add("1");
            list.Add("2");
            list.Add("3");

            string removedElement = list.RandomString();

            Console.WriteLine(removedElement);
        }
    }
}
