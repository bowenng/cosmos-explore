using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExploreCosmosDB.CLI.Commands
{
    public class Command
    {
        private Func<Dictionary<string, string>, Task> action;
        public Command(Func<Dictionary<string, string>, Task> action)
        {
            this.action = action;
        }

        public async Task ExecuteAsync(Dictionary<string, string> arguments)
        {
            await action(arguments);
        }
    }
}
