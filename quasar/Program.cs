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
            var infoCommand = new InfoCommand();
            var newpostCommand = new NewPostCommand();
            rootCommand.Add(initCommand);
            rootCommand.Add(buildCommand);
            rootCommand.Add(runCommand);
            rootCommand.Add(infoCommand);
            rootCommand.Add(newpostCommand);

            return rootCommand.Invoke(args);
        }
    }
}