using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon_2017_Bill_Emanuel
{
    class Column
    {
        public string Header { get; set; }
        public int Id { get; set; }
        public string Example1 { get; set; }
        public string Example2 { get; set; }
        public string Example3 { get; set; }
        public override string ToString()
        {
            return string.Format("{0} {1} ({2}, {3}, {4}...", Id, Header, Example1, Example2, Example3);
        }
    }
}
