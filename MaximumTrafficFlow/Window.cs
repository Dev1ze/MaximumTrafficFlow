using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MaximumTrafficFlow.Window;

namespace MaximumTrafficFlow
{
    static class Window
    {
        private static int startPositionY = 80;
        private static int startPositionX = 60;
        static int marginRight = 50;
        static int marginBottom = startPositionY;

        public static void Write(Form1 form, IDataStructure objectPrint, string nameMatrix)
        {
            int heightBox = 0;
            TextBox textBox = SetTextBox(form, ref heightBox, objectPrint);
            textBox.Text = objectPrint.ToString();
            Label label = SetLabel(form, nameMatrix, textBox);
            if ((startPositionY + heightBox) > marginBottom) marginBottom += heightBox;
        }

        public static void NewLIne()
        {
            startPositionY = marginBottom + 50;
            startPositionX = 60;
        }

        private static TextBox SetTextBox(Form form, ref int heightBox, IDataStructure objectPrint)
        {
            int matrixWidth = objectPrint.Width * 48; // Предполагаем начальную ширину матрицы
            int matrixHeight = objectPrint.Heigth * 14; // Предполагаем начальную высоту матрицы
            TextBox textBox = new TextBox();
            textBox.WordWrap = true;
            textBox.Multiline = true; // Разрешаем многострочный режим
            textBox.Location = new Point(startPositionX, startPositionY); // Положение textBox'а
            heightBox = matrixHeight;
            textBox.Width = matrixWidth;
            textBox.Height = matrixHeight;
            startPositionX += matrixWidth + marginRight;
            form.Controls.Add(textBox); // Добавляем textBox на форму
            return textBox;
        }

        //private static TextBox SetTextBox(Form form, ref int heightBox, List<List<int>> connectedVertices, TextBox matrix)
        //{
        //    int Wigth;
        //    TextBox textBox = new TextBox();
        //    textBox.WordWrap = true;
        //    textBox.Multiline = true; // Разрешаем многострочный режим
        //    Wigth = matrix.Width + 20 + startPositionX;
        //    textBox.Location = new Point(Wigth, matrix.Location.Y); // Положение каждого textBox'а
        //    int matrixWidth = FindLongestList(connectedVertices) * 48; // Предполагаем начальную ширину матрицы
        //    int matrixHeight = connectedVertices.Count * 14; // Предполагаем начальную высоту матрицы
        //    heightBox = matrixHeight;
        //    textBox.Width = matrixWidth; // Учитываем полосу прокрутки и небольшой отступ
        //    textBox.Height = matrixHeight;
        //    form.Controls.Add(textBox); // Добавляем textBox на форму
        //    return textBox;
        //}

        private static Label SetLabel(Form form, string nameBlock, TextBox textBox)
        {
            Label label = new Label();
            label.Text = nameBlock;
            label.Width = TextRenderer.MeasureText(nameBlock, label.Font).Width;
            label.Location = new Point(textBox.Location.X + ((textBox.Width / 2) - (label.Width / 2)), textBox.Location.Y - 20);
            form.Controls.Add(label);
            return label;
        }
    }
}
