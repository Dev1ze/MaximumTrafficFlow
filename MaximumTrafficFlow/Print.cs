using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaximumTrafficFlow
{
    static class Print
    {
        private static int Heiht = 20;
        const int startPositionX = 80;

        public static void Start(Form1 form, Matrix matrix, string nameMatrix)
        {
            int heightBox = 0;
            TextBox textBox = SetTextBox(form, ref heightBox, matrix);
            Label label = SetLabel(form, nameMatrix, heightBox);
            FillTextBox(textBox, matrix);
        }

        public static void Start(Form1 form, Matrix matrix, string nameMatrix, object[] descriptions)
        {
            int heightBox = 0;
            TextBox textBox = SetTextBox(form, ref heightBox, matrix);
            Label label = SetLabel(form, nameMatrix, heightBox);
            TextBox textBox1 = SetTextBox(form, ref heightBox, (List<List<int>>)descriptions[2], textBox);
            FillTextBox(textBox, matrix);
            FillTextBox(textBox1, (List<List<int>>)descriptions[2]);
        }

        private static TextBox SetTextBox(Form form, ref int heightBox, Matrix matrix)
        {
            TextBox textBox = new TextBox();
            textBox.WordWrap = true;
            textBox.Multiline = true; // Разрешаем многострочный режим
            textBox.Location = new Point(startPositionX, Heiht); // Положение каждого textBox'а
            int matrixWidth = matrix.Arrayy.GetLength(1) * 48; // Предполагаем начальную ширину матрицы
            int matrixHeight = matrix.Arrayy.GetLength(0) * 14; // Предполагаем начальную высоту матрицы
            heightBox = matrixHeight;
            textBox.Width = matrixWidth; // Учитываем полосу прокрутки и небольшой отступ
            textBox.Height = matrixHeight;
            Heiht += matrixHeight + 20;
            form.Controls.Add(textBox); // Добавляем textBox на форму
            return textBox;
        }

        private static TextBox SetTextBox(Form form, ref int heightBox, List<List<int>> connectedVertices, TextBox matrix)
        {
            int Wigth;
            TextBox textBox = new TextBox();
            textBox.WordWrap = true;
            textBox.Multiline = true; // Разрешаем многострочный режим
            Wigth = matrix.Width + 20 + startPositionX;
            textBox.Location = new Point(Wigth, matrix.Location.Y); // Положение каждого textBox'а
            int matrixWidth = connectedVertices[0].Count * 48; // Предполагаем начальную ширину матрицы
            int matrixHeight = connectedVertices.Count * 14; // Предполагаем начальную высоту матрицы
            heightBox = matrixHeight;
            textBox.Width = matrixWidth; // Учитываем полосу прокрутки и небольшой отступ
            textBox.Height = matrixHeight;
            form.Controls.Add(textBox); // Добавляем textBox на форму
            return textBox;
        }

        private static Label SetLabel(Form form, string nameBlock, int heightBox)
        {
            Label label = new Label();
            label.Text = nameBlock;
            label.Width = TextRenderer.MeasureText(nameBlock, label.Font).Width;
            label.Location = new Point(startPositionX - label.Width, (Heiht - 20) - (heightBox / 2));
            form.Controls.Add(label);
            return label;
        }

        private static void FillTextBox(TextBox textBox, Matrix matrix)
        {
            string row = "";
            for (int i = 0; i < matrix.Arrayy.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.Arrayy.GetLength(1); j++)
                {
                    row += matrix.Arrayy[i, j].ToString() + "\t";
                }
                textBox.Text += row + "\r\n";
                row = "";
            }
        }

        private static void FillTextBox(TextBox textBox, List<List<int>> connectionVertices)
        {
            string row = "";
            for (int i = 0; i < connectionVertices.Count; i++)
            {
                for (int j = 0; j < connectionVertices[i].Count; j++)
                {
                    if (j == 0)
                    {
                        row += connectionVertices[i][j].ToString() + " |" + "\t";
                    }
                    else row += connectionVertices[i][j].ToString() + "\t";

                }
                textBox.Text += row + "\r\n";
                row = "";
            }
        }
    }
}
