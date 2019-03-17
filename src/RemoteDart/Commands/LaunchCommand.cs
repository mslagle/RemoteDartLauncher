using RemoteDart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteDart.Commands
{
    public class LaunchCommand : ICommand
    {
        public string GetDescription()
        {
            return "Primes the launch system for remote dart launching";
        }

        public string Run(string[] args)
        {
            if ((args.Any() && string.Equals(args.First(), "-force", StringComparison.OrdinalIgnoreCase))
                || Cache.Status == DartStatus.Ready)
            {
                Cache.Status = DartStatus.Pending;
                return "System is primed for firing.  Check status by running command \"STATUS\"";
            }

            if (args.Any())
            {
                throw new Exception("Unknown argument.  Arguments accepted: -force");
            }

            if (Cache.Status != DartStatus.Fired)
            {
                throw new Exception($"System is not ready to prime.  Current status is \"{DartStatus.Pending.ToString().ToUpper()}\"");
            }

            throw new Exception("Unable to process");
        }
    }
}
