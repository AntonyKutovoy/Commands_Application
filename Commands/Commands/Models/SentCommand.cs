using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commands.Models
{
    public class SentCommand
    {
        public int Terminal_Id { get; set; }
        public int Command_Id { get; set; }
        public int Parameter1 { get; set; }
        public int Parameter2 { get; set; }
        public int Parameter3 { get; set; }
        public int Parameter4 { get; set; }
        public string Str_Parameter1 { get; set; }
        public string Str_Parameter2 { get; set; }
        public int State { get; set; }
        public string State_Name { get; set; }
        public string Time_Created { get; set; }
        public string Time_Delivered { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
