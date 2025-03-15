namespace MaximumTrafficFlow
{
    partial class VisualGraph
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CreateEdge = new System.Windows.Forms.Button();
            this.indexFrom = new System.Windows.Forms.TextBox();
            this.indexTo = new System.Windows.Forms.TextBox();
            this.valueEdge = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.startIndex = new System.Windows.Forms.Label();
            this.endIndex = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ErrorText = new System.Windows.Forms.Label();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_forDelete = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CreateEdge
            // 
            this.CreateEdge.Location = new System.Drawing.Point(21, 21);
            this.CreateEdge.Name = "CreateEdge";
            this.CreateEdge.Size = new System.Drawing.Size(141, 23);
            this.CreateEdge.TabIndex = 0;
            this.CreateEdge.Text = "Создать ребро";
            this.CreateEdge.UseVisualStyleBackColor = true;
            this.CreateEdge.Click += new System.EventHandler(this.button_CreateEdge);
            // 
            // indexFrom
            // 
            this.indexFrom.Location = new System.Drawing.Point(112, 50);
            this.indexFrom.Name = "indexFrom";
            this.indexFrom.Size = new System.Drawing.Size(50, 20);
            this.indexFrom.TabIndex = 1;
            this.indexFrom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // indexTo
            // 
            this.indexTo.Location = new System.Drawing.Point(112, 76);
            this.indexTo.Name = "indexTo";
            this.indexTo.Size = new System.Drawing.Size(50, 20);
            this.indexTo.TabIndex = 2;
            this.indexTo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // valueEdge
            // 
            this.valueEdge.Location = new System.Drawing.Point(112, 102);
            this.valueEdge.Name = "valueEdge";
            this.valueEdge.Size = new System.Drawing.Size(50, 20);
            this.valueEdge.TabIndex = 3;
            this.valueEdge.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(21, 168);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(141, 36);
            this.button2.TabIndex = 4;
            this.button2.Text = "Найти минимальный разрез";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // startIndex
            // 
            this.startIndex.AutoSize = true;
            this.startIndex.Location = new System.Drawing.Point(18, 53);
            this.startIndex.Name = "startIndex";
            this.startIndex.Size = new System.Drawing.Size(47, 13);
            this.startIndex.TabIndex = 5;
            this.startIndex.Text = "Из узла";
            // 
            // endIndex
            // 
            this.endIndex.AutoSize = true;
            this.endIndex.Location = new System.Drawing.Point(18, 79);
            this.endIndex.Name = "endIndex";
            this.endIndex.Size = new System.Drawing.Size(40, 13);
            this.endIndex.TabIndex = 6;
            this.endIndex.Text = "В узел";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Значение ребра";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.textBox_forDelete);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.DeleteButton);
            this.panel1.Controls.Add(this.ErrorText);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.endIndex);
            this.panel1.Controls.Add(this.startIndex);
            this.panel1.Controls.Add(this.valueEdge);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.indexTo);
            this.panel1.Controls.Add(this.CreateEdge);
            this.panel1.Controls.Add(this.indexFrom);
            this.panel1.Location = new System.Drawing.Point(615, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(184, 281);
            this.panel1.TabIndex = 8;
            // 
            // ErrorText
            // 
            this.ErrorText.ForeColor = System.Drawing.Color.Red;
            this.ErrorText.Location = new System.Drawing.Point(4, 139);
            this.ErrorText.Name = "ErrorText";
            this.ErrorText.Size = new System.Drawing.Size(175, 26);
            this.ErrorText.TabIndex = 10;
            this.ErrorText.Text = "Указаны несуществующие узлы";
            this.ErrorText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ErrorText.Visible = false;
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(21, 247);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(141, 23);
            this.DeleteButton.TabIndex = 9;
            this.DeleteButton.Text = "Удалить вершину";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.button_DeleteNode);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 231);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Вершина";
            // 
            // textBox_forDelete
            // 
            this.textBox_forDelete.Location = new System.Drawing.Point(112, 224);
            this.textBox_forDelete.Name = "textBox_forDelete";
            this.textBox_forDelete.Size = new System.Drawing.Size(50, 20);
            this.textBox_forDelete.TabIndex = 12;
            // 
            // VisualGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Name = "VisualGraph";
            this.Text = "Создание сети";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.VisualGraph_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VisualGraph_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.VisualGraph_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.VisualGraph_MouseUp);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CreateEdge;
        private System.Windows.Forms.TextBox indexFrom;
        private System.Windows.Forms.TextBox indexTo;
        private System.Windows.Forms.TextBox valueEdge;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label startIndex;
        private System.Windows.Forms.Label endIndex;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label ErrorText;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.TextBox textBox_forDelete;
        private System.Windows.Forms.Label label1;
    }
}