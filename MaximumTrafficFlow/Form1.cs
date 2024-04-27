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

            List<List<int>> allPath = new List<List<int>>();
            //int[,] matrix = new int[,]
            //{
            //    {0,6900,0,0,0,0,0,9200,0,0,4600,2300,0,0,0 },
            //    {0,0,4600,4600,0,0,0,0,0,0,0,0,0,0,0 },
            //    {0,0,0,4600,4600,0,0,0,0,0,0,0,0,0,0 },
            //    {0,0,2300,0,0,0,6900,0,0,0,0,0,0,0,0 },
            //    {0,0,0,0,0,4600,0,0,0,4600,0,0,0,0,0 },
            //    {0,0,0,0,2300,0,2300,0,0,0,0,0,0,0,0 },
            //    {0,0,0,0,0,2300,0,4600,0,0,0,0,0,0,0 },
            //    {0,0,0,0,0,0,0,0,6900,0,0,0,0,4600,0 },
            //    {0,0,0,0,0,0,0,6900,0,6900,0,0,0,0,0 },
            //    {0,0,0,0,0,0,0,0,6900,0,4600,0,0,0,0 },
            //    {0,0,0,0,0,0,0,0,0,0,0,6900,0,0,0 },
            //    {0,0,0,0,0,0,0,0,0,0,0,0,4600,0,6900 },
            //    {0,0,0,0,0,0,0,0,0,0,0,4600,0,4600,4600 },
            //    {0,0,0,0,0,0,0,0,0,0,0,0,4600,0,4600 },
            //    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 }
            //};

            int[,] matrix = new int[6, 6]
            {
                {0,7,4,2,0,0 },
                {0,0,0,0,1,0 },
                {0,0,0,0,2,0 },
                {0,0,0,0,0,4 },
                {0,0,0,0,0,5 },
                {0,0,0,0,0,0 }
            };
            Matrix connectionMatrix = new Matrix(matrix);
            connectionMatrix.PrintMatrix(this, "R = ");
            Graph graph = new Graph(new Matrix((int[,])matrix.Clone())); //Клонирование матрицы в обьект Matrix который в новой ссылке

            Matrix flowMatrix = new Matrix(graph.GetFlowMatrix().Arrayy);
            flowMatrix.PrintMatrix(this, "X = ");

            Matrix rMinusX = RminusX.StartProcess(connectionMatrix, flowMatrix);
            rMinusX.PrintMatrix(this, "R - X = ");
            rMinusX.PrintMatrix(this, "R - X = ");
            rMinusX.PrintMatrix(this, "R - X = ");

            object[] minimalEdgaAndPath = new object[2];
            minimalEdgaAndPath = XplusDelta.StartProcess(connectionMatrix, flowMatrix);

            while ((int)minimalEdgaAndPath[0] != 0)
            {
                int minimalEdge = (int)minimalEdgaAndPath[0];
                flowMatrix.Arrayy = XplusDelta.Sum(flowMatrix.Arrayy, minimalEdge, (List<int>)minimalEdgaAndPath[1]);
                minimalEdgaAndPath = XplusDelta.StartProcess(connectionMatrix, flowMatrix);
            }
            List<List<int>> edges = new List<List<int>>();
            edges = (List<List<int>>)minimalEdgaAndPath[1];


            //int[,] matrixRminusXn = new int[6, 6]
            //{
            //    {0,6,2,0,0,0 },
            //    {4,0,8,4,0,0 },
            //    {8,8,0,0,0,0 },
            //    {7,9,2,0,8,2 },
            //    {0,6,4,3,0,2 },
            //    {0,0,0,8,10,0 }
            //};

            //Matrix Xn = new Matrix(matrixXn);
            //Matrix RminusXn = new Matrix(matrixRminusXn);

            //XplusDeltaResult.PrintMatrix(textBox1);
        }
    }
}
