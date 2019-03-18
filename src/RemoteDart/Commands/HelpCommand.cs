using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteDart.Commands
{
    public class HelpCommand : ICommand
    {
        public string GetDescription()
        {
            return "Shows all available commands";
        }

        public string Run(string[] args)
        {
            var type = typeof(ICommand);
            var commands = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p) && p.IsClass);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("The following commands are available:");

            foreach (var cmd in commands)
            {
                var name = cmd.Name.Replace("Command", "").ToUpper();
                var description = ((ICommand)Activator.CreateInstance(cmd)).GetDescription();

                sb.AppendLine($"{name.PadRight(10)}{description}");
            }

            return sb.ToString();
        }
    }
}
