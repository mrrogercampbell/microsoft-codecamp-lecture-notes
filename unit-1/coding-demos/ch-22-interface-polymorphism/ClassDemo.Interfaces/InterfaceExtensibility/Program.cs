using System;

namespace InterfaceExtensibility
{
    class Program
    {
        static void Main(string[] args)
        {
            ILogger consoleLogger = new ConsoleLogger();

            DbMigrator migrator = new DbMigrator(consoleLogger);

            //This simulates the successful migration
            migrator.Migrate(true);

            //This simulates the unsuccessful migration
            migrator.Migrate(false);

            // The path for window users will be differnt be sure to start from your C drive
            // Example: "C:\\Projects\\log.txt"
                // Once you run the code then go to that location to see the file
            ILogger fileWriteLogger = new FileLogger("/Users/roger/Projects/ClassDemo.Interfaces/log.txt");
            // Mac users just be sure to swap out roger for your computers username
            // Example:"/Users/<YOUR USERNAME HERE>/Projects/ClassDemo.Interfaces/log.txt"
            // 

            DbMigrator migrator2 = new DbMigrator(fileWriteLogger);

            //This simulates the successful migration
            migrator2.Migrate(true);

            //This simulates the unsuccessful migration
            migrator2.Migrate(false);

        }
    }
}
