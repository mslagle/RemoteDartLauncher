using RemoteDart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Current system status is \"{Cache.Status.ToString().ToUpper()}\"");

            if (Cache.LastConnection.AddMinutes(1) > DateTime.Now)
            {
                sb.AppendLine($"Remote dart system is online.  Last system connection was {Cache.LastConnection.ToShortTimeString()}.");
            }
            else if (Cache.LastConnection == default(DateTime))
            {
                sb.AppendLine($"Remote dart system has not connected since system went operational.  Check dart launcher system.");
            }
            else
            {
                sb.AppendLine($"Remote dart system is offline.  Last system connection was {Cache.LastConnection.ToShortTimeString()}.");
            }

            return sb.ToString();
        }


    }
}
