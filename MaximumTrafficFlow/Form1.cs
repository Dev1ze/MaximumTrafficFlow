using GraphMinCutLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaximumTrafficFlow
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        public void PrintText(List<List<string>> list)
        {
            foreach (var line in list)
            {
                foreach(var lineItem in line) 
                {
                    Window.Write(this, lineItem, "X");
                }
                Window.NewLIne();
            }
        }
    }
}
