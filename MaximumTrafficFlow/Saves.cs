using System.Text.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaximumTrafficFlow
{
    public partial class Saves: Form
    {
        public static event Action<DataSaveGraph> OnOpenSavedGraph;

        private string path;

        public Saves()
        {
            InitializeComponent();
            path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "saves");
            string[] files = Directory.GetFiles(path);

            foreach (string file in files)
            {
                Button button = new Button();
                button.Width = 150;
                button.Click += Button_Click;
                button.Text = Path.GetFileName(file);
                flowLayoutPanel1.Controls.Add(button);
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string jsonString = File.ReadAllText(path + @"\" + $"{button.Text}");
            DataSaveGraph dataSave = JsonSerializer.Deserialize<DataSaveGraph>(jsonString);
            OnOpenSavedGraph?.Invoke(dataSave);
        }

    }
}
