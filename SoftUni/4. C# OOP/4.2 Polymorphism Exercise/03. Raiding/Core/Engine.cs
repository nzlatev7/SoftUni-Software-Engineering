using _3.Core.Interfaces;
using _3.Factories.Interfaces;
using _3.IO;
using _3.IO.Interfaces;
using _3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IHeroFactory heroFactory;

        private ICollection<IBaseHero> heroes;

        public Engine(IReader reader, IWriter writer, IHeroFactory heroFactory)
        {
            this.reader = reader;
            this.writer = writer;
            this.heroFactory = heroFactory;

            heroes = new List<IBaseHero>();
        }

        public void Run()
        {
            int n = int.Parse(reader.ReadLine());

            for (int i = 0; i < n; i++)
            {
                try
                {
                    heroes.Add(CreateHero());                  
                }
                catch (Exception ex)
                {
                    i--;
                    writer.WriteLine(ex.Message);
                }          
            }

            int bossPower = int.Parse(reader.ReadLine());

            foreach (var hero in heroes)
            {
                writer.WriteLine(hero.CastAbility());
            }

            if (heroes.Sum(h => h.Power) >= bossPower)
            {
                writer.WriteLine("Victory!");
            }
            else
            {
                writer.WriteLine("Defeat...");
            }

        }

        private IBaseHero CreateHero()
        {
            string heroName = reader.ReadLine();
            string heroType = reader.ReadLine();

            return heroFactory.Create(heroName, heroType);
        }
    }
}
