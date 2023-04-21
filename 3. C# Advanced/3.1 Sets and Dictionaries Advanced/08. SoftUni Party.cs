using System;
using System.Collections.Generic;

namespace _08._SoftUni_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> guests = new HashSet<string>();
            HashSet<string> vipGuests = new HashSet<string>();

            bool startParty = false;
            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string reservationNum = command;

                if (reservationNum == "PARTY")
                {
                    startParty = true;
                }
                if (startParty)
                {
                    if (vipGuests.Contains(reservationNum))
                    {
                        vipGuests.Remove(reservationNum);
                        continue;
                    }
                    guests.Remove(reservationNum);
                }
                else
                {
                    if (char.IsDigit(reservationNum[0]))
                    {
                        vipGuests.Add(reservationNum);
                        continue;
                    }
                    guests.Add(reservationNum);
                }
            }
            Console.WriteLine(guests.Count + vipGuests.Count);
            PrintGuests(vipGuests);
            PrintGuests(guests);

        }
        static void PrintGuests(HashSet<string> guests)
        {
            foreach (var guest in guests)
            {
                Console.WriteLine(guest);
            }
        }
    }
}
