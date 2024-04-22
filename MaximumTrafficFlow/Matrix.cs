using System;
using System.Collections.Generic;
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
            Array = array;
        }
        public int[,] Array { get; set; }

        public void PrintMatrix(TextBox textBox)
        {
            string row = "";
            for (int i = 0; i < Array.GetLength(0); i++)
            {
                for (int j = 0; j < Array.GetLength(1); j++)
                {
                    row += Array[i, j].ToString() + "\t";
                }
                textBox.Text += row + "\r\n";
                row = "";
            }
        }
    }
}
