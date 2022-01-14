namespace LSTBusline
{
    partial class DisplayForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DisplayForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pbtHide = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label18 = new System.Windows.Forms.Label();
            this.nudLedSize = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.cbxDisplayLedStyle = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.nudDisplayNbRow = new System.Windows.Forms.NumericUpDown();
            this.nudDisplayNbLine = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pbtDisplayLedOff = new System.Windows.Forms.Button();
            this.pbtDisplayLedOn = new System.Windows.Forms.Button();
            this.ledMatrixControl = new LedMatrixControlNamespace.LedMatrixControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLedSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDisplayNbRow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDisplayNbLine)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pbtHide);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 336);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel1.MinimumSize = new System.Drawing.Size(1206, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1258, 170);
            this.panel1.TabIndex = 5;
            // 
            // pbtHide
            // 
            this.pbtHide.Location = new System.Drawing.Point(4, 7);
            this.pbtHide.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pbtHide.Name = "pbtHide";
            this.pbtHide.Size = new System.Drawing.Size(88, 27);
            this.pbtHide.TabIndex = 5;
            this.pbtHide.Text = "button1";
            this.pbtHide.UseVisualStyleBackColor = true;
            this.pbtHide.Click += new System.EventHandler(this.bptHide_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.nudLedSize);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.cbxDisplayLedStyle);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.nudDisplayNbRow);
            this.groupBox2.Controls.Add(this.nudDisplayNbLine);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.pbtDisplayLedOff);
            this.groupBox2.Controls.Add(this.pbtDisplayLedOn);
            this.groupBox2.Location = new System.Drawing.Point(98, 13);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox2.Size = new System.Drawing.Size(402, 150);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Display";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(202, 115);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(84, 15);
            this.label18.TabIndex = 15;
            this.label18.Text = "Led size coeff :";
            // 
            // nudLedSize
            // 
            this.nudLedSize.DecimalPlaces = 2;
            this.nudLedSize.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudLedSize.Location = new System.Drawing.Point(301, 112);
            this.nudLedSize.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.nudLedSize.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudLedSize.Name = "nudLedSize";
            this.nudLedSize.Size = new System.Drawing.Size(88, 23);
            this.nudLedSize.TabIndex = 14;
            this.nudLedSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudLedSize.ValueChanged += new System.EventHandler(this.nudLedSize_ValueChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(28, 114);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 15);
            this.label12.TabIndex = 13;
            this.label12.Text = "Led style :";
            // 
            // cbxDisplayLedStyle
            // 
            this.cbxDisplayLedStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDisplayLedStyle.FormattingEnabled = true;
            this.cbxDisplayLedStyle.Items.AddRange(new object[] {
            "Circle",
            "Square"});
            this.cbxDisplayLedStyle.Location = new System.Drawing.Point(103, 112);
            this.cbxDisplayLedStyle.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cbxDisplayLedStyle.Name = "cbxDisplayLedStyle";
            this.cbxDisplayLedStyle.Size = new System.Drawing.Size(83, 23);
            this.cbxDisplayLedStyle.TabIndex = 12;
            this.cbxDisplayLedStyle.SelectedIndexChanged += new System.EventHandler(this.cbxDisplayLedStyle_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(233, 84);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 15);
            this.label11.TabIndex = 11;
            this.label11.Text = "Nb rows :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(33, 84);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 15);
            this.label10.TabIndex = 10;
            this.label10.Text = "Nb lines :";
            // 
            // nudDisplayNbRow
            // 
            this.nudDisplayNbRow.Location = new System.Drawing.Point(301, 82);
            this.nudDisplayNbRow.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.nudDisplayNbRow.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudDisplayNbRow.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudDisplayNbRow.Name = "nudDisplayNbRow";
            this.nudDisplayNbRow.Size = new System.Drawing.Size(88, 23);
            this.nudDisplayNbRow.TabIndex = 9;
            this.nudDisplayNbRow.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudDisplayNbRow.ValueChanged += new System.EventHandler(this.nudDisplayNbRow_ValueChanged);
            // 
            // nudDisplayNbLine
            // 
            this.nudDisplayNbLine.Location = new System.Drawing.Point(103, 82);
            this.nudDisplayNbLine.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.nudDisplayNbLine.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudDisplayNbLine.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudDisplayNbLine.Name = "nudDisplayNbLine";
            this.nudDisplayNbLine.Size = new System.Drawing.Size(84, 23);
            this.nudDisplayNbLine.TabIndex = 8;
            this.nudDisplayNbLine.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudDisplayNbLine.ValueChanged += new System.EventHandler(this.nudDisplayNbLine_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(208, 54);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "Led Off color :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 54);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Led On color :";
            // 
            // pbtDisplayLedOff
            // 
            this.pbtDisplayLedOff.Location = new System.Drawing.Point(301, 48);
            this.pbtDisplayLedOff.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pbtDisplayLedOff.Name = "pbtDisplayLedOff";
            this.pbtDisplayLedOff.Size = new System.Drawing.Size(88, 27);
            this.pbtDisplayLedOff.TabIndex = 2;
            this.pbtDisplayLedOff.UseVisualStyleBackColor = true;
            this.pbtDisplayLedOff.Click += new System.EventHandler(this.pbtDisplayLedOff_Click);
            // 
            // pbtDisplayLedOn
            // 
            this.pbtDisplayLedOn.Location = new System.Drawing.Point(99, 48);
            this.pbtDisplayLedOn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pbtDisplayLedOn.Name = "pbtDisplayLedOn";
            this.pbtDisplayLedOn.Size = new System.Drawing.Size(88, 27);
            this.pbtDisplayLedOn.TabIndex = 1;
            this.pbtDisplayLedOn.UseVisualStyleBackColor = true;
            this.pbtDisplayLedOn.Click += new System.EventHandler(this.pbtDisplayLedOn_Click);
            // 
            // ledMatrixControl
            // 
            this.ledMatrixControl.BackColor = System.Drawing.Color.Black;
            this.ledMatrixControl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ledMatrixControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ledMatrixControl.LedOffColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ledMatrixControl.LedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.ledMatrixControl.Location = new System.Drawing.Point(0, 0);
            this.ledMatrixControl.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ledMatrixControl.Name = "ledMatrixControl";
            this.ledMatrixControl.NbLedLines = 16;
            this.ledMatrixControl.NbLedRows = 166;
            this.ledMatrixControl.Size = new System.Drawing.Size(1258, 336);
            this.ledMatrixControl.SizeCoeff = 0.67D;
            this.ledMatrixControl.TabIndex = 2;
            this.ledMatrixControl.Text = "ledMatrixControl";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1012, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "(C) Daniel Kirstenpfad / schrankmonster.de";
            // 
            // DisplayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1258, 506);
            this.Controls.Add(this.ledMatrixControl);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MinimumSize = new System.Drawing.Size(553, 39);
            this.Name = "DisplayForm";
            this.Text = "Los Santos Transit BUS Linienanzeiger";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLedSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDisplayNbRow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDisplayNbLine)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
      private LedMatrixControlNamespace.LedMatrixControl ledMatrixControl;
      private System.Windows.Forms.Panel panel1;
      private System.Windows.Forms.Button pbtHide;
        private GroupBox groupBox2;
        private Label label18;
        private NumericUpDown nudLedSize;
        private Label label12;
        private ComboBox cbxDisplayLedStyle;
        private Label label11;
        private Label label10;
        private NumericUpDown nudDisplayNbRow;
        private NumericUpDown nudDisplayNbLine;
        private Label label6;
        private Label label5;
        private Button pbtDisplayLedOff;
        private Button pbtDisplayLedOn;
        private Label label1;
    }
}

