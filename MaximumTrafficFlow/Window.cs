using GraphMinCutLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MaximumTrafficFlow.Window;
using static System.Net.Mime.MediaTypeNames;

namespace MaximumTrafficFlow
{
    static class Window
    {
        private static int startPositionY = 60;
        private static int startPositionX = 60;
        static int margin = 50;
        static List<int> heigherBlock = new List<int>();

        public static void Write(Form1 form, string objectPrint, string nameMatrix)
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

        private static TextBox SetTextBox(Form form, string objectPrint)
        {
            TextBox textBox = new TextBox
            {
                Font = new Font("Consolas", 10) //Шрифт где все знаки одинаковой ширины 
            };
            int matrixWidth = TextRenderer.MeasureText(objectPrint, textBox.Font).Width;
            int matrixHeight = TextRenderer.MeasureText(objectPrint, textBox.Font).Height;
            textBox.WordWrap = true;
            textBox.Multiline = true;
            textBox.Location = new Point(startPositionX, startPositionY); // Положение textBox'а
            textBox.Width = matrixWidth;
            textBox.Height = matrixHeight;
            startPositionX += matrixWidth + margin;
            form.Controls.Add(textBox);
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
