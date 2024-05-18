using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphMinCutLibrary
{
    public class IntValue
    {
        int Value {  get; set; }
        public IntValue(int value) 
        {
            Value = value;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Value + "    ");
            return sb.ToString();
        }
    }
}
