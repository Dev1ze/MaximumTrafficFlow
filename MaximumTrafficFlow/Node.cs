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
        public Point SizeNumber(int number)
        {
            int height;
            int width;
            width = TextRenderer.MeasureText(number.ToString(), FontText).Width;
            height = TextRenderer.MeasureText(number.ToString(), FontText).Height;
            return new Point(width, height);
        }

    }
}
