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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

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
            graph.CreateListConnectedVertices();
            List<int> path = new List<int>();
            path = graph.BuildPath(graph.connectedVertices);

        }

        class Graph
        {
            public Graph()
            {
                Matrix = new int[6, 6]
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
            
            public List<List<int>> connectedVertices = new List<List<int>>();

            public void CreateListConnectedVertices()
            {
                List<int> usedVertices = new List<int>();
                for (int numberRow = 0; numberRow < Matrix.GetLength(0); numberRow++)
                {
                    List<int> rowVertices = new List<int>();
                    for (int j = 0; j < Matrix.GetLength(1); j++)
                    {
                        rowVertices.Add(Matrix[numberRow, j]);
                    }
                    connectedVertices.Add(FindConnectedVerticesInRow(rowVertices, numberRow, usedVertices));
                }
            }

            List<int> FindConnectedVerticesInRow(List<int> rowVertices, int numberRow, List<int> usedVertices)
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

            bool CheckIndividuality(int indexVertex, List<int> usedVertices)
            {
                foreach (var usedVertex in usedVertices)
                {
                    if (usedVertex == indexVertex) return false;
                }
                return true;
            }

            List<int> RemoveEmptyVertices(List<int> lineSegment, ref int targetVertex)
            {
                for (int index = lineSegment.Count - 1; index > 0; index--)
                {
                    if (lineSegment[index] != targetVertex && index != 0) lineSegment.RemoveAt(index);
                }
                if(lineSegment.Count > 1) targetVertex = lineSegment[0];
                return lineSegment;
            }

            public List<int> BuildPath(List<List<int>> connectedVertices)
            {
                List<int> path = new List<int>();
                int targetVertex = Matrix.GetLength(0);
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

        }
        //void PrintMatrix(List<List<int>> matrix)
        //{
        //    string line = "";
        //    foreach (List<int> list in matrix)
        //    {
        //        foreach (int num in list)
        //        {
        //            line += num.ToString() + "\t";
        //        }
        //        textBox1.Text += line + "\r\n";
        //        line = "";
        //    }
        //}
    }
}
