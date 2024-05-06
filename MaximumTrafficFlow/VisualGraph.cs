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

        private void VisualGraph_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                nodes.Add(new Node(e.Location));
                Refresh();
            }
        }

        private void VisualGraph_Paint(object sender, PaintEventArgs e)
        {
            foreach (var node in nodes) 
            {
                e.Graphics.FillEllipse(node.Color, node.Position.X - Node.Radius / 2, node.Position.Y - Node.Radius / 2, Node.Radius, Node.Radius);
            }
        }
    }
}
