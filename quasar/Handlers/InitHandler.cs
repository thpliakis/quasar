using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quasar.Handlers
{
    public class InitHandler
    {
        public static void InitializeProject(string projectName)
        {
            // Logic to create the project folder and add default content
            Directory.CreateDirectory(projectName);

            // Create and add default files or content to the project folder
            File.WriteAllText(Path.Combine(projectName, "README.txt"), $"Welcome to {projectName}!");

            Console.WriteLine($"Project '{projectName}' initialized with default content.");
        }
    }
}
