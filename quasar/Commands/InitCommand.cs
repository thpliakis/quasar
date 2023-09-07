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

        public static int CopyTemplate(string projectName)
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

        // CopyDirectory method copies the entire directory structure from the source directory to the destination directory.
        private static void CopyDirectory(string sourceDir, string destDir)
        {
            // Create the destination directory if it doesn't exist already.
            Directory.CreateDirectory(destDir);

            // Iterate through all files in the source directory and its subdirectories.
            foreach (var file in Directory.GetFiles(sourceDir, "*", SearchOption.AllDirectories))
            {
                // Determine the relative path of the file within the source directory.
                string relativePath = Path.GetRelativePath(sourceDir, file);

                // Combine the relative path with the destination directory to create the full destination path.
                string destFile = Path.Combine(destDir, relativePath);

                // Ensure that the directory structure leading to the destination file exists.
                Directory.CreateDirectory(Path.GetDirectoryName(destFile));

                // Copy the file from the source location to the destination location.
                File.Copy(file, destFile);
            }
        }

        // GetTemplateDirectory method retrieves the directory containing the template files.
        private static string GetTemplateDirectory()
        {
            // Get the assembly (executable) that contains this code.
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            // Get the directory where the assembly is located.
            var assemblyDirectory = System.IO.Path.GetDirectoryName(assembly.Location);

            // Combine the assembly directory with the "templates" subdirectory to get the template directory.
            return Path.Combine(assemblyDirectory, "templates");
        }
    }
}
