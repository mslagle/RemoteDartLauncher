using RemoteDart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteDart.Commands
{
    public class ResetCommand : ICommand
    {
        public string GetDescription()
        {
            return "Resets the system to be fired again";
        }

        public string Run(string[] args)
        {
            if ((args.Any() && string.Equals(args.First(), "-force", StringComparison.OrdinalIgnoreCase))
                || Cache.Status == DartStatus.Fired)
            {
                Cache.Status = DartStatus.Ready;
                return "System reset status to \"READY\"";
            }

            if (args.Any())
            {
                throw new Exception("Unknown argument.  Arguments accepted: -force");
            }

            if (Cache.Status != DartStatus.Fired)
            {
                throw new Exception("System has not been fired yet.  Unable to reset!");
            }

            throw new Exception("Unable to process");
        }
    }
}
