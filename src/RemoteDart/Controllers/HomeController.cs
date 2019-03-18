using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RemoteDart.Commands;
using RemoteDart.Models;

namespace RemoteDart.Controllers
{
    public class HomeController : Controller
    {
        CommandManager commandManager = new CommandManager();

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Command([FromBody]CommandModel command)
        {
            var result = string.Empty;
            try
            {
                result = commandManager.Run(command.Command, command.Arguments);
            }
            catch (Exception e)
            {
                result = $"<span style=\"color:red\">{e.Message}</span>";
            }

            return Ok(result);
        }

        public IActionResult LaunchDart()
        {
            Cache.LastConnection = DateTime.Now;

            if (Cache.Status == DartStatus.Pending)
            {
                Cache.Status = DartStatus.Fired;
                return Ok("f");
            }

            return Ok("n");
        }
    }


}
