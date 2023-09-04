using ConsoleTables;
using System.CommandLine;

namespace quasar.Commands
{
    public class InfoCommand : Command
    {
        public InfoCommand() : base("info","Print information about the site")
        {
            this.SetHandler(DisplayInfo);
        }

        public static void DisplayInfo()
        {
            // Simulate fetching some data
            var quasarInfoList = new[]
            {
            new { Name = "Quasar A", Description = "Description A", Version = 1 },
            new { Name = "Quasar B", Description = "Description B", Version = 2 },
            };

            // Create a table and add columns
            var table = new ConsoleTable("Name", "Description", "Version");

            // Populate the table with data
            foreach (var quasarInfo in quasarInfoList)
            {
                table.AddRow(quasarInfo.Name, quasarInfo.Description, quasarInfo.Version);
            }
            
            // Print the table
            //table.Write(Format.MarkDown);
            table.Write();
            //Console.WriteLine();
        }
    }
}
