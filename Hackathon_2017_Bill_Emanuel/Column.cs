using emanuel.Extensions;
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
        public List<string> Examples { get; set; }
        public string StringExample { get; set; }
        public string DoubleExample { get; set; }
        public ColumnType Type { get; set; }
        public Column()
        {
            this.Type = ColumnType.String;
        }
        public override string ToString()
        {
            var type = this.Type != ColumnType.String ? string.Concat(": ", this.Type.ToString()) : string.Empty;
            (string stringExample, string doubleExample) = (
                string.IsNullOrEmpty(StringExample) ? string.Empty : string.Concat(", ", StringExample),
                string.IsNullOrEmpty(DoubleExample) ? string.Empty : string.Concat(", ", DoubleExample));
            return $"{Id} {Header}{type} ({Examples.AggregateToString(",")}{stringExample}{doubleExample}...)";
        }
    }

    public enum ColumnType
    {
        String,
        Int,
        Double
    }
}
