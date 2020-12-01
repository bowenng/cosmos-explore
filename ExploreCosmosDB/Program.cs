using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ExploreCosmosDB.CLI.CosmosResources;
using ExploreCosmosDB.CLI.Executors;
using ExploreCosmosDB.CLI.Factories;

namespace ExploreCosmosDB
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await REPL();
        }

        static async Task REPL()
        {
            CLIFactory factory = new CLIFactory();
            CommandExecutor commandExecutor = new CommandExecutor(factory);

            while (true)
            {
                Console.Write(">> ");
                string line = Console.ReadLine();

                if (line.Trim().Equals("exit"))
                {
                    Console.WriteLine("See you.");
                    break;
                }

                string[] input = line.Split();
                await commandExecutor.RunAsync(input);
            }
        }
    }
}
