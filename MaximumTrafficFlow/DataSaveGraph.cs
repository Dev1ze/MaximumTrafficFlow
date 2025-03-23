using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximumTrafficFlow
{
    public class DataSaveGraph
    {
        public List<NodeData> nodeDatas { get; set; } = new List<NodeData>();
        public List<EdgeData> edgeDatas { get; set; } = new List<EdgeData>();
        public void FillList(List<Edge> edges, List<Node> nodes)
        {
            foreach(Node node in nodes)
            {
                nodeDatas.Add(new NodeData
                {
                    Number = node.Number,
                    Position = node.Position,
                });
            }
            foreach (Edge edge in edges)
            {
                edgeDatas.Add(new EdgeData
                {
                    From = edge.StartIndex,
                    To = edge.EndIndex,
                    Weight = edge.ValueStream,
                    startPosX = edge.StartPos.X,
                    startPosY = edge.StartPos.Y,
                    endPosX = edge.EndPos.X,
                    endPosY = edge.EndPos.Y,
                });
            }
        }
    }



    public class NodeData
    {
        public int Number { get; set; }
        public Point Position { get; set; }
    }

    public class EdgeData
    {
        public int From { get; set; }
        public int To { get; set; }
        public int Weight { get; set; }
        public int startPosX { get; set; }
        public int startPosY { get; set; }
        public int endPosX { get; set; }
        public int endPosY { get; set; }
    }
}
