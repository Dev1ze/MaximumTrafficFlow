using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximumTrafficFlow
{
    public class Node
    {
        public Node(Point positoin) 
        {
            Position = positoin;
        }

        public static int Radius { get; set; } = 40;
        public Brush Color { get; set; } = Brushes.Blue;
        public Point Position { get; set; }
    }
}
