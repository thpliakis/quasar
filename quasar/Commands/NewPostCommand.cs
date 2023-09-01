using System.CommandLine;

namespace quasar.Commands
{
    public class NewPostCommand : Command
    {
        public NewPostCommand(string name, string? description = null) : base(name, description)
        {
        }
    }
}
