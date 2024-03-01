namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings stack = new StackOfStrings();



            Console.WriteLine(stack.IsEmpty());

            stack.Push("1");

            stack.AddRange(new List<string> { "1", "2", "3"});

            Console.WriteLine(stack.IsEmpty());
        }
    }
}