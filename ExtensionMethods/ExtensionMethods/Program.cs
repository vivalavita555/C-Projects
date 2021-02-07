namespace ExtensionMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            string post = "This is a very long blog post blah blah blah blah";
            var shortenedPost = post.Shorten(5);

            System.Console.WriteLine(shortenedPost);
        }
    }
}
