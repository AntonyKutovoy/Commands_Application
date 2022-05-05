using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commands.Models
{
    public class ViewPage
    {
        public List<Command> Commands { get; set; }
        public List<SentCommand> SentCommands { get; set; }
        public UserInput UserInput { get; set; }
    }
}
