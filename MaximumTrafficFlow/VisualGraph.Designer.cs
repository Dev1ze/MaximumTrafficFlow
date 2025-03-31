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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VisualGraph));
            this.ErrorText = new System.Windows.Forms.Label();
            this.ShowResults = new System.Windows.Forms.Button();
            this.valueEdge = new System.Windows.Forms.TextBox();
            this.btn_FindMinCut = new System.Windows.Forms.Button();
            this.indexTo = new System.Windows.Forms.TextBox();
            this.indexFrom = new System.Windows.Forms.TextBox();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.textBox_forDelete = new System.Windows.Forms.TextBox();
            this.CreateEdge = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.DeleteEdge = new System.Windows.Forms.Button();
            this.SaveGraph = new System.Windows.Forms.Button();
            this.DoneImg = new System.Windows.Forms.PictureBox();
            this.panelChildForm = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DoneImg)).BeginInit();
            this.SuspendLayout();
            // 
            // ErrorText
            // 
            this.ErrorText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ErrorText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ErrorText.ForeColor = System.Drawing.Color.Red;
            this.ErrorText.Location = new System.Drawing.Point(0, 206);
            this.ErrorText.Name = "ErrorText";
            this.ErrorText.Size = new System.Drawing.Size(262, 41);
            this.ErrorText.TabIndex = 10;
            this.ErrorText.Text = "Указаны несуществующие узлы";
            this.ErrorText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ErrorText.Visible = false;
            // 
            // ShowResults
            // 
            this.ShowResults.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ShowResults.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ShowResults.ForeColor = System.Drawing.Color.Transparent;
            this.ShowResults.Location = new System.Drawing.Point(33, 299);
            this.ShowResults.Name = "ShowResults";
            this.ShowResults.Size = new System.Drawing.Size(143, 31);
            this.ShowResults.TabIndex = 0;
            this.ShowResults.Text = "ПОКАЗАТЬ РЕШЕНИЕ";
            this.ShowResults.UseVisualStyleBackColor = true;
            this.ShowResults.Visible = false;
            this.ShowResults.Click += new System.EventHandler(this.ShowResults_Click);
            // 
            // valueEdge
            // 
            this.valueEdge.BackColor = System.Drawing.Color.DarkGray;
            this.valueEdge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.valueEdge.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.valueEdge.ForeColor = System.Drawing.SystemColors.WindowText;
            this.valueEdge.Location = new System.Drawing.Point(167, 23);
            this.valueEdge.Multiline = true;
            this.valueEdge.Name = "valueEdge";
            this.valueEdge.Size = new System.Drawing.Size(60, 25);
            this.valueEdge.TabIndex = 2;
            this.valueEdge.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // btn_FindMinCut
            // 
            this.btn_FindMinCut.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_FindMinCut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_FindMinCut.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_FindMinCut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_FindMinCut.Image = ((System.Drawing.Image)(resources.GetObject("btn_FindMinCut.Image")));
            this.btn_FindMinCut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_FindMinCut.Location = new System.Drawing.Point(33, 256);
            this.btn_FindMinCut.Name = "btn_FindMinCut";
            this.btn_FindMinCut.Size = new System.Drawing.Size(192, 40);
            this.btn_FindMinCut.TabIndex = 4;
            this.btn_FindMinCut.Text = "НАЙТИ МИНИМАЛЬНЫЙ РАЗРЕЗ";
            this.btn_FindMinCut.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_FindMinCut.UseVisualStyleBackColor = true;
            this.btn_FindMinCut.Click += new System.EventHandler(this.FindMinCut_Click);
            // 
            // indexTo
            // 
            this.indexTo.BackColor = System.Drawing.Color.DarkGray;
            this.indexTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.indexTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.indexTo.ForeColor = System.Drawing.SystemColors.WindowText;
            this.indexTo.Location = new System.Drawing.Point(100, 23);
            this.indexTo.Multiline = true;
            this.indexTo.Name = "indexTo";
            this.indexTo.Size = new System.Drawing.Size(60, 25);
            this.indexTo.TabIndex = 2;
            this.indexTo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // indexFrom
            // 
            this.indexFrom.BackColor = System.Drawing.Color.DarkGray;
            this.indexFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.indexFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.indexFrom.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.indexFrom.Location = new System.Drawing.Point(33, 23);
            this.indexFrom.Multiline = true;
            this.indexFrom.Name = "indexFrom";
            this.indexFrom.Size = new System.Drawing.Size(60, 25);
            this.indexFrom.TabIndex = 1;
            this.indexFrom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // DeleteButton
            // 
            this.DeleteButton.BackColor = System.Drawing.Color.DarkGray;
            this.DeleteButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.DeleteButton.FlatAppearance.BorderSize = 0;
            this.DeleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteButton.ForeColor = System.Drawing.Color.Black;
            this.DeleteButton.Image = ((System.Drawing.Image)(resources.GetObject("DeleteButton.Image")));
            this.DeleteButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DeleteButton.Location = new System.Drawing.Point(34, 173);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(192, 31);
            this.DeleteButton.TabIndex = 9;
            this.DeleteButton.Text = "               УДАЛИТЬ ВЕРШИНУ";
            this.DeleteButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DeleteButton.UseVisualStyleBackColor = false;
            this.DeleteButton.Click += new System.EventHandler(this.button_DeleteNode);
            // 
            // textBox_forDelete
            // 
            this.textBox_forDelete.BackColor = System.Drawing.Color.DarkGray;
            this.textBox_forDelete.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_forDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_forDelete.ForeColor = System.Drawing.Color.Black;
            this.textBox_forDelete.Location = new System.Drawing.Point(33, 142);
            this.textBox_forDelete.Multiline = true;
            this.textBox_forDelete.Name = "textBox_forDelete";
            this.textBox_forDelete.Size = new System.Drawing.Size(194, 24);
            this.textBox_forDelete.TabIndex = 12;
            this.textBox_forDelete.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // CreateEdge
            // 
            this.CreateEdge.BackColor = System.Drawing.Color.DarkGray;
            this.CreateEdge.FlatAppearance.BorderSize = 0;
            this.CreateEdge.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreateEdge.ForeColor = System.Drawing.Color.Black;
            this.CreateEdge.Image = ((System.Drawing.Image)(resources.GetObject("CreateEdge.Image")));
            this.CreateEdge.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CreateEdge.Location = new System.Drawing.Point(34, 54);
            this.CreateEdge.Name = "CreateEdge";
            this.CreateEdge.Size = new System.Drawing.Size(192, 29);
            this.CreateEdge.TabIndex = 0;
            this.CreateEdge.Text = "                СОЗДАТЬ РЕБРО";
            this.CreateEdge.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CreateEdge.UseVisualStyleBackColor = false;
            this.CreateEdge.Click += new System.EventHandler(this.button_CreateEdge);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "ОТКУДА";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(111, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "КУДА";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(182, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "ВЕС";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(95)))), ((int)(((byte)(100)))));
            this.panel1.Controls.Add(this.DeleteEdge);
            this.panel1.Controls.Add(this.SaveGraph);
            this.panel1.Controls.Add(this.ErrorText);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.ShowResults);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.CreateEdge);
            this.panel1.Controls.Add(this.textBox_forDelete);
            this.panel1.Controls.Add(this.DeleteButton);
            this.panel1.Controls.Add(this.indexFrom);
            this.panel1.Controls.Add(this.indexTo);
            this.panel1.Controls.Add(this.btn_FindMinCut);
            this.panel1.Controls.Add(this.valueEdge);
            this.panel1.Controls.Add(this.DoneImg);
            this.panel1.Location = new System.Drawing.Point(540, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(262, 338);
            this.panel1.TabIndex = 13;
            // 
            // DeleteEdge
            // 
            this.DeleteEdge.BackColor = System.Drawing.Color.DarkGray;
            this.DeleteEdge.FlatAppearance.BorderSize = 0;
            this.DeleteEdge.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteEdge.Image = ((System.Drawing.Image)(resources.GetObject("DeleteEdge.Image")));
            this.DeleteEdge.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DeleteEdge.Location = new System.Drawing.Point(34, 89);
            this.DeleteEdge.Name = "DeleteEdge";
            this.DeleteEdge.Size = new System.Drawing.Size(192, 33);
            this.DeleteEdge.TabIndex = 20;
            this.DeleteEdge.Text = "   УДАЛИТЬ РЕБРО";
            this.DeleteEdge.UseVisualStyleBackColor = false;
            this.DeleteEdge.Click += new System.EventHandler(this.DeleteEdge_Click);
            // 
            // SaveGraph
            // 
            this.SaveGraph.FlatAppearance.BorderSize = 0;
            this.SaveGraph.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveGraph.Image = ((System.Drawing.Image)(resources.GetObject("SaveGraph.Image")));
            this.SaveGraph.Location = new System.Drawing.Point(182, 299);
            this.SaveGraph.Name = "SaveGraph";
            this.SaveGraph.Size = new System.Drawing.Size(45, 31);
            this.SaveGraph.TabIndex = 14;
            this.SaveGraph.UseVisualStyleBackColor = true;
            this.SaveGraph.Click += new System.EventHandler(this.SaveGraph_Click);
            // 
            // DoneImg
            // 
            this.DoneImg.Image = ((System.Drawing.Image)(resources.GetObject("DoneImg.Image")));
            this.DoneImg.Location = new System.Drawing.Point(50, 37);
            this.DoneImg.Name = "DoneImg";
            this.DoneImg.Size = new System.Drawing.Size(160, 160);
            this.DoneImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.DoneImg.TabIndex = 16;
            this.DoneImg.TabStop = false;
            this.DoneImg.Visible = false;
            // 
            // panelChildForm
            // 
            this.panelChildForm.AutoScroll = true;
            this.panelChildForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChildForm.ForeColor = System.Drawing.Color.Black;
            this.panelChildForm.Location = new System.Drawing.Point(0, 0);
            this.panelChildForm.Name = "panelChildForm";
            this.panelChildForm.Size = new System.Drawing.Size(802, 498);
            this.panelChildForm.TabIndex = 9;
            this.panelChildForm.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Menu;
            this.label4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(0, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(300, 14);
            this.label4.TabIndex = 0;
            this.label4.Text = "ЛКМ - Добавить вершину; ПКМ - Переместить вершину";
            // 
            // VisualGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 498);
            this.Controls.Add(this.label4);
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
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DoneImg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label ErrorText;
        private System.Windows.Forms.Button ShowResults;
        private System.Windows.Forms.TextBox valueEdge;
        private System.Windows.Forms.Button btn_FindMinCut;
        private System.Windows.Forms.TextBox indexTo;
        private System.Windows.Forms.TextBox indexFrom;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.TextBox textBox_forDelete;
        private System.Windows.Forms.Button CreateEdge;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox DoneImg;
        private System.Windows.Forms.Button SaveGraph;
        private System.Windows.Forms.Panel panelChildForm;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button DeleteEdge;
    }
}