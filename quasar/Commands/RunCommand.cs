using System.CommandLine;
using System.Diagnostics;

namespace quasar.Commands
{
    public class RunCommand : Command
    {
        public RunCommand() : base("run", "Runs the project locally")
        {
            this.SetHandler(RunProject);
        }

        public static void RunProject()
        {
            // Logic to create the project folder and add default content
            //Directory.CreateDirectory(projectName);

            var command = "dotnet";
            var arguments = $"run";

            var processInfo = new ProcessStartInfo
            {
                FileName = command,
                Arguments = arguments,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };
            try
            {
                using (var process = new Process())
                {
                    process.StartInfo = processInfo;
                    process.Start();
                    process.WaitForExit();

                    if (process.ExitCode == 0)
                    {
                        Console.WriteLine("Project run successfully.");
                    }
                    else
                    {
                        Console.Error.WriteLine("Error running project.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Error running project.", ex);
            }

            Console.WriteLine($"Project ran successfully.");
        }
    }
}
