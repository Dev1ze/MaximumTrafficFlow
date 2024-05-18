using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphMinCutLibrary
{
    public class Matrix
    {
        public Matrix(int[,] array)
        {
            Arrayy = array;
        }
        public int[,] Arrayy { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            int rows = Arrayy.GetLength(0);
            int columns = Arrayy.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    sb.Append(Arrayy[i, j] + "    ");
                }
                if (i < rows - 1) sb.AppendLine();
            }
            return sb.ToString();
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
