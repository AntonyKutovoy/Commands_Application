using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commands.Models
{
    public class Page<T>
    {
        public List<T> Items { get; set; } = new List<T>();
    }
}
