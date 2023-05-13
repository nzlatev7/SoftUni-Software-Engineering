
using System.Text;

List<string> strings = Console.ReadLine().Split(", ").ToList();
Queue<string> songs = new Queue<string>(strings);

while (songs.Any()) // while songs.Count > 0
{
    string[] data = Console.ReadLine().Split(" ");

    string command = data[0];

    if (command == "Play")
    {
        songs.Dequeue();
    }
    else if (command == "Add")
    {
        string song = string.Empty;
        if (data.Length > 2)
        {
            List<string> words = data.Skip(1).ToList();
            song = string.Join(" ", words);
            //song = SubString(data);
        }
        else
        {
            song = data[1];
        }
        
        if (songs.Contains(song))
        {
            Console.WriteLine($"{song} is already contained!");
            continue;
        }

        songs.Enqueue(song);
    }
    else if (command == "Show")
    {
        Console.WriteLine(string.Join(", ", songs));
    }
}

Console.WriteLine("No more songs!");
