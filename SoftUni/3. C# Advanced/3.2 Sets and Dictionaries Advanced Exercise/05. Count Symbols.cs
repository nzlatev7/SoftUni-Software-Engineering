
string text = Console.ReadLine();

Dictionary<char, int> characterCount = new Dictionary<char, int>();

foreach (var ch in text)
{
    if (characterCount.ContainsKey(ch))
    { 
        characterCount[ch]++;
    }
    else
    {
        characterCount.Add(ch, 1);
    }
}

foreach (var current in characterCount.OrderBy(x => x.Key))
{
    Console.WriteLine($"{current.Key}: {current.Value} time/s");
}