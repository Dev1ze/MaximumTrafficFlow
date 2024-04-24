using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximumTrafficFlow
{
    public class Graph
    {
        public Matrix ConnectionsMatrix { get; }
        private Matrix FlowMatrix { get; set; }
        private int Vertices { get; set; }
        public Graph(Matrix connectionsMatrix)
        {
            Vertices = connectionsMatrix.Array.GetLength(0);
            ConnectionsMatrix = connectionsMatrix;
        }

        private void DFSAlgoritm(int source, int stock, bool[] isVisited, List<int> path, List<List<int>> allPath)
        {
            isVisited[source] = true;
            path.Add(source + 1);

            if(source == stock - 1)
            {
                allPath.Add(new List<int>(path));
            }
            else
            {
                for (int itemRow = 0; itemRow <= Vertices - 1; itemRow++)
                {
                    if (ConnectionsMatrix.Array[source, itemRow] != 0 && !isVisited[itemRow])
                    {
                        DFSAlgoritm(itemRow, stock, isVisited, path, allPath);
                    }
                }
            }

            path.RemoveAt(path.Count - 1);
            isVisited[source] = false;
        }
        
        public List<List<int>> FindAllPath()
        {
            int source = 0;
            int stock = Vertices;
            bool[] isVisited = new bool[Vertices];
            List<int> path = new List<int>();
            List<List<int>> allPath = new List<List<int>>();
            DFSAlgoritm(source, stock, isVisited, path, allPath);
            return allPath;
        }
    }
}
