using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;

namespace ExploreCosmosDB.CLI.CosmosResources
{
    public class DatabaseActions
    {
        public DatabaseActions()
        {
            
        }

        public async static Task ViewDatabasesAsync()
        {
            Console.WriteLine();
            Console.WriteLine($" >> View Databases << ");

            var iterator = Client.Instance.GetDatabaseQueryIterator<DatabaseProperties>();
            int count = 0;

            while (iterator.HasMoreResults)
            {
                var databases = await iterator.ReadNextAsync();
                foreach (var database in databases)
                {
                    DescribeDatabase(database);
                    count++;
                }
            }

            if (count == 0)
            {
                Console.WriteLine("You don't have any database.");
            }
        }

        public async static Task CreateDatabaseAsync(Dictionary<string, string> arguments)
        {
            string databaseId = arguments["databaseId"];

            Console.WriteLine();
            Console.WriteLine($" >> Creating Database {databaseId} << ");

            var result = await Client.Instance.CreateDatabaseAsync(databaseId);
            var database = result.Resource;

            DescribeDatabase(database);
        }

        private static void DescribeDatabase(DatabaseProperties database)
        {
            Console.WriteLine($"Database Id: {database.Id}; Modified: {database.LastModified}");
        }

        public async static Task DeleteDatabaseAsync(Dictionary<string, string> arguments)
        {
            string databaseId = arguments["databaseId"];

            Console.WriteLine();
            Console.WriteLine($" >> Deleting Database {databaseId} << ");

            await Client.Instance.GetDatabase(databaseId).DeleteAsync();

            Console.WriteLine($"Deleted Deleting {databaseId}.");
        }
    }
}
