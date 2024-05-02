using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximumTrafficFlow
{
    public interface IDataStructure
    {
        string ToString();

        int Width { get; }

        int Heigth { get; }
        
    }
}
