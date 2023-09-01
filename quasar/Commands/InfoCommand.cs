using System.CommandLine;

namespace quasar.Commands
{
    public class InfoCommand : Command
    {
        public InfoCommand(string name, string? description = null) : base(name, description)
        {
        }
    }
}
