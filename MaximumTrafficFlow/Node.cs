using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaximumTrafficFlow
{
    public class Node
    {
        public Node(Point positoin) 
        {
            Position = positoin;
        }

        public static int Radius { get; set; } = 40;
        public Brush Color { get; set; } = Brushes.Black;
        public Point Position { get; set; }
        public int Number { get; set; }
        public static Font FontText { get; set; } = new Font("Arial", 14);
        public static List<Edge> Edges = new List<Edge>();
        public void AddEdge(Edge edge)
        {
            Edges.Add(edge);
        }
        public Point SizeNumber(int number)
        {
            int height;
            int width;
            width = TextRenderer.MeasureText(number.ToString(), FontText).Width;
            height = TextRenderer.MeasureText(number.ToString(), FontText).Height;
            return new Point(width, height);
        }

        public static void UpdateAllEdge(List<Edge> edges, int index, Point Position)
        {
            foreach (Edge edge in edges)
            {
                if (edge.StartIndex == index)
                {
                    if (edge.StartPos.X > edge.EndPos.X && edge.StartPos.Y > edge.EndPos.Y)
                    {
                        edge.StartPos = new Point(Position.X + 5, Position.Y - 5);
                    }
                    else if (edge.StartPos.X > edge.EndPos.X && edge.StartPos.Y < edge.EndPos.Y)
                    {
                        edge.StartPos = new Point(Position.X - 5, Position.Y - 5);
                    }
                    else if (edge.StartPos.X < edge.EndPos.X && edge.StartPos.Y < edge.EndPos.Y)
                    {
                        edge.StartPos = new Point(Position.X - 5, Position.Y + 5);
                    }
                    else if (edge.StartPos.X < edge.EndPos.X && edge.StartPos.Y > edge.EndPos.Y)
                    {
                        edge.StartPos = new Point(Position.X + 5, Position.Y + 5);
                    }
                    else { edge.StartPos = Position; }

                }
                if (edge.EndIndex == index)
                {
                    if (edge.StartPos.X > edge.EndPos.X && edge.StartPos.Y > edge.EndPos.Y)
                    {
                        edge.EndPos = new Point(Position.X + 5, Position.Y - 5);
                    }
                    else if (edge.StartPos.X > edge.EndPos.X && edge.StartPos.Y < edge.EndPos.Y)
                    {
                        edge.EndPos = new Point(Position.X - 5, Position.Y - 5);
                    }
                    else if (edge.StartPos.X < edge.EndPos.X && edge.StartPos.Y < edge.EndPos.Y)
                    {
                        edge.EndPos = new Point(Position.X - 5, Position.Y + 5);
                    }
                    else if (edge.StartPos.X < edge.EndPos.X && edge.StartPos.Y > edge.EndPos.Y)
                    {
                        edge.EndPos = new Point(Position.X + 5, Position.Y + 5);
                    }
                    else { edge.EndPos = Position; }
                }
            }
        }
    }
}
