using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quasar.Services
{
    public class Tex2Html
    {
        public void ConvertLatexToHtml()
        {
            // Define the source and output directories.

            string sourceDirectory = "Source";
            string outputDirectory = "Output";

            // Create the output directory if it doesn't exist.
            Directory.CreateDirectory(sourceDirectory);
            Directory.CreateDirectory(outputDirectory);

            // Get a list of all LaTeX files in the source directory.
            string[] latexFiles = Directory.GetFiles(sourceDirectory, "*.tex");
            foreach (string latexFile in latexFiles)
            {
                Console.WriteLine(latexFile);
            }

            foreach (string latexFile in latexFiles)
            {
                // Generate a html from the LaTeX file using pandoc.
                string texFileName = Path.GetFileName(latexFile);
                string texPath = Path.Combine(sourceDirectory, texFileName);

                // Convert the PDF to HTML using Pandoc.
                string htmlFileName = Path.GetFileNameWithoutExtension(latexFile) + ".html";
                string htmlPath = Path.Combine(outputDirectory, htmlFileName);


                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "pandoc",
                    Arguments = $" --toc {texPath} -s --mathjax -o {htmlPath}",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };
                Console.WriteLine(psi.FileName + " " + psi.Arguments);
                try
                {
                    using (Process process = new Process { StartInfo = psi })
                    {
                        process.Start();
                        process.WaitForExit();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }


                Console.WriteLine($"Converted '{latexFile}' to '{htmlPath}'");
            }

            Console.WriteLine("Static site generation complete.");
        }
    }
}
