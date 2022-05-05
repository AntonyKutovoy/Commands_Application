using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commands.Models
{
    public class Command
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Parameter_Name1 { get; set; }
        public string Parameter_Name2 { get; set; }
        public string Parameter_Name3 { get; set; }
        public string Parameter_Name4 { get; set; }
        public string Str_Parameter_Name1 { get; set; }
        public string Str_Parameter_Name2 { get; set; }
        public string Parameter_Default_Value1 { get; set; }
        public string Parameter_Default_Value2 { get; set; }
        public string Parameter_Default_Value3 { get; set; }
        public string Parameter_Default_Value4 { get; set; }
        public string Str_Parameter_Default_Value1 { get; set; }
        public string Str_Parameter_Default_Value2 { get; set; }
        public bool Visible { get; set; }
        public int Parameters_Count { get; set; }
    }
}
