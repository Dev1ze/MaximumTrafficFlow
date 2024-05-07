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
            for (int i = 0; i < nodes.Count; i++)
            {
                Node.UpdateAllEdge(Node.Edges, i, nodes[i].Position);
                foreach (var edge in Node.Edges)
                {
                    e.Graphics.DrawLine(edge.ColorEdge, edge.StartPos.X, edge.StartPos.Y, edge.EndPos.X, edge.EndPos.Y);
                }
            }
            foreach (var node in nodes)
            {
                e.Graphics.FillEllipse(node.Color, node.Position.X - Node.Radius / 2, node.Position.Y - Node.Radius / 2, Node.Radius, Node.Radius);
                e.Graphics.DrawString(node.Number.ToString(), Node.FontText, Brushes.White, node.Position.X - node.SizeNumber(node.Number).X / 2, node.Position.Y - node.SizeNumber(node.Number).Y / 2);
            }
        }

        private double Distance(Point mousePoint, Point nodePoint)
        {
            return Math.Sqrt(Math.Pow(Math.Abs(mousePoint.X - nodePoint.X), 2) + Math.Pow(Math.Abs(mousePoint.Y - nodePoint.Y), 2));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Point start = new Point(nodes[int.Parse(textBox1.Text) - 1].Position.X, nodes[int.Parse(textBox1.Text) - 1].Position.Y);
            Point end = new Point(nodes[int.Parse(textBox2.Text) - 1].Position.X, nodes[int.Parse(textBox2.Text) - 1].Position.Y);
            nodes[int.Parse(textBox1.Text) - 1].AddEdge(new Edge(start, end, int.Parse(textBox1.Text) - 1, int.Parse(textBox2.Text) - 1));
            Node.UpdateAllEdge(Node.Edges, int.Parse(textBox1.Text) - 1, nodes[int.Parse(textBox1.Text) - 1].Position);
            Node.UpdateAllEdge(Node.Edges, int.Parse(textBox2.Text) - 1, nodes[int.Parse(textBox2.Text) - 1].Position);
            Refresh();
        }
    }
}
