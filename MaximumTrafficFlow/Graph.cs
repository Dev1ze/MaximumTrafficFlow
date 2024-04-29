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
        public Matrix ConnectionsMatrix { get; } //Матрица смежности
        public Matrix FlowMatrix { get; } //Матрица потока
        public int Vertices { get; }
        private int CountRow { get; set; }
        private int CountColumn { get; set; }

        public List<List<int>> allPaths = new List<List<int>>(); 

        public Graph(Matrix connectionsMatrix)
        {
            CountRow = connectionsMatrix.Arrayy.GetLength(1);
            CountColumn = connectionsMatrix.Arrayy.GetLength(0);
            Vertices = connectionsMatrix.Arrayy.GetLength(0);
            ConnectionsMatrix = connectionsMatrix;
            FlowMatrix = new Matrix(CreateEmptyMatrix());
        }

        private int[,] CreateEmptyMatrix()
        {
            int[,] emptyMatrix = new int[CountColumn, CountRow];
            for (int i = 1; i < CountColumn; i++)
            {
                for (int j = 1; j < CountRow; j++)
                {
                    emptyMatrix[i, j] = 0;
                }
            }
            return emptyMatrix;
        }

        private int FindMinimumOnPath(List<int> path, int[,] Matrix)
        {
            int minimalGraphEdge = int.MaxValue;
            List<int> graphEdges = new List<int>();
            for (int indexPath = 0; indexPath + 1 < path.Count; indexPath++)
            {
                int column = path[indexPath];
                int row = path[indexPath + 1];
                graphEdges.Add(Matrix[column, row]);
            }
            foreach (var graphEdge in graphEdges)
            {
                if (graphEdge < minimalGraphEdge) minimalGraphEdge = graphEdge;
            }
            return minimalGraphEdge;
        }

        private void DFSAlgoritm(int source, int stock, bool[] isVisited, List<int> path, List<List<int>> allPaths)
        {
            isVisited[source] = true;
            path.Add(source);

            if(source == stock - 1)
            {
                int minimalGraphEdge;
                minimalGraphEdge = FindMinimumOnPath(path, ConnectionsMatrix.Arrayy);
                if (minimalGraphEdge > 0)
                {
                    allPaths.Add(new List<int>(path));

                    //Заполняем матрицу потока
                    for (int i = 0; i + 1 < path.Count; i++)
                    {
                        int column = path[i];
                        int row = path[i + 1];
                        FlowMatrix.Arrayy[column, row] += minimalGraphEdge;
                    }

                    //Вычитаем из матрицы смежности данные по пути(path) по которому проехали
                    for (int i = 0; i + 1 < path.Count; i++)
                    {
                        int column = path[i];
                        int row = path[i + 1];
                        ConnectionsMatrix.Arrayy[column, row] -= minimalGraphEdge;
                    }
                }
            }
            else
            {
                for (int itemRow = Vertices - 1; itemRow > 0; itemRow--)
                {
                    if (ConnectionsMatrix.Arrayy[source, itemRow] != 0 && !isVisited[itemRow])
                    {
                        DFSAlgoritm(itemRow, stock, isVisited, path, allPaths);
                    }
                }
            }

            path.RemoveAt(path.Count - 1);
            isVisited[source] = false;
        }
        
        public Matrix GetFlowMatrix()
        {
            int source = 0;
            int stock = Vertices;
            bool[] isVisited = new bool[Vertices];
            List<int> path = new List<int>();
            DFSAlgoritm(source, stock, isVisited, path, allPaths);
            VertexPlusOne(allPaths);
            return FlowMatrix;
        }

        private void VertexPlusOne(List<List<int>> allPaths)
        {
            for (int i = 0; i < allPaths.Count; i++)
            {
                for (int j = 0; j < allPaths[i].Count; j++)
                {
                     allPaths[i][j] += 1;

                }
            }
        }
    }
}
