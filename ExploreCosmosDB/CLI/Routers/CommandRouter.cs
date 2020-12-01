using System.Collections.Generic;
using global::ExploreCosmosDB.CLI.Commands;

namespace ExploreCosmosDB.CLI.Routers
{
    public class CommandRouter
    {
        private Dictionary<string, Dictionary<string, Command>> commandMapping;

        public CommandRouter()
        {
            commandMapping = new Dictionary<string, Dictionary<string, Command>>();
        }

        public CommandRouter AddCommand(string GroupName, string ActionName, Command Command)
        {
            if (!commandMapping.ContainsKey(GroupName))
            {
                commandMapping[GroupName] = new Dictionary<string, Command>();
            }

            commandMapping[GroupName][ActionName] = Command;

            return this;
        }

        public Command GetCommand(string GroupName, string ActionName)
        {
            return commandMapping[GroupName][ActionName];
        }
    }
}
