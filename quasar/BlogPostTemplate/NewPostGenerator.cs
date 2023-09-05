namespace quasar.BlogPostTemplate
{
    public class NewPostGenerator
    {
        private readonly string templatePath;
        private readonly string outputPath;
        private readonly string customTitle;
        private readonly string customAuthor;

        public NewPostGenerator(string outputPath, string customTitle, string customAuthor)
        {
            this.templatePath = "PostTemplate.tex"; //templatePath;
            this.outputPath = outputPath;
            this.customTitle = customTitle;
            this.customAuthor = customAuthor;
        }

        // usage
        //var generator = new PostGenerator("PostTemplate.tex", "MyCustomPost.tex", "My Custom Blog Post", "John Doe");
        //string templatePath = "PostTemplate.tex"; // Replace with the path to your template
        //string outputPath = "MyCustomPost.tex"; // Specify the desired output path and filename
        //string customTitle = "My Custom Blog Post";
        //string customAuthor = "John Doe";
        //generator.GeneratePost();

        public void GeneratePost()
        {
            try
            {
                // Read the LaTeX template from the specified file
                string latexTemplate = File.ReadAllText(templatePath);

                // Replace placeholders with custom values
                latexTemplate = latexTemplate.Replace("Your Blog Post Title", customTitle);
                latexTemplate = latexTemplate.Replace("Your Name", customAuthor);

                // Create and write the modified LaTeX document to the specified output path
                File.WriteAllText(outputPath, latexTemplate);

                Console.WriteLine($"LaTeX document '{outputPath}' created successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
