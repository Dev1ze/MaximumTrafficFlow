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
using System.Diagnostics;

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
            Directory.CreateDirectory(path);
            string[] files = Directory.GetFiles(path, "*.json");

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
                button.BackColor = Color.FromArgb(35, 40, 45);
                button.FlatStyle = FlatStyle.Flat;
                button.Width = 160;
                button.Height = 35;
                button.Click += Button_Click;
                button.ForeColor = Color.White;
                button.Text = Path.GetFileName(file);

                delete.BackColor = Color.FromArgb(35, 40, 45);
                delete.FlatStyle = FlatStyle.Flat;
                delete.Image = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img") + @"\" + "Delete.png");
                delete.Height = 35;
                delete.Width = 50;
                delete.ForeColor = Color.White;
                delete.Click += DeleteButton_Click;

                flowLayoutPanel1.Controls.Add(ItemSave);
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string jsonString = File.ReadAllText(path + @"\" + $"{button.Text}");
            try 
            {
                DataSaveGraph dataSave = JsonSerializer.Deserialize<DataSaveGraph>(jsonString);
                dataSave.Name = button.Text;
                OnOpenSavedGraph?.Invoke(dataSave);
            }
            catch
            {
                MessageBox.Show("Не удалось прочитать файл!", "Ошибка чтения!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            Button deleteButton = sender as Button;
            if (deleteButton != null && deleteButton.Parent is FlowLayoutPanel itemSave)
            {
                flowLayoutPanel1.Controls.Remove(itemSave);
                string fileName = itemSave.Controls[0].Text;
                File.Delete($"{path}\\{fileName}");
            }
        }
        private void OpenFolder_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", path);
        }
    }
}
