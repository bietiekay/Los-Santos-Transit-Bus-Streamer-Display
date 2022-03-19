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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DisplayForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.ResetConfiguration = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.timeToNextStop = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.UpdateStatusTextbox = new System.Windows.Forms.TextBox();
            this.versionlabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Lizenzen = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.HotkeysActive = new System.Windows.Forms.CheckBox();
            this.button_previousstop = new System.Windows.Forms.Button();
            this.button_nextstop = new System.Windows.Forms.Button();
            this.button_switchline = new System.Windows.Forms.Button();
            this.button_switchmode = new System.Windows.Forms.Button();
            this.pbtHide = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pbtLEDBackgroundButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.invertLogoCheckbox = new System.Windows.Forms.CheckBox();
            this.autoSwitchAfterFirst = new System.Windows.Forms.CheckBox();
            this.currentTimeStopOnLineChange = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LinienAbbruchZeitUpDownControl = new System.Windows.Forms.NumericUpDown();
            this.label18 = new System.Windows.Forms.Label();
            this.nudLedSize = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.cbxDisplayLedStyle = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pbtDisplayLedOff = new System.Windows.Forms.Button();
            this.pbtDisplayLedOn = new System.Windows.Forms.Button();
            this.ledMatrixControl = new LedMatrixControlNamespace.LedMatrixControl();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LinienAbbruchZeitUpDownControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLedSize)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ResetConfiguration);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox1);
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
            // ResetConfiguration
            // 
            this.ResetConfiguration.Location = new System.Drawing.Point(4, 116);
            this.ResetConfiguration.Name = "ResetConfiguration";
            this.ResetConfiguration.Size = new System.Drawing.Size(88, 47);
            this.ResetConfiguration.TabIndex = 12;
            this.ResetConfiguration.Text = "Konfiguration resetten";
            this.ResetConfiguration.UseVisualStyleBackColor = true;
            this.ResetConfiguration.Click += new System.EventHandler(this.ResetConfiguration_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.timeToNextStop);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.UpdateStatusTextbox);
            this.groupBox3.Controls.Add(this.versionlabel);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.Lizenzen);
            this.groupBox3.Location = new System.Drawing.Point(823, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(432, 150);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Informationen";
            // 
            // timeToNextStop
            // 
            this.timeToNextStop.AutoSize = true;
            this.timeToNextStop.Location = new System.Drawing.Point(144, 23);
            this.timeToNextStop.Name = "timeToNextStop";
            this.timeToNextStop.Size = new System.Drawing.Size(24, 15);
            this.timeToNextStop.TabIndex = 13;
            this.timeToNextStop.Text = "00s";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "Zeit bis nächste Abfahrt";
            // 
            // UpdateStatusTextbox
            // 
            this.UpdateStatusTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.UpdateStatusTextbox.Location = new System.Drawing.Point(6, 121);
            this.UpdateStatusTextbox.Name = "UpdateStatusTextbox";
            this.UpdateStatusTextbox.Size = new System.Drawing.Size(420, 23);
            this.UpdateStatusTextbox.TabIndex = 10;
            // 
            // versionlabel
            // 
            this.versionlabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.versionlabel.AutoSize = true;
            this.versionlabel.Location = new System.Drawing.Point(300, 81);
            this.versionlabel.Name = "versionlabel";
            this.versionlabel.Size = new System.Drawing.Size(45, 15);
            this.versionlabel.TabIndex = 8;
            this.versionlabel.Text = "version";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(134, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(292, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "(C) Daniel Kirstenpfad / bietiekay / schrankmonster.de";
            // 
            // Lizenzen
            // 
            this.Lizenzen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Lizenzen.Location = new System.Drawing.Point(351, 77);
            this.Lizenzen.Name = "Lizenzen";
            this.Lizenzen.Size = new System.Drawing.Size(75, 23);
            this.Lizenzen.TabIndex = 9;
            this.Lizenzen.Text = "Lizenzen";
            this.Lizenzen.UseVisualStyleBackColor = true;
            this.Lizenzen.Click += new System.EventHandler(this.Lizenzen_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.HotkeysActive);
            this.groupBox1.Controls.Add(this.button_previousstop);
            this.groupBox1.Controls.Add(this.button_nextstop);
            this.groupBox1.Controls.Add(this.button_switchline);
            this.groupBox1.Controls.Add(this.button_switchmode);
            this.groupBox1.Location = new System.Drawing.Point(656, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(161, 150);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Steuerung";
            // 
            // HotkeysActive
            // 
            this.HotkeysActive.AutoSize = true;
            this.HotkeysActive.Location = new System.Drawing.Point(6, 124);
            this.HotkeysActive.Name = "HotkeysActive";
            this.HotkeysActive.Size = new System.Drawing.Size(97, 19);
            this.HotkeysActive.TabIndex = 5;
            this.HotkeysActive.Text = "Hotkeys aktiv";
            this.HotkeysActive.UseVisualStyleBackColor = true;
            this.HotkeysActive.CheckedChanged += new System.EventHandler(this.HotkeysActive_CheckedChanged);
            // 
            // button_previousstop
            // 
            this.button_previousstop.Location = new System.Drawing.Point(6, 73);
            this.button_previousstop.Name = "button_previousstop";
            this.button_previousstop.Size = new System.Drawing.Size(141, 23);
            this.button_previousstop.TabIndex = 4;
            this.button_previousstop.Text = "vorheriger Halt";
            this.button_previousstop.UseVisualStyleBackColor = true;
            this.button_previousstop.Click += new System.EventHandler(this.button_previousstop_Click);
            // 
            // button_nextstop
            // 
            this.button_nextstop.Location = new System.Drawing.Point(6, 95);
            this.button_nextstop.Name = "button_nextstop";
            this.button_nextstop.Size = new System.Drawing.Size(141, 23);
            this.button_nextstop.TabIndex = 3;
            this.button_nextstop.Text = "nächster Halt";
            this.button_nextstop.UseVisualStyleBackColor = true;
            this.button_nextstop.Click += new System.EventHandler(this.button_nextstop_Click);
            // 
            // button_switchline
            // 
            this.button_switchline.Location = new System.Drawing.Point(6, 48);
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
            this.groupBox2.Controls.Add(this.pbtLEDBackgroundButton);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.invertLogoCheckbox);
            this.groupBox2.Controls.Add(this.autoSwitchAfterFirst);
            this.groupBox2.Controls.Add(this.currentTimeStopOnLineChange);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.LinienAbbruchZeitUpDownControl);
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
            this.groupBox2.Size = new System.Drawing.Size(551, 150);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "LED und Linien Einstellungen";
            // 
            // pbtLEDBackgroundButton
            // 
            this.pbtLEDBackgroundButton.Location = new System.Drawing.Point(273, 19);
            this.pbtLEDBackgroundButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pbtLEDBackgroundButton.Name = "pbtLEDBackgroundButton";
            this.pbtLEDBackgroundButton.Size = new System.Drawing.Size(88, 27);
            this.pbtLEDBackgroundButton.TabIndex = 23;
            this.pbtLEDBackgroundButton.UseVisualStyleBackColor = true;
            this.pbtLEDBackgroundButton.Click += new System.EventHandler(this.pbtLEDBackgroundButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(190, 25);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 15);
            this.label7.TabIndex = 22;
            this.label7.Text = "Hintergrund:";
            // 
            // invertLogoCheckbox
            // 
            this.invertLogoCheckbox.AutoSize = true;
            this.invertLogoCheckbox.Location = new System.Drawing.Point(376, 25);
            this.invertLogoCheckbox.Name = "invertLogoCheckbox";
            this.invertLogoCheckbox.Size = new System.Drawing.Size(168, 19);
            this.invertLogoCheckbox.TabIndex = 21;
            this.invertLogoCheckbox.Text = "Alternativ Logo verwenden";
            this.toolTip1.SetToolTip(this.invertLogoCheckbox, "verwendet statt Zeichen 162 das Zeichen 163 aus dem Font.");
            this.invertLogoCheckbox.UseVisualStyleBackColor = true;
            this.invertLogoCheckbox.CheckedChanged += new System.EventHandler(this.invertLogoCheckbox_CheckedChanged);
            // 
            // autoSwitchAfterFirst
            // 
            this.autoSwitchAfterFirst.AutoSize = true;
            this.autoSwitchAfterFirst.Location = new System.Drawing.Point(310, 88);
            this.autoSwitchAfterFirst.Name = "autoSwitchAfterFirst";
            this.autoSwitchAfterFirst.Size = new System.Drawing.Size(234, 49);
            this.autoSwitchAfterFirst.TabIndex = 20;
            this.autoSwitchAfterFirst.Text = "automatisch Halt wechseln\r\n(bei Haltestellen mit gleicher Abfahrzeit\r\n wird nur d" +
    "ie letzte angezeigt)";
            this.toolTip1.SetToolTip(this.autoSwitchAfterFirst, resources.GetString("autoSwitchAfterFirst.ToolTip"));
            this.autoSwitchAfterFirst.UseVisualStyleBackColor = true;
            this.autoSwitchAfterFirst.CheckedChanged += new System.EventHandler(this.autoSwitchAfterFirst_CheckedChanged);
            // 
            // currentTimeStopOnLineChange
            // 
            this.currentTimeStopOnLineChange.AutoSize = true;
            this.currentTimeStopOnLineChange.Location = new System.Drawing.Point(189, 95);
            this.currentTimeStopOnLineChange.Name = "currentTimeStopOnLineChange";
            this.currentTimeStopOnLineChange.Size = new System.Drawing.Size(103, 34);
            this.currentTimeStopOnLineChange.TabIndex = 19;
            this.currentTimeStopOnLineChange.Text = "Linienwechsel \r\nAutomatik";
            this.toolTip1.SetToolTip(this.currentTimeStopOnLineChange, "bei Linienwechsel wird die jeweils aktuellste Haltestelle vorausgewählt");
            this.currentTimeStopOnLineChange.UseVisualStyleBackColor = true;
            this.currentTimeStopOnLineChange.CheckedChanged += new System.EventHandler(this.currentTimeStopOnLineChange_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(351, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 15);
            this.label3.TabIndex = 18;
            this.label3.Text = "min";
            // 
            // label2
            // 
            this.label2.AccessibleDescription = "test";
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(192, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 15);
            this.label2.TabIndex = 17;
            this.label2.Text = "Abfahrtzeittoleranz:";
            this.toolTip1.SetToolTip(this.label2, "Das Zeitfenster in dem noch nicht die nächste Abfahrzeit angezeigt wird.");
            // 
            // LinienAbbruchZeitUpDownControl
            // 
            this.LinienAbbruchZeitUpDownControl.Location = new System.Drawing.Point(306, 62);
            this.LinienAbbruchZeitUpDownControl.Name = "LinienAbbruchZeitUpDownControl";
            this.LinienAbbruchZeitUpDownControl.Size = new System.Drawing.Size(39, 23);
            this.LinienAbbruchZeitUpDownControl.TabIndex = 16;
            this.LinienAbbruchZeitUpDownControl.ValueChanged += new System.EventHandler(this.LinienAbbruchZeitUpDownControl_ValueChanged);
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
            this.label12.Location = new System.Drawing.Point(35, 117);
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
            this.cbxDisplayLedStyle.Location = new System.Drawing.Point(94, 114);
            this.cbxDisplayLedStyle.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cbxDisplayLedStyle.Name = "cbxDisplayLedStyle";
            this.cbxDisplayLedStyle.Size = new System.Drawing.Size(88, 23);
            this.cbxDisplayLedStyle.TabIndex = 12;
            this.cbxDisplayLedStyle.SelectedIndexChanged += new System.EventHandler(this.cbxDisplayLedStyle_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 87);
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
            this.pbtDisplayLedOff.Location = new System.Drawing.Point(94, 81);
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
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LinienAbbruchZeitUpDownControl)).EndInit();
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
        private Button button_switchline;
        private Button button_switchmode;
        private Label versionlabel;
        private Button Lizenzen;
        private GroupBox groupBox3;
        private TextBox UpdateStatusTextbox;
        private Label label3;
        private Label label2;
        private NumericUpDown LinienAbbruchZeitUpDownControl;
        private ToolTip toolTip1;
        private CheckBox currentTimeStopOnLineChange;
        private Label label4;
        private CheckBox autoSwitchAfterFirst;
        private Label timeToNextStop;
        private CheckBox invertLogoCheckbox;
        private CheckBox HotkeysActive;
        private Label label7;
        private Button pbtLEDBackgroundButton;
        private Button ResetConfiguration;
    }
}

