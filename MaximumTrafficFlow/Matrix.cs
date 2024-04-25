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
            Arrayy = array;
        }
        public int[,] Arrayy { get; set; }

        public void PrintMatrix(TextBox textBox)
        {
            string row = "";
            for (int i = 0; i < Arrayy.GetLength(0); i++)
            {
                for (int j = 0; j < Arrayy.GetLength(1); j++)
                {
                    row += Arrayy[i, j].ToString() + "\t";
                }
                textBox.Text += row + "\r\n";
                row = "";
            }
        }


    }
}
