using System;
namespace InterfaceExtensibility
{
    public class DbMigrator
    {
        private ILogger _logger;

        public DbMigrator(ILogger logger)
        {
            _logger = logger;
        }

        public void Migrate(bool wasMigrationSuccessful)
        {
            if (wasMigrationSuccessful == true)
            {
                _logger.LogInfo($"Migration started at {DateTime.Now}");


                _logger.LogInfo($"Migration Ended at {DateTime.Now}");
            }
            else
            {
                _logger.LogError($"Migration Failed at {DateTime.Now}");
                
            }


        }
    }
}
