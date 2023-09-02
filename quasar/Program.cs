using quasar.Commands;
using System.CommandLine;

namespace quasar
{
    static class Program
    {
        static int Main(string[] args)
        {
            var rootCommand = new RootCommand("A command-line app for project initialization");
            var initCommand = new InitCommand();
            var buildCommand = new BuildCommand();
            rootCommand.Add(initCommand);
            rootCommand.Add(buildCommand);

            return rootCommand.Invoke(args);
        }
    }
}