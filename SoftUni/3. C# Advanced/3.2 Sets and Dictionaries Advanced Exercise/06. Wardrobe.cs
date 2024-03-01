
int n = int.Parse(Console.ReadLine());

Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

for (int i = 0; i < n; i++)
{
    string[] data = Console.ReadLine().Split(" -> ");

    string color = data[0];

    List<string> clothesForAdding = new List<string>(data[1].Split(",", StringSplitOptions.RemoveEmptyEntries));

    if (wardrobe.ContainsKey(color))
    {
        foreach (var garment in clothesForAdding)
        {
            if (wardrobe[color].ContainsKey(garment))
            {
                wardrobe[color][garment]++;
            }
            else
            {
                wardrobe[color].Add(garment, 1);
            }
        }
    }
    else
    {
        Dictionary<string, int> clothes = new Dictionary<string, int>();
        foreach (var garment in clothesForAdding)
        {
            if (!clothes.ContainsKey(garment))
            {
                clothes.Add(garment, 1);
            }
            
        }

        wardrobe.Add(color, clothes);
    }
}

string[] item = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
string searchingColor = item[0];
string seachingGarment = item[1];

bool isFoundColor = false;
bool isFoundGarment = false;

foreach (var garment in wardrobe)
{
    if (searchingColor == garment.Key)
    {
        isFoundColor = true;
    }

    Console.WriteLine($"{garment.Key} clothes:");

    foreach (var current in garment.Value)
    {
        if (current.Key == seachingGarment)
        {
            isFoundGarment = true;
        }

        if (isFoundColor && isFoundGarment)
        {
            Console.WriteLine($"* {current.Key} - {current.Value} (found!)");

            isFoundColor = false;
            isFoundGarment = false;

            continue;
        }

        Console.WriteLine($"* {current.Key} - {current.Value}");
    }
}
