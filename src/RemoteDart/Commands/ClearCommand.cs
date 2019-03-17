using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteDart.Commands
{
    public class ClearCommand : ICommand
    {
        public string GetDescription()
        {
            return "Clears the screen";
        }

        public string Run(string[] args)
        {
            throw new NotImplementedException();
        }
    }
}
