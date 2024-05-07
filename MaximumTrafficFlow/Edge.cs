using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximumTrafficFlow
{
    public class Edge
    {
        public Edge(Point startPos, Point endPos, int startIndex, int endIndex)
        {
            StartPos = startPos;
            EndPos = endPos;
            StartIndex = startIndex;
            EndIndex = endIndex;
        }
        public Point StartPos { get; set; }
        public Point EndPos { get; set; }
        public int StartIndex { get; set; }
        public int EndIndex { get; set; }
        public Pen ColorEdge { get; set; } = new Pen(Color.Black, 2f);
    }
}