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
                {3,0,8,4,1,0 },
                {6,8,0,0,2,0 },
                {5,9,0,0,8,4 },
                {0,5,2,3,0,5 },
                {0,0,0,6,7,0 }
            };


            int[,] flow = new int[6, 6]
            {
                {0,1,2,2,0,0 },
                {-1,0,0,0,1,0 },
                {-2,0,0,0,2,0 },
                {-2,0,0,0,0,2 },
                {0,-1,-2,0,0,3 },
                {0,0,0,-2,-3,0 }
            };
            Matrix connectionMatrix = new Matrix(matrix);
            connectionMatrix.PrintMatrix(this, "R = ");
            Graph graph = new Graph(new Matrix((int[,])matrix.Clone())); //Клонирование матрицы в обьект Matrix который в новой ссылке

            //Matrix Xn = new Matrix(graph.GetFlowMatrix().Arrayy);
            Matrix Xn = new Matrix(flow);
            Xn.PrintMatrix(this, "X0 = ");

            Matrix rMinusX = RminusX.StartProcess(new Matrix((int[,])connectionMatrix.Arrayy.Clone()), Xn);
            rMinusX.PrintMatrix(this, "R - X0 = ");

            object[] minimalEdgaAndPath = new object[2];
            minimalEdgaAndPath = XplusDelta.FindDelta(rMinusX, Xn);

            int countLoop = 0;
            while ((int)minimalEdgaAndPath[0] != 0)
            {
                string nameMatrixRminusX = "R - X" + (countLoop + 1) + " = ";
                string nameMatrixXn = "X" + (countLoop + 1) + " (X" + countLoop + "+Δ) = ";
                int minimalEdge = (int)minimalEdgaAndPath[0];
                Xn = XplusDelta.Sum(Xn, minimalEdge, (List<int>)minimalEdgaAndPath[1]);
                Xn.PrintMatrix(this, nameMatrixXn);
                rMinusX = RminusX.StartProcess(new Matrix((int[,])connectionMatrix.Arrayy.Clone()), Xn);
                rMinusX.PrintMatrix(this, nameMatrixRminusX);
                minimalEdgaAndPath = XplusDelta.FindDelta(rMinusX, Xn);
                countLoop++;
            }
            //List<int> edges = new List<int>();
            //edges = (List<int>)minimalEdgaAndPath[1];

            List<List<int>> edges = new List<List<int>>();
            edges = (List<List<int>>)minimalEdgaAndPath[1];
        }
    }
}
