using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace MaximumTrafficFlow
{
    public class Edge
    {
        public Edge(Point startPos, Point endPos, int startIndex, int endIndex, int valueStream)
        {
            StartPos = startPos;
            EndPos = endPos;
            StartIndex = startIndex;
            EndIndex = endIndex;
            ValueStream = valueStream;
        }
        public Point StartPos { get; set; }
        public Point EndPos { get; set; }
        public int StartIndex { get; set; }
        public int EndIndex { get; set; }
        public int ValueStream { get; set; }
        public Point ValueStreamPos 
        {
            get
            {
                int withValueText = TextRenderer.MeasureText(ValueStream.ToString(), Node.FontText).Width / 2;
                int hightValueText = TextRenderer.MeasureText(ValueStream.ToString(), Node.FontText).Height / 2;
                Point centerEdgePos = GetCenterEdge(StartPos, EndPos);
                Point quarterEdgePos = new Point(GetCenterEdge(centerEdgePos, EndPos).X, GetCenterEdge(centerEdgePos, EndPos).Y);
                Point result = new Point(quarterEdgePos.X - withValueText, quarterEdgePos.Y - hightValueText);
                return result;
            }
            set { }
        }
        public Pen ColorEdge { get; set; } = new Pen(Color.Black, 2f);
        private Point GetCenterEdge(Point start, Point end)
        {
            Point result;
            result = new Point((start.X + end.X) / 2, (start.Y + end.Y) / 2);
            return result;
        }
    }
}