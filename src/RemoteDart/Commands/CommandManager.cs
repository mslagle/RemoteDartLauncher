using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteDart.Commands
{
    public class CommandManager
    {
        static bool awaitingInput { get; set; }
        static ICommand previousCommand { get; set; }

        public string Run(string command, string[] arguments)
        {
            var type = typeof(ICommand);
            var commands = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p) && p.IsClass);

            var found = commands.FirstOrDefault(x => string.Equals(x.Name.Replace("Command", ""), command, StringComparison.OrdinalIgnoreCase));
            if (found == null)
            {
                throw new Exception($"Command \"{command}\" is not found.  Use command HELP to show a list of commands.");
            }

            var obj = (ICommand)Activator.CreateInstance(found);
            string result = obj.Run(arguments);
            result = result.Replace(Environment.NewLine, "<br />");
            result = result.Replace("  ", "&nbsp;&nbsp;");
            return result;
        }
    }

    public interface ICommand
    {
        string GetDescription();
        string Run(string[] args);

    }
}
