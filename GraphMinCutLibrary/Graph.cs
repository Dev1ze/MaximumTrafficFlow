using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphMinCutLibrary
{
    public class Graph
    {
        public Matrix Matrix { get; } //Матрица смежности
        public List<List<string>> Results { get; private set; }
        public event Action<List<List<int>>> GetResult;
        public Graph(Matrix connectionsMatrix)
        {
            Matrix = connectionsMatrix;
            Results = new List<List<string>>();
        }

        public List<List<int>> FindMinimalCut()
        {
            int countLoop = 1;
            Matrix connectionMatrix = Matrix;
            Results.Add(new List<string>() 
            {
                "R",
                connectionMatrix.ToString()
            });

            Matrix Xn = new Matrix(new int[connectionMatrix.Arrayy.GetLength(0), connectionMatrix.Arrayy.GetLength(1)]);
            Results.Add(new List<string>() 
            {
                "X",
                Xn.ToString() 
            });

            Matrix rMinusX = RminusX.StartProcess(new Matrix((int[,])connectionMatrix.Arrayy.Clone()), Xn);
            object[] minimalEdgaAndPath = new object[3];
            minimalEdgaAndPath = XplusDelta.FindDelta(rMinusX, Xn);
            Results.Add(new List<string>() 
            {
                "R-X",
                rMinusX.ToString(), 
                "Список вершин",
                new Listing((List<List<int>>)minimalEdgaAndPath[2]).ToString(),
                "Путь",
                new Listing((List<int>)minimalEdgaAndPath[1]).ToString(),
                "∆",
                new IntValue((int)minimalEdgaAndPath[0]).ToString()
            });

            
            while ((int)minimalEdgaAndPath[0] != 0)
            {
                int minimalEdge = (int)minimalEdgaAndPath[0];
                Xn = XplusDelta.Sum(Xn, minimalEdge, (List<int>)minimalEdgaAndPath[1]);
                Results.Add(new List<string>() 
                { 
                    "X" + countLoop.ToString(),
                    Xn.ToString() 
                });

                rMinusX = RminusX.StartProcess(new Matrix((int[,])connectionMatrix.Arrayy.Clone()), Xn);
                minimalEdgaAndPath = XplusDelta.FindDelta(rMinusX, Xn);
                Results.Add(new List<string>()
                {
                    "R-X" + countLoop.ToString(),
                    rMinusX.ToString(),
                    "Список вершин",
                    new Listing((List<List<int>>)minimalEdgaAndPath[2]).ToString(),
                    "Путь",
                    new Listing((List<int>)minimalEdgaAndPath[1]).ToString(),
                    "∆",
                    new IntValue((int)minimalEdgaAndPath[0]).ToString()
                });
                countLoop++;
            }
            List<List<int>> multitude = Multitude.GetMultitude((List<List<int>>)minimalEdgaAndPath[2]);
            List<List<int>> minimalEdges = Multitude.GetMinimalEdges(multitude.Last(), multitude.First(), Matrix);
            Results.Add(new List<string>() 
            { 
                "Множество B",
                new Listing(multitude.First()).ToString(),
                "Множество A",
                new Listing(multitude.Last()).ToString(),

            });

            for (int i = minimalEdges.Count; i > 0; i--)
            {
                Results.Add(new List<string>()
                {
                    "Минимальный разрез #" + i.ToString(),
                    new Listing(minimalEdges.ElementAt(i - 1)).ToString()
                });
            }
            GetResult.Invoke(multitude);
            return multitude;
        }
    }
}
