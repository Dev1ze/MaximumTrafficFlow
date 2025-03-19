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
            this.btn_FindMinCut = new System.Windows.Forms.Button();
            this.startIndex = new System.Windows.Forms.Label();
            this.endIndex = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_forDelete = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.ErrorText = new System.Windows.Forms.Label();
            this.panelChildForm = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ShowResults = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CreateEdge
            // 
            this.CreateEdge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CreateEdge.Location = new System.Drawing.Point(631, 12);
            this.CreateEdge.Name = "CreateEdge";
            this.CreateEdge.Size = new System.Drawing.Size(141, 23);
            this.CreateEdge.TabIndex = 0;
            this.CreateEdge.Text = "Создать ребро";
            this.CreateEdge.UseVisualStyleBackColor = true;
            this.CreateEdge.Click += new System.EventHandler(this.button_CreateEdge);
            // 
            // indexFrom
            // 
            this.indexFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.indexFrom.Location = new System.Drawing.Point(722, 51);
            this.indexFrom.Name = "indexFrom";
            this.indexFrom.Size = new System.Drawing.Size(50, 20);
            this.indexFrom.TabIndex = 1;
            this.indexFrom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // indexTo
            // 
            this.indexTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.indexTo.Location = new System.Drawing.Point(722, 77);
            this.indexTo.Name = "indexTo";
            this.indexTo.Size = new System.Drawing.Size(50, 20);
            this.indexTo.TabIndex = 2;
            this.indexTo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // valueEdge
            // 
            this.valueEdge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.valueEdge.Location = new System.Drawing.Point(722, 103);
            this.valueEdge.Name = "valueEdge";
            this.valueEdge.Size = new System.Drawing.Size(50, 20);
            this.valueEdge.TabIndex = 3;
            this.valueEdge.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // btn_FindMinCut
            // 
            this.btn_FindMinCut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_FindMinCut.Location = new System.Drawing.Point(631, 169);
            this.btn_FindMinCut.Name = "btn_FindMinCut";
            this.btn_FindMinCut.Size = new System.Drawing.Size(141, 36);
            this.btn_FindMinCut.TabIndex = 4;
            this.btn_FindMinCut.Text = "Найти минимальный разрез";
            this.btn_FindMinCut.UseVisualStyleBackColor = true;
            this.btn_FindMinCut.Click += new System.EventHandler(this.FindMinCut_Click);
            // 
            // startIndex
            // 
            this.startIndex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.startIndex.AutoSize = true;
            this.startIndex.Location = new System.Drawing.Point(628, 54);
            this.startIndex.Name = "startIndex";
            this.startIndex.Size = new System.Drawing.Size(47, 13);
            this.startIndex.TabIndex = 5;
            this.startIndex.Text = "Из узла";
            // 
            // endIndex
            // 
            this.endIndex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.endIndex.AutoSize = true;
            this.endIndex.Location = new System.Drawing.Point(628, 80);
            this.endIndex.Name = "endIndex";
            this.endIndex.Size = new System.Drawing.Size(40, 13);
            this.endIndex.TabIndex = 6;
            this.endIndex.Text = "В узел";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(628, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Значение ребра";
            // 
            // textBox_forDelete
            // 
            this.textBox_forDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_forDelete.Location = new System.Drawing.Point(722, 225);
            this.textBox_forDelete.Name = "textBox_forDelete";
            this.textBox_forDelete.Size = new System.Drawing.Size(50, 20);
            this.textBox_forDelete.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(628, 232);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Вершина";
            // 
            // DeleteButton
            // 
            this.DeleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteButton.Location = new System.Drawing.Point(631, 248);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(141, 23);
            this.DeleteButton.TabIndex = 9;
            this.DeleteButton.Text = "Удалить вершину";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.button_DeleteNode);
            // 
            // ErrorText
            // 
            this.ErrorText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ErrorText.ForeColor = System.Drawing.Color.Red;
            this.ErrorText.Location = new System.Drawing.Point(614, 140);
            this.ErrorText.Name = "ErrorText";
            this.ErrorText.Size = new System.Drawing.Size(175, 26);
            this.ErrorText.TabIndex = 10;
            this.ErrorText.Text = "Указаны несуществующие узлы";
            this.ErrorText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ErrorText.Visible = false;
            // 
            // panelChildForm
            // 
            this.panelChildForm.AutoScroll = true;
            this.panelChildForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChildForm.Location = new System.Drawing.Point(0, 0);
            this.panelChildForm.Name = "panelChildForm";
            this.panelChildForm.Size = new System.Drawing.Size(802, 498);
            this.panelChildForm.TabIndex = 9;
            this.panelChildForm.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Location = new System.Drawing.Point(606, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(193, 314);
            this.panel1.TabIndex = 13;
            // 
            // ShowResults
            // 
            this.ShowResults.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ShowResults.Location = new System.Drawing.Point(631, 286);
            this.ShowResults.Name = "ShowResults";
            this.ShowResults.Size = new System.Drawing.Size(141, 23);
            this.ShowResults.TabIndex = 0;
            this.ShowResults.Text = "Показать решение";
            this.ShowResults.UseVisualStyleBackColor = true;
            this.ShowResults.Visible = false;
            this.ShowResults.Click += new System.EventHandler(this.ShowResults_Click);
            // 
            // VisualGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 498);
            this.Controls.Add(this.ShowResults);
            this.Controls.Add(this.textBox_forDelete);
            this.Controls.Add(this.CreateEdge);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.indexFrom);
            this.Controls.Add(this.ErrorText);
            this.Controls.Add(this.indexTo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_FindMinCut);
            this.Controls.Add(this.endIndex);
            this.Controls.Add(this.valueEdge);
            this.Controls.Add(this.startIndex);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelChildForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VisualGraph";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Создание сети";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.VisualGraph_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VisualGraph_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.VisualGraph_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.VisualGraph_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CreateEdge;
        private System.Windows.Forms.TextBox indexFrom;
        private System.Windows.Forms.TextBox indexTo;
        private System.Windows.Forms.TextBox valueEdge;
        private System.Windows.Forms.Button btn_FindMinCut;
        private System.Windows.Forms.Label startIndex;
        private System.Windows.Forms.Label endIndex;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label ErrorText;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.TextBox textBox_forDelete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelChildForm;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button ShowResults;
    }
}