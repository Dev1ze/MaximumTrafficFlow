using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        //Vertices - Вершины графа

        int[,] matrix = new int[6, 6]
        {
            {0,6,2,0,0,0 },
            {4,0,8,4,0,0 },
            {8,8,0,0,0,0 },
            {7,9,2,0,8,2 },
            {0,6,4,3,0,2 },
            {0,0,0,8,10,0 }
        };
        List<int> usedVertices = new List<int>();
        List<List<int>> connectedVertices = new List<List<int>>();

        private void button1_Click(object sender, EventArgs e)
        {
            StartIterateMatrix();
        }

        void StartIterateMatrix()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                List<int> rowVertices = new List<int>();        
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    rowVertices.Add(matrix[i,j]);
                }
                connectedVertices.Add(FindConnectedVertices(rowVertices, i));
            }
        }

        List<int> FindConnectedVertices(List<int> rowVertices, int numberRow)
        {
            List<int> connectedVertices = new List<int>(); 
            connectedVertices.Add(numberRow + 1);
            usedVertices.Add(numberRow + 1);
            for (int indexVertex = 0; indexVertex < rowVertices.Count; indexVertex++)
            {
                if (rowVertices[indexVertex] > 0 && CheckIndividuality(indexVertex + 1))
                {
                    connectedVertices.Add(indexVertex + 1);
                    usedVertices.Add(indexVertex + 1);
                }
            }
            return connectedVertices;
        }

        bool CheckIndividuality(int indexVertex)
        {
            foreach (var usedVertex in usedVertices)
            {
                if(usedVertex == indexVertex) return false;
            }
            return true;
        }
    }
}
