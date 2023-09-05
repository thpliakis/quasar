using quasar.BlogPostTemplate;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Diagnostics;

namespace quasar.Commands
{
    public class NewPostCommand : Command
    {
        public NewPostCommand() : base("new-post", "Create an empty new post in latex")
        {
            var projectNameArgument = new Argument<string>("postName", "Name of the new postr");
            AddArgument(projectNameArgument);
            this.SetHandler(NewPostCreation);
        }

        public static void NewPostCreation()
        {
            try
            {
                var newpost = new NewPostGenerator();
                newpost.GeneratePost();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Error creating new post.", ex);
            }
            Console.WriteLine($"Project built successfully.");

        }
    }
}
