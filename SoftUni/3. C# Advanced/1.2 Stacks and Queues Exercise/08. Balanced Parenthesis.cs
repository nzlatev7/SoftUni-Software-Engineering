
string chars = Console.ReadLine(); //1 2 3 4 5 6

Stack<char> stack = new Stack<char>();

bool isValidExpression = true;

foreach (var ch in chars)
{

    if (ch == '{' || ch == '(' || ch == '[')
    {
        stack.Push(ch);
    }
    else if (ch == '}')
    {
        if (stack.Count == 0 || stack.Pop() != '{')
        {
            isValidExpression = false;
            break;
        }
    }
    else if (ch == ')')
    {
        if (stack.Count == 0 ||stack.Pop() != '(')
        {
            isValidExpression = false;
            break;
        }
    }
    else if (ch == ']')
    {
        if (stack.Count == 0 || stack.Pop() != '[')
        {
            isValidExpression = false;
            break;
        }
    }
}
//if (stack.Count != 0)
//{
//    isValidExpression = false;
//}


if (isValidExpression)
{
    Console.WriteLine("YES");
}
else
{
    Console.WriteLine("NO");
}