using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MaximumTrafficFlow
{
    public class Matrix : IDataStructure
    {
        public Matrix(int[,] array)
        {
            Arrayy = array;
        }
        public int[,] Arrayy { get; set; }

        public override string ToString()
        {
            string text = "";
            string row = "";
            for (int i = 0; i < Arrayy.GetLength(0); i++)
            {
                for (int j = 0; j < Arrayy.GetLength(1); j++)
                {
                    row += Arrayy[i, j].ToString() + "\t";
                }
                text += row + "\r\n";
                row = "";
            }
            return text;
        }

        private int width;

        public int Width
        {
            get 
            {
                return Arrayy.GetLength(1);
            }
        }

        private int heigth;

        public int Heigth
        {
            get
            {
                return Arrayy.GetLength(0);
            }
        }
    }
}
