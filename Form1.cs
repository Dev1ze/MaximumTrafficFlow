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
            Graph graph = new Graph();
            textBox1.Text = XplusDelta.StartProcess(graph.Matrix).ToString();
        }

        class Graph
        {
            public Graph()
            {
                Matrix = new int[,]
                {
                    {0,6,2,0,0,0 },
                    {4,0,8,4,0,0 },
                    {8,8,0,0,0,0 },
                    {7,9,2,0,8,2 },
                    {0,6,4,3,0,2 },
                    {0,0,0,8,10,0 }
                };
            }
            public int[,] Matrix { get; set; }
        }

        static class XplusDelta
        {
            public static int StartProcess(int[,] matrix)
            {
                List<List<int>> connectedVertices = new List<List<int>>();
                List<int> path = new List<int>();
                int minimalGraphEdge;
                connectedVertices = CreateListConnectedVertices(matrix);
                path = BuildPath(connectedVertices, matrix);
                minimalGraphEdge = FindMinimumOnPath(path, matrix);
                return minimalGraphEdge;
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
                List<List<int>> reverseConnectedVertices = Enumerable.Reverse(connectedVertices).ToList();
                foreach (List<int> lineSegment in reverseConnectedVertices)
                {
                    RemoveEmptyVertices(lineSegment, ref targetVertex);
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
        }
    }
}
