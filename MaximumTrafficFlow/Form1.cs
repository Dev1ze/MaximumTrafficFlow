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
        public event Action onClickBack;
        public Form1()
        {
            InitializeComponent();
        }
        
        public void PrintText(List<List<string>> list)
        {
            foreach (var line in list)
            {
                if(line.Count == 1)
                {
                    Window.WriteTitle(this, line[0]);
                }
                for(int i = 0; i < line.Count - 1; i = i + 2)
                {
                    Window.Write(this, line[i + 1], line[i]);
                }
                Window.NewLIne();
            }
            Window.ResetPosition();
        }

        private void BackToGraph_Click(object sender, EventArgs e)
        {
            onClickBack?.Invoke();
        }
    }
}
