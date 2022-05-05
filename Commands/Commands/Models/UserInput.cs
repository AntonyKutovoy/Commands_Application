using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commands.Models
{
    public class UserInput
    {
        public int TerminalId { get; set; }
        public SendingCommand SendingCommand { get; set; }
    }
}
