using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximumTrafficFlow
{
    public class IntValue : IDataStructure
    {
        public IntValue(int value)
        {
            Value = value;
        }

        public int Value { get; set; }

        public override string ToString()
        {
            return Value.ToString();
        }
        public int Width { get { return Value.ToString().Length; } }

        public int Heigth { get { return 2; } }
    }
}
