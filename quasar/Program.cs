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
            var runCommand = new RunCommand();
            rootCommand.Add(initCommand);
            rootCommand.Add(buildCommand);
            rootCommand.Add(runCommand);

            return rootCommand.Invoke(args);
        }
    }
}