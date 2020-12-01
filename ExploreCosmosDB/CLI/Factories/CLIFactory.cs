using System;
using System.Collections.Generic;
using ExploreCosmosDB.CLI.Commands;
using ExploreCosmosDB.CLI.CosmosResources;
using ExploreCosmosDB.CLI.Parsers;
using ExploreCosmosDB.CLI.Routers;

namespace ExploreCosmosDB.CLI.Factories
{
    public class CLIFactory
    {
        public CLIFactory()
        {
        }

        public ICommandParser MakeParser()
        {
            return new CommandParser();
        }

        public CommandRouter MakeRouter()
        {
            CommandRouter commandRouter = new CommandRouter();
            commandRouter.AddCommand("database", "create", new Command(DatabaseActions.CreateDatabaseAsync));
            commandRouter.AddCommand("database", "view", new Command(_ => DatabaseActions.ViewDatabasesAsync()));
            commandRouter.AddCommand("database", "delete", new Command(DatabaseActions.DeleteDatabaseAsync));

            commandRouter.AddCommand("container", "create", new Command(ContainerActions.CreateContainerAsync));
            commandRouter.AddCommand("container", "view", new Command(ContainerActions.ViewContainersAsync));
            commandRouter.AddCommand("container", "delete", new Command(ContainerActions.DeleteContainerAsync));
            return commandRouter;
        }
    }
}
