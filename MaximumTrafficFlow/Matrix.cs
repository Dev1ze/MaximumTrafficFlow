using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaximumTrafficFlow
{
    public class Matrix
    {
        public Matrix(int[,] array)
        {
            Arrayy = array;
        }
        public int[,] Arrayy { get; set; }
        private int countPrintMatrix = 1;
        private static int Heiht = 20;

        public void PrintMatrix(Form1 form, string nameMatrix)
        {
            int heightBox = 0;
            TextBox textBox = SetTextBox(form, ref heightBox);
            Label label = SetLabel(form, nameMatrix, heightBox);
            FillTextBox(textBox);
            countPrintMatrix++;
        }

        private TextBox SetTextBox(Form form, ref int heightBox)
        {
            TextBox textBox = new TextBox();
            textBox.WordWrap = true;
            textBox.Multiline = true; // Разрешаем многострочный режим
            textBox.Location = new Point(80, Heiht); // Положение каждого textBox'а
            int matrixWidth = Arrayy.GetLength(1) * 48; // Предполагаем начальную ширину матрицы
            int matrixHeight = Arrayy.GetLength(0) * 14; // Предполагаем начальную высоту матрицы
            heightBox = matrixHeight;
            textBox.Width = matrixWidth; // Учитываем полосу прокрутки и небольшой отступ
            textBox.Height = matrixHeight;
            Heiht += matrixHeight + 20;
            form.Controls.Add(textBox); // Добавляем textBox на форму
            return textBox;
        }

        private Label SetLabel(Form form, string nameBlock, int heightBox)
        {
            Label label = new Label();
            label.Text = nameBlock;
            label.Location = new Point(40, (Heiht - 20) - (heightBox/2));
            label.Width = nameBlock.Length * 6;
            form.Controls.Add(label);
            return label;
        }

        private void FillTextBox(TextBox textBox)
        {
            string row = "";
            for (int i = 0; i < Arrayy.GetLength(0); i++)
            {
                for (int j = 0; j < Arrayy.GetLength(1); j++)
                {
                    row += Arrayy[i, j].ToString() + "\t";
                }
                textBox.Text += row + "\r\n";
                row = "";
            }
        }
    }
}
