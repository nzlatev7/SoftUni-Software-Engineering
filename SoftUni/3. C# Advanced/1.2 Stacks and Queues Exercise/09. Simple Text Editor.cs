


int n = int.Parse(Console.ReadLine());

string text = string.Empty;

Stack<string> undo = new Stack<string>();

for (int i = 0; i < n; i++)
{
    string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

    string command = data[0];

    if (command == "1")
    {
        undo.Push(text.ToString());

        string textForAdding = data[1];

        text += textForAdding;
    }
    else if (command == "2")
    {
        undo.Push(text.ToString());

        int count = int.Parse(data[1]);

        int startIndex = text.Length - count;
        text = text.Remove(startIndex, count);
    }
    else if (command == "3")
    {
        int index = int.Parse(data[1]);

        Console.WriteLine(text[index - 1]);
    }
    else if (command == "4")
    {
        text = undo.Pop();
    }
}
