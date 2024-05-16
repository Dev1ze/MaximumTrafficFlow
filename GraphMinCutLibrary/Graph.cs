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

        public event Action<List<int>> GetResult;
        public Graph(Matrix connectionsMatrix)
        {
            Matrix = connectionsMatrix;
            Results = new List<List<string>>();
        }

        public List<int> FindMinimalCut()
        {
            Matrix connectionMatrix = Matrix;
            Results.Add(new List<string>() { connectionMatrix.ToString() });

            Matrix Xn = new Matrix(new int[connectionMatrix.Arrayy.GetLength(0), connectionMatrix.Arrayy.GetLength(1)]);
            Results.Add(new List<string>() { Xn.ToString() });

            Matrix rMinusX = RminusX.StartProcess(new Matrix((int[,])connectionMatrix.Arrayy.Clone()), Xn);
            object[] minimalEdgaAndPath = new object[3];
            minimalEdgaAndPath = XplusDelta.FindDelta(rMinusX, Xn);
            Results.Add(new List<string>() 
            { 
                rMinusX.ToString(), 
                new Listing((List<List<int>>)minimalEdgaAndPath[2]).ToString(),
                new Listing((List<int>)minimalEdgaAndPath[1]).ToString(),
                minimalEdgaAndPath[0].ToString() 
            });

            int countLoop = 0;
            while ((int)minimalEdgaAndPath[0] != 0)
            {
                int minimalEdge = (int)minimalEdgaAndPath[0];
                Xn = XplusDelta.Sum(Xn, minimalEdge, (List<int>)minimalEdgaAndPath[1]);
                Results.Add(new List<string>() { Xn.ToString() });

                rMinusX = RminusX.StartProcess(new Matrix((int[,])connectionMatrix.Arrayy.Clone()), Xn);
                minimalEdgaAndPath = XplusDelta.FindDelta(rMinusX, Xn);
                Results.Add(new List<string>()
                {
                    rMinusX.ToString(),
                    new Listing((List<List<int>>)minimalEdgaAndPath[2]).ToString(),
                    new Listing((List<int>)minimalEdgaAndPath[1]).ToString(),
                    minimalEdgaAndPath[0].ToString()
                });
                countLoop++;
            }
            List<int> multitude = Multitude.GetMultitude((List<List<int>>)minimalEdgaAndPath[2]);
            Results.Add(new List<string>() { new Listing(multitude).ToString(), });
            GetResult.Invoke(multitude);
            return multitude;
        }
    }
}
