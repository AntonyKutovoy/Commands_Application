using Commands.Interfaces;
using Commands.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commands.Controllers
{
    public class CommandController : Controller
    {
        private readonly ICommandsService _commandService;

        public CommandController(ICommandsService commandService)
        {
            _commandService = commandService;
        }
        public async Task<IActionResult> Index(int terminalId)
        {
            if (terminalId == 0)
                return View(await _commandService.GetViewPage());
            return View(await _commandService.GetViewPageWithOneTerminal(terminalId));
        }

        [HttpPost]
        public async Task<IActionResult> SendCommand(ViewPage viewPage)
        {
            await _commandService.SendCommand(viewPage);
            return RedirectToAction("Index", new { terminalId = viewPage.UserInput.TerminalId });
        }
    }
}
