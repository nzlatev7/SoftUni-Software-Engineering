using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class DataModifier
    {
        public int DaysBetweenTwoDates(string firstDate, string secondDate)
        {
            string[] firstData = firstDate.Split();
            string[] secondData = secondDate.Split();


            DateTime startDate = new DateTime(int.Parse(firstData[0]), int.Parse(firstData[1]), int.Parse(firstData[2]));
            DateTime endDate = new DateTime(int.Parse(secondData[0]), int.Parse(secondData[1]), int.Parse(secondData[2]));

            return (endDate.Date - startDate.Date).Days;
        }

    }
}
