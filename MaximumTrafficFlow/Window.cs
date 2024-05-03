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
        private static int startPositionY = 60;
        private static int startPositionX = 60;
        static int margin = 50;
        static List<int> heigherBlock = new List<int>();

        public static void Write(Form1 form, IDataStructure objectPrint, string nameMatrix)
        {
            TextBox textBox = SetTextBox(form, objectPrint);
            textBox.Text = objectPrint.ToString();
            Label label = SetLabel(form, nameMatrix, textBox);
            heigherBlock.Add(textBox.Height);
        }

        public static void NewLIne()
        {
            startPositionY += FindMaximumValue(heigherBlock) + margin;
            startPositionX = 60;
            heigherBlock.Clear();
        }

        private static TextBox SetTextBox(Form form, IDataStructure objectPrint)
        {
            int matrixWidth = objectPrint.Width * 48;
            int matrixHeight = objectPrint.Heigth * 14;
            TextBox textBox = new TextBox();
            textBox.WordWrap = true;
            textBox.Multiline = true; // Разрешаем многострочный режим
            textBox.Location = new Point(startPositionX, startPositionY); // Положение textBox'а
            textBox.Width = matrixWidth;
            textBox.Height = matrixHeight;
            startPositionX += matrixWidth + margin;
            form.Controls.Add(textBox); // Добавляем textBox на форму
            return textBox;
        }

        private static Label SetLabel(Form form, string nameBlock, TextBox textBox)
        {
            Label label = new Label();
            label.Text = nameBlock;
            label.Width = TextRenderer.MeasureText(nameBlock, label.Font).Width;
            label.Location = new Point(textBox.Location.X + ((textBox.Width / 2) - (label.Width / 2)), textBox.Location.Y - 20);
            form.Controls.Add(label);
            return label;
        }

        private static int FindMaximumValue(List<int> values)
        {
            int maxValue = 0;
            foreach (var item in values)
            {
                if (item > maxValue) maxValue = item;
            }
            return maxValue;
        }
    }
}
