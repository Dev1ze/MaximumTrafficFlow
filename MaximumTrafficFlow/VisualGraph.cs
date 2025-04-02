using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using GraphMinCutLibrary;
using System.Text.Json;
using System.IO;
using Newtonsoft.Json.Linq;

namespace MaximumTrafficFlow
{
    public partial class VisualGraph : Form
    {
        int MaxNodes { get; set; } = 25;
        Form1 form1 = new Form1();
        public List<Node> nodes = new List<Node>();
        public int selectedNodeIndex = -1;
        public static event Action OnExsistEdge;
        Matrix matrix1;
        Graph graph;

        public VisualGraph()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            form1.onClickBack += BackToGraph;
            ShowResults.Visible = false;
            Node.Edges.Clear();
        }

        private void VisualGraph_MouseDown(object sender, MouseEventArgs e)
        {
            if (graph == null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    ExceptionHandler.HandleAddNodes(ErrorText);
                    ExceptionChecker.CheckLimitNodes(MaxNodes, nodes);
                    if (!ExceptionHandler.IsError)
                    {

                        nodes.Add(new Node(e.Location));
                        nodes[nodes.Count - 1].Number = nodes.Count;
                        Refresh();
                    }
                }

                if (e.Button == MouseButtons.Right)
                {
                    for (int i = 0; i < nodes.Count; i++)
                    {
                        if (Distance(e.Location, nodes[i].Position) < Node.Radius)
                        {
                            selectedNodeIndex = i;
                            break;
                        }
                    }
                }
            }
        }

        private void VisualGraph_MouseMove(object sender, MouseEventArgs e)
        {
            if (selectedNodeIndex != -1 && e.Location.X > 0 && e.Location.Y > 0)
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
            DrawEdges(e);
            DrawNodes(e);
        }

        private void button_DeleteNode(object sender, EventArgs e)
        {
            string deleteIndex = textBox_forDelete.Text ?? "";
            ExceptionHandler.HandleDeleteNode(ErrorText);
            ExceptionChecker.CheckDeleteNode(nodes, deleteIndex);
            if (!ExceptionHandler.IsError)
            {
                int indexForDelete = int.Parse(textBox_forDelete.Text) - 1;

                // Удаляем вершину
                nodes.RemoveAt(indexForDelete);

                // Удаляем связанные рёбра (проходим в обратном порядке, чтобы безопасно удалять)
                for (int j = Node.Edges.Count - 1; j >= 0; j--)
                {
                    if (Node.Edges[j].StartIndex == indexForDelete || Node.Edges[j].EndIndex == indexForDelete)
                    {
                        Node.Edges.RemoveAt(j);
                    }
                }

                // Обновляем индексы вершин в рёбрах
                for (int i = 0; i < Node.Edges.Count; i++)
                {
                    if (Node.Edges[i].StartIndex > indexForDelete)
                        Node.Edges[i].StartIndex--;
                    if (Node.Edges[i].EndIndex > indexForDelete)
                        Node.Edges[i].EndIndex--;
                }

                // Перенумеровываем вершины
                for (int i = 0; i < nodes.Count; i++)
                {
                    nodes[i].Number = i + 1;
                }
                Refresh();
            }
        }

        private void button_CreateEdge(object sender, EventArgs e)
        {
            string startIndex = indexFrom.Text ?? "";
            string endIndex = indexTo.Text ?? "";
            string valueStream = valueEdge.Text ?? "";
            List<TextBox> InputsFields = new List<TextBox>()
            {
                indexFrom,
                indexTo,
                valueEdge
            };

            ExceptionHandler.HandleBuildEdge(ErrorText);
            ExceptionChecker.CheckAllExceptions(Node.Edges, startIndex, endIndex, nodes, InputsFields);

            if (!ExceptionHandler.IsError)
            {
                BuildEdge(nodes);
            }

            if(Node.Edges.Count >= 2) SaveGraph.Visible = true;
        }

        private void FindMinCut_Click(object sender, EventArgs e) //Нажатие на кнопку "Найти минимальный разрез"
        {
            string startIndex = indexFrom.Text ?? "";
            string endIndex = indexTo.Text ?? "";
            string valueStream = valueEdge.Text ?? "";
            List<TextBox> InputsFields = new List<TextBox>()
            {
                indexFrom,
                indexTo,
                valueEdge
            };
            ExceptionHandler.HandleFindMinimalCut(ErrorText);
            ExceptionChecker.CheckIsolatedkNode(nodes);
            ExceptionChecker.CheckExsistGraph(Node.Edges);

            if (!ExceptionHandler.IsError)
            {
                matrix1 = new Matrix(MatrixConverter.BuildMatrix(Node.Edges));
                graph = new Graph(matrix1);
                graph.OnGetResult += GetMultitude;
                graph.FindMinimalCut();
                form1.PrintText(graph.Results);
                ShowResults.Visible = true;
                SwitchEnableInterface(panel1, false, graph.Results);
            }
        }

        private void BuildEdge(List<Node> nodes)
        {
            ErrorText.Visible = false;
            int start = int.Parse(indexFrom.Text) - 1;
            int end = int.Parse(indexTo.Text) - 1;
            int value = int.Parse(valueEdge.Text);
            Point startPos = new Point(nodes[start].Position.X, nodes[start].Position.Y);
            Point endPos = new Point(nodes[end].Position.X, nodes[end].Position.Y);
            nodes[start].AddEdge(new Edge(startPos, endPos, start, end, value));
            nodes[start].IndexTo.Add(end);
            nodes[end].IndexFrom.Add(start);
            Node.UpdateRelatedEdge(Node.Edges, start, nodes[start].Position);
            Node.UpdateRelatedEdge(Node.Edges, end, nodes[end].Position);
            Refresh();
        }

        private void DrawEdges(PaintEventArgs e)
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                Node.UpdateRelatedEdge(Node.Edges, i, nodes[i].Position);
                foreach (var edge in Node.Edges)
                {
                    e.Graphics.DrawLine(edge.ColorEdge, edge.StartPos.X, edge.StartPos.Y, edge.EndPos.X, edge.EndPos.Y);
                    e.Graphics.DrawString(edge.ValueStream.ToString(), Node.FontText, Brushes.Black, edge.ValueStreamPos);
                    DrawArrow(e.Graphics, edge.StartPos, edge.EndPos, edge.ColorEdge.Color,0.5f);
                }
            }
        }

        private void DrawArrow(Graphics g, Point start, Point end, Color color, float arrowPositionFactor)
        {
            Pen arrowPen = new Pen(color, 2);
            double angle = Math.Atan2(end.Y - start.Y, end.X - start.X); // Вычисляем угол наклона ребра

            int arrowSize = 10; // Размер стрелки

            // Смещение точки стрелки (0.5 - середина, 0.7 - ближе к концу, 0.9 - почти в конце)
            float arrowX = start.X + (end.X - start.X) * arrowPositionFactor;
            float arrowY = start.Y + (end.Y - start.Y) * arrowPositionFactor;
            PointF arrowPoint = new PointF(arrowX, arrowY);

            // Вычисляем точки для стрелки
            PointF arrowPoint1 = new PointF(
                arrowPoint.X - arrowSize * (float)Math.Cos(angle - Math.PI / 6),
                arrowPoint.Y - arrowSize * (float)Math.Sin(angle - Math.PI / 6)
            );
            PointF arrowPoint2 = new PointF(
                arrowPoint.X - arrowSize * (float)Math.Cos(angle + Math.PI / 6),
                arrowPoint.Y - arrowSize * (float)Math.Sin(angle + Math.PI / 6)
            );

            // Рисуем стрелку двумя линиями
            g.DrawLine(arrowPen, arrowPoint, arrowPoint1);
            g.DrawLine(arrowPen, arrowPoint, arrowPoint2);
        }

        private void DrawNodes(PaintEventArgs e)
        {
            foreach (var node in nodes)
            {
                e.Graphics.FillEllipse(node.Color, node.Position.X - Node.Radius / 2, node.Position.Y - Node.Radius / 2, Node.Radius, Node.Radius);
                e.Graphics.DrawString(node.Number.ToString(), Node.FontText, Brushes.White, node.NodeCenterPos);
            }
        }

        private double Distance(Point mousePoint, Point nodePoint)
        {
            return Math.Sqrt(Math.Pow(Math.Abs(mousePoint.X - nodePoint.X), 2) + Math.Pow(Math.Abs(mousePoint.Y - nodePoint.Y), 2));
        }

        public void GetMultitude(List<List<int>> list)
        {
            List<Edge> indexesMinimalPaths = new List<Edge>();
            for(int i = 0; i < Node.Edges.Count; i++)
            {
                int[] itemList = new int[2];
                itemList[0] = Node.Edges[i].StartIndex;
                itemList[1] = Node.Edges[i].EndIndex;
                if(GetCountRepeats(itemList, list.First()) == 1)
                {
                    indexesMinimalPaths.Add(Node.Edges[i]);
                }
            }
            foreach(var edge in indexesMinimalPaths) 
            {
                edge.ColorEdge = Pens.Red;
            }
            Refresh();
        }

        private int GetCountRepeats(int[] itemList, List<int> list)
        {
            int countRepeats = 0;
            for(int i = 0; i < itemList.Length; i++) 
            { 
                for(int j = 0; j < list.Count; j++)
                {
                    if (list[j] - 1 == itemList[i])
                    {
                        countRepeats++;
                    }
                }
            }
            return countRepeats;
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            TextBox textBox = sender as TextBox;
            //ErrorText.Visible = false;
            if ((!char.IsDigit(number) && number != (char)Keys.Back) || (textBox.Text.Length > 5 && number != (char)Keys.Back))
            {
                // Если символ не является цифрой, отменяем его ввод
                e.Handled = true;
            }
        }

        private void ShowResults_Click(object sender, EventArgs e)
        {
            if (graph.Results.Count == 0)
            {
                graph.OnGetResult += GetMultitude;
                graph.FindMinimalCut();
                form1.PrintText(graph.Results);
            }
            form1.TopLevel = false;  // Делаем форму вложенной
            form1.FormBorderStyle = FormBorderStyle.None; // Убираем границы
            form1.Dock = DockStyle.Fill; // Растягиваем на всю панель
            panelChildForm.Controls.Add(form1); // Добавляем в панель
            panelChildForm.Visible = true;
            panelChildForm.BringToFront();
            form1.Show();
            string i;
        }

        private void BackToGraph()
        {
            panelChildForm.Visible = false;
            panelChildForm.SendToBack();
        }

        private void SwitchEnableInterface(Control panel, bool isEnables, List<List<string>> results) 
        {
            string imgPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img");
            foreach (Control item in panel.Controls)
            {
                if (item.Name != "ShowResults" && item.Name != "SaveGraph")
                {
                    item.Visible = isEnables;
                }
            }
            if (results[results.Count - 2].Last() == "")
            {
                DoneImg.Image = Image.FromFile(imgPath + @"\" + "Error-Icon.png");
                DoneImg.Visible = true;
            }
                
            else 
            {
                DoneImg.Image = Image.FromFile(imgPath + @"\" + "Done-Icon.png");
                DoneImg.Visible = true;
            }
        }

        private void SaveGraph_Click(object sender, EventArgs e)
        {
            ExceptionHandler.HandleSaveGrapgh(ErrorText);
            ExceptionChecker.CheckZeroDataForSave(nodes);
            
            if(!ExceptionHandler.IsError)
            {
                string name = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
                string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "saves");
                if (!Directory.Exists(fullPath))
                {
                    Directory.CreateDirectory(fullPath);
                }
                string pathToSaveFile = Path.Combine(fullPath, $"{name}.json");
                DataSaveGraph dataSave = new DataSaveGraph();
                dataSave.FillList(Node.Edges, nodes);
                string jsonString = JsonSerializer.Serialize(dataSave, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(pathToSaveFile, jsonString);
                DataSaveGraph dataSave2 = JsonSerializer.Deserialize<DataSaveGraph>(jsonString);
                ExceptionChecker.CheckSucsessSave(pathToSaveFile);
            }
            
        }

        public void LoadGraph(List<NodeData> nodeDatas, List<EdgeData> edgeDatas)
        {
            foreach (NodeData nodeData in nodeDatas)
            {
                nodes.Add(new Node(nodeData.Position));
                nodes[nodes.Count - 1].Number = nodes.Count;
            }

            foreach (EdgeData edgeData in edgeDatas)
            {
                int start = edgeData.From;
                int end = edgeData.To;
                int value = edgeData.Weight;
                Point startPos = new Point(nodes[start].Position.X, nodes[start].Position.Y);
                Point endPos = new Point(nodes[end].Position.X, nodes[end].Position.Y);
                nodes[start].AddEdge(new Edge(startPos, endPos, start, end, value));
                nodes[start].IndexTo.Add(end);
                nodes[end].IndexFrom.Add(start);
                Node.UpdateRelatedEdge(Node.Edges, start, nodes[start].Position);
                Node.UpdateRelatedEdge(Node.Edges, end, nodes[end].Position);
            }
        }

        private void DeleteEdge_Click(object sender, EventArgs e)
        {
            int start = int.Parse(indexFrom.Text) - 1;
            int end = int.Parse(indexTo.Text) - 1;
            int value = int.Parse(valueEdge.Text);

            ExceptionHandler.HandleDeleteEdge(ErrorText);
            ExceptionChecker.CheckNoneExsistEdge(Node.Edges, indexFrom.Text, indexTo.Text, valueEdge.Text);
            if (!ExceptionHandler.IsError)
            {
                for (int i = 0; i < Node.Edges.Count; i++)
                {
                    if (Node.Edges[i].StartIndex == start && Node.Edges[i].EndIndex == end && Node.Edges[i].ValueStream == value)
                    {
                        Node.Edges.RemoveAt(i);
                        int indexEnd = nodes[start].IndexTo.IndexOf(end);
                        nodes[start].IndexTo.RemoveAt(indexEnd);
                        int indexStart = nodes[end].IndexFrom.IndexOf(start);
                        nodes[end].IndexFrom.RemoveAt(indexStart);
                        Refresh();
                        return;
                    }
                }
            }
        }
    }
}
