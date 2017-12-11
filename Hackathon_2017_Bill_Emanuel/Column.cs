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
        public string StringExample { get; set; }
        public string DoubleExample { get; set; }
        public ColumnType Type { get; set; }
        public Column()
        {
            this.Type = ColumnType.String;
        }
        public override string ToString()
        {
            return string.Format("{0} {1}{5} ({2}, {3}, {4}{6}{7}...)", Id, Header, Example1, Example2, Example3,
                this.Type != ColumnType.String ? string.Concat(": ", this.Type.ToString()) : string.Empty
                , string.IsNullOrEmpty(StringExample) ? string.Empty : string.Concat(", ", StringExample), string.IsNullOrEmpty(DoubleExample) ? string.Empty : string.Concat(", ", DoubleExample));
        }
    }

    public enum ColumnType
    {
        String,
        Int,
        Double
    }
}
