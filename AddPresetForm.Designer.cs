namespace PlaylistParser
{
    partial class AddPresetForm
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
            this.addBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.hoursGroupBox = new System.Windows.Forms.GroupBox();
            this.Hour21 = new System.Windows.Forms.CheckBox();
            this.Hour22 = new System.Windows.Forms.CheckBox();
            this.Hour23 = new System.Windows.Forms.CheckBox();
            this.Hour20 = new System.Windows.Forms.CheckBox();
            this.Hour19 = new System.Windows.Forms.CheckBox();
            this.Hour18 = new System.Windows.Forms.CheckBox();
            this.Hour17 = new System.Windows.Forms.CheckBox();
            this.Hour16 = new System.Windows.Forms.CheckBox();
            this.Hour15 = new System.Windows.Forms.CheckBox();
            this.Hour14 = new System.Windows.Forms.CheckBox();
            this.Hour13 = new System.Windows.Forms.CheckBox();
            this.Hour12 = new System.Windows.Forms.CheckBox();
            this.Hour11 = new System.Windows.Forms.CheckBox();
            this.Hour10 = new System.Windows.Forms.CheckBox();
            this.Hour09 = new System.Windows.Forms.CheckBox();
            this.Hour08 = new System.Windows.Forms.CheckBox();
            this.Hour07 = new System.Windows.Forms.CheckBox();
            this.Hour06 = new System.Windows.Forms.CheckBox();
            this.Hour05 = new System.Windows.Forms.CheckBox();
            this.Hour04 = new System.Windows.Forms.CheckBox();
            this.Hour03 = new System.Windows.Forms.CheckBox();
            this.Hour02 = new System.Windows.Forms.CheckBox();
            this.Hour01 = new System.Windows.Forms.CheckBox();
            this.Hour00 = new System.Windows.Forms.CheckBox();
            this.fromComboBox = new System.Windows.Forms.ComboBox();
            this.toComboBox = new System.Windows.Forms.ComboBox();
            this.presetNameTextBox = new System.Windows.Forms.TextBox();
            this.PresetNameLable = new System.Windows.Forms.Label();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.DescriptionTextBox = new System.Windows.Forms.TextBox();
            this.hoursGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(49, 382);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(75, 23);
            this.addBtn.TabIndex = 0;
            this.addBtn.Tag = "Add";
            this.addBtn.Text = "Add";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.BtnClick);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(169, 382);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 1;
            this.cancelBtn.Tag = "Cancel";
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.BtnClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 183);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "From";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(167, 184);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "To";
            // 
            // hoursGroupBox
            // 
            this.hoursGroupBox.Controls.Add(this.Hour21);
            this.hoursGroupBox.Controls.Add(this.Hour22);
            this.hoursGroupBox.Controls.Add(this.Hour23);
            this.hoursGroupBox.Controls.Add(this.Hour20);
            this.hoursGroupBox.Controls.Add(this.Hour19);
            this.hoursGroupBox.Controls.Add(this.Hour18);
            this.hoursGroupBox.Controls.Add(this.Hour17);
            this.hoursGroupBox.Controls.Add(this.Hour16);
            this.hoursGroupBox.Controls.Add(this.Hour15);
            this.hoursGroupBox.Controls.Add(this.Hour14);
            this.hoursGroupBox.Controls.Add(this.Hour13);
            this.hoursGroupBox.Controls.Add(this.Hour12);
            this.hoursGroupBox.Controls.Add(this.Hour11);
            this.hoursGroupBox.Controls.Add(this.Hour10);
            this.hoursGroupBox.Controls.Add(this.Hour09);
            this.hoursGroupBox.Controls.Add(this.Hour08);
            this.hoursGroupBox.Controls.Add(this.Hour07);
            this.hoursGroupBox.Controls.Add(this.Hour06);
            this.hoursGroupBox.Controls.Add(this.Hour05);
            this.hoursGroupBox.Controls.Add(this.Hour04);
            this.hoursGroupBox.Controls.Add(this.Hour03);
            this.hoursGroupBox.Controls.Add(this.Hour02);
            this.hoursGroupBox.Controls.Add(this.Hour01);
            this.hoursGroupBox.Controls.Add(this.Hour00);
            this.hoursGroupBox.Location = new System.Drawing.Point(12, 215);
            this.hoursGroupBox.Name = "hoursGroupBox";
            this.hoursGroupBox.Size = new System.Drawing.Size(260, 161);
            this.hoursGroupBox.TabIndex = 31;
            this.hoursGroupBox.TabStop = false;
            this.hoursGroupBox.Text = "Hours";
            // 
            // Hour21
            // 
            this.Hour21.AutoSize = true;
            this.Hour21.Location = new System.Drawing.Point(200, 83);
            this.Hour21.Name = "Hour21";
            this.Hour21.Size = new System.Drawing.Size(38, 17);
            this.Hour21.TabIndex = 50;
            this.Hour21.Tag = "21";
            this.Hour21.Text = "21";
            this.Hour21.UseVisualStyleBackColor = true;
            // 
            // Hour22
            // 
            this.Hour22.AutoSize = true;
            this.Hour22.Location = new System.Drawing.Point(200, 105);
            this.Hour22.Name = "Hour22";
            this.Hour22.Size = new System.Drawing.Size(38, 17);
            this.Hour22.TabIndex = 49;
            this.Hour22.Tag = "22";
            this.Hour22.Text = "22";
            this.Hour22.UseVisualStyleBackColor = true;
            // 
            // Hour23
            // 
            this.Hour23.AutoSize = true;
            this.Hour23.Location = new System.Drawing.Point(200, 127);
            this.Hour23.Name = "Hour23";
            this.Hour23.Size = new System.Drawing.Size(38, 17);
            this.Hour23.TabIndex = 48;
            this.Hour23.Tag = "23";
            this.Hour23.Text = "23";
            this.Hour23.UseVisualStyleBackColor = true;
            // 
            // Hour20
            // 
            this.Hour20.AutoSize = true;
            this.Hour20.Location = new System.Drawing.Point(200, 61);
            this.Hour20.Name = "Hour20";
            this.Hour20.Size = new System.Drawing.Size(38, 17);
            this.Hour20.TabIndex = 47;
            this.Hour20.Tag = "20";
            this.Hour20.Text = "20";
            this.Hour20.UseVisualStyleBackColor = true;
            // 
            // Hour19
            // 
            this.Hour19.AutoSize = true;
            this.Hour19.Location = new System.Drawing.Point(200, 39);
            this.Hour19.Name = "Hour19";
            this.Hour19.Size = new System.Drawing.Size(38, 17);
            this.Hour19.TabIndex = 46;
            this.Hour19.Tag = "19";
            this.Hour19.Text = "19";
            this.Hour19.UseVisualStyleBackColor = true;
            // 
            // Hour18
            // 
            this.Hour18.AutoSize = true;
            this.Hour18.Location = new System.Drawing.Point(200, 17);
            this.Hour18.Name = "Hour18";
            this.Hour18.Size = new System.Drawing.Size(38, 17);
            this.Hour18.TabIndex = 45;
            this.Hour18.Tag = "18";
            this.Hour18.Text = "18";
            this.Hour18.UseVisualStyleBackColor = true;
            // 
            // Hour17
            // 
            this.Hour17.AutoSize = true;
            this.Hour17.Location = new System.Drawing.Point(141, 127);
            this.Hour17.Name = "Hour17";
            this.Hour17.Size = new System.Drawing.Size(38, 17);
            this.Hour17.TabIndex = 44;
            this.Hour17.Tag = "17";
            this.Hour17.Text = "17";
            this.Hour17.UseVisualStyleBackColor = true;
            // 
            // Hour16
            // 
            this.Hour16.AutoSize = true;
            this.Hour16.Location = new System.Drawing.Point(141, 105);
            this.Hour16.Name = "Hour16";
            this.Hour16.Size = new System.Drawing.Size(38, 17);
            this.Hour16.TabIndex = 43;
            this.Hour16.Tag = "16";
            this.Hour16.Text = "16";
            this.Hour16.UseVisualStyleBackColor = true;
            // 
            // Hour15
            // 
            this.Hour15.AutoSize = true;
            this.Hour15.Location = new System.Drawing.Point(141, 83);
            this.Hour15.Name = "Hour15";
            this.Hour15.Size = new System.Drawing.Size(38, 17);
            this.Hour15.TabIndex = 42;
            this.Hour15.Tag = "15";
            this.Hour15.Text = "15";
            this.Hour15.UseVisualStyleBackColor = true;
            // 
            // Hour14
            // 
            this.Hour14.AutoSize = true;
            this.Hour14.Location = new System.Drawing.Point(141, 61);
            this.Hour14.Name = "Hour14";
            this.Hour14.Size = new System.Drawing.Size(38, 17);
            this.Hour14.TabIndex = 41;
            this.Hour14.Tag = "14";
            this.Hour14.Text = "14";
            this.Hour14.UseVisualStyleBackColor = true;
            // 
            // Hour13
            // 
            this.Hour13.AutoSize = true;
            this.Hour13.Location = new System.Drawing.Point(141, 39);
            this.Hour13.Name = "Hour13";
            this.Hour13.Size = new System.Drawing.Size(38, 17);
            this.Hour13.TabIndex = 40;
            this.Hour13.Tag = "13";
            this.Hour13.Text = "13";
            this.Hour13.UseVisualStyleBackColor = true;
            // 
            // Hour12
            // 
            this.Hour12.AutoSize = true;
            this.Hour12.Location = new System.Drawing.Point(141, 17);
            this.Hour12.Name = "Hour12";
            this.Hour12.Size = new System.Drawing.Size(38, 17);
            this.Hour12.TabIndex = 39;
            this.Hour12.Tag = "12";
            this.Hour12.Text = "12";
            this.Hour12.UseVisualStyleBackColor = true;
            // 
            // Hour11
            // 
            this.Hour11.AutoSize = true;
            this.Hour11.Location = new System.Drawing.Point(82, 127);
            this.Hour11.Name = "Hour11";
            this.Hour11.Size = new System.Drawing.Size(38, 17);
            this.Hour11.TabIndex = 38;
            this.Hour11.Tag = "11";
            this.Hour11.Text = "11";
            this.Hour11.UseVisualStyleBackColor = true;
            // 
            // Hour10
            // 
            this.Hour10.AutoSize = true;
            this.Hour10.Location = new System.Drawing.Point(82, 105);
            this.Hour10.Name = "Hour10";
            this.Hour10.Size = new System.Drawing.Size(38, 17);
            this.Hour10.TabIndex = 37;
            this.Hour10.Tag = "10";
            this.Hour10.Text = "10";
            this.Hour10.UseVisualStyleBackColor = true;
            // 
            // Hour09
            // 
            this.Hour09.AutoSize = true;
            this.Hour09.Location = new System.Drawing.Point(82, 83);
            this.Hour09.Name = "Hour09";
            this.Hour09.Size = new System.Drawing.Size(38, 17);
            this.Hour09.TabIndex = 36;
            this.Hour09.Tag = "09";
            this.Hour09.Text = "09";
            this.Hour09.UseVisualStyleBackColor = true;
            // 
            // Hour08
            // 
            this.Hour08.AutoSize = true;
            this.Hour08.Location = new System.Drawing.Point(82, 61);
            this.Hour08.Name = "Hour08";
            this.Hour08.Size = new System.Drawing.Size(38, 17);
            this.Hour08.TabIndex = 35;
            this.Hour08.Tag = "08";
            this.Hour08.Text = "08";
            this.Hour08.UseVisualStyleBackColor = true;
            // 
            // Hour07
            // 
            this.Hour07.AutoSize = true;
            this.Hour07.Location = new System.Drawing.Point(82, 39);
            this.Hour07.Name = "Hour07";
            this.Hour07.Size = new System.Drawing.Size(38, 17);
            this.Hour07.TabIndex = 34;
            this.Hour07.Tag = "07";
            this.Hour07.Text = "07";
            this.Hour07.UseVisualStyleBackColor = true;
            // 
            // Hour06
            // 
            this.Hour06.AutoSize = true;
            this.Hour06.Location = new System.Drawing.Point(82, 17);
            this.Hour06.Name = "Hour06";
            this.Hour06.Size = new System.Drawing.Size(38, 17);
            this.Hour06.TabIndex = 33;
            this.Hour06.Tag = "6";
            this.Hour06.Text = "06";
            this.Hour06.UseVisualStyleBackColor = true;
            // 
            // Hour05
            // 
            this.Hour05.AutoSize = true;
            this.Hour05.Location = new System.Drawing.Point(23, 127);
            this.Hour05.Name = "Hour05";
            this.Hour05.Size = new System.Drawing.Size(38, 17);
            this.Hour05.TabIndex = 32;
            this.Hour05.Tag = "05";
            this.Hour05.Text = "05";
            this.Hour05.UseVisualStyleBackColor = true;
            // 
            // Hour04
            // 
            this.Hour04.AutoSize = true;
            this.Hour04.Location = new System.Drawing.Point(23, 105);
            this.Hour04.Name = "Hour04";
            this.Hour04.Size = new System.Drawing.Size(38, 17);
            this.Hour04.TabIndex = 31;
            this.Hour04.Tag = "04";
            this.Hour04.Text = "04";
            this.Hour04.UseVisualStyleBackColor = true;
            // 
            // Hour03
            // 
            this.Hour03.AutoSize = true;
            this.Hour03.Location = new System.Drawing.Point(23, 83);
            this.Hour03.Name = "Hour03";
            this.Hour03.Size = new System.Drawing.Size(38, 17);
            this.Hour03.TabIndex = 30;
            this.Hour03.Tag = "03";
            this.Hour03.Text = "03";
            this.Hour03.UseVisualStyleBackColor = true;
            // 
            // Hour02
            // 
            this.Hour02.AutoSize = true;
            this.Hour02.Location = new System.Drawing.Point(23, 61);
            this.Hour02.Name = "Hour02";
            this.Hour02.Size = new System.Drawing.Size(38, 17);
            this.Hour02.TabIndex = 29;
            this.Hour02.Tag = "02";
            this.Hour02.Text = "02";
            this.Hour02.UseVisualStyleBackColor = true;
            // 
            // Hour01
            // 
            this.Hour01.AutoSize = true;
            this.Hour01.Location = new System.Drawing.Point(23, 39);
            this.Hour01.Name = "Hour01";
            this.Hour01.Size = new System.Drawing.Size(38, 17);
            this.Hour01.TabIndex = 28;
            this.Hour01.Tag = "01";
            this.Hour01.Text = "01";
            this.Hour01.UseVisualStyleBackColor = true;
            // 
            // Hour00
            // 
            this.Hour00.AutoSize = true;
            this.Hour00.Location = new System.Drawing.Point(23, 17);
            this.Hour00.Name = "Hour00";
            this.Hour00.Size = new System.Drawing.Size(38, 17);
            this.Hour00.TabIndex = 27;
            this.Hour00.Tag = "00";
            this.Hour00.Text = "00";
            this.Hour00.UseVisualStyleBackColor = true;
            // 
            // fromComboBox
            // 
            this.fromComboBox.Location = new System.Drawing.Point(65, 180);
            this.fromComboBox.Name = "fromComboBox";
            this.fromComboBox.Size = new System.Drawing.Size(50, 21);
            this.fromComboBox.TabIndex = 32;
            this.fromComboBox.SelectedValueChanged += new System.EventHandler(this.PopulateCheckBoxes);
            // 
            // toComboBox
            // 
            this.toComboBox.Location = new System.Drawing.Point(194, 180);
            this.toComboBox.Name = "toComboBox";
            this.toComboBox.Size = new System.Drawing.Size(50, 21);
            this.toComboBox.TabIndex = 33;
            this.toComboBox.SelectedValueChanged += new System.EventHandler(this.PopulateCheckBoxes);
            // 
            // presetNameTextBox
            // 
            this.presetNameTextBox.Location = new System.Drawing.Point(32, 41);
            this.presetNameTextBox.Name = "presetNameTextBox";
            this.presetNameTextBox.Size = new System.Drawing.Size(212, 20);
            this.presetNameTextBox.TabIndex = 34;
            this.presetNameTextBox.Text = "New Preset";
            // 
            // PresetNameLable
            // 
            this.PresetNameLable.AutoSize = true;
            this.PresetNameLable.Location = new System.Drawing.Point(32, 22);
            this.PresetNameLable.Name = "PresetNameLable";
            this.PresetNameLable.Size = new System.Drawing.Size(29, 13);
            this.PresetNameLable.TabIndex = 35;
            this.PresetNameLable.Text = "Имя";
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.AutoSize = true;
            this.DescriptionLabel.Location = new System.Drawing.Point(32, 74);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(57, 13);
            this.DescriptionLabel.TabIndex = 37;
            this.DescriptionLabel.Text = "Описание";
            // 
            // DescriptionTextBox
            // 
            this.DescriptionTextBox.Location = new System.Drawing.Point(32, 93);
            this.DescriptionTextBox.Multiline = true;
            this.DescriptionTextBox.Name = "DescriptionTextBox";
            this.DescriptionTextBox.Size = new System.Drawing.Size(212, 75);
            this.DescriptionTextBox.TabIndex = 36;
            // 
            // AddPresetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 414);
            this.ControlBox = false;
            this.Controls.Add(this.DescriptionLabel);
            this.Controls.Add(this.DescriptionTextBox);
            this.Controls.Add(this.PresetNameLable);
            this.Controls.Add(this.presetNameTextBox);
            this.Controls.Add(this.toComboBox);
            this.Controls.Add(this.fromComboBox);
            this.Controls.Add(this.hoursGroupBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.addBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AddPresetForm";
            this.Text = "AddPreset";
            this.Load += new System.EventHandler(this.AddPresetForm_Load);
            this.hoursGroupBox.ResumeLayout(false);
            this.hoursGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox hoursGroupBox;
        private System.Windows.Forms.CheckBox Hour21;
        private System.Windows.Forms.CheckBox Hour22;
        private System.Windows.Forms.CheckBox Hour23;
        private System.Windows.Forms.CheckBox Hour20;
        private System.Windows.Forms.CheckBox Hour19;
        private System.Windows.Forms.CheckBox Hour18;
        private System.Windows.Forms.CheckBox Hour17;
        private System.Windows.Forms.CheckBox Hour16;
        private System.Windows.Forms.CheckBox Hour15;
        private System.Windows.Forms.CheckBox Hour14;
        private System.Windows.Forms.CheckBox Hour13;
        private System.Windows.Forms.CheckBox Hour12;
        private System.Windows.Forms.CheckBox Hour11;
        private System.Windows.Forms.CheckBox Hour10;
        private System.Windows.Forms.CheckBox Hour09;
        private System.Windows.Forms.CheckBox Hour08;
        private System.Windows.Forms.CheckBox Hour07;
        private System.Windows.Forms.CheckBox Hour06;
        private System.Windows.Forms.CheckBox Hour05;
        private System.Windows.Forms.CheckBox Hour04;
        private System.Windows.Forms.CheckBox Hour03;
        private System.Windows.Forms.CheckBox Hour02;
        private System.Windows.Forms.CheckBox Hour01;
        private System.Windows.Forms.CheckBox Hour00;
        private System.Windows.Forms.ComboBox fromComboBox;
        private System.Windows.Forms.ComboBox toComboBox;
        private System.Windows.Forms.TextBox presetNameTextBox;
        private System.Windows.Forms.Label PresetNameLable;
        private System.Windows.Forms.Label DescriptionLabel;
        private System.Windows.Forms.TextBox DescriptionTextBox;
    }
}