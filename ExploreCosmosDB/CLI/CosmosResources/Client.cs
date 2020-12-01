using System;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;

namespace ExploreCosmosDB.CLI.CosmosResources
{
    public class Client
    {
        private static CosmosClient instance;
        private static readonly object padlock = new object();

        public static CosmosClient Instance {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
                            string endpoint = config["CosmosEndpoint"];
                            string masterKey = config["CosmosMasterKey"];
                            instance = new CosmosClient(endpoint, masterKey);
                        }
                    }
                }
                return instance;
            }
        }

        protected Client()
        {
        }
    }
}
