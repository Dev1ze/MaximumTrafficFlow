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
                Refresh();
            }
            if (e.Button == MouseButtons.Right)
            {
                for(int i = 0; i < nodes.Count; i++)
                {
                    if(Distance(e.Location, nodes[i].Position) < Node.Radius / 2)
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
            foreach (var node in nodes) 
            {
                e.Graphics.FillEllipse(node.Color, node.Position.X - Node.Radius / 2, node.Position.Y - Node.Radius / 2, Node.Radius, Node.Radius);
            }
        }

        private double Distance(Point mousePoint, Point nodePoint)
        {
            return Math.Sqrt(Math.Pow(Math.Abs(mousePoint.X - nodePoint.X), 2) + Math.Pow(Math.Abs(mousePoint.Y - nodePoint.Y), 2));
        }


    }
}
