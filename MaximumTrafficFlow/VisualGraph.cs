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
        public static event Action OnExsistEdge;

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
        private void button_CreateEdge(object sender, EventArgs e)
        {

            string startIndex = indexFrom.Text ?? "";
            string endIndex = indexTo.Text ?? "";
            string valueStream = valueEdge.Text ?? "";
            List<TextBox> InputsFields = new List<TextBox>()
            {
                indexFrom,
                indexTo,
                valueEdge
            };
            ExceptionHandler.Handle(NonExsistNode,EmptyFields, noneExsistEdge);
            ExceptionChecker.CheckExsistNode(nodes, startIndex, endIndex);
            ExceptionChecker.CheckEmptyFields(InputsFields);
            ExceptionChecker.CheckExsistEdge(Node.Edges, startIndex, endIndex);
            if (!ExceptionHandler.IsError)
            {
                BuildEdge(nodes);
            }
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.GetResult += GetMultitude;
            form1.Show();
        }

        private void BuildEdge(List<Node> nodes)
        {
            NonExsistNode.Visible = false;
            EmptyFields.Visible = false;
            noneExsistEdge.Visible = false;
            int start = int.Parse(indexFrom.Text) - 1;
            int end = int.Parse(indexTo.Text) - 1;
            int value = int.Parse(valueEdge.Text);
            Point startPos = new Point(nodes[start].Position.X, nodes[start].Position.Y);
            Point endPos = new Point(nodes[end].Position.X, nodes[end].Position.Y);
            nodes[start].AddEdge(new Edge(startPos, endPos, start, end, value));
            Node.UpdateRelatedEdge(Node.Edges, start, nodes[start].Position);
            Node.UpdateRelatedEdge(Node.Edges, end, nodes[end].Position);
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

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            NonExsistNode.Visible = false;
            EmptyFields.Visible = false;
            noneExsistEdge.Visible = false;
            if (!char.IsDigit(number) && number != (char)Keys.Back)
            {
                // Если символ не является цифрой, отменяем его ввод
                e.Handled = true;
            }
        }
    }
}
