using System.CommandLine;
using System.Diagnostics;

namespace quasar.Commands
{
    public class InitCommand : Command
    {
        private readonly Argument? projectNameArgument;
        //private readonly InitHandler initHandler;

        public InitCommand() : base("init", "Initialize a new project and start writting latex") 
        {
            var projectNameArgument = new Argument<string>("projectName", "Name of the project folder");
            AddArgument(projectNameArgument);
            this.SetHandler(InitializeProject, projectNameArgument);
        }

        public static void InitializeProject(string projectName)
        {
            // Logic to create the project folder and add default content
            //Directory.CreateDirectory(projectName);

            // !!!! If i use the whole default template this command must be removed.
            // !!!! If i use parts of the default template i must use this command.

            var command = "dotnet";
            var arguments = $"new webapp -n {projectName}";

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
                        Console.WriteLine("Empty web project created successfully.");
                    }
                    else
                    {
                        Console.Error.WriteLine("Error creating empty web project.");
                    }
                }
            }catch(Exception ex)
            {
                Console.Error.WriteLine("Error creating empty web project.", ex);
            }

            var command2 = "cd";
            var arguments2 = $"{projectName}";

            processInfo = new ProcessStartInfo
            {
                FileName = command2,
                Arguments = arguments2,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };
            try
            {
                using var process = new Process();
                process.StartInfo = processInfo;
                process.Start();
                process.WaitForExit();

                if (process.ExitCode == 0)
                {
                    Console.WriteLine("Changed directory successfully.");
                }
                else
                {
                    Console.Error.WriteLine("Error changing directory.");
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Error changing directory.", ex);
            }

            Console.WriteLine($"Project '{projectName}' initialized with default content.");
        }

        public int CopyTemplate(string projectName)
        {
            if (string.IsNullOrWhiteSpace(projectName))
            {
                Console.WriteLine("Please provide a project name.");
                return 1;
            }

            string templatePath = Path.Combine(GetTemplateDirectory(), "MyDefaultProject");
            string destinationPath = Path.Combine(Directory.GetCurrentDirectory(), projectName);

            if (Directory.Exists(destinationPath))
            {
                Console.WriteLine($"The directory '{projectName}' already exists.");
                return 1;
            }

            CopyDirectory(templatePath, destinationPath);

            Console.WriteLine($"Project '{projectName}' has been created in '{Directory.GetCurrentDirectory()}'.");

            return 0;
        }
    }
}
