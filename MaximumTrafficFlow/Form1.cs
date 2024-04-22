using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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

        private void button1_Click(object sender, EventArgs e)
        {
            int[,] matrixRminusXn = new int[6, 6]
            {
                {0,6,2,0,0,0 },
                {4,0,8,4,0,0 },
                {8,8,0,0,0,0 },
                {7,9,2,0,8,2 },
                {0,6,4,3,0,2 },
                {0,0,0,8,10,0 }
            };
            int[,] matrixXn = new int[6, 6]
            {
                {0,1,2,2,0,0 },
                {-1,0,0,0,1,0 },
                {-2,0,0,0,2,0 },
                {-2,0,0,0,0,2 },
                {0,-1,-2,0,0,3 },
                {0,0,0,-2,-3,0 }
            };

            Matrix Xn = new Matrix(matrixXn);
            Matrix RminusXn = new Matrix(matrixRminusXn);
            Matrix XplusDeltaResult = new Matrix(XplusDelta.StartProcess(RminusXn.Array, Xn.Array));
            XplusDeltaResult.PrintMatrix(textBox1);

        }
    }
}
