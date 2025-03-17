namespace MaximumTrafficFlow
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.BackToGraph = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BackToGraph
            // 
            this.BackToGraph.Location = new System.Drawing.Point(25, 13);
            this.BackToGraph.Name = "BackToGraph";
            this.BackToGraph.Size = new System.Drawing.Size(75, 23);
            this.BackToGraph.TabIndex = 0;
            this.BackToGraph.Text = "Вернутся";
            this.BackToGraph.UseVisualStyleBackColor = true;
            this.BackToGraph.Click += new System.EventHandler(this.BackToGraph_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1456, 616);
            this.Controls.Add(this.BackToGraph);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Поиск минимального разреза";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BackToGraph;
    }
}
