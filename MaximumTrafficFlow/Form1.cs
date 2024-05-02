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
            int[,] matrix = new int[,]
            {
                {0,6900,0,0,0,0,0,9200,0,0,4600,2300,0,0,0 },
                {0,0,4600,4600,0,0,0,0,0,0,0,0,0,0,0 },
                {0,4600,0,4600,4600,0,0,0,0,0,0,0,0,0,0 },
                {0,4600,2300,0,0,0,6900,0,0,0,0,0,0,0,0 },
                {0,0,4600,0,0,4600,0,0,0,4600,0,0,0,0,0 },
                {0,0,0,0,2300,0,2300,0,0,0,0,0,0,0,0 },
                {0,0,0,4600,0,2300,0,4600,0,0,0,0,0,0,0 },
                {0,0,0,0,0,0,4600,0,6900,0,0,0,0,4600,0 },
                {0,0,0,0,0,2300,0,6900,0,6900,0,0,0,0,0 },
                {0,0,0,0,2300,0,0,0,6900,0,4600,0,0,0,0 },
                {0,0,0,0,0,0,0,0,0,6900,0,6900,0,0,0 },
                {0,0,0,0,0,0,0,0,0,0,6900,0,4600,0,6900 },
                {0,0,0,0,0,0,0,0,4600,0,0,4600,0,4600,4600 },
                {0,0,0,0,0,0,0,4600,0,0,0,0,4600,0,4600 },
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 }
            };

            //            int[,] flow = new int[,]
            //{
            //                {0,6900,0,0,0,0,0,2300,0,0,2300,2300,0,0,0 },
            //                {0,0,2300,4600,0,0,0,0,0,0,0,0,0,0,0 },
            //                {0,0,0,0,2300,0,0,0,0,0,0,0,0,0,0 },
            //                {0,0,0,0,0,0,4600,0,0,0,0,0,0,0,0 },
            //                {0,0,0,0,0,0,0,0,0,2300,0,0,0,0,0 },
            //                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            //                {0,0,0,0,0,0,0,4600,0,0,0,0,0,0,0 },
            //                {0,0,0,0,0,0,0,0,2300,0,0,0,0,4600,0 },
            //                {0,0,0,0,0,0,0,0,0,2300,0,0,0,0,0 },
            //                {0,0,0,0,0,0,0,0,0,0,4600,0,0,0,0 },
            //                {0,0,0,0,0,0,0,0,0,0,0,6900,0,0,0 },
            //                {0,0,0,0,0,0,0,0,0,0,0,0,2300,0,6900 },
            //                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,2300 },
            //                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,4600 },
            //                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 }
            //};

            //int[,] matrix = new int[6, 6]
            //{
            //    {0,7,4,2,0,0 },
            //    {3,0,8,4,1,0 },
            //    {6,8,0,0,2,0 },
            //    {5,9,0,0,8,4 },
            //    {0,5,2,3,0,5 },
            //    {0,0,0,6,7,0 }
            //};


            //int[,] flow = new int[6, 6]
            //{
            //    {0,1,2,2,0,0 },
            //    {-1,0,0,0,1,0 },
            //    {-2,0,0,0,2,0 },
            //    {-2,0,0,0,0,2 },
            //    {0,-1,-2,0,0,3 },
            //    {0,0,0,-2,-3,0 }
            //};
            Matrix connectionMatrix = new Matrix(matrix);
            Window.Write(this, connectionMatrix, "R = ");

            Graph graph = new Graph(new Matrix((int[,])matrix.Clone())); //Клонирование матрицы в обьект Matrix который в новой ссылке

            Matrix Xn = new Matrix(graph.GetFlowMatrix().Arrayy);

            //Matrix Xn = new Matrix(flow);
            Window.Write(this, new Listing(graph.allPaths), "X0 = ");
            Window.NewLIne();
            Window.Write(this, connectionMatrix, "R = ");
            Window.Write(this, new Listing(graph.allPaths), "X0 = ");

            //Matrix rMinusX = RminusX.StartProcess(new Matrix((int[,])connectionMatrix.Arrayy.Clone()), Xn);
            Matrix rMinusX = new Matrix(matrix);
            object[] minimalEdgaAndPath = new object[3];
            minimalEdgaAndPath = XplusDelta.FindDelta(rMinusX, Xn);
            //Window.Start(this, rMinusX, "R - X0 = ", minimalEdgaAndPath);

            int countLoop = 0;
            while ((int)minimalEdgaAndPath[0] != 0)
            {
                string nameMatrixRminusX = "R - X" + (countLoop + 1) + " = ";
                string nameMatrixXn = "X" + (countLoop + 1) + " (X" + countLoop + " + Δ) = ";
                int minimalEdge = (int)minimalEdgaAndPath[0];
                Xn = XplusDelta.Sum(Xn, minimalEdge, (List<int>)minimalEdgaAndPath[1]);
                //Window.Write(this, Xn, nameMatrixXn);
                rMinusX = RminusX.StartProcess(new Matrix((int[,])connectionMatrix.Arrayy.Clone()), Xn);
                minimalEdgaAndPath = XplusDelta.FindDelta(rMinusX, Xn);
                //Window.Start(this, rMinusX, nameMatrixRminusX, minimalEdgaAndPath);
                countLoop++;
            }
            List<List<int>> edges = new List<List<int>>();
            edges = (List<List<int>>)minimalEdgaAndPath[2];

            //List<List<int>> edges = new List<List<int>>();
            //edges = (List<List<int>>)minimalEdgaAndPath[1];
        }
    }
}
