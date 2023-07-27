
using Singleton;

class Program
{
    static void Main(string[] args)
    {
        //var instance = SingletonDataContrainer.Instance;
        //var instance2 = SingletonDataContrainer.Instance;

        for (int i = 0; i < 10; i++)
        {
            new Thread(() =>
            {
                var instance = SingletonDataContrainer.Instance;
            }).Start();
        }

        //int population = instance.GetPopulation("paris");
        //Console.WriteLine(population);
    }
}