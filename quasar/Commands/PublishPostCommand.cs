using System.CommandLine;

namespace quasar.Commands
{
    public class PublishPostCommand : Command
    {
        public PublishPostCommand() : base("publish", "Publish a new post" )
        {
            var postNameArgument = new Argument<string>("postName", "Name of the post to be published");
            AddArgument(postNameArgument);
            this.SetHandler(PublishPost, postNameArgument);
        }

        public static void PublishPost(string projectName)
        {

        }

    }
}
