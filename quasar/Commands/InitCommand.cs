﻿using System.CommandLine;
using System.Diagnostics;

namespace quasar.Commands
{
    public class InitCommand : Command
    {
        private readonly Argument? projectNameArgument;
        //private readonly InitHandler initHandler;

        public InitCommand() : base("init", "Initialize a new project") 
        {
            var projectNameArgument = new Argument<string>("projectName", "Name of the project folder");
            AddArgument(projectNameArgument);
            this.SetHandler(InitializeProject, projectNameArgument);
        }

        public static void InitializeProject(string projectName)
        {
            // Logic to create the project folder and add default content
            //Directory.CreateDirectory(projectName);

            var command = "dotnet";
            var arguments = $"new blazorwasm -n {projectName}";

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
                        Console.WriteLine("Blazor WebAssembly project created successfully.");
                    }
                    else
                    {
                        Console.Error.WriteLine("Error creating Blazor WebAssembly project.");
                    }
                }
            }catch(Exception ex)
            {
                Console.Error.WriteLine("Error creating Blazor WebAssembly project.", ex);
            }
            // Create and add default files or content to the project folder
            //File.WriteAllText(Path.Combine(projectName, "README.txt"), $"Welcome to {projectName}!");

            Console.WriteLine($"Project '{projectName}' initialized with default content.");
        }
    }
}