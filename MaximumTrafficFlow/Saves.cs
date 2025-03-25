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
                Button delete = new Button();
                FlowLayoutPanel ItemSave = new FlowLayoutPanel();
                ItemSave.FlowDirection = FlowDirection.LeftToRight;
                ItemSave.AutoSize = true;
                ItemSave.WrapContents = false;
                ItemSave.Controls.Add(button);
                ItemSave.Controls.Add(delete);
                button.Width = 100;
                delete.Text = "Удалить";
                button.Width = 150;
                button.Click += Button_Click;
                delete.Click += DeleteButton_Click;
                button.Text = Path.GetFileName(file);
                flowLayoutPanel1.Controls.Add(ItemSave);
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string jsonString = File.ReadAllText(path + @"\" + $"{button.Text}");
            DataSaveGraph dataSave = JsonSerializer.Deserialize<DataSaveGraph>(jsonString);
            OnOpenSavedGraph?.Invoke(dataSave);
        }
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            Button deleteButton = sender as Button;
            if (deleteButton != null && deleteButton.Parent is FlowLayoutPanel itemSave)
            {
                flowLayoutPanel1.Controls.Remove(itemSave);
                string fileName = itemSave.Controls[0].Text;
                File.Delete($"{path}\\{fileName}");
                //itemSave.Dispose();
            }
        }
    }
}
