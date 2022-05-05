using Commands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commands.Interfaces
{
    public interface ICommandsService
    {
        Task<ViewPage> GetViewPage();
        Task SendCommand(ViewPage viewPage);
    }
}
