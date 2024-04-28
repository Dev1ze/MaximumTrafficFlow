using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaximumTrafficFlow
{
    public class Matrix
    {
        public Matrix(int[,] array)
        {
            Arrayy = array;
        }
        public int[,] Arrayy { get; set; }
    }
}
