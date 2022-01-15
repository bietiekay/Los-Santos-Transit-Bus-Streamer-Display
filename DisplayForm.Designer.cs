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
            this.versionlabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_previousstop = new System.Windows.Forms.Button();
            this.button_nextstop = new System.Windows.Forms.Button();
            this.button_reset = new System.Windows.Forms.Button();
            this.button_switchline = new System.Windows.Forms.Button();
            this.button_switchmode = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pbtHide = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label18 = new System.Windows.Forms.Label();
            this.nudLedSize = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.cbxDisplayLedStyle = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pbtDisplayLedOff = new System.Windows.Forms.Button();
            this.pbtDisplayLedOn = new System.Windows.Forms.Button();
            this.ledMatrixControl = new LedMatrixControlNamespace.LedMatrixControl();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLedSize)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.versionlabel);
            this.panel1.Controls.Add(this.groupBox1);
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
            // versionlabel
            // 
            this.versionlabel.AutoSize = true;
            this.versionlabel.Location = new System.Drawing.Point(1201, 121);
            this.versionlabel.Name = "versionlabel";
            this.versionlabel.Size = new System.Drawing.Size(45, 15);
            this.versionlabel.TabIndex = 8;
            this.versionlabel.Text = "version";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_previousstop);
            this.groupBox1.Controls.Add(this.button_nextstop);
            this.groupBox1.Controls.Add(this.button_reset);
            this.groupBox1.Controls.Add(this.button_switchline);
            this.groupBox1.Controls.Add(this.button_switchmode);
            this.groupBox1.Location = new System.Drawing.Point(507, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(310, 150);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Buttons";
            // 
            // button_previousstop
            // 
            this.button_previousstop.Location = new System.Drawing.Point(6, 85);
            this.button_previousstop.Name = "button_previousstop";
            this.button_previousstop.Size = new System.Drawing.Size(141, 23);
            this.button_previousstop.TabIndex = 4;
            this.button_previousstop.Text = "vorheriger Halt";
            this.button_previousstop.UseVisualStyleBackColor = true;
            this.button_previousstop.Click += new System.EventHandler(this.button_previousstop_Click);
            // 
            // button_nextstop
            // 
            this.button_nextstop.Location = new System.Drawing.Point(153, 85);
            this.button_nextstop.Name = "button_nextstop";
            this.button_nextstop.Size = new System.Drawing.Size(141, 23);
            this.button_nextstop.TabIndex = 3;
            this.button_nextstop.Text = "nächster Halt";
            this.button_nextstop.UseVisualStyleBackColor = true;
            this.button_nextstop.Click += new System.EventHandler(this.button_nextstop_Click);
            // 
            // button_reset
            // 
            this.button_reset.Location = new System.Drawing.Point(6, 121);
            this.button_reset.Name = "button_reset";
            this.button_reset.Size = new System.Drawing.Size(92, 23);
            this.button_reset.TabIndex = 2;
            this.button_reset.Text = "Reset";
            this.button_reset.UseVisualStyleBackColor = true;
            this.button_reset.Click += new System.EventHandler(this.button_reset_Click);
            // 
            // button_switchline
            // 
            this.button_switchline.Location = new System.Drawing.Point(6, 56);
            this.button_switchline.Name = "button_switchline";
            this.button_switchline.Size = new System.Drawing.Size(141, 23);
            this.button_switchline.TabIndex = 1;
            this.button_switchline.Text = "Linie wechseln";
            this.button_switchline.UseVisualStyleBackColor = true;
            this.button_switchline.Click += new System.EventHandler(this.button_switchline_Click);
            // 
            // button_switchmode
            // 
            this.button_switchmode.Location = new System.Drawing.Point(6, 25);
            this.button_switchmode.Name = "button_switchmode";
            this.button_switchmode.Size = new System.Drawing.Size(141, 23);
            this.button_switchmode.TabIndex = 0;
            this.button_switchmode.Text = "Modus wechseln";
            this.button_switchmode.UseVisualStyleBackColor = true;
            this.button_switchmode.Click += new System.EventHandler(this.button_switchmode_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(963, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(292, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "(C) Daniel Kirstenpfad / bietiekay / schrankmonster.de";
            // 
            // pbtHide
            // 
            this.pbtHide.Location = new System.Drawing.Point(4, 7);
            this.pbtHide.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pbtHide.Name = "pbtHide";
            this.pbtHide.Size = new System.Drawing.Size(88, 27);
            this.pbtHide.TabIndex = 5;
            this.pbtHide.Text = "Einklappen";
            this.pbtHide.UseVisualStyleBackColor = true;
            this.pbtHide.Click += new System.EventHandler(this.bptHide_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.nudLedSize);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.cbxDisplayLedStyle);
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
            this.groupBox2.Text = "LED Einstellungen";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(21, 56);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(65, 15);
            this.label18.TabIndex = 15;
            this.label18.Text = "LED Größe:";
            // 
            // nudLedSize
            // 
            this.nudLedSize.DecimalPlaces = 2;
            this.nudLedSize.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudLedSize.Location = new System.Drawing.Point(94, 52);
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
            this.label12.Location = new System.Drawing.Point(222, 56);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(51, 15);
            this.label12.TabIndex = 13;
            this.label12.Text = "LED Typ:";
            // 
            // cbxDisplayLedStyle
            // 
            this.cbxDisplayLedStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDisplayLedStyle.FormattingEnabled = true;
            this.cbxDisplayLedStyle.Items.AddRange(new object[] {
            "Kreis",
            "Quadrat"});
            this.cbxDisplayLedStyle.Location = new System.Drawing.Point(281, 52);
            this.cbxDisplayLedStyle.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cbxDisplayLedStyle.Name = "cbxDisplayLedStyle";
            this.cbxDisplayLedStyle.Size = new System.Drawing.Size(88, 23);
            this.cbxDisplayLedStyle.TabIndex = 12;
            this.cbxDisplayLedStyle.SelectedIndexChanged += new System.EventHandler(this.cbxDisplayLedStyle_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(190, 25);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "Farbe LED aus:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 25);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Farbe LED an:";
            // 
            // pbtDisplayLedOff
            // 
            this.pbtDisplayLedOff.Location = new System.Drawing.Point(281, 19);
            this.pbtDisplayLedOff.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pbtDisplayLedOff.Name = "pbtDisplayLedOff";
            this.pbtDisplayLedOff.Size = new System.Drawing.Size(88, 27);
            this.pbtDisplayLedOff.TabIndex = 2;
            this.pbtDisplayLedOff.UseVisualStyleBackColor = true;
            this.pbtDisplayLedOff.Click += new System.EventHandler(this.pbtDisplayLedOff_Click);
            // 
            // pbtDisplayLedOn
            // 
            this.pbtDisplayLedOn.Location = new System.Drawing.Point(94, 19);
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
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLedSize)).EndInit();
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
        private Label label6;
        private Label label5;
        private Button pbtDisplayLedOff;
        private Button pbtDisplayLedOn;
        private Label label1;
        private GroupBox groupBox1;
        private Button button_previousstop;
        private Button button_nextstop;
        private Button button_reset;
        private Button button_switchline;
        private Button button_switchmode;
        private Label versionlabel;
    }
}

