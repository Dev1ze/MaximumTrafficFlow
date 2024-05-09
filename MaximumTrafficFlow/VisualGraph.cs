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
            this.DoubleBuffered = true;
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
                    //e.Graphics.FillEllipse(Brushes.White, edge.ValueStreamPos.X, edge.ValueStreamPos.Y, 20,20);
                    e.Graphics.DrawString(edge.ValueStream.ToString(), Node.FontText, Brushes.Black, edge.ValueStreamPos);
                }
            }
        }

        private void DrawNodes(PaintEventArgs e)
        {
            foreach (var node in nodes)
            {
                e.Graphics.FillEllipse(node.Color, node.Position.X - Node.Radius / 2, node.Position.Y - Node.Radius / 2, Node.Radius, Node.Radius);
                e.Graphics.DrawString(node.Number.ToString(), Node.FontText, Brushes.White, node.NodeCenterPos);
            }
        }
        private double Distance(Point mousePoint, Point nodePoint)
        {
            return Math.Sqrt(Math.Pow(Math.Abs(mousePoint.X - nodePoint.X), 2) + Math.Pow(Math.Abs(mousePoint.Y - nodePoint.Y), 2));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.GetResult += GetMultitude;
            form1.Show();
        }

        public void GetMultitude(List<int> list)
        {
            List<Edge> indexesMinimalPaths = new List<Edge>();
            for(int i = 0; i < Node.Edges.Count; i++)
            {
                int[] itemList = new int[2];
                itemList[0] = Node.Edges[i].StartIndex;
                itemList[1] = Node.Edges[i].EndIndex;
                if(GetCountRepeats(itemList, list) == 1)
                {
                    indexesMinimalPaths.Add(Node.Edges[i]);
                }
            }
            foreach(var edge in indexesMinimalPaths) 
            {
                edge.ColorEdge = Pens.Red;
            }
            Refresh();
        }

        private int GetCountRepeats(int[] itemList, List<int> list)
        {
            int countRepeats = 0;
            for(int i = 0; i < itemList.Length; i++) 
            { 
                for(int j = 0; j < list.Count; j++)
                {
                    if (list[j] - 1 == itemList[i])
                    {
                        countRepeats++;
                    }
                }
            }
            return countRepeats;
        }
    }
}
