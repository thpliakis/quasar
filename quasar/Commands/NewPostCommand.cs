﻿using quasar.BlogPostTemplate;
using System.CommandLine;
using YamlDotNet.Serialization;
using System;
using System.IO;

namespace quasar.Commands
{
    public class NewPostCommand : Command
    {
        private string postName;
        private string postTitle;

        public NewPostCommand() : base("new-post", "Create an empty new post in latex")
        {
            var postNameArgument = new Argument<string>("postfileName", "Name of the new postr");
            AddArgument(postNameArgument);
            postName = postNameArgument.ToString();

            var postTitleArgument = new Argument<string>("postTitle", "Name of the new postr");
            AddArgument(postTitleArgument);
            postTitle = postTitleArgument.ToString();

            this.SetHandler(NewPostCreation);
        }

        public void NewPostCreation()
        {
            // Specify the path to your YAML configuration file
            // TODO!!!
            string configFilePath = "config.yaml";

            try
            {
                // Read the YAML file using YamlDotNet
                string yamlContent = File.ReadAllText(configFilePath);

                // Deserialize the YAML content into an object
                var deserializer = new DeserializerBuilder().Build();
                var config = deserializer.Deserialize<Config>(yamlContent);

                // Access the values from the configuration object
                Console.WriteLine("Author: " + config.author);

                var newpost = new NewPostGenerator(postName, postTitle, config.author);
                newpost.GeneratePost();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error creating new post or Error reading the configuration file: " + e.Message);
            }
          
            Console.WriteLine($"Project built successfully.");

        }

        public class Config
        {
            public string author { get; set; }
            public string firstname { get; set; }
            public string lastname { get; set; }
        }
    }
}
