using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TV_Шаповалова.Classes
{

    public class Channel
    {
        public string Name { get; set; }
        public string Src { get; set; }
        public List<string> ProgramNames { get; set; } = new List<string>();
        public List<string> ProgramSrcs { get; set; } = new List<string>();
    }

}
