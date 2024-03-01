
using CodeTracker;

namespace AuthorProblem
{
    [Author("Goshko")]
    public class StartUp
    {
        [Author("Ivancho")]
        static void Main(string[] args)
        {
            Tracker tracker = new Tracker();

            tracker.PrintMethodsByAuthor();
        }
        [Author("Kiro")]
        public void Add()
        {

        }
    }
}