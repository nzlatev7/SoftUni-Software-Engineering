using System;

namespace _5
{
    public class Stat
    {
        private const string ExceptionMesssage = "{0} should be between 0 and 100.";
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Stat(int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
        }

        public int Endurance 
        {
            get => endurance;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(string.Format(ExceptionMesssage, nameof(Endurance)));
                }

                endurance = value;
            }
        }
        public int Sprint
        {
            get => sprint;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(string.Format(ExceptionMesssage, nameof(Sprint)));
                }

                sprint = value;
            }
        }
        public int Dribble
        {
            get => dribble;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(string.Format(ExceptionMesssage, nameof(Dribble)));
                }

                dribble = value;
            }
        }
        public int Passing
        {
            get => passing;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(string.Format(ExceptionMesssage, nameof(Passing)));
                }

                passing = value;
            }
        }
        public int Shooting
        {
            get => shooting;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(string.Format(ExceptionMesssage, nameof(Shooting)));
                }

                shooting = value;
            }
        }


        public double SkillLevel { get => CalculateSkillLevel(); }

        public double CalculateSkillLevel()
        {
            return (endurance + sprint + dribble + passing + shooting) / 5.0; 
        }
    }
}