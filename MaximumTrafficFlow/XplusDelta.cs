using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximumTrafficFlow
{
    public static class XplusDelta
    {
        public static object[] StartProcess(Matrix matrixRminusDelta, Matrix matrixXn)
        {
            object[] pathAndMinimalEdge = new object[2];
            List<List<int>> connectedVertices = new List<List<int>>();
            List<int> path = new List<int>();
            int minimalGraphEdge;
            connectedVertices = CreateListConnectedVertices(matrixRminusDelta.Arrayy);
            path = BuildPath(connectedVertices, matrixRminusDelta.Arrayy);
            if (path[0] == 1 && path[path.Count-1] == matrixXn.Arrayy.GetLength(0))
            {
                minimalGraphEdge = FindMinimumOnPath(path, matrixRminusDelta.Arrayy);
                pathAndMinimalEdge[0] = minimalGraphEdge;
                pathAndMinimalEdge[1] = path;
                return pathAndMinimalEdge;
            }
            else
            {
                for(int i = 0; i < connectedVertices.Count; i++)
                {
                    if (connectedVertices[i].Count == 1) 
                    {
                        connectedVertices.RemoveAt(i);
                        i--;
                    }
                }
                pathAndMinimalEdge[0] = 0;
                pathAndMinimalEdge[1] = connectedVertices;
                return pathAndMinimalEdge;
            }
            
            //int[,] XplusDeltaResult = Sum(matrixXn.Arrayy, minimalGraphEdge, path);
            //return XplusDeltaResult;
        }

        static List<List<int>> CreateListConnectedVertices(int[,] matrix)
        {
            List<List<int>> connectedVertices = new List<List<int>>();
            List<int> usedVertices = new List<int>();
            for (int numberRow = 0; numberRow < matrix.GetLength(0); numberRow++)
            {
                List<int> rowVertices = new List<int>();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    rowVertices.Add(matrix[numberRow, j]);
                }
                connectedVertices.Add(FindConnectedVerticesInRow(rowVertices, numberRow, usedVertices));
            }
            return connectedVertices;
        }

        static List<int> FindConnectedVerticesInRow(List<int> rowVertices, int numberRow, List<int> usedVertices)
        {
            List<int> connectedVerticesInRow = new List<int>();
            connectedVerticesInRow.Add(numberRow + 1);
            usedVertices.Add(numberRow + 1);
            for (int indexVertex = 0; indexVertex < rowVertices.Count; indexVertex++)
            {
                if (rowVertices[indexVertex] > 0 && CheckIndividuality(indexVertex + 1, usedVertices))
                {
                    connectedVerticesInRow.Add(indexVertex + 1);
                    usedVertices.Add(indexVertex + 1);
                }
            }
            return connectedVerticesInRow;
        }
        static List<int> BuildPath(List<List<int>> connectedVertices, int[,] matrix)
        {
            List<int> path = new List<int>();
            int targetVertex = matrix.GetLength(0);
            List<List<int>> reverseConnectedVertices = new List<List<int>>();
            reverseConnectedVertices = Enumerable.Reverse(connectedVertices).ToList();
            foreach (List<int> lineSegment in reverseConnectedVertices)
            {
                RemoveEmptyVertices(new List<int>(lineSegment), ref targetVertex);
                if (lineSegment.Count > 1)
                {
                    path.Add(lineSegment[lineSegment.Count - 1]);
                    path.Add(lineSegment[0]);
                }
            }
            return path;
        }

        static bool CheckIndividuality(int indexVertex, List<int> usedVertices)
        {
            foreach (var usedVertex in usedVertices)
            {
                if (usedVertex == indexVertex) return false;
            }
            return true;
        }

        static List<int> RemoveEmptyVertices(List<int> lineSegment, ref int targetVertex)
        {
            for (int index = lineSegment.Count - 1; index > 0; index--)
            {
                if (lineSegment[index] != targetVertex && index != 0) lineSegment.RemoveAt(index);
            }
            if (lineSegment.Count > 1) targetVertex = lineSegment[0];
            return lineSegment;
        }

        static int FindMinimumOnPath(List<int> path, int[,] Matrix)
        {
            int minimalGraphEdge = int.MaxValue;
            List<int> graphEdges = new List<int>();
            for (int indexPath = 0; indexPath < path.Count; indexPath += 2)
            {
                int column = path[indexPath];
                int row = path[indexPath + 1];
                graphEdges.Add(Matrix[row - 1, column - 1]);
            }
            foreach (var graphEdge in graphEdges)
            {
                if (graphEdge < minimalGraphEdge) minimalGraphEdge = graphEdge;
            }
            return minimalGraphEdge;
        }

        public static int[,] Sum(int[,] Xn, int delta, List<int> path)
        {
            for (int indexPath = 0; indexPath < path.Count; indexPath += 2)
            {
                int column = path[indexPath];
                int row = path[indexPath + 1];
                Xn[row - 1, column - 1] += delta;
                Xn[column - 1, row - 1] -= delta;
            }
            return Xn;
        }


    }
}
