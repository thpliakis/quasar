using System.CommandLine;

namespace quasar.Commands
{
    public class PublishPostCommand : Command
    {
        public PublishPostCommand(string name, string? description = null) : base(name, description)
        {
        }
    }
}
