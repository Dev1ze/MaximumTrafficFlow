namespace MaximumTrafficFlow
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.panelSideMenu = new System.Windows.Forms.Panel();
            this.btn_DockerHub = new System.Windows.Forms.Button();
            this.btn_Saves = new System.Windows.Forms.Button();
            this.btn_CreateGraph = new System.Windows.Forms.Button();
            this.btn_Home = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelChildForm = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Title = new System.Windows.Forms.Label();
            this.panelSideMenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSideMenu
            // 
            this.panelSideMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.panelSideMenu.Controls.Add(this.btn_DockerHub);
            this.panelSideMenu.Controls.Add(this.btn_Saves);
            this.panelSideMenu.Controls.Add(this.btn_CreateGraph);
            this.panelSideMenu.Controls.Add(this.btn_Home);
            this.panelSideMenu.Controls.Add(this.panelLogo);
            this.panelSideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSideMenu.Location = new System.Drawing.Point(0, 0);
            this.panelSideMenu.Name = "panelSideMenu";
            this.panelSideMenu.Size = new System.Drawing.Size(200, 586);
            this.panelSideMenu.TabIndex = 0;
            // 
            // btn_DockerHub
            // 
            this.btn_DockerHub.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_DockerHub.FlatAppearance.BorderSize = 0;
            this.btn_DockerHub.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_DockerHub.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_DockerHub.ForeColor = System.Drawing.Color.White;
            this.btn_DockerHub.Image = ((System.Drawing.Image)(resources.GetObject("btn_DockerHub.Image")));
            this.btn_DockerHub.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_DockerHub.Location = new System.Drawing.Point(0, 258);
            this.btn_DockerHub.Name = "btn_DockerHub";
            this.btn_DockerHub.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btn_DockerHub.Size = new System.Drawing.Size(200, 45);
            this.btn_DockerHub.TabIndex = 4;
            this.btn_DockerHub.Text = "              LINUX - Версия";
            this.btn_DockerHub.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_DockerHub.UseVisualStyleBackColor = true;
            this.btn_DockerHub.Click += new System.EventHandler(this.btn_DockerHub_Click);
            // 
            // btn_Saves
            // 
            this.btn_Saves.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_Saves.FlatAppearance.BorderSize = 0;
            this.btn_Saves.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Saves.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_Saves.ForeColor = System.Drawing.Color.White;
            this.btn_Saves.Image = ((System.Drawing.Image)(resources.GetObject("btn_Saves.Image")));
            this.btn_Saves.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Saves.Location = new System.Drawing.Point(0, 213);
            this.btn_Saves.Name = "btn_Saves";
            this.btn_Saves.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btn_Saves.Size = new System.Drawing.Size(200, 45);
            this.btn_Saves.TabIndex = 3;
            this.btn_Saves.Text = "              СОХРАНЕНИЯ";
            this.btn_Saves.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Saves.UseVisualStyleBackColor = true;
            this.btn_Saves.Click += new System.EventHandler(this.Saves_Click);
            // 
            // btn_CreateGraph
            // 
            this.btn_CreateGraph.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_CreateGraph.FlatAppearance.BorderSize = 0;
            this.btn_CreateGraph.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_CreateGraph.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_CreateGraph.ForeColor = System.Drawing.Color.White;
            this.btn_CreateGraph.Image = ((System.Drawing.Image)(resources.GetObject("btn_CreateGraph.Image")));
            this.btn_CreateGraph.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_CreateGraph.Location = new System.Drawing.Point(0, 168);
            this.btn_CreateGraph.Name = "btn_CreateGraph";
            this.btn_CreateGraph.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btn_CreateGraph.Size = new System.Drawing.Size(200, 45);
            this.btn_CreateGraph.TabIndex = 2;
            this.btn_CreateGraph.Text = "              СОЗДАТЬ ГРАФ";
            this.btn_CreateGraph.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_CreateGraph.UseVisualStyleBackColor = true;
            this.btn_CreateGraph.Click += new System.EventHandler(this.CreateGraph_Click);
            // 
            // btn_Home
            // 
            this.btn_Home.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_Home.FlatAppearance.BorderSize = 0;
            this.btn_Home.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Home.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_Home.ForeColor = System.Drawing.Color.White;
            this.btn_Home.Image = ((System.Drawing.Image)(resources.GetObject("btn_Home.Image")));
            this.btn_Home.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Home.Location = new System.Drawing.Point(0, 123);
            this.btn_Home.Name = "btn_Home";
            this.btn_Home.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btn_Home.Size = new System.Drawing.Size(200, 45);
            this.btn_Home.TabIndex = 1;
            this.btn_Home.Text = "              ГЛАВНАЯ";
            this.btn_Home.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Home.UseVisualStyleBackColor = true;
            this.btn_Home.Click += new System.EventHandler(this.btn_Home_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.panelLogo.Controls.Add(this.pictureBox1);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(200, 123);
            this.panelLogo.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 78);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // panelChildForm
            // 
            this.panelChildForm.AllowDrop = true;
            this.panelChildForm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelChildForm.Location = new System.Drawing.Point(200, 68);
            this.panelChildForm.Name = "panelChildForm";
            this.panelChildForm.Size = new System.Drawing.Size(808, 518);
            this.panelChildForm.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(60)))), ((int)(((byte)(65)))));
            this.panel1.Controls.Add(this.Title);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(200, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(808, 70);
            this.panel1.TabIndex = 2;
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Title.ForeColor = System.Drawing.SystemColors.Control;
            this.Title.Location = new System.Drawing.Point(6, 19);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(0, 29);
            this.Title.TabIndex = 0;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 586);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelChildForm);
            this.Controls.Add(this.panelSideMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "Graph Minimum Cut Finder";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panelSideMenu.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSideMenu;
        private System.Windows.Forms.Button btn_Home;
        private System.Windows.Forms.Button btn_CreateGraph;
        private System.Windows.Forms.Button btn_Saves;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panelChildForm;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Button btn_DockerHub;
    }
}