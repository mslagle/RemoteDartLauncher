using RemoteDart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteDart.Commands
{
    public class StatusCommand : ICommand
    {
        public string GetDescription()
        {
            return "Shows the current status of the remote Dart Launcher System";
        }

        public string Run(string[] args)
        {
            if (args.Any())
            {
                throw new Exception("This command does not take any arguments!");
            }

            return $"Current system status is \"{Cache.Status.ToString().ToUpper()}\"";
        }
    }
}
