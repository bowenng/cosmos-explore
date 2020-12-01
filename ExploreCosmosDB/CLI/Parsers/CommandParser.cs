using System;
using System.Collections.Generic;

namespace ExploreCosmosDB.CLI.Parsers
{
    public class CommandParser : ICommandParser
    {
        private string groupName;
        private string actionName;
        private Dictionary<string, string> arguments;

        public CommandParser()
        {
        }

        public string GroupName => groupName;

        public string ActionName => actionName;

        public Dictionary<string, string> Arguments => arguments;

        public void Parse(string[] input)
        {
            if (input.Length < 2 || input.Length % 2 != 0)
            {
                throw new ArgumentException("Invalid input: [Group] [Action] {--flag value}...");
            }

            groupName = input[0];
            actionName = input[1];
            arguments = new Dictionary<string, string>();

            for (int i = 2; i < input.Length; i += 2)
            { 
                string flag = input[i];
                if (!flag.StartsWith("--"))
                {
                    throw new ArgumentException("Invalid flag: " + flag);
                }
                flag = flag[2..];
                string value = input[i + 1];
                arguments[flag] = value;
            }
        }
    }
}
