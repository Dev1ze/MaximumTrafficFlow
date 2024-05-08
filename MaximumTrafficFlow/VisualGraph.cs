using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace MaximumTrafficFlow
{
    public partial class VisualGraph : Form
    {
        public VisualGraph()
        {
            InitializeComponent();
        }

        public List<Node> nodes = new List<Node>();
        public int selectedNodeIndex = -1;

        private void VisualGraph_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                nodes.Add(new Node(e.Location));
                nodes[nodes.Count - 1].Number = nodes.Count;
                Refresh();
            }
            if (e.Button == MouseButtons.Right)
            {
                for (int i = 0; i < nodes.Count; i++)
                {
                    if (Distance(e.Location, nodes[i].Position) < Node.Radius)
                    {
                        selectedNodeIndex = i;
                        break;
                    }
                }
            }
        }

        private void VisualGraph_MouseMove(object sender, MouseEventArgs e)
        {
            if(selectedNodeIndex != -1)
            {
                nodes[selectedNodeIndex].Position = e.Location;
                Refresh();
            }
        }

        private void VisualGraph_MouseUp(object sender, MouseEventArgs e)
        {
            selectedNodeIndex = -1;
        }

        private void VisualGraph_Paint(object sender, PaintEventArgs e)
        {
            DrawEdges(e);
            DrawNodes(e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int startIndex = int.Parse(textBox1.Text) - 1;
            int endIndex = int.Parse(textBox2.Text) - 1;
            int valueStream = int.Parse(textBox3.Text);
            Point startPos = new Point(nodes[startIndex].Position.X, nodes[startIndex].Position.Y);
            Point endPos = new Point(nodes[endIndex].Position.X, nodes[endIndex].Position.Y);
            nodes[startIndex].AddEdge(new Edge(startPos, endPos, startIndex, endIndex, valueStream));
            Node.UpdateRelatedEdge(Node.Edges, startIndex, nodes[startIndex].Position);
            Node.UpdateRelatedEdge(Node.Edges, endIndex, nodes[endIndex].Position);
            Refresh();
        }

        private void DrawEdges(PaintEventArgs e)
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                Node.UpdateRelatedEdge(Node.Edges, i, nodes[i].Position);
                foreach (var edge in Node.Edges)
                {
                    e.Graphics.DrawLine(edge.ColorEdge, edge.StartPos.X, edge.StartPos.Y, edge.EndPos.X, edge.EndPos.Y);
                    e.Graphics.DrawString(edge.ValueStream.ToString(), Node.FontText, Brushes.Black, HalfSegment(HalfSegment(edge.StartPos, edge.EndPos), edge.EndPos).X, HalfSegment(HalfSegment(edge.StartPos, edge.EndPos), edge.EndPos).Y);
                }
            }
        }

        private void DrawNodes(PaintEventArgs e)
        {
            Point nodeCenterPos;
            foreach (var node in nodes)
            {
                nodeCenterPos = new Point(node.Position.X - node.SizeNumber(node.Number).X / 2, node.Position.Y - node.SizeNumber(node.Number).Y / 2);
                e.Graphics.FillEllipse(node.Color, node.Position.X - Node.Radius / 2, node.Position.Y - Node.Radius / 2, Node.Radius, Node.Radius);
                e.Graphics.DrawString(node.Number.ToString(), Node.FontText, Brushes.White, nodeCenterPos);
            }
        }
        private double Distance(Point mousePoint, Point nodePoint)
        {
            return Math.Sqrt(Math.Pow(Math.Abs(mousePoint.X - nodePoint.X), 2) + Math.Pow(Math.Abs(mousePoint.Y - nodePoint.Y), 2));
        }
        private Point HalfSegment(Point start, Point end)
        {
            Point result;
            result = new Point((start.X + end.X) / 2, (start.Y + end.Y) / 2);
            return result;
        }


    }
}
