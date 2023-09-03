using System.CommandLine;
using System.Diagnostics;

namespace quasar.Commands
{
    public class BuildCommand : Command
    {
        public BuildCommand() : base("build", "Builds the project")
        {
            this.SetHandler(BuildProject);
        }

        public static void BuildProject()
        {
            // Logic to create the project folder and add default content
            //Directory.CreateDirectory(projectName);

            var command = "dotnet";
            var arguments = $"build";

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
                        Console.WriteLine("Project built successfully.");
                    }
                    else
                    {
                        Console.Error.WriteLine("Error building project.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Error building project.", ex);
            }

            Console.WriteLine($"Project built successfully.");
        }
    }
}
