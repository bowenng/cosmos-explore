using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ExploreCosmosDB.CLI.Commands;
using ExploreCosmosDB.CLI.Factories;
using ExploreCosmosDB.CLI.Parsers;
using ExploreCosmosDB.CLI.Routers;

namespace ExploreCosmosDB.CLI.Executors
{
    public class CommandExecutor
    {
        private ICommandParser parser;
        private CommandRouter router;

        public CommandExecutor(CLIFactory Factory)
        {
            this.parser = Factory.MakeParser();
            this.router = Factory.MakeRouter();
        }

        public async Task RunAsync(string[] input)
        {
            parser.Parse(input);
            Dictionary<string, string> arguments = parser.Arguments;
            string groupName = parser.GroupName;
            string actionName = parser.ActionName;

            Command command = router.GetCommand(groupName, actionName);
            await command.ExecuteAsync(arguments);
        }
    }
}
