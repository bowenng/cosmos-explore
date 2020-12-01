using System;
using System.Collections.Generic;

namespace ExploreCosmosDB.CLI.Parsers
{
    public interface ICommandParser
    {
        void Parse(string[] Input);
        string GroupName { get; }
        string ActionName { get; }
        Dictionary<string, string> Arguments { get; }
    }
}
