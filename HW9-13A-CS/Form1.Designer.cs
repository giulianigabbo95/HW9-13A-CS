namespace MyHomework
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmbDistributionType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.NbClusters = new System.Windows.Forms.NumericUpDown();
            this.btnClusters = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.NbPath = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.NbPoints = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.btnRecalc = new System.Windows.Forms.Button();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.btnMeans = new System.Windows.Forms.Button();
            this.NbIterations = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NbClusters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NbPath)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NbPoints)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NbIterations)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.NbIterations);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.btnMeans);
            this.panel2.Controls.Add(this.cmbDistributionType);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.NbClusters);
            this.panel2.Controls.Add(this.btnClusters);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.NbPath);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.NbPoints);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.btnRecalc);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1418, 80);
            this.panel2.TabIndex = 41;
            // 
            // cmbDistributionType
            // 
            this.cmbDistributionType.FormattingEnabled = true;
            this.cmbDistributionType.Items.AddRange(new object[] {
            "Normal N(0,1)",
            "Exp N(0,1)",
            "N(0,1) Squared",
            "N(0,1) Squared / N(0,1) Squared"});
            this.cmbDistributionType.Location = new System.Drawing.Point(465, 48);
            this.cmbDistributionType.Name = "cmbDistributionType";
            this.cmbDistributionType.Size = new System.Drawing.Size(159, 21);
            this.cmbDistributionType.TabIndex = 56;
            this.cmbDistributionType.SelectedIndexChanged += new System.EventHandler(this.cmbDistributionType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(462, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 55;
            this.label1.Text = "Realization from:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(1030, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 54;
            this.label6.Text = "No Clusters";
            // 
            // NbClusters
            // 
            this.NbClusters.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NbClusters.Location = new System.Drawing.Point(1097, 14);
            this.NbClusters.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.NbClusters.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.NbClusters.Name = "NbClusters";
            this.NbClusters.Size = new System.Drawing.Size(77, 23);
            this.NbClusters.TabIndex = 53;
            this.NbClusters.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NbClusters.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NbClusters.ValueChanged += new System.EventHandler(this.NbClusters_ValueChanged);
            // 
            // btnClusters
            // 
            this.btnClusters.BackColor = System.Drawing.Color.Transparent;
            this.btnClusters.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnClusters.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClusters.ForeColor = System.Drawing.Color.Black;
            this.btnClusters.Location = new System.Drawing.Point(1180, 14);
            this.btnClusters.Name = "btnClusters";
            this.btnClusters.Size = new System.Drawing.Size(79, 24);
            this.btnClusters.TabIndex = 52;
            this.btnClusters.Text = "Redraw";
            this.btnClusters.UseVisualStyleBackColor = false;
            this.btnClusters.Click += new System.EventHandler(this.btnClusters_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Firebrick;
            this.label5.Location = new System.Drawing.Point(24, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 20);
            this.label5.TabIndex = 51;
            this.label5.Text = "Parameters";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(330, 53);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 49;
            this.label3.Text = "σ (variance) = 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(330, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 48;
            this.label2.Text = "mu (mean) = 0";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(1024, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(381, 13);
            this.label4.TabIndex = 45;
            this.label4.Text = "You can move the chart inside the viewport or resize it using bottom-right corner" +
    "";
            // 
            // NbPath
            // 
            this.NbPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NbPath.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NbPath.Location = new System.Drawing.Point(222, 20);
            this.NbPath.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NbPath.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NbPath.Name = "NbPath";
            this.NbPath.Size = new System.Drawing.Size(76, 23);
            this.NbPath.TabIndex = 44;
            this.NbPath.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NbPath.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.NbPath.ValueChanged += new System.EventHandler(this.NbPath_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(165, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 43;
            this.label8.Text = "m (Paths)";
            // 
            // NbPoints
            // 
            this.NbPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NbPoints.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NbPoints.Location = new System.Drawing.Point(222, 48);
            this.NbPoints.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NbPoints.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.NbPoints.Name = "NbPoints";
            this.NbPoints.Size = new System.Drawing.Size(76, 23);
            this.NbPoints.TabIndex = 42;
            this.NbPoints.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NbPoints.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.NbPoints.ValueChanged += new System.EventHandler(this.NbPoints_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(165, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 13);
            this.label7.TabIndex = 41;
            this.label7.Text = "n (Points)";
            // 
            // btnRecalc
            // 
            this.btnRecalc.BackColor = System.Drawing.Color.Transparent;
            this.btnRecalc.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnRecalc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecalc.ForeColor = System.Drawing.Color.Black;
            this.btnRecalc.Location = new System.Drawing.Point(630, 18);
            this.btnRecalc.Name = "btnRecalc";
            this.btnRecalc.Size = new System.Drawing.Size(79, 53);
            this.btnRecalc.TabIndex = 40;
            this.btnRecalc.Text = "Recalc";
            this.btnRecalc.UseVisualStyleBackColor = false;
            this.btnRecalc.Click += new System.EventHandler(this.btnRecalc_Click);
            // 
            // MainPanel
            // 
            this.MainPanel.BackColor = System.Drawing.Color.Gainsboro;
            this.MainPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 80);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(1418, 518);
            this.MainPanel.TabIndex = 42;
            // 
            // btnMeans
            // 
            this.btnMeans.BackColor = System.Drawing.Color.Transparent;
            this.btnMeans.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnMeans.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMeans.ForeColor = System.Drawing.Color.Black;
            this.btnMeans.Location = new System.Drawing.Point(829, 20);
            this.btnMeans.Name = "btnMeans";
            this.btnMeans.Size = new System.Drawing.Size(76, 49);
            this.btnMeans.TabIndex = 57;
            this.btnMeans.Text = "Means and Variances";
            this.btnMeans.UseVisualStyleBackColor = false;
            this.btnMeans.Click += new System.EventHandler(this.btnMeans_Click);
            // 
            // NbIterations
            // 
            this.NbIterations.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NbIterations.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NbIterations.Location = new System.Drawing.Point(747, 46);
            this.NbIterations.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NbIterations.Name = "NbIterations";
            this.NbIterations.Size = new System.Drawing.Size(76, 23);
            this.NbIterations.TabIndex = 59;
            this.NbIterations.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NbIterations.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(744, 26);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 13);
            this.label9.TabIndex = 58;
            this.label9.Text = "I (Iterations)";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1418, 598);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.panel2);
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Name = "Form1";
            this.Text = "Path Simulation";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NbClusters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NbPath)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NbPoints)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NbIterations)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown NbPath;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown NbPoints;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnRecalc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown NbClusters;
        private System.Windows.Forms.Button btnClusters;
        private System.Windows.Forms.ComboBox cmbDistributionType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown NbIterations;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnMeans;
    }
}

