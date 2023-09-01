using System.CommandLine;

namespace quasar.Commands
{
    public class RunCommand : Command
    {
        public RunCommand(string name, string? description = null) : base(name, description)
        {
        }
    }
}
