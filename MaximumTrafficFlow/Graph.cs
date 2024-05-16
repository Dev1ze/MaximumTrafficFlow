using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MaximumTrafficFlow
{
    public class Graph
    {
        public Matrix Matrix { get; } //Матрица смежности
        public event Action<List<int>> GetResult;
        Form1 canvas = new Form1();

        public Graph(Matrix connectionsMatrix)
        {
            Matrix = connectionsMatrix;
        }

        public List<int> FindMinimalCut()
        {
            canvas.Show();
            Matrix connectionMatrix = Matrix;
            Window.Write(canvas, connectionMatrix, "R");
            Window.NewLIne();

            Matrix Xn = new Matrix(new int[connectionMatrix.Arrayy.GetLength(0), connectionMatrix.Arrayy.GetLength(1)]);
            Window.Write(canvas, Xn, "X0");
            Window.NewLIne();

            Matrix rMinusX = RminusX.StartProcess(new Matrix((int[,])connectionMatrix.Arrayy.Clone()), Xn);
            Window.Write(canvas, rMinusX, "R - X0");

            object[] minimalEdgaAndPath = new object[3];
            minimalEdgaAndPath = XplusDelta.FindDelta(rMinusX, Xn);
            Window.Write(canvas, new Listing((List<List<int>>)minimalEdgaAndPath[2]), "Список вершин");
            Window.Write(canvas, new Listing((List<int>)minimalEdgaAndPath[1]), "Путь");
            Window.Write(canvas, new IntValue((int)minimalEdgaAndPath[0]), "Δ");
            Window.NewLIne();

            int countLoop = 0;
            while ((int)minimalEdgaAndPath[0] != 0)
            {
                string nameMatrixRminusX = "R - X" + (countLoop + 1);
                string nameMatrixXn = "X" + (countLoop + 1) + " (X" + countLoop + " + Δ)";
                int minimalEdge = (int)minimalEdgaAndPath[0];
                Xn = XplusDelta.Sum(Xn, minimalEdge, (List<int>)minimalEdgaAndPath[1]);
                Window.Write(canvas, Xn, nameMatrixXn);
                Window.NewLIne();

                rMinusX = RminusX.StartProcess(new Matrix((int[,])connectionMatrix.Arrayy.Clone()), Xn);
                minimalEdgaAndPath = XplusDelta.FindDelta(rMinusX, Xn);
                Window.Write(canvas, rMinusX, nameMatrixRminusX);
                Window.Write(canvas, new Listing((List<List<int>>)minimalEdgaAndPath[2]), "Список вершин");
                Window.Write(canvas, new Listing((List<int>)minimalEdgaAndPath[1]), "Путь");
                Window.Write(canvas, new IntValue((int)minimalEdgaAndPath[0]), "Δ");

                Window.NewLIne();
                countLoop++;
            }
            List<int> multitude = Multitude.GetMultitude((List<List<int>>)minimalEdgaAndPath[2]);
            Window.Write(canvas, new Listing(multitude), "Ответ");
            GetResult.Invoke(multitude);
            return multitude;
        }
    }
}
