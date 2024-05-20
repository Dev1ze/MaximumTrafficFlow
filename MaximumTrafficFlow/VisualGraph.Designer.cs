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
            this.NonExsistNode = new System.Windows.Forms.Label();
            this.EmptyFields = new System.Windows.Forms.Label();
            this.noneExsistEdge = new System.Windows.Forms.Label();
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
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.NonExsistNode);
            this.panel1.Controls.Add(this.endIndex);
            this.panel1.Controls.Add(this.EmptyFields);
            this.panel1.Controls.Add(this.startIndex);
            this.panel1.Controls.Add(this.noneExsistEdge);
            this.panel1.Controls.Add(this.valueEdge);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.indexTo);
            this.panel1.Controls.Add(this.CreateEdge);
            this.panel1.Controls.Add(this.indexFrom);
            this.panel1.Location = new System.Drawing.Point(615, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(184, 219);
            this.panel1.TabIndex = 8;
            // 
            // NonExsistNode
            // 
            this.NonExsistNode.ForeColor = System.Drawing.Color.Red;
            this.NonExsistNode.Location = new System.Drawing.Point(2, 139);
            this.NonExsistNode.Name = "NonExsistNode";
            this.NonExsistNode.Size = new System.Drawing.Size(179, 13);
            this.NonExsistNode.TabIndex = 10;
            this.NonExsistNode.Text = "Указаны несуществующие узлы";
            this.NonExsistNode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.NonExsistNode.Visible = false;
            // 
            // EmptyFields
            // 
            this.EmptyFields.ForeColor = System.Drawing.Color.Red;
            this.EmptyFields.Location = new System.Drawing.Point(4, 139);
            this.EmptyFields.Name = "EmptyFields";
            this.EmptyFields.Size = new System.Drawing.Size(175, 13);
            this.EmptyFields.TabIndex = 9;
            this.EmptyFields.Text = "Не все поля заполнены";
            this.EmptyFields.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.EmptyFields.Visible = false;
            // 
            // noneExsistEdge
            // 
            this.noneExsistEdge.AutoSize = true;
            this.noneExsistEdge.ForeColor = System.Drawing.Color.Red;
            this.noneExsistEdge.Location = new System.Drawing.Point(1, 139);
            this.noneExsistEdge.Name = "noneExsistEdge";
            this.noneExsistEdge.Size = new System.Drawing.Size(182, 13);
            this.noneExsistEdge.TabIndex = 11;
            this.noneExsistEdge.Text = "Ребро должно иметь направление";
            this.noneExsistEdge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.noneExsistEdge.Visible = false;
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
        private System.Windows.Forms.Label EmptyFields;
        private System.Windows.Forms.Label NonExsistNode;
        private System.Windows.Forms.Label noneExsistEdge;
    }
}