using System.CommandLine;

namespace quasar.Commands
{
    public class BuildCommand : Command
    {
        public BuildCommand(string name, string? description = null) : base(name, description)
        {
        }
    }
}
