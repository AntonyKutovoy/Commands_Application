using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commands.Models
{
    public class SendingCommand
    {
        public int Command_Id { get; set; }
        public int Parameter1 { get; set; }
        public int Parameter2 { get; set; }
        public int Parameter3 { get; set; }
        public int Parameter4 { get; set; }
        public string Str_Parameter1 { get; set; }
        public string Str_Parameter2 { get; set; }
    }
}
