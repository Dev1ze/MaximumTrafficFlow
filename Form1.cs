using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaximumTrafficFlow
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int[,] matrix = new int[6, 6]
        {
            {0,6,2,0,0,0 },
            {4,0,8,4,0,0 },
            {8,8,0,0,0,0 },
            {7,9,2,0,8,2 },
            {0,6,4,3,0,2 },
            {0,0,0,8,10,0 }
        };


        private void button1_Click(object sender, EventArgs e)
        {
            PrintMatrix();
        }

        void PrintMatrix()
        {
            string line = "";
            int i = 0;
            while (i < matrix.GetLength(0))
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    line += matrix[i, j].ToString() + "\t";
                }
                textBox1.Text += line + "\r\n";
                line = "";
                i++;
            }
        }
    }
}
