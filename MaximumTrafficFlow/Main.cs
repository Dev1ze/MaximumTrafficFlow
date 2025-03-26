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
    public partial class Main: Form
    {
        private Form activeForm = null;

        public Main()
        {
            InitializeComponent();
            OpenChildForm(new HomePage(), "ГЛАВНАЯ");
            Saves.OnOpenSavedGraph += LoadGraph;
        }

        private void OpenChildForm(Form childForm, string title)
        {
            if (activeForm != null) activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            Title.Text = title;
        }

        private void btn_Home_Click(object sender, EventArgs e)
        {
            OpenChildForm(new HomePage(), "ГЛАВНАЯ");
        }

        private void CreateGraph_Click(object sender, EventArgs e)
        {
            VisualGraph visualGraph = new VisualGraph();
            OpenChildForm(visualGraph, "СОЗДАНИЕ НОВОГО ГРАФА");
            Node.Edges.Clear();
        }

        private void Saves_Click(object sender, EventArgs e)
        {
            Saves saves = new Saves();
            OpenChildForm(saves, "СОХРАНЕНИЯ");
        }

        private void LoadGraph(DataSaveGraph dataSaveGraph)
        {
            VisualGraph visualGraph = new VisualGraph();
            visualGraph.LoadGraph(dataSaveGraph.nodeDatas, dataSaveGraph.edgeDatas);
            OpenChildForm(visualGraph, dataSaveGraph.Name);
        }
    }
}
