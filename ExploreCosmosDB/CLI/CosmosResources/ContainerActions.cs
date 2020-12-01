using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;

namespace ExploreCosmosDB.CLI.CosmosResources
{
    public class ContainerActions
    {
        public ContainerActions()
        {
        }

        public async static Task CreateContainerAsync(Dictionary<string, string> arguments)
        {
            string databaseId = arguments["databaseId"];
            string containerId = arguments["containerId"];
            string partitionKey = arguments["pk"];
            int throughput = 400;

            Console.WriteLine();
            Console.WriteLine($" >> Creating Container {containerId} in {databaseId} << ");
            Console.WriteLine($" Throughput: {throughput} RU/sec");
            Console.WriteLine($" Throughput: {partitionKey}");
            Console.WriteLine();

            var containerProperties = new ContainerProperties
            {
                Id = containerId,
                PartitionKeyPath = partitionKey
            };

            var database = Client.Instance.GetDatabase(databaseId);
            var result = await database.CreateContainerAsync(containerProperties, throughput: throughput);
            var container = result.Resource;

            Console.WriteLine($"Created New Container: {containerId}");
            DescribeContainer(container);
        }

        public async static Task DeleteContainerAsync(Dictionary<string, string> arguments)
        {
            string databaseId = arguments["databaseId"];
            string containerId = arguments["containerId"];

            var container = Client.Instance.GetContainer(databaseId, containerId);
            Console.WriteLine($" >> Deleting Container {containerId} <<");
            await container.DeleteContainerAsync();
            Console.WriteLine($"Deleted {containerId}.");

        }

        public async static Task ViewContainersAsync(Dictionary<string, string> arguments)
        {
            string databaseId = arguments["databaseId"];
            Console.WriteLine();
            Console.WriteLine($" >> Viewing Containers in {databaseId} << ");

            var database = Client.Instance.GetDatabase(databaseId);
            var containersIterator = database.GetContainerQueryIterator<ContainerProperties>();

            int count = 0;
            while (containersIterator.HasMoreResults)
            {
                var containers = await containersIterator.ReadNextAsync();
                foreach (var container in containers)
                {
                    DescribeContainer(container);
                    count++;
                }
            }
        }

        private static void DescribeContainer(ContainerProperties container)
        {
            Console.WriteLine($"{container.Id}; PK:{container.PartitionKeyPath}; Last Modified: {container.LastModified};");
        }
    }
}
